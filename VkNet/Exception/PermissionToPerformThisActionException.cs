using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при отсутствии прав выполнения этого действия
	/// Проверьте, получены ли нужные права доступа при авторизации. Это можно сделать
	/// с помощью метода
	/// account.getAppPermissions.
	/// Код ошибки - 7
	/// </summary>
	[Serializable]
	public class PermissionToPerformThisActionException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса PermissionToPerformThisActionException
		/// </summary>
		public PermissionToPerformThisActionException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса PermissionToPerformThisActionException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public PermissionToPerformThisActionException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса PermissionToPerformThisActionException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public PermissionToPerformThisActionException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса PermissionToPerformThisActionException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public PermissionToPerformThisActionException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public PermissionToPerformThisActionException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}