using System;
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
	private UserDeletedOrBannedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}