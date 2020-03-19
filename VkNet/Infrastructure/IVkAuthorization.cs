using System;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Информация об авторизации приложения на действия.
	/// </summary>
	public interface IVkAuthorization<TPageType>
	{
		/// <summary>
		/// Получить результат авторизации
		/// </summary>
		/// <param name="url">
		/// URL в котором содержатся параметры о авторизации
		/// </param>
		/// <returns>
		/// Результат авторизации <see cref="T:VkNet.Model.AuthorizationResult" />
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		/// URL должен начинаться со строки 'https://oauth.vk.com/blank.html'
		/// </exception>
		AuthorizationResult GetAuthorizationResult(Uri url);

		/// <summary>
		/// Получить тип страницы авторизации
		/// </summary>
		/// <param name="url">
		/// Текщий URL страницы авторизации
		/// </param>
		/// <returns>
		/// Тип страницы для авторизации Implicit Flow
		/// </returns>
		TPageType GetPageType(Uri url);
	}
}