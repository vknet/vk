using System;
using VkNet.Exception;
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
		public object Instance
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

				if (Type == typeof(Document))
				{
					return Document;
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

				return null;
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

			string type = response[key: "type"];

			switch (type)
			{
				case "photo":
				case "posted_photo":

				{
					attachment.Type = typeof(Photo);
					attachment.Photo = response[key: type];

					break;
				}
				case "video":

				{
					attachment.Type = typeof(Video);
					attachment.Video = response[key: "video"];

					break;
				}
				case "audio":

				{
					attachment.Type = typeof(Audio);
					attachment.Audio = response[key: "audio"];

					break;
				}
				case "doc":

				{
					attachment.Type = typeof(Document);
					attachment.Document = response[key: "doc"];

					break;
				}
				case "graffiti":

				{
					attachment.Type = typeof(Graffiti);
					attachment.Graffiti = response[key: "graffiti"];

					break;
				}
				case "link":

				{
					attachment.Type = typeof(Link);
					attachment.Link = response[key: "link"];

					break;
				}
				case "note":

				{
					attachment.Type = typeof(Note);
					attachment.Note = response[key: "note"];

					break;
				}
				case "app":

				{
					attachment.Type = typeof(ApplicationContent);
					attachment.ApplicationContent = response[key: "app"];

					break;
				}
				case "poll":

				{
					attachment.Type = typeof(Poll);
					attachment.Poll = response[key: "poll"];

					break;
				}
				case "page":

				{
					attachment.Type = typeof(Page);
					attachment.Page = response[key: "page"];

					break;
				}
				case "album":

				{
					attachment.Type = typeof(Album);
					attachment.Album = response[key: "album"];

					break;
				}
				case "photos_list":

				{
					attachment.Type = typeof(PhotosList);
					attachment.PhotosList = response[key: "photos_list"];

					break;
				}
				case "wall":

				{
					attachment.Type = typeof(Post);
					attachment.Wall = response[key: "wall"];

					break;
				}
				case "sticker":

				{
					attachment.Type = typeof(Sticker);
					attachment.Sticker = response[key: "sticker"];

					break;
				}
				case "gift":

				{
					attachment.Type = typeof(Gift);
					attachment.Gift = response[key: "gift"];

					break;
				}
				case "wall_reply":

				{
					attachment.Type = typeof(WallReply);
					attachment.WallReply = response[key: "wall_reply"];

					break;
				}
				case "market_album":

				{
					attachment.Type = typeof(MarketAlbum);
					attachment.MarketAlbum = response[key: "market_album"];

					break;
				}
				case "market":

				{
					attachment.Type = typeof(Market);
					attachment.Market = response[key: "market"];

					break;
				}
				case "pretty_cards":

				{
					attachment.Type = typeof(PrettyCards);
					attachment.PrettyCards = response[key: "pretty_cards"];

					break;
				}
				default:

				{
					throw new InvalidParameterException(message: string.Format(format: "The type '{0}' of attachment is not defined. {1}"
							, arg0: type
							, arg1: response[key: "date"]));
				}
			}

			return attachment;
		}

	#endregion

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
		/// Документ.
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
		private PhotosList PhotosList;

		/// <summary>
		/// Запись на стене.
		/// </summary>
		private Post Wall { get; set; }

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

	#endregion
	}
}