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
		public MediaAttachment Instance
		{
			get
			{
				if (Type == typeof(Photo))
				{
					return Photo;
				}

				if (Type == typeof(Video))
				{
					return Video;
				}

				if (Type == typeof(Audio))
				{
					return Audio;
				}

				if (Type == typeof(AudioMessage))
				{
					return AudioMessage;
				}

				if (Type == typeof(Document))
				{
					return Document;
				}

				if (Type == typeof(Article))
				{
					return Article;
				}

				if (Type == typeof(Podcast))
				{
					return Podcast;
				}

				if (Type == typeof(Graffiti))
				{
					return Graffiti;
				}

				if (Type == typeof(Link))
				{
					return Link;
				}

				if (Type == typeof(Note))
				{
					return Note;
				}

				if (Type == typeof(ApplicationContent))
				{
					return ApplicationContent;
				}

				if (Type == typeof(Poll))
				{
					return Poll;
				}

				if (Type == typeof(Page))
				{
					return Page;
				}

				if (Type == typeof(Album))
				{
					return Album;
				}

				if (Type == typeof(PhotosList))
				{
					return PhotosList;
				}

				if (Type == typeof(Post))
				{
					return WallPost;
				}

				if (Type == typeof(Wall))
				{
					return Wall;
				}

				if (Type == typeof(Sticker))
				{
					return Sticker;
				}

				if (Type == typeof(Gift))
				{
					return Gift;
				}

				if (Type == typeof(WallReply))
				{
					return WallReply;
				}

				if (Type == typeof(MarketAlbum))
				{
					return MarketAlbum;
				}

				if (Type == typeof(Market))
				{
					return Market;
				}

				if (Type == typeof(PrettyCards))
				{
					return PrettyCards;
				}

				if (Type == typeof(Call))
				{
					return Call;
				}

				if (Type == typeof(Story))
				{
					return Story;
				}

				if (Type == typeof(AudioPlaylist))
				{
					return AudioPlaylist;
				}

				if (Type == typeof(MoneyTransfer))
				{
					return MoneyTransfer;
				}

				if (Type == typeof(MoneyRequest))
				{
					return MoneyRequest;
				}

				if (Type == typeof(Event))
				{
					return Event;
				}

				return UnknownAttachment;
			}
		}

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
			var attachment = new Attachment();

			string type = response["type"];

			switch (type)
			{
				case "photo":
				case "posted_photo":

				{
					attachment.Type = typeof(Photo);
					attachment.Photo = response[type];

					break;
				}

				case "video":

				{
					attachment.Type = typeof(Video);
					attachment.Video = response["video"];

					break;
				}

				case "audio":

				{
					attachment.Type = typeof(Audio);
					attachment.Audio = response["audio"];

					break;
				}

				case "doc":

				{
					attachment.Type = typeof(Document);
					attachment.Document = response["doc"];

					break;
				}

				case "podcast":

				{
					attachment.Type = typeof(Podcast);
					attachment.Podcast = response["podcast"];

					break;
				}

				case "article":

				{
					attachment.Type = typeof(Article);
					attachment.Article = response[type];

					break;
				}

				case "event":

				{
					attachment.Type = typeof(Event);
					attachment.Event = response[type];

					break;
				}

				case "graffiti":

				{
					attachment.Type = typeof(Graffiti);
					attachment.Graffiti = response["graffiti"];

					break;
				}

				case "link":

				{
					attachment.Type = typeof(Link);
					attachment.Link = response["link"];

					break;
				}

				case "money_transfer":

				{
					attachment.Type = typeof(MoneyTransfer);
					attachment.MoneyTransfer = response["money_transfer"];

					break;
				}

				case "money_request":

				{
					attachment.Type = typeof(MoneyRequest);
					attachment.MoneyRequest = response[type];

					break;
				}

				case "note":

				{
					attachment.Type = typeof(Note);
					attachment.Note = response["note"];

					break;
				}

				case "app":

				{
					attachment.Type = typeof(ApplicationContent);
					attachment.ApplicationContent = response["app"];

					break;
				}

				case "poll":

				{
					attachment.Type = typeof(Poll);
					attachment.Poll = response["poll"];

					break;
				}

				case "page":

				{
					attachment.Type = typeof(Page);
					attachment.Page = response["page"];

					break;
				}

				case "album":

				{
					attachment.Type = typeof(Album);
					attachment.Album = response["album"];

					break;
				}

				case "photos_list":

				{
					attachment.Type = typeof(PhotosList);
					attachment.PhotosList = response["photos_list"];

					break;
				}

				case "wall":

				{
					attachment.Type = typeof(Wall);
					attachment.Wall = response["wall"];

					break;
				}

				case "sticker":

				{
					attachment.Type = typeof(Sticker);
					attachment.Sticker = response["sticker"];

					break;
				}

				case "gift":

				{
					attachment.Type = typeof(Gift);
					attachment.Gift = response["gift"];

					break;
				}

				case "wall_reply":

				{
					attachment.Type = typeof(WallReply);
					attachment.WallReply = response["wall_reply"];

					break;
				}

				case "market_album":

				{
					attachment.Type = typeof(MarketAlbum);
					attachment.MarketAlbum = response["market_album"];

					break;
				}

				case "market":

				{
					attachment.Type = typeof(Market);
					attachment.Market = response["market"];

					break;
				}

				case "pretty_cards":

				{
					attachment.Type = typeof(PrettyCards);
					attachment.PrettyCards = response["pretty_cards"];

					break;
				}

				case "audio_message":

				{
					attachment.Type = typeof(AudioMessage);
					attachment.AudioMessage = response["audio_message"];

					break;
				}

				case "call":

				{
					attachment.Type = typeof(Call);
					attachment.Call = response["call"];

					break;
				}

				case "story":

				{
					attachment.Type = typeof(Story);
					attachment.Story = response["story"];

					break;
				}

				case "audio_playlist":

				{
					attachment.Type = typeof(AudioPlaylist);
					attachment.AudioPlaylist = response[type];

					break;
				}

				default:

				{
					attachment.Type = typeof(UnknownAttachment);
					attachment.UnknownAttachment = response[type];

					break;
				}
			}

			return attachment;
		}

	#endregion

		public override string ToString()
		{
			return $"{Type.Name}";
		}

	#region Поля

		/// <summary>
		/// Фотография из альбома или фотография, загруженная напрямую с компьютера
		/// пользователя.
		/// </summary>
		private Photo Photo { get; set; }

		/// <summary>
		/// Видеозапись.
		/// </summary>
		private Video Video { get; set; }

		/// <summary>
		/// Аудиозапись.
		/// </summary>
		private Audio Audio { get; set; }

		/// <summary>
		/// Документ.
		/// </summary>
		private Document Document { get; set; }

		/// <summary>
		/// Подкаст.
		/// </summary>
		private Podcast Podcast { get; set; }

		/// <summary>
		/// Граффити.
		/// </summary>
		private Graffiti Graffiti { get; set; }

		/// <summary>
		/// Ссылка на Web-страницу.
		/// </summary>
		private Link Link { get; set; }

		/// <summary>
		/// Заметка.
		/// </summary>
		private Note Note { get; set; }

		/// <summary>
		/// Контент приложения.
		/// </summary>
		private ApplicationContent ApplicationContent { get; set; }

		/// <summary>
		/// Опрос.
		/// </summary>
		private Poll Poll { get; set; }

		/// <summary>
		/// Wiki страница.
		/// </summary>
		private Page Page { get; set; }

		/// <summary>
		/// Альбом с фотографиями.
		/// </summary>
		private Album Album { get; set; }

		/// <summary>
		/// Список фотографий
		/// </summary>
		private PhotosList PhotosList { get; set; }

		/// <summary>
		/// Запись на стене.
		/// </summary>
		private Post WallPost { get; set; }

		/// <summary>
		/// Запись на стене.
		/// </summary>
		private Wall Wall { get; set; }

		/// <summary>
		/// Стикер.
		/// </summary>
		private Sticker Sticker { get; set; }

		/// <summary>
		/// Подарок.
		/// </summary>
		private Gift Gift { get; set; }

		/// <summary>
		/// Комментарии к записи на стене.
		/// </summary>
		private WallReply WallReply { get; set; }

		/// <summary>
		/// Каталог товаров.
		/// </summary>
		private MarketAlbum MarketAlbum { get; set; }

		/// <summary>
		/// Товар.
		/// </summary>
		private Market Market { get; set; }

		/// <summary>
		/// </summary>
		private PrettyCards PrettyCards { get; set; }

		/// <summary>
		/// Аудио сообщение
		/// </summary>
		private AudioMessage AudioMessage { get; set; }

		/// <summary>
		/// Статья
		/// </summary>
		private Article Article { get; set; }

		/// <summary>
		/// Звонок.
		/// </summary>
		private Call Call { get; set; }

		/// <summary>
		/// История.
		/// </summary>
		private Story Story { get; set; }

		/// <summary>
		/// Плейлист.
		/// </summary>
		private AudioPlaylist AudioPlaylist { get; set; }

		/// <summary>
		/// Неизвестное вложение.
		/// </summary>
		private UnknownAttachment UnknownAttachment { get; set; }

		/// <summary>
		/// Перевод денег.
		/// </summary>
		private MoneyTransfer MoneyTransfer { get; set; }

		/// <summary>
		/// Выставление счета
		/// </summary>
		private MoneyRequest MoneyRequest { get; set; }

		/// <summary>
		/// Встреча
		/// </summary>
		private Event Event { get; set; }

	#endregion
	}
}