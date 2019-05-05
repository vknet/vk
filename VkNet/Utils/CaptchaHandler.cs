using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Core;
using VkNet.Exception;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class CaptchaHandler : ICaptchaHandler
	{
		private readonly ILogger<CaptchaHandler> _logger;

		private readonly ICaptchaSolver _captchaSolver;

		/// <inheritdoc />
		public CaptchaHandler(ILogger<CaptchaHandler> logger, ICaptchaSolver captchaSolver)
		{
			_logger = logger;
			_captchaSolver = captchaSolver;
		}

		/// <inheritdoc />
		public int MaxCaptchaRecognitionCount { get; set; }

		/// <inheritdoc />
		public T Perform<T>(Func<long?, string, T> action)
		{
			return PerformAsync(Transform(action), CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task<T> PerformAsync<T>(Func<long?, string, Task<T>> action, CancellationToken cancellationToken = default)
		{
			var numberOfRemainingAttemptsToSolveCaptcha = MaxCaptchaRecognitionCount;
			var numberOfRemainingAttemptsToAuthorize = MaxCaptchaRecognitionCount + 1;
			long? captchaSidTemp = null;
			string captchaKeyTemp = null;
			var callCompleted = false;
			var result = default(T);

			do
			{
				try
				{
					result = await action(captchaSidTemp, captchaKeyTemp).ConfigureAwait(false);
					numberOfRemainingAttemptsToAuthorize--;
					callCompleted = true;
				}
				catch (CaptchaNeededException captchaNeededException)
				{
					_logger?.LogWarning("Повторная обработка капчи");

					if (numberOfRemainingAttemptsToSolveCaptcha < MaxCaptchaRecognitionCount)
					{
						await _captchaSolver.CaptchaIsFalseAsync(cancellationToken).ConfigureAwait(false);
					}

					if (numberOfRemainingAttemptsToSolveCaptcha <= 0)
					{
						continue;
					}

					captchaSidTemp = captchaNeededException.Sid;

					captchaKeyTemp = await _captchaSolver.SolveAsync(captchaNeededException.Img?.AbsoluteUri, cancellationToken)
						.ConfigureAwait(false);

					numberOfRemainingAttemptsToSolveCaptcha--;
				}
			} while (numberOfRemainingAttemptsToAuthorize > 0 && !callCompleted);

			// Повторно выбрасываем исключение, если капча ни разу не была распознана верно
			if (callCompleted || !captchaSidTemp.HasValue)
			{
				return result;
			}

			_logger?.LogError("Капча ни разу не была распознана верно");

			throw new CaptchaNeededException(captchaSidTemp.Value, captchaKeyTemp);
		}

		private Func<long?, string, Task<T>> Transform<T>(Func<long?, string, T> action)
		{
			Func<long?, string, Task<T>> transform;

		#if NET40
			transform = (sid, key) => TaskEx.FromResult(action(sid, key));

			return transform;
		#else
			transform = (sid, key) => Task.FromResult(action(sid, key));

			return transform;
		#endif
		}
	}
}