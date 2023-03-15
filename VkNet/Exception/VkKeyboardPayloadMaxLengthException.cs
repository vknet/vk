namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при превышении максимальной длины Payload клавиатуры
/// </summary>
public class VkKeyboardPayloadMaxLengthException : VkApiException
{
	/// <inheritdoc />
	public VkKeyboardPayloadMaxLengthException(string message) : base(message)
	{
	}
}