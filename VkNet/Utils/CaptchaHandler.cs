using System;
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
					result = action.Invoke(captchaSidTemp, captchaKeyTemp);
					numberOfRemainingAttemptsToAuthorize--;
					callCompleted = true;
				}
				catch (CaptchaNeededException captchaNeededException)
				{
					RepeatSolveCaptchaAsync(captchaNeededException,
						ref numberOfRemainingAttemptsToSolveCaptcha,
						ref captchaSidTemp,
						ref captchaKeyTemp);
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

		private void RepeatSolveCaptchaAsync(CaptchaNeededException captchaNeededException,
												ref int numberOfRemainingAttemptsToSolveCaptcha,
												ref long? captchaSidTemp,
												ref string captchaKeyTemp)
		{
			_logger?.LogWarning("Повторная обработка капчи");

			if (numberOfRemainingAttemptsToSolveCaptcha < MaxCaptchaRecognitionCount)
			{
				_captchaSolver?.CaptchaIsFalse();
			}

			if (numberOfRemainingAttemptsToSolveCaptcha <= 0)
			{
				return;
			}

			captchaSidTemp = captchaNeededException.Sid;
			captchaKeyTemp = _captchaSolver?.Solve(captchaNeededException.Img?.AbsoluteUri);
			numberOfRemainingAttemptsToSolveCaptcha--;
		}
	}
}