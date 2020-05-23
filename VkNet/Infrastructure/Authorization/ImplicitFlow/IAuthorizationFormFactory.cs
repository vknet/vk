using VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Фабрика для создания форм авторизации
	/// </summary>
	public interface IAuthorizationFormFactory
	{
		/// <summary>
		/// Создать форму авторизации
		/// </summary>
		/// <param name="type">Тип страницы авторизации</param>
		/// <returns>Страница авторизации</returns>
		IAuthorizationForm Create(ImplicitFlowPageType type);
	}
}