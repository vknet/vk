namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при выходе за лимит кнопок в клавиатуре
	/// </summary>
	public class TooMuchButtons : System.Exception
	{
		public TooMuchButtons(string message) : base(message)
		{
		}
	}
}
