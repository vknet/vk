using System;
using System.Runtime.Serialization;

namespace VkNet.Exception;

/// <inheritdoc />
[Serializable]
public sealed class VkAuthorizationException : System.Exception
{
	/// <inheritdoc />
	public VkAuthorizationException()
	{
	}

	/// <inheritdoc />
	public VkAuthorizationException(string message) : base(message)
	{
	}

	/// <inheritdoc />
	private VkAuthorizationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{

	}
}