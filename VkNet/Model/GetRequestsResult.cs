using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
    /// <summary>
    /// Результат запроса friends.getRequests
    /// </summary>
    [Serializable] 
    public class GetRequestsResult
    {
        /// <summary>
        /// Total requests number
        /// </summary>
        [JsonProperty("count")]
        public uint Count { get; set; }
        
        /// <summary>
        /// User ID's
        /// </summary>
        [JsonProperty("items")]
        public ReadOnlyCollection<long> Items { get; set; }
        
        /// <summary>
        /// Total unread requests number
        /// </summary>
        [JsonProperty("count_unread")]
        public uint CountUnread { get; set; }
    }
}