namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при выходе за лимит количества элементов в шаблоне
	/// </summary>
	public class TooMuchElementsInTemplateException : VkApiException
	{
		public TooMuchElementsInTemplateException(string message) : base(message)
		{
		}
	}
}
