using System;
using VkNet.Model;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если произошла ошибка выполнения кода.
	/// Код ошибки - 13
	/// </summary>
	[Serializable]
	public sealed class ErrorExecutingCodeException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ErrorExecutingCodeException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode { get; }
	}
}