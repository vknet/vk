using System.Net.Http;
using System.Threading.Tasks;
using Flurl;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Форма логина
	/// </summary>
	public interface IImplicitFlowLoginForm
	{
		/// <summary>
		/// Выполнить авторизацию
		/// </summary>
		/// <param name="authorizeUrl">Url авторизации</param>
		/// <returns>Содержимое ответа от vk</returns>
		Task<AuthorizationFormResult> ExecuteAsync(Url authorizeUrl);
	}
}