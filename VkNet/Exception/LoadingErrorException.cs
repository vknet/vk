using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при ошибке загрузки документа.
	/// Код ошибки - 22
	/// </summary>
	[Serializable]
	public class LoadingErrorException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса LoadingErrorException
		/// </summary>
		public LoadingErrorException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса LoadingErrorException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public LoadingErrorException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса LoadingErrorException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public LoadingErrorException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса LoadingErrorException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public LoadingErrorException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public LoadingErrorException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}