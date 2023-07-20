using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при остутствии доступа к пользователю.
/// Доступ к пользователю запрещен.
/// Код ошибки - 170
/// </summary>
[Serializable]
[VkError(VkErrorCode.UserAccessDenied)]
public sealed class UserAccessDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public UserAccessDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private UserAccessDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}