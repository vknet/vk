namespace VkNet.Abstractions.Core
{
	/// <summary>
	/// Менеджер управления токеном приложения
	/// </summary>
	public interface ITokenManager
	{
		/// <summary>
		/// Токен приложения
		/// </summary>
		string Token { get; }

		/// <summary>
		/// Время истечения токена
		/// </summary>
		/// <remarks>
		/// В секундах, 0 - бесконечный токен
		/// </remarks>
		int ExpireTime { get; }

		/// <summary>
		/// <c> true </c> - если токен приложения истек
		/// </summary>
		bool IsExpired { get; }

		/// <summary>
		/// Обновить токен
		/// </summary>
		/// <returns> <c> true </c> - если обновление токена приложения прошло успешно </returns>
		bool RefreshToken();

		/// <summary>
		/// Установить значение токена приложения
		/// </summary>
		/// <param name="token"> Токен приложения </param>
		void SetToken(string token);
	}
}