using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если произошла ошибка выполнения кода.
	/// Код ошибки - 13
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.ErrorExecutingCode)]
	public sealed class ErrorExecutingCodeException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ErrorExecutingCodeException(VkError response) : base(response)
		{
		}
	}
}