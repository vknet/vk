using System.Threading;
using System.Threading.Tasks;
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
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns> Access token. </returns>
		Task<AuthorizationResult> AuthorizeAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// Задать параметры авторизации
		/// </summary>
		/// <param name="authorizationParams">Параметры авторизации</param>
		void SetAuthorizationParams(IApiAuthParams authorizationParams);
	}
}