using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неверном API ID приложения.
	/// Найдите приложение в списке администрируемых на странице
	/// http://vk.com/apps?act=settings и укажите в запросе верный
	/// API_ID (идентификатор приложения).
	/// Либо используйте стандартный APP_ID для Android: 2890984
	/// Код ошибки - 101
	/// </summary>
	[Serializable]
	public class InvalidAppIdException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidAppIdException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidAppId;
	}
}