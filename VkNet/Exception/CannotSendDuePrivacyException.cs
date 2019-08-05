using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке отправить сообщение пользователю,
	/// в связи с настройками приватности.
	/// Код ошибки - 902
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CannotSendDuePrivacy)]
	public sealed class CannotSendDuePrivacyException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CannotSendDuePrivacyException(VkError response) : base(response)
		{
		}
	}
}