using System;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <summary>
	/// VkApi Authorization
	/// </summary>
	public interface IVkApiAuth
	{
		/// <summary>
		/// Была ли произведена авторизация каким либо образом
		/// </summary>
		bool IsAuthorized { get; }

		/// <summary>
		/// Авторизация и получение токена
		/// </summary>
		/// <param name="params"> Данные авторизации </param>
		void Authorize(IApiAuthParams @params);

		/// <summary>
		/// Авторизация и получение токена
		/// </summary>
		/// <param name="params"> Данные авторизации </param>
		void Authorize(ApiAuthParams @params);

		/// <summary>
		/// Получает новый AccessToken используя логин, пароль, приложение и настройки
		/// указанные при последней авторизации.
		/// </summary>
		/// <param name="code">
		/// Делегат двух факторной авторизации. Если не указан - будет взят из параметров
		/// (если есть)
		/// </param>
		/// <exception cref="AggregateException">
		/// Невозможно обновить токен доступа т.к. последняя авторизация происходила не при
		/// помощи логина и пароля
		/// </exception>
		void RefreshToken(Func<string> code = null);

		/// <summary>
		/// Выйти из системы
		/// </summary>
		/// <remarks>
		/// Забыть токен авторизации
		/// </remarks>
		void LogOut();
	}
}