using System;

namespace VkNet.Exception;

/// <summary>
/// Информация утрачена, нужно запросить новые key и ts методом groups.getLongPollServer.
/// </summary>
[Serializable]
public sealed class LongPollInfoLostException : LongPollException
{
	/// <inheritdoc />
	public LongPollInfoLostException() : base(InfoLostException,
		"Информация утрачена, нужно запросить новые key и ts")
	{
	}

	/// <inheritdoc />
	private LongPollInfoLostException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base()
	{

	}
}