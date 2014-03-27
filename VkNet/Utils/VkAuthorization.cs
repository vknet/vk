namespace VkNet.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using VkNet.Exception;

    /// <summary>
    /// Информация об авторизации приложения на действия.
    /// </summary>
    public class VkAuthorization
    {
        private readonly List<NameValue> _decodedAnswer;

        private VkAuthorization(Uri responseUrl)
        {
            _decodedAnswer = Decode(responseUrl);
        }

        /// <summary>
        /// Извлекает из URL, на которую произошло перенаправление при авторизации, информацию об авторизации.
        /// </summary>
        /// <param name="responseUrl">
        /// URL, на которую произошло перенаправление при авторизации.
        /// </param>
        /// <returns>Информация об авторизации.</returns>
        public static VkAuthorization From(Uri responseUrl)
        {
            return new VkAuthorization(responseUrl);
        }

        /// <summary>
        /// Возвращает признак была ли авторизация успешной.
        /// </summary>
        public bool IsAuthorized
        {
            get { return AccessToken != null; }
        }

        /// <summary>
        /// Проверяет требуется ли получения у авторизации на запрошенные приложением действия (при установке приложения пользователю).
        /// </summary>
        public bool IsAuthorizationRequired
        {
            get { return GetFieldValue("__q_hash") != null; }
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
        public string ExpiresIn
        {
            get { return GetFieldValue("expires_in"); }
        }

        /// <summary>
        /// Идентификатор пользователя, у которого работает приложение (от имени которого был произведен вход).
        /// </summary>
        public long UserId
        {
            get
            {
                var userIdFieldValue = GetFieldValue("user_id");
                long userId;
                if (!long.TryParse(userIdFieldValue, out userId))
                    throw new VkApiException("UserId is not integer value.");

                return userId;
            }
        }

        private string GetFieldValue(string fieldName)
        {
            return _decodedAnswer.Where(i => i.Name == fieldName).Select(i => i.Value).FirstOrDefault();
        }

        internal sealed class NameValue
        {
            public string Name { get; set; }

            public string Value { get; set; }

            public NameValue(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return string.Format("{0}={1}", Name, Value);
            }
        }

        private static List<NameValue> Decode(Uri url)
        {
            if (!string.IsNullOrEmpty(url.Query))
                return DecodeQuery(url);

            return DecodeFragment(url);
        }

        private static List<NameValue> DecodeQuery(Uri url)
        {
            var urlQuery = url.Query;
            var query = urlQuery.StartsWith("?") || urlQuery.StartsWith("#") ? urlQuery.Substring(1) : urlQuery;
            return query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split('=')).Select(s => new NameValue(s[0], s[1])).ToList();
        }

        private static List<NameValue> DecodeFragment(Uri url)
        {
            var urlQuery = url.Fragment;
            var query = urlQuery.StartsWith("#") ? urlQuery.Substring(1) : urlQuery;
            return query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split('=')).Select(s => new NameValue(s[0], s[1])).ToList();
        }
    }
}