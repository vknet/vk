namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при выходе за лимит количества элементов в шаблоне
/// </summary>
public class TooMuchElementsInTemplateException : VkApiException
{
	/// <inheritdoc />
	public TooMuchElementsInTemplateException(string message) : base(message)
	{
	}
}