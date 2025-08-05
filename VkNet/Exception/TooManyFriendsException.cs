using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при превышении лимита друзей.
/// Код ошибки - 242
/// </summary>
[Serializable]
[VkError(VkErrorCode.TooManyFriends)]
public sealed class TooManyFriendsException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public TooManyFriendsException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private TooManyFriendsException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}