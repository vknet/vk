using System;
using JetBrains.Annotations;

namespace VkNet.Abstractions.Core
{
	/// <summary>
	/// Служит для оповещения об истечении токена.
	/// </summary>
	/// <param name="sender">
	/// Экземпляр API у которого истекло время токена.
	/// </param>
	public delegate void VkApiDelegate(IVkApi sender);

	/// <summary>
	/// Менеджер управления токеном приложения
	/// </summary>
	public interface ITokenManager : IDisposable
	{
		/// <summary>
		/// Токен приложения
		/// </summary>
		string Token { get; }

		/// <summary>
		/// Время истечения токена
		/// </summary>
		/// <remarks>
		/// В секундах, 0 - бесконечный токен
		/// </remarks>
		int ExpireTime { get; set; }

		/// <summary>
		/// Идентификатор пользователя, от имени которого была проведена авторизация.
		/// </summary>
		long? UserId { get; set; }

		/// <summary>
		/// <c> true </c> - если токен приложения истек
		/// </summary>
		bool IsExpired { get; }

		/// <summary>
		/// <c> true </c> - если была произведена авторизация.
		/// </summary>
		bool IsAuthorized { get; }

		/// <summary>
		/// Оповещает об истечении срока токена доступа
		/// </summary>
		[UsedImplicitly]
		event VkApiDelegate OnTokenExpires;

		/// <summary>
		/// Обновить токен
		/// </summary>
		/// <returns> <c> true </c> - если обновление токена прошло успешно </returns>
		bool RefreshToken();

		/// <summary>
		/// Установить значение токена приложения
		/// </summary>
		/// <param name="token"> Токен приложения </param>
		void SetToken(string token);
	}
}