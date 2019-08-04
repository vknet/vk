using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неверном timestamp
	/// Получить актуальное значение Вы можете методом utils.getServerTime.
	/// Код ошибки - 150
	/// </summary>
	[Serializable]
	public sealed class InvalidTimestampException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidTimestampException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidTimestamp;
	}
}