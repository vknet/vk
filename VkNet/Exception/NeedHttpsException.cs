using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если требуется выполнение запросов по HTTPS
	/// Требуется выполнение запросов по протоколу HTTPS, т.к. пользователь включил
	/// настройку, требующую работу через
	/// безопасное соединение.
	/// Чтобы избежать появления такой ошибки, в Standalone-приложении Вы можете
	/// предварительно проверять состояние этой
	/// настройки у пользователя методом account.getInfo.
	/// Код ошибки - 16
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.NeedHttps)]
	public sealed class NeedHttpsException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public NeedHttpsException(VkError response) : base(response)
		{
		}
	}
}