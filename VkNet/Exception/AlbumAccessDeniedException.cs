using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при отсутствии доступа к альбому.
	/// Доступ к альбому запрещён.
	/// Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id
	/// положительный, для сообществ —
	/// отрицательный), и доступ к запрашиваемому контенту для текущего пользователя
	/// есть в полной версии сайта.
	/// </summary>
	[Serializable]
	public class AlbumAccessDeniedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumAccessDeniedException
		/// </summary>
		public AlbumAccessDeniedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public AlbumAccessDeniedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public AlbumAccessDeniedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AlbumAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public AlbumAccessDeniedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public AlbumAccessDeniedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}