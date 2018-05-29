using VkNet.Utils;

namespace VkNet.Exception
{
	/// <inheritdoc />
	public class RateLimitReachedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса RateLimitReachedException
		/// </summary>
		public RateLimitReachedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса RateLimitReachedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public RateLimitReachedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса RateLimitReachedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public RateLimitReachedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса RateLimitReachedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public RateLimitReachedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public RateLimitReachedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}