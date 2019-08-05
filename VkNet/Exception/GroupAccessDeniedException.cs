using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к группе запрещен.
	/// Убедитесь, что текущий пользователь является участником или руководителем
	/// сообщества (для закрытых и частных групп
	/// и встреч).
	/// Код ошибки - 203
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.GroupAccessDenied)]
	public sealed class GroupAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public GroupAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}