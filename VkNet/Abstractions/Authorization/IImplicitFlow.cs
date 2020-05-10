using System;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Abstractions.Authorization
{
	/// <inheritdoc />
	/// <summary>
	/// Implicit flow — самый короткий и простой вариант.
	/// Ключ возвращается на устройство пользователя, где был открыт диалог авторизации
	/// (в виде дополнительного параметра URL).
	/// Такой ключ может быть использован только для запросов непосредственно с
	/// устройства пользователя
	/// (например, для выполнения вызовов из Javascript на веб-сайте или из мобильного
	/// приложения).
	/// </summary>
	/// <remarks>
	/// https://vk.com/dev/implicit_flow_user
	/// </remarks>
	[UsedImplicitly]
	public interface IImplicitFlow : IAuthorizationFlow
	{
		/// <summary>
		/// Построить URL для авторизации.
		/// </summary>
		/// <param name="clientId"> Идентификатор Вашего приложения. </param>
		/// <param name="scope">
		/// Битовая маска настроек доступа приложения, которые необходимо проверить при
		/// авторизации
		/// пользователя и запросить отсутствующие.
		/// </param>
		/// <param name="display"> Указывает тип отображения страницы авторизации. </param>
		/// <param name="state">
		/// Произвольная строка, которая будет возвращена вместе с
		/// результатом авторизации.
		/// </param>
		/// <returns> Возвращает Uri для авторизации </returns>
		[Obsolete("Используйте перегрузку Url CreateAuthorizeUrl();\nПараметры авторизации должны быть уставленны вызовом void SetAuthorizationParams(IApiAuthParams authorizationParams);")]
		Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state);

		/// <summary>
		/// Построить URL для авторизации.
		/// </summary>
		/// <returns> Возвращает Uri для авторизации </returns>
		Uri CreateAuthorizeUrl();
	}
}