using System;
using VkToolkit.Utils;

namespace VkToolkit.Model
{    
    public class LastActivity
    {
        public long? UserId { get; set; }
        public bool? IsOnline { get; set; }
        public DateTime? Time { get; set; }

        internal static LastActivity FromJson(VkResponse activity)
        {
            var result = new LastActivity();

            result.IsOnline = activity["online"];
            result.Time = activity["time"];

            return result;            
        }
    }
}