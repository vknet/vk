using VkNet.Model;

namespace VkNet.Abstractions.Core
{
	/// <summary>
	/// Выполняет обход ошибки валидации: https://vk.com/dev/need_validation
	/// </summary>
	public interface INeedValidationHandler
	{
		/// <summary>
		/// Выполняет обход ошибки валидации: https://vk.com/dev/need_validation
		/// </summary>
		/// <param name="validateUrl"> Адрес страницы валидации </param>
		/// <param name="phoneNumber">
		/// Номер телефона, который необходимо ввести на
		/// странице валидации
		/// </param>
		/// <returns> Информация об авторизации приложения. </returns>
		AuthorizationResult Validate(string validateUrl, string phoneNumber);
	}
}