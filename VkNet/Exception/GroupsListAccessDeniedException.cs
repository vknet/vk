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
	public sealed class GroupsListAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public GroupsListAccessDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.GroupsListAccessDenied;
	}
}