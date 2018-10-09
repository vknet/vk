using System;
using JetBrains.Annotations;
using VkNet.Abstractions.Authorization;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// VkApi
	/// </summary>
	public interface IVkApi : IDisposable, IVkApiAuthAsync, IVkApiCategories, IVkApiCaptcha, IVkInvoke
	{
	#region Properties

		/// <summary>
		/// Ограничение на кол-во запросов в секунду
		/// </summary>
		float RequestsPerSecond { get; set; }

		/// <summary>
		/// Браузер.
		/// </summary>
		IBrowser Browser { get; set; }

		/// <summary>
		/// Поток авторизации
		/// </summary>
		IAuthorizationFlow AuthorizationFlow { get; set; }

		/// <summary>
		/// Токен для доступа к методам API
		/// </summary>
		string Token { get; }

		/// <summary>
		/// Идентификатор пользователя, от имени которого была проведена авторизация.
		/// Если авторизация не была произведена с использованием метода Authorize(int
		/// то возвращается null.
		/// </summary>

		// ReSharper disable once MemberCanBePrivate.Global
		long? UserId { get; set; }

		/// <summary>
		/// Оповещает об истечении срока токена доступа
		/// </summary>
		[UsedImplicitly]
		event VkApiDelegate OnTokenExpires;

	#endregion

	#region Methods

		/// <summary>
		/// Установить язык
		/// </summary>
		/// <param name="language"> </param>
		void SetLanguage(Language language);

		/// <summary>
		/// Установить язык
		/// </summary>
		Language? GetLanguage();

		/// <summary>
		/// Обход ошибки валидации: https://vk.com/dev/need_validation
		/// </summary>
		/// <param name="validateUrl"> Адрес, на который нужно перейти для валидации </param>
		/// <param name="phoneNumber">
		/// Номер телефона, который нужно ввести на странице
		/// валидации
		/// </param>
		void Validate(string validateUrl, string phoneNumber);

	#endregion
	}
}