using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если пользователь отключил вещание названия
/// трека.
/// Код ошибки - 221
/// </summary>
[Serializable]
[VkError(VkErrorCode.UserDisabledTrackNameBroadcast)]
public sealed class UserDisabledTrackNameBroadcastException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public UserDisabledTrackNameBroadcastException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private UserDisabledTrackNameBroadcastException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}