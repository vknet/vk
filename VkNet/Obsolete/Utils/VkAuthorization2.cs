using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Exception;
using VkNet.Infrastructure;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <summary>
	/// Информация об авторизации приложения на действия.
	/// </summary>
	[Obsolete(ObsoleteText.ObsoleteClass)]
	public class VkAuthorization2
	{
		/// <summary>
		/// Список наименования полей.
		/// </summary>
		private readonly Dictionary<string, string> _nameValues;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="uriFragment"> URL ответа. </param>
		private VkAuthorization2(string uriFragment)
		{
			_nameValues = Decode(urlFragment: uriFragment);
		}

		/// <summary>
		/// Возвращает признак была ли авторизация успешной.
		/// </summary>
		public bool IsAuthorized => _nameValues.ContainsKey(key: Constants.AccessToken);

		/// <summary>
		/// Проверяет требуется ли получения у авторизации на запрошенные приложением
		/// действия (при установке приложения
		/// пользователю).
		/// </summary>
		public bool IsAuthorizationRequired => _nameValues.ContainsKey(key: "__q_hash");

		/// <summary>
		/// Маркер доступа, который необходимо использовать для доступа к API ВКонтакте.
		/// </summary>
		public string AccessToken => GetFieldValue(fieldName: Constants.AccessToken);

		/// <summary>
		/// Время истечения срока действия маркера доступа.
		/// </summary>
		public int ExpiresIn => GetExpiresIn();

		/// <summary>
		/// Произвольная строка, которая будет возвращена вместе с результатом авторизации.
		/// </summary>
		public string State => GetFieldValue(fieldName: "state");

		/// <summary>
		/// Идентификатор пользователя, у которого работает приложение (от имени которого
		/// был произведен вход).
		/// </summary>
		public long UserId => GetUserId();

		/// <summary>
		/// E-mail пользователя, у которого работает приложение (от имени которого был
		/// произведен вход).
		/// </summary>
		public string Email => GetFieldValue(fieldName: "email");

		/// <summary>
		/// ID капчи, если она появилась
		/// </summary>
		public bool IsCaptchaNeeded => _nameValues.ContainsKey(key: "sid");

		/// <summary>
		/// ID капчи, если она появилась
		/// </summary>
		public long CaptchaSid => GetCaptchaSid();

		/// <summary>
		/// Извлекает из URL, на которую произошло перенаправление при авторизации,
		/// информацию об авторизации.
		/// </summary>
		/// <param name="uriFragment">
		/// URL, на которую произошло перенаправление при авторизации.
		/// </param>
		/// <returns> Информация об авторизации. </returns>
		public static VkAuthorization2 From(string uriFragment)
		{
			return new VkAuthorization2(uriFragment: uriFragment);
		}

		/// <summary>
		/// Получить значение поля.
		/// </summary>
		/// <param name="fieldName"> Наименование поля. </param>
		/// <returns> Значение поля. </returns>
		private string GetFieldValue(string fieldName)
		{
			return _nameValues.ContainsKey(key: fieldName)
				? _nameValues[key: fieldName]
				: throw new KeyNotFoundException(message: fieldName);
		}

		/// <summary>
		/// Расшифровывает указанный URL.
		/// </summary>
		/// <param name="urlFragment"> URL. </param>
		/// <returns> Список наименования полей. </returns>
		private static Dictionary<string, string> Decode(string urlFragment)
		{
			var uri = new Uri(uriString: urlFragment);

			if (string.IsNullOrWhiteSpace(value: uri.Query) && string.IsNullOrWhiteSpace(value: uri.Fragment))
			{
				return new Dictionary<string, string>();
			}

			var query = string.IsNullOrWhiteSpace(value: uri.Query)
				? uri.Fragment.Substring(startIndex: 1)
				: uri.Query.Substring(startIndex: 1);

			return query.Split(separator: new[] { '&' }, options: StringSplitOptions.RemoveEmptyEntries)
				.Select(selector: s => s.Split('='))
				.ToDictionary(keySelector: s => s[0], elementSelector: s => s[1]);
		}

		private int GetExpiresIn()
		{
			var expiresInValue = GetFieldValue(fieldName: "expires_in");

			if (!int.TryParse(s: expiresInValue, result: out var expiresIn))
			{
				throw new VkApiException(message: "ExpiresIn is not integer value.");
			}

			return expiresIn;
		}

		private long GetUserId()
		{
			var userIdFieldValue = GetFieldValue(fieldName: "user_id");

			if (!long.TryParse(s: userIdFieldValue, result: out var userId))
			{
				throw new VkApiException(message: "UserId is not long value.");
			}

			return userId;
		}

		private long GetCaptchaSid()
		{
			var userIdFieldValue = GetFieldValue(fieldName: "sid");

			if (!long.TryParse(s: userIdFieldValue, result: out var userId))
			{
				throw new VkApiException(message: "sid is not long value.");
			}

			return userId;
		}
	}
}