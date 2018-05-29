using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при включенном ТЕСТОВОМ приложении, либо если
	/// пользователь не вошел в систему.
	/// Выключите приложение в настройках https://vk.com/editapp?id={Ваш API_ID}
	/// Код ошибки - 11
	/// </summary>
	[Serializable]
	public class OffAppOrLoginException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса OffAppOrLoginException
		/// </summary>
		public OffAppOrLoginException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса OffAppOrLoginException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public OffAppOrLoginException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса OffAppOrLoginException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public OffAppOrLoginException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса OffAppOrLoginException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public OffAppOrLoginException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public OffAppOrLoginException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}