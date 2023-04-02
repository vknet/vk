using System;
using System.Runtime.Serialization;

namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое, когда количество кнопок в клавиатуре превышает максимум
/// </summary>
[Serializable]
public sealed class VkKeyboardMaxButtonsException : VkApiException
{
	/// <inheritdoc />
	public VkKeyboardMaxButtonsException(string message) : base(message)
	{
	}

	private VkKeyboardMaxButtonsException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base()
	{

	}
}