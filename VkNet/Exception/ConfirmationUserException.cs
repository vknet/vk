using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если требуется подтверждение со стороны
	/// пользователя.
	/// Код ошибки - 24
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.ConfirmationUser)]
	public sealed class ConfirmationUserException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ConfirmationUserException(VkError response) : base(response)
		{
		}
	}
}