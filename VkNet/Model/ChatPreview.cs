using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Превью чата
    /// </summary>
    [Serializable]
    public class ChatPreview
    {
        /// <summary>
        /// Информация о чате.
        /// </summary>
        [JsonProperty("preview")]
        public ChatPreviewField Preview { get; set; }

        /// <summary>
        /// Массив объектов пользователей
        /// </summary>
        [JsonProperty("profiles")]
        public IEnumerable<User> Profiles { get; set; }

        /// <summary>
        /// Массив объектов сообществ
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<Group> Groups { get; set; }

        /// <summary>
        /// Массив объектов, описывающих e-mail.
        /// </summary>
        [JsonProperty("emails")]
        public IEnumerable<Email> Emails { get; set; }

        #region Методы

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static ChatPreview FromJson(VkResponse response)
        {
            return new ChatPreview
            {
                Preview = response["preview"],
                Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
                Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x),
                Emails = response["emails"].ToReadOnlyCollectionOf<Email>(x => x)
            };
        }

        #endregion
    }
}