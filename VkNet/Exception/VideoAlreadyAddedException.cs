using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке добавить уже добавленное видео.
	/// Код ошибки - 800
	/// </summary>
	[Serializable]
	public class VideoAlreadyAddedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlreadyAddedException
		/// </summary>
		public VideoAlreadyAddedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlreadyAddedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public VideoAlreadyAddedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlreadyAddedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public VideoAlreadyAddedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlreadyAddedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public VideoAlreadyAddedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public VideoAlreadyAddedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}