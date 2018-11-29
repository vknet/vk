using System;
using JetBrains.Annotations;
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
		/// Передайте <c> true </c>, чтобы включить поддержку двухфакторной аутентификации.
		/// </summary>
		bool? TwoFactorSupported { get; set; }

		/// <summary>
		/// Временный код, полученный после прохождения авторизации или код двухфакторной
		/// авторизации.
		/// </summary>
		string Code { get; set; }

		/// <summary>
		/// Cекретный ключ Вашего приложения.
		/// </summary>
		string ClientSecret { get; set; }

		/// <summary>
		/// Идентификатор Вашего приложения.
		/// </summary>
		long ClientId { get; set; }

		/// <summary>
		/// Адрес, на который будет переадресован пользователь после прохождения
		/// авторизации.
		/// </summary>
		Uri RedirectUri { get; set; }

		/// <summary>
		/// Указывает тип отображения страницы авторизации.
		/// </summary>
		[CanBeNull]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		Display Display { get; set; }

		/// <summary>
		/// Права доступа приложения.
		/// См. описание <see href="https://vk.com/dev/permissions" />.
		/// </summary>
		/// <remarks>
		/// ВНИМАНИЕ!!! Settings.All по умолчанию не содержит Settings.Offline
		/// </remarks>
		[CanBeNull]
		Settings Scope { get; set; }

		/// <summary>
		/// Произвольная строка, которая будет возвращена вместе с результатом авторизации.
		/// </summary>
		string State { get; set; }

		/// <summary>
		/// Логин пользователя.
		/// </summary>
		string Login { get; set; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		string Password { get; set; }

		/// <summary>
		/// Идентификатор капчи (если установлена).
		/// </summary>
		long? CaptchaSid { get; set; }

		/// <summary>
		/// Ключ капчи (если необходимо).
		/// </summary>
		string CaptchaKey { get; set; }
	}
}