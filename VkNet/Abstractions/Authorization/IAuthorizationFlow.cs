using VkNet.Model;

namespace VkNet.Abstractions.Authorization
{
	/// <summary>
	/// Поток авторизации
	/// </summary>
	public interface IAuthorizationFlow<T>
	{
		/// <summary>
		/// </summary>
		T AuthorizationParameters { get; set; }

		/// <summary>
		/// Авторизация
		/// </summary>
		/// <returns> Access token. </returns>
		AuthorizationResult Aurhorize();
	}
}