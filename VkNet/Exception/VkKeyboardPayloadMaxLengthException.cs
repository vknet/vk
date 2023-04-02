using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при превышении максимальной длины Payload клавиатуры
/// </summary>
[Serializable]
public sealed class VkKeyboardPayloadMaxLengthException : VkApiException
{
	/// <inheritdoc />
	public VkKeyboardPayloadMaxLengthException(string message) : base(message)
	{
	}

	/// <inheritdoc/>
	private VkKeyboardPayloadMaxLengthException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base()
	{

	}

	/// <inheritdoc />
	[UsedImplicitly]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}