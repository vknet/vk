using System;
using VkNet.Utils;
using VkNet.UWP.Model.Attachments;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация о медиавложении в записи.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[Serializable]
	public class Attachment
	{
		/// <summary>
		/// Экземпляр самого прикрепления.
		/// </summary>
		public MediaAttachment Instance { get; private set; }

		/// <summary>
		/// Информация о типе вложения.
		/// </summary>
		public Type Type { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Attachment FromJson(VkResponse response)
		{
			string type = response["type"];

			return type switch
			{
				"photo" or "posted_photo" => CreateTyped<Photo>(response[type]),
				"audio" => CreateTyped<Audio>(response[type]),
				"video" => CreateTyped<Video>(response[type]),
				"doc" => CreateTyped<Document>(response[type]),
				"podcast" => CreateTyped<Podcast>(response[type]),
				"article" => CreateTyped<Article>(response[type]),
				"event" => CreateTyped<Event>(response[type]),
				"graffiti" => CreateTyped<Graffiti>(response[type]),
				"money_transfer" => CreateTyped<MoneyTransfer>(response[type]),
				"money_request" => CreateTyped<MoneyRequest>(response[type]),
				"note" => CreateTyped<Note>(response[type]),
				"poll" => CreateTyped<Poll>(response[type]),
				"page" => CreateTyped<Page>(response[type]),
				"album" => CreateTyped<Album>(response[type]),
				"photos_list" => CreateTyped<PhotosList>(response[type]),
				"wall" => CreateTyped<Wall>(response[type]),
				"sticker" => CreateTyped<Sticker>(response[type]),
				"wall_reply" => CreateTyped<WallReply>(response[type]),
				"market_album" => CreateTyped<MarketAlbum>(response[type]),
				"market" => CreateTyped<Market>(response[type]),
				"pretty_cards" => CreateTyped<PrettyCards>(response[type]),
				"audio_message" => CreateTyped<AudioMessage>(response[type]),
				"call" => CreateTyped<Call>(response[type]),
				"story" => CreateTyped<Story>(response[type]),
				"audio_playlist" => CreateTyped<AudioPlaylist>(response[type]),
				var _ => CreateTyped<UnknownAttachment>(response[type])
			};
		}

	#endregion

		/// <inheritdoc />
		public override string ToString()
		{
			return Type.Name;
		}

	#region Приватные методы

		private static Attachment CreateTyped<TAttachment>(TAttachment instance)
			where TAttachment : MediaAttachment
		{
			var attachment = new Attachment
			{
				Type = typeof(TAttachment),
				Instance = instance
			};

			return attachment;
		}

	#endregion
	}
}