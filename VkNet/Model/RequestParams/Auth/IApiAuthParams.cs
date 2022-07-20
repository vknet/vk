using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Параметры авторизации
	/// </summary>
	public interface IApiAuthParams
	{
		/// <summary>
		/// Идентификатор приложения с помощью которого будет авторизован пользователь
		/// </summary>
		ulong ApplicationId { get; set; }

		/// <summary>
		/// Логин пользователя
		/// </summary>
		string Login { get; set; }

		/// <summary>
		/// Пароль пользователя
		/// </summary>
		string Password { get; set; }

		/// <summary>
		/// Права доступа приложений
		/// См. описание <see href="https://vk.com/dev/permissions" />
		/// </summary>
		/// <remarks>
		/// ВНИМАНИЕ!!! Settings.All по умолчанию не содержит Settings.Offline и
		/// Settings.Messages
		/// </remarks>
		Settings Settings { get; set; }

		/// <summary>
		/// Функция двух факторной авторизации
		/// </summary>
		Func<string> TwoFactorAuthorization { get; set; }

		/// <summary>
		/// Токен доступа, полученный извне
		/// </summary>
		string AccessToken { get; set; }

		/// <summary>
		/// Время, в течении которого действует токен доступа полученный извне (0 -
		/// бесконечно, по умолчанию)
		/// Используется при авторизации с помощью токена доступа, полученного извне
		/// </summary>
		int TokenExpireTime { get; set; }

		/// <summary>
		/// Идентификатор пользователя, установившего приложение
		/// Используется при авторизации с помощью токена доступа, полученного извне
		/// </summary>
		long UserId { get; set; }

		/// <summary>
		/// Идентификатор капчи (если установлена)
		/// </summary>
		ulong? CaptchaSid { get; set; }

		/// <summary>
		/// Ключ капчи (если необходимо)
		/// </summary>
		string CaptchaKey { get; set; }

		/// <summary>
		/// Имя узла прокси-сервера.
		/// </summary>
		[Obsolete("Use HttpClient to configure proxy. Documentation reference https://github.com/vknet/vk/wiki/Proxy-Configuration", true)]
		string Host { get; set; }

		/// <summary>
		/// Номер порта используемого Host.
		/// </summary>
		[Obsolete("Use HttpClient to configure proxy. Documentation reference https://github.com/vknet/vk/wiki/Proxy-Configuration", true)]
		int? Port { get; set; }

		/// <summary>
		/// Логин для прокси с авторизацией. Если прокси без авторизации - оставить пустым
		/// </summary>
		[Obsolete("Use HttpClient to configure proxy. Documentation reference https://github.com/vknet/vk/wiki/Proxy-Configuration", true)]
		string ProxyLogin { get; set; }

		/// <summary>
		/// Пароль для прокси с авторищацией. Если прокси без авторизации - оставить пустым
		/// </summary>
		[Obsolete("Use HttpClient to configure proxy. Documentation reference https://github.com/vknet/vk/wiki/Proxy-Configuration", true)]
		string ProxyPassword { get; set; }

		/// <summary>
		/// Номер телефона
		/// </summary>
		string Phone { get; set; }

		/// <summary>
		/// Cекретный ключ Вашего приложения.
		/// </summary>
		string ClientSecret { get; set; }

		/// <summary>
		/// Если возникли проблемы с получением кода из приложения или пользователь не
		/// хочет использовать приложение для генерации кодов,
		/// Вы можете форсировать получение кода по SMS, повторно передав запрос
		/// авторизации с этим параметром равным <c> true </c>
		/// </summary>
		bool? ForceSms { get; set; }

		/// <summary>
		/// Указывает тип отображения страницы авторизации.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		Display Display { get; set; }

		/// <summary>
		/// Адрес, на который будет переадресован пользователь после прохождения
		/// авторизации / передан code.
		/// </summary>
		Uri RedirectUri { get; set; }

		/// <summary>
		/// Произвольная строка, которая будет возвращена вместе с результатом авторизации.
		/// </summary>
		string State { get; set; }

		/// <summary>
		/// Передайте <c> true </c>, чтобы включить поддержку двухфакторной аутентификации.
		/// </summary>
		bool? TwoFactorSupported { get; set; }

		/// <summary>
		/// Тип авторизации.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		GrantType GrantType { get; set; }

		/// <summary>
		/// Тип ответа, который Вы хотите получить.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		ResponseType ResponseType { get; set; }

		/// <summary>
		/// Параметр, указывающий, что необходимо не пропускать этап подтверждения прав,
		/// даже если пользователь уже авторизован.
		/// (При <c> true </c>)
		/// </summary>
		bool? Revoke { get; set; }

		/// <summary>
		/// Код подтверждения двухфакторной авторизации / временный код, полученный после
		/// прохождения авторизации.
		/// </summary>
		string Code { get; set; }

		/// <summary>
		/// Параметр, указывающий, что VkNet должен автоматически обновлять токен в случае если он становится недействительным
		/// </summary>
		bool IsTokenUpdateAutomatically { get; set; }

		/// <summary>
		/// Свойство, указывающее, достаточно ли заполнено данных для авторизации
		/// </summary>
		bool IsValid { get; }
	}
}