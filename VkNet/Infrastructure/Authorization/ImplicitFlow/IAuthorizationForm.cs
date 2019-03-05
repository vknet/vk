using System.Threading.Tasks;
using Flurl;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
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
		/// <returns>Содержимое ответа от vk</returns>
		Task<AuthorizationFormResult> ExecuteAsync(Url url);
	}
}