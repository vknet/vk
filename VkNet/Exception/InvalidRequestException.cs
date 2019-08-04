using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неверном запросе.
	/// Проверьте синтаксис запроса и список используемых параметров (его можно найти
	/// на странице с описанием метода).
	/// Код ошибки - 8
	/// </summary>
	[Serializable]
	public sealed class InvalidRequestException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidRequestException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidRequest;
	}
}