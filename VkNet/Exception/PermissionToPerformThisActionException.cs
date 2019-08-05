using System;
using VkNet.Model;
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
	[VkError(VkErrorCode.PermissionToPerformThisAction)]
	public sealed class PermissionToPerformThisActionException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public PermissionToPerformThisActionException(VkError response) : base(response)
		{
		}
	}
}