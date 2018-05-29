using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если действие разрешено только для
	/// Standalone и Open API приложений.
	/// Код ошибки - 21
	/// </summary>
	[Serializable]
	public class OnlySandaloneOrOpenApiException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса OnlySandaloneOrOpenApiException
		/// </summary>
		public OnlySandaloneOrOpenApiException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса OnlySandaloneOrOpenApiException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public OnlySandaloneOrOpenApiException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса OnlySandaloneOrOpenApiException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public OnlySandaloneOrOpenApiException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса OnlySandaloneOrOpenApiException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public OnlySandaloneOrOpenApiException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public OnlySandaloneOrOpenApiException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}