using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при попытке добавить в друзья пользователя,
	/// который не найден.
	/// Код ошибки - 177
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CannotAddUserNotFound)]
	public class CannotAddUserNotFoundException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CannotAddUserNotFoundException(VkError response) : base(response)
		{
		}
	}
}