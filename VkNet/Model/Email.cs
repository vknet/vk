using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
    /// <summary>
    /// E-Mail.
    /// </summary>
    [Serializable]
    public class Email
    {
        /// <summary>
        /// Идентификатор e-mail
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Адрес e-mail
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}