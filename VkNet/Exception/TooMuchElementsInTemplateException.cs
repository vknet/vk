namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при выходе за лимит количества элементов в шаблоне
	/// </summary>
	public class TooMuchElementsInTemplateException : System.Exception
	{
		public TooMuchElementsInTemplateException(string message) : base(message)
		{
		}
	}
}
