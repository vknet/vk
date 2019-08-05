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
	[VkError(VkErrorCode.PublicServerError)]
	public sealed class PublicServerErrorException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public PublicServerErrorException(VkError response) : base(response)
		{
		}
	}
}