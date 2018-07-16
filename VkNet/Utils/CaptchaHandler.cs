using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NLog;
using VkNet.Abstractions.Core;
using VkNet.Exception;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class CaptchaHandler : ICaptchaHandler
	{
		private readonly ILogger _logger;

		private readonly ICaptchaSolver _captchaSolver;

		/// <inheritdoc />
		public CaptchaHandler(ILogger logger, ICaptchaSolver captchaSolver)
		{
			_logger = logger;
			_captchaSolver = captchaSolver;
		}

		/// <inheritdoc />
		public int MaxCaptchaRecognitionCount { get; set; }

		/// <inheritdoc />
		public async Task<T> CaptchaHandlerAsync<T>(Func<long?, string, T> action)
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
					result = action.Invoke(arg1: captchaSidTemp, arg2: captchaKeyTemp);
					numberOfRemainingAttemptsToAuthorize--;
					callCompleted = true;
				}
				catch (CaptchaNeededException captchaNeededException)
				{
					RepeatSolveCaptchaAsync<T>(captchaNeededException,
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

			_logger?.Error(message: "Капча ни разу не была распознана верно");

			throw new CaptchaNeededException(sid: captchaSidTemp.Value, img: captchaKeyTemp);
		}

		private void RepeatSolveCaptchaAsync<T>(CaptchaNeededException captchaNeededException,
												ref int numberOfRemainingAttemptsToSolveCaptcha, ref long? captchaSidTemp,
												ref string captchaKeyTemp)
		{
			_logger?.Warn(message: "Повторная обработка капчи");

			if (numberOfRemainingAttemptsToSolveCaptcha < MaxCaptchaRecognitionCount)
			{
				_captchaSolver?.CaptchaIsFalse();
			}

			if (numberOfRemainingAttemptsToSolveCaptcha <= 0)
			{
				return;
			}

			captchaSidTemp = captchaNeededException.Sid;
			captchaKeyTemp = _captchaSolver?.Solve(url: captchaNeededException.Img?.AbsoluteUri);
			numberOfRemainingAttemptsToSolveCaptcha--;
		}
	}
}