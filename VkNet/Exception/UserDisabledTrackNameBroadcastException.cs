using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если пользователь отключил вещание названия
	/// трека.
	/// Код ошибки - 221
	/// </summary>
	[Serializable]
	public class UserDisabledTrackNameBroadcastException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса UserDisabledTrackNameBroadcastException
		/// </summary>
		public UserDisabledTrackNameBroadcastException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserDisabledTrackNameBroadcastException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public UserDisabledTrackNameBroadcastException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserDisabledTrackNameBroadcastException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public UserDisabledTrackNameBroadcastException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserDisabledTrackNameBroadcastException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public UserDisabledTrackNameBroadcastException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public UserDisabledTrackNameBroadcastException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}