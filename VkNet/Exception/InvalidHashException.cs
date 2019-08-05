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
	[VkError(VkErrorCode.InvalidHash)]
	public sealed class InvalidHashException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidHashException(VkError response) : base(response)
		{
		}
	}
}