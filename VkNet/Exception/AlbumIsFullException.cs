using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если альбом переполнен.
	/// Перед продолжением работы нужно удалить лишние объекты из альбома или
	/// использовать другой альбом.
	/// Код ошибки - 300
	/// </summary>
	[Serializable]
	public class AlbumIsFullException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumIsFullException
		/// </summary>
		public AlbumIsFullException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumIsFullException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public AlbumIsFullException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumIsFullException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public AlbumIsFullException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumIsFullException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public AlbumIsFullException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public AlbumIsFullException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}