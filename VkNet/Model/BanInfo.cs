using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model
{
    public class BanInfo
    {
        public long? AdminId { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
        public DateTime? EndDate { get; set; }
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