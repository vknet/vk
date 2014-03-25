using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Информация о блокировке пользователя
    /// </summary>
    public class BanInfo
    {
        /// <summary>
        /// Идентификатор администратора группы заблокировавший пользователя
        /// </summary>
        public long? AdminId { get; set; }

        /// <summary>
        /// Дата блокировки
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата окончания блокировки
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Причина блокировки
        /// </summary>
        public BanReason Reason { get; set; }

        internal static BanInfo FromJson(VkResponse response)
        {
            var info = new BanInfo();

            info.AdminId = response["admin_id"];
            info.Date = response["date"];
            info.Comment = response["comment"];
            info.EndDate = response["end_date"];
            info.Reason = response["reason"];

            return info;
        }
    }
}