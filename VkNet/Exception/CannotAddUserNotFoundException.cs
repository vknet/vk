using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при попытке добавить в друзья пользователя,
	/// который не найден.
	/// Код ошибки - 177
	/// </summary>
	[Serializable]
	public class CannotAddUserNotFoundException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса CannotAddUserNotFoundException
		/// </summary>
		public CannotAddUserNotFoundException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotAddUserNotFoundException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public CannotAddUserNotFoundException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotAddUserNotFoundException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public CannotAddUserNotFoundException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotAddUserNotFoundException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public CannotAddUserNotFoundException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public CannotAddUserNotFoundException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}