using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при ошибке работы с рекламным кабинетом.
	/// Код ошибки - 603
	/// </summary>
	[Serializable]
	public class ErrorWorkWithAdsException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса ErrorWorkWithAdsException
		/// </summary>
		public ErrorWorkWithAdsException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ErrorWorkWithAdsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public ErrorWorkWithAdsException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ErrorWorkWithAdsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public ErrorWorkWithAdsException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ErrorWorkWithAdsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public ErrorWorkWithAdsException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public ErrorWorkWithAdsException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}