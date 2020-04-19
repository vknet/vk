namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при превышении максимальной длины Payload клавиатуры
	/// </summary>
	public class VkKeyboardPayloadMaxLengthException : System.Exception
	{
		public VkKeyboardPayloadMaxLengthException(string message) : base(message)
		{
		}
	}
}