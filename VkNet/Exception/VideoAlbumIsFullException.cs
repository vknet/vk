using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если видеоальбом переполнен.
	/// Перед продолжением работы нужно удалить лишние объекты из альбома или
	/// использовать другой альбом.
	/// Код ошибки - 302
	/// </summary>
	[Serializable]
	public class VideoAlbumIsFullException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlbumIsFullException
		/// </summary>
		public VideoAlbumIsFullException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlbumIsFullException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public VideoAlbumIsFullException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlbumIsFullException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public VideoAlbumIsFullException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VideoAlbumIsFullException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public VideoAlbumIsFullException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public VideoAlbumIsFullException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}