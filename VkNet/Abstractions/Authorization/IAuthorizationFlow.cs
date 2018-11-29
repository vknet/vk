using System;
using VkNet.Model;

namespace VkNet.Abstractions.Authorization
{
	/// <summary>
	/// Поток авторизации
	/// </summary>
	public interface IAuthorizationFlow
	{
		/// <summary>
		/// Авторизация
		/// </summary>
		/// <returns> Access token. </returns>
		AuthorizationResult Authorize();

		/// <summary>
		/// Установить параметры авторизации.
		/// </summary>
		/// <param name="authParams">
		/// Параметры авторизации.
		/// </param>
		void SetAuthParams(IApiAuthParams authParams);

		/// <summary>
		/// Получить параметры авторизации.
		/// </summary>
		/// <returns>
		/// Параметры авторизации.
		/// </returns>
		IApiAuthParams GetAuthParams();

		/// <summary>
		/// Построить URL для авторизации.
		/// </summary>
		/// <returns> Возвращает Uri для авторизации. </returns>
		Uri CreateAuthorizeUrl();
	}
}