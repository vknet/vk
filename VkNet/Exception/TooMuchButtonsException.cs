using System;
using System.Runtime.Serialization;

namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при выходе за лимит кнопок в клавиатуре
/// </summary>
[Serializable]
public sealed class TooMuchButtonsException : VkApiException
{
	/// <inheritdoc />
	public TooMuchButtonsException(string message) : base(message)
	{
	}

	/// <inheritdoc />
	private TooMuchButtonsException(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{

	}
}