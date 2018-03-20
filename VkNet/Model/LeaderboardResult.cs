using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LeaderboardResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public ReadOnlyCollection<LeaderboardItem> Items { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("profiles")]
        public ReadOnlyCollection<User> Profiles { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LeaderboardItem
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("score")]
        public long Score { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("level")]
        public long Level { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("points")]
        public long Points { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}