using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Exception;

namespace VkNet.Utils
{
    /// <summary>
    /// Информация об авторизации приложения на действия.
    /// </summary>
    public class VkAuthorization
    {
		/// <summary>
		/// Список наименования полей.
		/// </summary>
		private readonly Dictionary<string, string> _nameValues;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="uriFragment">URL ответа.</param>
		private VkAuthorization(string uriFragment)
        {
            _nameValues = Decode(uriFragment);
        }

        /// <summary>
        /// Извлекает из URL, на которую произошло перенаправление при авторизации, информацию об авторизации.
        /// </summary>
        /// <param name="uriFragment">
        /// URL, на которую произошло перенаправление при авторизации.
        /// </param>
        /// <returns>Информация об авторизации.</returns>
        public static VkAuthorization From(string uriFragment)
		{
			return new VkAuthorization(uriFragment);
		}

		/// <summary>
        /// Возвращает признак была ли авторизация успешной.
        /// </summary>
        public bool IsAuthorized
		{
			get { return _nameValues.ContainsKey("access_token"); }
		}

		/// <summary>
        /// Проверяет требуется ли получения у авторизации на запрошенные приложением действия (при установке приложения пользователю).
        /// </summary>
        public bool IsAuthorizationRequired
		{
			get { return _nameValues.ContainsKey("__q_hash"); }
		}

		/// <summary>
        /// Маркер доступа, который необходимо использовать для доступа к API ВКонтакте.
        /// </summary>
        public string AccessToken
		{
			get { return GetFieldValue("access_token"); }
		}

		/// <summary>
        /// Время истечения срока действия маркера доступа.
        /// </summary>
        public int ExpiresIn
		{
			get { return GetExpiresIn(); }
		}

		/// <summary>
        /// Идентификатор пользователя, у которого работает приложение (от имени которого был произведен вход).
        /// </summary>
        public long UserId
		{
			get { return GetUserId(); }
		}

		/// <summary>
        /// E-mail пользователя, у которого работает приложение (от имени которого был произведен вход).
        /// </summary>
        public string Email
		{
			get { return GetFieldValue("email"); }
		}

		/// <summary>
        /// ID капчи, если она появилась
        /// </summary>
        public bool IsCaptchaNeeded
		{
			get { return _nameValues.ContainsKey("sid"); }
		}

		/// <summary>
	    /// ID капчи, если она появилась
	    /// </summary>
	    public long CaptchaSid
		{
			get { return GetCaptchaSid(); }
		}

		/// <summary>
		/// Получить значение поля.
		/// </summary>
		/// <param name="fieldName">Наименование поля.</param>
		/// <returns>Значение поля.</returns>
		private string GetFieldValue(string fieldName)
		{
			return _nameValues.ContainsKey(fieldName) 
				? _nameValues[fieldName] 
				: throw new KeyNotFoundException(fieldName);
        }

	    /// <summary>
	    /// Расшифровывает указанный URL.
	    /// </summary>
	    /// <param name="urlFragment">URL.</param>
	    /// <returns>Список наименования полей.</returns>
	    private static Dictionary<string, string> Decode(string urlFragment)
	    {
		    var uri = new Uri(urlFragment);

		    if (string.IsNullOrWhiteSpace(uri.Query) && string.IsNullOrWhiteSpace(uri.Fragment))
		    {
			    return new Dictionary<string, string>();
		    }

		    var query = string.IsNullOrWhiteSpace(uri.Query) 
			    ? uri.Fragment.Substring(1) 
			    : uri.Query.Substring(1);
		    
		    return query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
			    .Select(s => s.Split('='))
			    .ToDictionary(s => s[0], s => s[1]);
	    }
	    
	    private int GetExpiresIn()
	    {
		    var expiresInValue = GetFieldValue("expires_in");
		    if (!int.TryParse(expiresInValue, out var expiresIn))
		    {
			    throw new VkApiException("ExpiresIn is not integer value.");
		    }

		    return expiresIn;
	    }
	    
	    private long GetUserId()
	    {
		    var userIdFieldValue = GetFieldValue("user_id");
		    if (!long.TryParse(userIdFieldValue, out var userId))
		    {
			    throw new VkApiException("UserId is not long value.");
		    }

		    return userId;
	    }

	    private long GetCaptchaSid()
	    {
		    var userIdFieldValue = GetFieldValue("sid");
		    if (!long.TryParse(userIdFieldValue, out var userId))
		    {
			    throw new VkApiException("sid is not long value.");
		    }

		    return userId;
	    }
    }
}