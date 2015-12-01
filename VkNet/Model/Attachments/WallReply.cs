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
			var wallReply = new WallReply
			{
				Id = response["id"],
				FromId = response["from_id"],
				Date = response["date"],
				Text = response["text"],
				Likes = response["likes"],
				ReplyToUId = response["reply_to_uid"],
				ReplyToCId = response["reply_to_cid"]
			};

			return wallReply;
		}
	}
}
