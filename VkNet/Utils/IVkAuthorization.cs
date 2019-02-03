using System;
using VkNet.Model;

namespace VkNet.Utils
{
	public interface IVkAuthorization
	{
		/// <summary>
		/// Получить результат авторизации
		/// </summary>
		/// <param name="url">URL в котором содержатся параметры о авторизации</param>
		/// <returns>Результат авторизации <see cref="AuthorizationResult"/></returns>
		/// <exception cref="ArgumentException">URL должен начинаться со строки 'https://oauth.vk.com/blank.html'</exception>
		AuthorizationResult GetAuthorizationResult(Uri url);
	}
}