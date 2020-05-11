namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при превышении максимальной длины Payload клавиатуры
	/// </summary>
	public class VkKeyboardPayloadMaxLengthException : VkApiException
	{
		public VkKeyboardPayloadMaxLengthException(string message) : base(message)
		{
		}
	}
}