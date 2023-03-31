using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при отсутствии авторизации на выполнение
/// запрошенной операции.
/// Код ошибки - 5
/// </summary>
[Serializable]
[VkError(VkErrorCode.AuthorizationFailed)]
public sealed class UserAuthorizationFailException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public UserAuthorizationFailException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private UserAuthorizationFailException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}