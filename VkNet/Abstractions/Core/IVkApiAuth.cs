using VkNet.Abstractions.Authorization;

namespace VkNet.Abstractions
{
	/// <summary>
	/// VkApi Authorization
	/// </summary>
	public interface IVkApiAuth
	{
		/// <summary>
		/// Авторизация и получение токена.
		/// </summary>
		/// <param name="authorizationFlow">
		/// Поток авторизации
		/// </param>
		void Authorize(IAuthorizationFlow authorizationFlow);

		/// <summary>
		/// Выйти из системы
		/// </summary>
		/// <remarks>
		/// Забыть токен авторизации
		/// </remarks>
		void LogOut();
	}
}