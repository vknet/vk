namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при выходе за лимит количества элементов в шаблоне
	/// </summary>
	public class TooMuchElementsInTemplate : System.Exception
	{
		public TooMuchElementsInTemplate(string message) : base(message)
		{
		}
	}
}
