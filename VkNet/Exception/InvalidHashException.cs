using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неверном хэше.
	/// Код ошибки - 121
	/// </summary>
	[Serializable]
	public sealed class InvalidHashException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidHashException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidHash;
	}
}