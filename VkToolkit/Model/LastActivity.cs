using System;

namespace VkToolkit.Model
{
    public class LastActivity
    {
        public long? UserId { get; set; }
        public bool? IsOnline { get; set; }
        public DateTime? Time { get; set; }
    }
}