namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое, когда количество кнопок в клавиатуре превышает максимум
/// </summary>
public class VkKeyboardMaxButtonsException : VkApiException
{
	/// <inheritdoc />
	public VkKeyboardMaxButtonsException(string message) : base(message)
	{
	}
}