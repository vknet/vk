using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    public class WallReply : MediaAttachment
    {
        static WallReply()
        {
            RegisterType(typeof(WallReply), "wall_reply");
        }

        public long? FromId { get; set; }

        public DateTime? Date { get; set; }

        public string Text { get; set; }

        public Likes Likes { get; set; }

        public long? ReplyToUId { get; set; }

        public long? ReplyToCId { get; set; }


        internal static WallReply FromJson(VkResponse response)
        {
            var wallReply = new WallReply();

            wallReply.Id = response["id"];
            wallReply.FromId = response["from_id"];
            wallReply.Date = response["date"];
            wallReply.Text = response["text"];
            wallReply.Likes = response["likes"];
            wallReply.ReplyToUId = response["reply_to_uid"];
            wallReply.ReplyToCId = response["reply_to_cid"];

            return wallReply;
        }
    }
}
