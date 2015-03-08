namespace VkNet.Model.Attachments
{
    using System;
    using System.Collections.ObjectModel;

    using Utils;

    public class Wall : MediaAttachment
    {
        static Wall()
        {
            RegisterType(typeof(Wall), "wall");
        }

        public long? FromId { get; set; }

        public long? ToId { get; set; }

        public DateTime? Date { get; set; }

#warning post_type must not be string
        public string PostType { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public Comments Comments { get; set; }

        /// <summary>
        /// Лайки
        /// </summary>
        public Likes Likes { get; set; }

        /// <summary>
        /// Репосты
        /// </summary>
        public Reposts Reposts { get; set; }

        public PostSource PostSource { get; set; }

        /// <summary>
        /// Информация о вложениях записи (фотографии ссылки и т.п.).
        /// </summary>
        public Collection<Attachment> Attachments { get; set; }

#warning add properties to wall class, see MessagesCategoryTest.GetHistory_ContainsRepost_Error46 method.
        // TODO add properties, 

        internal static Wall FromJson(VkResponse response)
        {
            var wall = new Wall();

            wall.Id = response["id"];
            wall.FromId = response["from_id"];
            wall.ToId = response["to_id"];
            wall.Date = response["date"];
            wall.PostType = response["post_type"];
            wall.Text = response["text"];

            wall.Attachments = response["attachments"];
            wall.Comments = response["comments"];
            wall.Likes = response["likes"];
            wall.Reposts = response["reposts"];
            wall.PostSource = response["post_source"];

            return wall;
        }
    }
}