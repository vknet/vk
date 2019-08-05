using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при попытке добавить в друзья пользователя,
	/// который занес Вас в свой черный
	/// список.
	/// Код ошибки - 175
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CannotAddYouBlacklisted)]
	public sealed class CannotAddYouBlacklistedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CannotAddYouBlacklistedException(VkError response) : base(response)
		{
		}
	}
}