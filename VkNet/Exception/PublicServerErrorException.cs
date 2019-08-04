using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при внутренней ошибке сервера.
	/// Попробуйте повторить запрос позже.
	/// Код ошибки - 10
	/// </summary>
	[Serializable]
	public sealed class PublicServerErrorException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public PublicServerErrorException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.PublicServerError;
	}
}