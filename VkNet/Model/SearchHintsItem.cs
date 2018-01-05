using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SearchHintsItem
    {
        /// <summary>
        /// тип объекта
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public SearchResultType Type { get; set; }

        /// <summary>
        /// данные о сообществе.
        /// </summary>
        [JsonProperty("group")]
        public SearchGroup Group { get; set; }

        /// <summary>
        /// данные о профиле.
        /// </summary>
        [JsonProperty("profile")]
        public SearchProfile Profile { get; set; }

        /// <summary>
        /// тип объекта
        /// </summary>
        [JsonProperty("section")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public SearchFilter Section { get; set; }
        
        /// <summary>
        /// описание объекта (для сообществ — тип и число участников, например, Group, 269,136 members,
        /// для профилей друзей или пользователями, которые не являются возможными друзьями — название университета или город,
        /// для профиля текущего пользователя — That's you, для профилей возможных друзей — N mutual friends).
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// поле возвращается, если объект был найден в глобальном поиске, всегда содержит 1.
        /// </summary>
        [JsonProperty("global")]
        public bool? Global { get; set; }
    }
}