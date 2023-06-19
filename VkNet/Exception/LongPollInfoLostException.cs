using System;
using System.Runtime.Serialization;

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
	private LongPollInfoLostException(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{

	}
}