using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если пользователь не найден, удален, либо
/// заблокирован.
/// Код ошибки - 18
/// </summary>
[Serializable]
[VkError(VkErrorCode.UserDeletedOrBanned)]
public sealed class UserDeletedOrBannedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public UserDeletedOrBannedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private UserDeletedOrBannedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}