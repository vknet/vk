using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при необходимости ввода капчи для вызова метода
/// Код ошибки - 14
/// </summary>
[Serializable]
[VkError(VkErrorCode.CaptchaNeeded)]
public sealed class CaptchaNeededException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public CaptchaNeededException(VkError response) : base(response)
	{
		if (response is null)
		{
			return;
		}

		Sid = response.CaptchaSid;
		Img = response.CaptchaImg;
	}

	/// <inheritdoc />
	private CaptchaNeededException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}

	/// <inheritdoc />
	[UsedImplicitly]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}

	/// <summary>
	/// Идентификатор капчи
	/// </summary>
	public ulong Sid { get; }

	/// <summary>
	/// Uri-адрес изображения с капчей
	/// </summary>
	public Uri Img { get; }
}