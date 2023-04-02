using System;

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
	private VkAuthorizationException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base()
	{

	}
}