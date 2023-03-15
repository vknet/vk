namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при выходе за лимит кнопок в клавиатуре
/// </summary>
public class TooMuchButtonsException : VkApiException
{
	/// <inheritdoc />
	public TooMuchButtonsException(string message) : base(message)
	{
	}
}