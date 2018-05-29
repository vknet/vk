using System;

namespace VkNet.Exception
{
	/// <summary>
	/// Базовый класс, для всех исключений, которые могут произойти при вызове методов
	/// API ВКонтакте.
	/// </summary>
	[Serializable]
	public class VkApiMethodInvokeException : VkApiException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiMethodInvokeException
		/// </summary>
		public VkApiMethodInvokeException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiMethodInvokeException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public VkApiMethodInvokeException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiMethodInvokeException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public VkApiMethodInvokeException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiMethodInvokeException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public VkApiMethodInvokeException(string message, int code) : base(message: message)
		{
			ErrorCode = code;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiMethodInvokeException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public VkApiMethodInvokeException(string message, int code, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
			ErrorCode = code;
		}
	}
}