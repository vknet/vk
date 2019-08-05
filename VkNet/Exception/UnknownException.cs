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
	[VkError(VkErrorCode.Unknown)]
	public sealed class UnknownException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public UnknownException(VkError response) : base(response)
		{
		}
	}
}