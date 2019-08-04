using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неизвестной ошибке
	/// Попробуйте повторить запрос позже.
	/// Код ошибки - 1
	/// </summary>
	[Serializable]
	public sealed class UnknownException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public UnknownException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.Unknown;
	}
}