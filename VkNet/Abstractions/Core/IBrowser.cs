using System;
using System.Net;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;

namespace VkNet.Utils
{
	/// <summary>
	/// Интерфейс браузера, с помощью которого осуществляется сетевое взаимодействие.
	/// Интерфейс введен с целью обеспечения возможности выполнения модульного
	/// тестирования.
	/// </summary>
	public interface IBrowser: IImplicitFlow, INeedValidationHandler
	{
		/// <summary>
		/// Прокси сервер
		/// </summary>
		IWebProxy Proxy { get; set; }

		/// <summary>
		/// Установить callback на случай, если понадобится код двухфакторной авторизации.
		/// </summary>
		/// <param name="func">
		/// Функция двухфакторной авторизации.
		/// </param>
		void SetTwoFactorCallback(Func<string> func);
	}
}