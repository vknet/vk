using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке запроса, когда приложение
	/// выключено (appid)
	/// Необходимо включить приложение в настройках https://vk.com/editapp?id={Ваш
	/// API_ID} или использовать тестовый режим
	/// (test_mode=1)
	/// Код ошибки - 2
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.AppOff)]
	public sealed class AppOffException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AppOffException(VkError response) : base(response)
		{
		}
	}
}