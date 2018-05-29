using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к списку групп запрещен из-за
	/// настроек конфиденциальности
	/// пользователя.
	/// Код ошибки - 260
	/// </summary>
	[Serializable]
	public class GroupsListAccessDeniedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса GroupsListAccessDeniedException
		/// </summary>
		public GroupsListAccessDeniedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса GroupsListAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public GroupsListAccessDeniedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса GroupsListAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public GroupsListAccessDeniedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса GroupsListAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public GroupsListAccessDeniedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public GroupsListAccessDeniedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}