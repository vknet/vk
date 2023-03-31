using System;

namespace VkNet.Exception;

/// <summary>
/// Истекло время действия ключа, нужно заново получить key методом groups.getLongPollServer.
/// </summary>
[Serializable]
public sealed class LongPollKeyExpiredException : LongPollException
{
	/// <inheritdoc />
	public LongPollKeyExpiredException() : base(KeyExpiredException,
		"Истекло время действия ключа, нужно заново получить key")
	{
	}

	/// <inheritdoc />
	private LongPollKeyExpiredException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base()
	{

	}
}