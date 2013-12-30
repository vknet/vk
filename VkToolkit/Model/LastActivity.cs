using System;
using VkToolkit.Utils;

namespace VkToolkit.Model
{    
    /// <summary>
    /// Информация о последней активности пользователя.
    /// </summary>
    public class LastActivity
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Текущий статус пользователя (true - в сети, false - не в сети).
        /// </summary>
        public bool? IsOnline { get; set; }
        /// <summary>
        /// Дата последней активности пользователя.
        /// </summary>
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