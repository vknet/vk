using System;
using VkNet.Model;
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
	[VkError(VkErrorCode.GroupsListAccessDenied)]
	public sealed class GroupsListAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public GroupsListAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}