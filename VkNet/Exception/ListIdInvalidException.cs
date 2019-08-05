using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если идентификатор списка неверен.
	/// Код ошибки - 171
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.ListIdInvalid)]
	public sealed class ListIdInvalidException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ListIdInvalidException(VkError response) : base(response)
		{
		}
	}
}