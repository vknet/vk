using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
    /// <summary>
    /// Превью чата
    /// </summary>
    [Serializable]
    public class ChatPreview
    {
        /// <summary>
        /// информация о чате.
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
    }
}