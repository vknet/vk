using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если действие запрещено для не Standalone
	/// приложений.
	/// Если ошибка возникает несмотря на то, что Ваше приложение имеет тип Standalone,
	/// убедитесь, что при авторизации Вы
	/// используете redirect_uri=https://oauth.vk.com/blank.html. Подробнее см.
	/// http://vk.com/dev/auth_mobile.
	/// Код ошибки - 20
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.NonStandaloneApplications)]
	public sealed class NonStandaloneApplicationsException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public NonStandaloneApplicationsException(VkError response) : base(response)
		{
		}
	}
}