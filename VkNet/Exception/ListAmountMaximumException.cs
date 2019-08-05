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
	[VkError(VkErrorCode.ListAmountMaximum)]
	public sealed class ListAmountMaximumException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ListAmountMaximumException(VkError response) : base(response)
		{
		}
	}
}