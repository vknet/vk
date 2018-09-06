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
	}
}