using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если комментарии к запрашиваемому видео
	/// закрыты.
	/// Код ошибки - 801
	/// </summary>
	[Serializable]
	public class VideoCommentsClosedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса VideoCommentsClosedException
		/// </summary>
		public VideoCommentsClosedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoCommentsClosedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public VideoCommentsClosedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoCommentsClosedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public VideoCommentsClosedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoCommentsClosedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public VideoCommentsClosedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public VideoCommentsClosedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}