using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при превышении лимита комментариев на стене.
	/// Код ошибки - 224
	/// </summary>
	[Serializable]
	public class TooManyAdsPostsException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyAdsPostsException
		/// </summary>
		public TooManyAdsPostsException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyAdsPostsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public TooManyAdsPostsException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyAdsPostsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public TooManyAdsPostsException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyAdsPostsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public TooManyAdsPostsException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyAdsPostsException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public TooManyAdsPostsException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}