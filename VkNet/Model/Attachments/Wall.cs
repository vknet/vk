namespace VkNet.Model.Attachments
{
    using System;
    using System.Collections.ObjectModel;

    using Utils;

	/// <summary>
	/// Запись на стене.
	/// </summary>
	public class Wall : MediaAttachment
    {
		/// <summary>
		/// Запись на стене.
		/// </summary>
		static Wall()
        {
            RegisterType(typeof(Wall), "wall");
        }

		/// <summary>
		/// Идентификатор пользователя, создавшего запись;
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Идентификатор владельца записи.
		/// </summary>
		public long? ToId { get; set; }

		/// <summary>
		/// Время публикации записи в формате unixtime.
		/// </summary>
		public DateTime? Date { get; set; }

#warning post_type must not be string
        public string PostType { get; set; }

		/// <summary>
		/// Текст записи.
		/// </summary>
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

		/// <summary>
		/// Информация о том, как была создана запись.
		/// </summary>
		public PostSource PostSource { get; set; }

        /// <summary>
        /// Информация о вложениях записи (фотографии ссылки и т.п.).
        /// </summary>
        public Collection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Информация о месте (если доступно).
		/// </summary>
		public Geo Geo { get; set; }

		/// <summary>
		/// Если запись была опубликована от имени группы и подписана пользователем, то в поле содержится идентификатор её автора
		/// </summary>
		public long? SignerId { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в поле содержится идентификатор владельца стены, у которого была скопирована запись.
		/// </summary>
		public long? CopyOwnerId { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в поле содержится идентификатор скопированной записи на стене ее владельца.
		/// </summary>
		public long? CopyPostId { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены и при её копировании был добавлен комментарий, его текст содержится в данном поле.
		/// </summary>
		public string CopyText { get; set; }

		internal static Wall FromJson(VkResponse response)
		{
			var wall = new Wall
			{
				Id = response["id"],
				FromId = response["from_id"],
				ToId = response["to_id"],
				Date = response["date"],
				PostType = response["post_type"],
				Text = response["text"],

				Attachments = response["attachments"],
				Comments = response["comments"],
				Likes = response["likes"],
				Reposts = response["reposts"],
				PostSource = response["post_source"],
				Geo = response["geo"],
				SignerId = response["signer_id"],
				CopyOwnerId = response["copy_owner_id "],
				CopyPostId = response["copy_post_id"],
				CopyText = response["copy_text"]
			};

			return wall;
		}
	}
}