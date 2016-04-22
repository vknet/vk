using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.edit
	/// </summary>
	public class GroupsEditParams
	{
		/// <summary>
		/// Параметры метода groups.edit
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public GroupsEditParams(bool gag = true)
		{
			GroupId = 0;
			Title = null;
			Description = null;
			ScreenName = null;
			Access = null;
			Website = null;
			Subject = null;
			Email = null;
			Phone = null;
			Rss = null;
			EventStartDate = null;
			EventFinishDate = null;
			EventGroupId = null;
			PublicCategory = null;
			PublicSubcategory = null;
			PublicDate = null;
			Wall = null;
			Topics = null;
			Photos = null;
			Video = null;
			Audio = null;
			Links = null;
			Events = null;
			Places = null;
			Contacts = null;
			Docs = null;
			Wiki = null;
			Messages = null;
			AgeLimits = null;
			Market = null;
			MarketComments = null;
			MarketCountry = null;
			MarketCity = null;
			MarketCurrency = null;
			MarketContact = null;
			MarketWiki = null;
			ObsceneFilter = null;
			ObsceneStopwords = null;
			ObsceneWords = null;
		}


		/// <summary>
		/// Идентификатор сообщества. положительное число, обязательный параметр.
		/// </summary>
		public ulong GroupId { get; set; }

		/// <summary>
		/// Название сообщества. строка.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Описание сообщества. строка.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Короткое имя сообщества. строка.
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Тип группы.
		/// </summary>
		public GroupAccess? Access { get; set; }

		/// <summary>
		/// Адрес сайта, который будет указан в информации о группе. строка.
		/// </summary>
		public string Website { get; set; }

		/// <summary>
		/// Тематика сообщества. строка.
		/// </summary>
		public GroupSubjects? Subject { get; set; }

		/// <summary>
		/// Электронный адрес организатора (для мероприятий). строка.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Номер телефона организатора (для мероприятий). строка.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Адрес rss для импорта новостей (доступен только группам, получившим соответствующее разрешение, обратитесь в http://vk.com/support для получения разрешения). строка.
		/// </summary>
		public string Rss { get; set; }

		/// <summary>
		/// Дата начала события. положительное число.
		/// </summary>
		public ulong? EventStartDate { get; set; }

		/// <summary>
		/// Дата окончания события. положительное число.
		/// </summary>
		public ulong? EventFinishDate { get; set; }

		/// <summary>
		/// Идентификатор группы, которая является организатором события (только для событий). положительное число.
		/// </summary>
		public ulong? EventGroupId { get; set; }

		/// <summary>
		/// Категория публичной страницы. положительное число.
		/// </summary>
		public ulong? PublicCategory { get; set; }

		/// <summary>
		/// Подкатегория публичной станицы. положительное число.
		/// </summary>
		public ulong? PublicSubcategory { get; set; }

		/// <summary>
		/// Дата основания компании, организации, которой посвящена публичная страница в виде строки формата "dd.mm.YYYY". строка.
		/// </summary>
		public string PublicDate { get; set; }

		/// <summary>
		/// Стена.
		/// </summary>
		public WallContentAccess? Wall { get; set; }

		/// <summary>
		/// Обсуждения.
		/// </summary>
		public ContentAccess? Topics { get; set; }

		/// <summary>
		/// Фотографии.
		/// </summary>
		public ContentAccess? Photos { get; set; }

		/// <summary>
		/// Видеозаписи.
		/// </summary>
		public ContentAccess? Video { get; set; }

		/// <summary>
		/// Аудиозаписи.
		/// </summary>
		public ContentAccess? Audio { get; set; }

		/// <summary>
		/// Ссылки (доступно только для публичных страниц).
		/// </summary>
		public bool? Links { get; set; }

		/// <summary>
		/// События (доступно только для публичных страниц).
		/// </summary>
		public bool? Events { get; set; }

		/// <summary>
		/// Места (доступно только для публичных страниц).
		/// </summary>
		public bool? Places { get; set; }

		/// <summary>
		/// Контакты (доступно только для публичных страниц).
		/// </summary>
		public bool? Contacts { get; set; }

		/// <summary>
		/// Документы сообщества.
		/// </summary>
		public ContentAccess? Docs { get; set; }

		/// <summary>
		/// Wiki-материалы сообщества.
		/// </summary>
		public ContentAccess? Wiki { get; set; }

		/// <summary>
		/// Сообщения сообщества.
		/// </summary>
		public bool? Messages { get; set; }

		/// <summary>
		/// Возрастное ограничение для сообщества. положительное число, по умолчанию 1.
		/// </summary>
		public ulong? AgeLimits { get; set; }

		/// <summary>
		/// Товары.
		/// </summary>
		public bool? Market { get; set; }

		/// <summary>
		/// Комментарии к товарам.
		/// </summary>
		public bool? MarketComments { get; set; }

		/// <summary>
		/// Регионы доставки товаров. список положительных чисел, разделенных запятыми.
		/// </summary>
		public IEnumerable<ulong> MarketCountry { get; set; }

		/// <summary>
		/// Города доставки товаров (в случае если указана одна страна). список положительных чисел, разделенных запятыми.
		/// </summary>
		public IEnumerable<ulong> MarketCity { get; set; }

		/// <summary>
		/// Идентификатор валюты магазина.
		/// </summary>
		public MarketCurrencyId? MarketCurrency { get; set; }

		/// <summary>
		/// Контакт для связи для продавцом.
		/// Для использования сообщений сообщества следует включить их и передать значение 0. положительное число.
		/// </summary>
		public ulong? MarketContact { get; set; }

		/// <summary>
		/// Идентификатор wiki-страницы с описанием магазина. положительное число.
		/// </summary>
		public ulong? MarketWiki { get; set; }

		/// <summary>
		/// Фильтр нецензурных выражений в комментариях.
		/// </summary>
		public bool? ObsceneFilter { get; set; }

		/// <summary>
		/// Фильтр по ключевым словам в комментариях.
		/// </summary>
		public bool? ObsceneStopwords { get; set; }

		/// <summary>
		/// Ключевые слова для фильтра комментариев. список слов, разделенных через запятую.
		/// </summary>
		public IEnumerable<string> ObsceneWords { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns>Объект типа <see cref="GroupsEditParams"/></returns>
		internal static VkParameters ToVkParameters(GroupsEditParams p)
		{
			var result = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "title", p.Title },
				{ "description", p.Description },
				{ "screen_name", p.ScreenName },
				{ "access", p.Access },
				{ "website", p.Website },
				{ "subject", p.Subject },
				{ "email", p.Email },
				{ "phone", p.Phone },
				{ "rss", p.Rss },
				{ "event_start_date", p.EventStartDate },
				{ "event_finish_date", p.EventFinishDate },
				{ "event_group_id", p.EventGroupId },
				{ "public_category", p.PublicCategory },
				{ "public_subcategory", p.PublicSubcategory },
				{ "public_date", p.PublicDate },
				{ "wall", p.Wall },
				{ "topics", p.Topics },
				{ "photos", p.Photos },
				{ "video", p.Video },
				{ "audio", p.Audio },
				{ "links", p.Links },
				{ "events", p.Events },
				{ "places", p.Places },
				{ "contacts", p.Contacts },
				{ "docs", p.Docs },
				{ "wiki", p.Wiki },
				{ "messages", p.Messages },
				{ "age_limits", p.AgeLimits },
				{ "market", p.Market },
				{ "market_comments", p.MarketComments },
				{ "market_country", p.MarketCountry },
				{ "market_city", p.MarketCity },
				{ "market_currency", p.MarketCurrency },
				{ "market_contact", p.MarketContact },
				{ "market_wiki", p.MarketWiki },
				{ "obscene_filter", p.ObsceneFilter },
				{ "obscene_stopwords", p.ObsceneStopwords },
				{ "obscene_words", p.ObsceneWords }
			};

			return result;
		}

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        internal static GroupsEditParams FromJson(VkResponse response)
        {
            var marketCountry = (VkResponseArray) response["market_country"];
            var marketCity = (VkResponseArray) response["market_city"];
            var result = new GroupsEditParams
            {
                GroupId = response["group_id"] ?? 0UL,
                Title = response["title"],
                Description = response["description"],
                ScreenName = response["screen_name"],
                Access = response["access"],
                Website = response["website"],
                Subject = response["seubject"],
                Email = response["email"],
                Phone = response["phone"],
                Rss = response["rss"],
                EventStartDate = response["event_start_date"],
                EventFinishDate = response["event_finish_date"],
                EventGroupId = response["event_group_id"],
                PublicCategory = response["public_category"],
                PublicSubcategory = response["public_subcategory"],
                PublicDate = response["public_date"],
                Wall = response["wall"],
                Topics = response["topics"],
                Photos = response["photos"],
                Video = response["video"],
                Audio = response["audio"],
                Links = response["links"],
                Events = response["events"],
                Places = response["places"],
                Contacts = response["contacts"],
                Docs = response["docs"],
                Wiki = response["wiki"],
                Messages = response["messages"],
                AgeLimits = response["age_limits"],
                Market = response["market"],
                MarketComments = response["market_comments"],
                MarketCountry = marketCountry.ToCollectionOf<ulong>(o => o),
                MarketCity = marketCity.ToCollectionOf<ulong>(o => o),
                MarketCurrency = response["market_currency"],
                MarketContact = response["market_contact"],
                MarketWiki = response["market_wiki"],
                ObsceneFilter = response["obscene_filter"],
                ObsceneStopwords = response["obscene_stopwords"],
                ObsceneWords = response["obscene_words"].ToReadOnlyCollectionOf<string>(o => o)
            };

            return result;
        }
    }
}