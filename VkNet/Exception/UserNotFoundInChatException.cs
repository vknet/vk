using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при отсутствии пользователя в чате.
/// </summary>
/// <remarks>
/// Код ошибки - 935
/// </remarks>
[Serializable]
[VkError(VkErrorCode.UserNotFoundInChat)]
public sealed class UserNotFoundInChatException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public UserNotFoundInChatException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private UserNotFoundInChatException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}