namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при выходе за лимит кнопок в клавиатуре
	/// </summary>
	public class TooMuchButtonsException : System.Exception
	{
		public TooMuchButtonsException(string message) : base(message)
		{
		}
	}
}
