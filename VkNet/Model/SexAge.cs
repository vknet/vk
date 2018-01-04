using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SexAge
    {
        /// <summary>
        /// обозначение возраста
        /// </summary>
        [JsonProperty("age_range")]
        public string AgeRange { get; set; }

        /// <summary>
        /// число переходов пользователей женского пола
        /// </summary>
        [JsonProperty("female")]
        public ulong Female { get; set; }

        /// <summary>
        /// число переходов пользователей мужского пола
        /// </summary>
        [JsonProperty("male")]
        public ulong Male { get; set; }
    }
}