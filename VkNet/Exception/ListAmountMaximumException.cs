using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если количество списков максимально.
	/// Код ошибки - 173
	/// </summary>
	[Serializable]
	public sealed class ListAmountMaximumException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ListAmountMaximumException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.ListAmountMaximum;
	}
}