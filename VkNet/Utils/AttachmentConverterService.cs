using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils
{
    /// <summary>
    /// Сервис для обработки вложений
    /// </summary>
    public class AttachmentConverterService
	{
		/// <summary>
		/// Инстанция сервиса.
		/// Может быть переопределена кастомной реализацией
		/// </summary>
		public static AttachmentConverterService Instance { get; set; } = new AttachmentConverterService();

		/// <summary>
		/// Десериализация из json
		/// </summary>
		public virtual Attachment FromJson(JToken item)
		{
			var type = item["type"].ToString();

			var typeToken = item[type];

			var attachment = type switch
			{
				"link" => CreateTyped(typeToken
					.ToObject<Link>()),
				"photo" or "posted_photo" => CreateTyped(typeToken
					.ToObject<Photo>()),
				"audio" => CreateTyped(typeToken
					.ToObject<Audio>()),
				"video" => CreateTyped(typeToken
					.ToObject<Video>()),
				"doc" => CreateTyped(typeToken
					.ToObject<Document>()),
				"podcast" => CreateTyped(typeToken
					.ToObject<Podcast>()),
				"article" => CreateTyped(typeToken
					.ToObject<Article>()),
				"event" => CreateTyped(typeToken
					.ToObject<Event>()),
				"graffiti" => CreateTyped(typeToken
					.ToObject<Graffiti>()),
				"money_transfer" => CreateTyped(typeToken
					.ToObject<MoneyTransfer>()),
				"money_request" => CreateTyped(typeToken
					.ToObject<MoneyRequest>()),
				"note" => CreateTyped(typeToken
					.ToObject<Note>()),
				"poll" => CreateTyped(typeToken
					.ToObject<Poll>()),
				"page" => CreateTyped(typeToken
					.ToObject<Page>()),
				"album" => CreateTyped(typeToken
					.ToObject<Album>()),
				"photos_list" => CreateTyped(typeToken
					.ToObject<PhotosList>()),
				"wall" => CreateTyped(typeToken
					.ToObject<Wall>()),
				"sticker" => CreateTyped(typeToken
					.ToObject<Sticker>()),
				"wall_reply" => CreateTyped(typeToken
					.ToObject<WallReply>()),
				"market_album" => CreateTyped(typeToken
					.ToObject<MarketAlbum>()),
				"market" => CreateTyped(typeToken
					.ToObject<Market>()),
				"pretty_cards" => CreateTyped(typeToken
					.ToObject<PrettyCards>()),
				"audio_message" => CreateTyped(typeToken
					.ToObject<AudioMessage>()),
				"call" => CreateTyped(typeToken
					.ToObject<Call>()),
				"story" => CreateTyped(typeToken
					.ToObject<Story>()),
				"audio_playlist" => CreateTyped(typeToken
					.ToObject<AudioPlaylist>()),
				var _ => CreateTyped(typeToken
					.ToObject<UnknownAttachment>())
			};

			return attachment;
		}

		/// <summary>
		/// Создает экземпляр Attachment
		/// </summary>
		protected virtual Attachment CreateTyped<TAttachment>(TAttachment instance)
			where TAttachment : MediaAttachment
		{
			var attachment = new Attachment
			{
				Type = typeof(TAttachment),
				Instance = instance
			};

			return attachment;
		}
	}
}