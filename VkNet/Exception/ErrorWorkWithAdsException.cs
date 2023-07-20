using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при ошибке работы с рекламным кабинетом.
/// Код ошибки - 603
/// </summary>
[Serializable]
[VkError(VkErrorCode.ErrorWorkWithAds)]
public sealed class ErrorWorkWithAdsException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public ErrorWorkWithAdsException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private ErrorWorkWithAdsException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}