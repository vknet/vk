using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке отправить сообщение пользователю,
	/// находясь в его черном списке.
	/// Код ошибки - 900
	/// </summary>
	[Serializable]
	public sealed class CannotSendBlacklistedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CannotSendBlacklistedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.CannotSendBlacklisted;
	}
}