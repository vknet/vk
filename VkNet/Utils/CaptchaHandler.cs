using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Core;
using VkNet.Exception;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils;

/// <inheritdoc cref="ICaptchaHandler" />
[UsedImplicitly]
public class CaptchaHandler : ICaptchaHandler
{
	private readonly ICaptchaSolver _captchaSolver;

	private readonly ILogger _logger;

	/// <inheritdoc cref="CaptchaHandler"/>
	public CaptchaHandler(ILogger logger, ICaptchaSolver captchaSolver)
	{
		_logger = logger;
		_captchaSolver = captchaSolver;
	}

	/// <inheritdoc />
	public int MaxCaptchaRecognitionCount { get; set; } = 3;

	/// <inheritdoc />
	public T Perform<T>(Func<ulong?, string, T> action)
	{
		var numberOfRemainingAttemptsToSolveCaptcha = MaxCaptchaRecognitionCount;
		var numberOfRemainingAttemptsToAuthorize = MaxCaptchaRecognitionCount + 1;
		ulong? captchaSidTemp = null;
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
		} while (numberOfRemainingAttemptsToSolveCaptcha > 0 && !callCompleted);

		// Повторно выбрасываем исключение, если капча ни разу не была распознана верно
		if (callCompleted || !captchaSidTemp.HasValue)
		{
			return result;
		}

		if (_logger.IsEnabled(LogLevel.Error))
		{
			_logger.LogError("Капча ни разу не была распознана верно");
		}

		throw new CaptchaNeededException(new()
		{
			CaptchaSid = captchaSidTemp.Value
		});
	}

	private void RepeatSolveCaptchaAsync(CaptchaNeededException captchaNeededException,
										ref int numberOfRemainingAttemptsToSolveCaptcha,
										ref ulong? captchaSidTemp,
										ref string captchaKeyTemp)
	{
		if (_logger.IsEnabled(LogLevel.Warning))
		{
			_logger.LogWarning("Повторная обработка капчи");
		}

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