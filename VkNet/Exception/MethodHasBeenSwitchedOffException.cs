using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если метод был выключен.
	/// Все актуальные методы ВК API, которые доступны в настоящий момент, перечислены
	/// здесь: http://vk.com/dev/methods.
	/// Код ошибки - 23
	/// </summary>
	[Serializable]
	public class MethodHasBeenSwitchedOffException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса MethodHasBeenSwitchedOffException
		/// </summary>
		public MethodHasBeenSwitchedOffException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса MethodHasBeenSwitchedOffException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public MethodHasBeenSwitchedOffException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса MethodHasBeenSwitchedOffException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public MethodHasBeenSwitchedOffException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса MethodHasBeenSwitchedOffException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public MethodHasBeenSwitchedOffException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public MethodHasBeenSwitchedOffException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}