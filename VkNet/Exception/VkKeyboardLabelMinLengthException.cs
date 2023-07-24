using System;
using System.Runtime.Serialization;

namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое, когда длина строки меньше 1 символа.
/// </summary>
[Serializable]
public class VkKeyboardLabelMinLengthException : VkApiException
{
	/// <inheritdoc />
	public VkKeyboardLabelMinLengthException(string message) : base(message)
	{
	}

	private VkKeyboardLabelMinLengthException(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{

	}
}