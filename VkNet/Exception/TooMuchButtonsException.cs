using System;

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
	private TooMuchButtonsException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base()
	{

	}
}