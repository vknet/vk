using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если подпись неверна.
/// Проверьте правильность формирования подписи запроса:
/// https://vk.com/dev/api_nohttps
/// Код ошибки - 4
/// </summary>
[Serializable]
[VkError(VkErrorCode.InvalidSignature)]
public sealed class InvalidSignatureException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public InvalidSignatureException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private InvalidSignatureException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}