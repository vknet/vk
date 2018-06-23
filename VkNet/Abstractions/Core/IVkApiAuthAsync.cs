using System;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <summary>
	/// VkApi Authorization Async
	/// </summary>
	public interface IVkApiAuthAsync : IVkApiAuth
	{
		/// <summary>
		/// Авторизация и получение токена в асинхронном режиме
		/// </summary>
		/// <param name="params"> Данные авторизации </param>
		Task AuthorizeAsync(IApiAuthParams @params);

		/// <summary>
		/// Получает новый AccessToken используя логин, пароль, приложение и настройки
		/// указанные при последней авторизации.
		/// </summary>
		/// <param name="code">
		/// Делегат двух-факторной авторизации. Если не указан - будет взят из параметров
		/// (если есть)
		/// </param>
		Task RefreshTokenAsync(Func<string> code = null);
	}
}