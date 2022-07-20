using System;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms
{
	/// <summary>
	/// Страница авторизации
	/// </summary>
	public interface IAuthorizationForm
	{
		/// <summary>
		/// Получить тип страницы автризации
		/// </summary>
		/// <returns>
		/// Тип страницы автризации
		/// </returns>
		ImplicitFlowPageType GetPageType();

		/// <summary>
		/// Выполнить авторизацию
		/// </summary>
		/// <param name="url">Url запроса</param>
		/// <param name="authParams">Параметры авторизации.</param>
		/// <returns>Содержимое ответа от vk</returns>
		Task<AuthorizationFormResult> ExecuteAsync(Uri url, IApiAuthParams authParams);
	}
}