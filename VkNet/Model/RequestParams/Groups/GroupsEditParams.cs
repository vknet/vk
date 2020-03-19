using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.edit
	/// </summary>
	[Serializable]
	public class GroupsEditParams
	{
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
		/// Адрес rss для импорта новостей (доступен только группам, получившим
		/// соответствующее разрешение, обратитесь в
		/// http://vk.com/support для получения разрешения). строка.
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
		/// Идентификатор группы, которая является организатором события (только для
		/// событий). положительное число.
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
		/// Дата основания компании, организации, которой посвящена публичная страница в
		/// виде строки формата "dd.mm.YYYY".
		/// строка.
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
		public AgeLimit? AgeLimits { get; set; }

		/// <summary>
		/// Товары включены.
		/// </summary>
		public bool? MarketEnabled { get; set; }

		/// <summary>
		/// Комментарии к товарам включены.
		/// </summary>
		public bool? MarketCommentsEnabled { get; set; }

		/// <summary>
		/// Регионы доставки товаров. список положительных чисел, разделенных запятыми.
		/// </summary>
		public IEnumerable<ulong> MarketCountry { get; set; }

		/// <summary>
		/// Города доставки товаров (в случае если указана одна страна). список
		/// положительных чисел, разделенных запятыми.
		/// </summary>
		public IEnumerable<ulong> MarketCity { get; set; }

		/// <summary>
		/// Идентификатор валюты магазина.
		/// </summary>
		public MarketCurrencyId? MarketCurrency { get; set; }

		/// <summary>
		/// Контакт для связи для продавцом.
		/// Для использования сообщений сообщества следует включить их и передать значение
		/// 0. положительное число.
		/// </summary>
		public ulong? MarketContact { get; set; }

		/// <summary>
		/// Идентификатор wiki-страницы с описанием магазина. положительное число.
		/// </summary>
		[Obsolete("This property does not exist in API v5")]
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
		/// Ключевые слова для фильтра комментариев. список слов, разделенных через
		/// запятую.
		/// </summary>
		public IEnumerable<string> ObsceneWords { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("main_section")]
		public uint? MainSection { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("secondary_section")]
		public uint? SecondarySection { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("country")]
		public uint? Country { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("city")]
		public uint? City { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("articles")]
		public bool? Articles { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("addresses")]
		public bool? Addresses { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupsEditParams FromJson(VkResponse response)
		{
			var res = new GroupsEditParams();

			res.GroupId = response["group_id"] ?? 0UL;
			res.Title = response["title"];
			res.Description = response["description"];
			res.ScreenName = response["screen_name"];
			res.Access = response["access"];
			res.Website = response["website"];
			res.Subject = response["seubject"];
			res.Email = response["email"];
			res.Phone = response["phone"];
			res.Rss = response["rss"];
			res.EventStartDate = response["event_start_date"];
			res.EventFinishDate = response["event_finish_date"];
			res.EventGroupId = response["event_group_id"];
			res.PublicCategory = response["public_category"];
			res.PublicSubcategory = response["public_subcategory"];
			res.PublicDate = response["public_date"];
			res.Wall = response["wall"];
			res.Topics = response["topics"];
			res.Photos = response["photos"];
			res.Video = response["video"];
			res.Audio = response["audio"];
			res.Links = response["links"];
			res.Events = response["events"];
			res.Places = response["places"];
			res.Contacts = response["contacts"];
			res.Docs = response["docs"];
			res.Wiki = response["wiki"];
			res.Messages = response["messages"];
			res.AgeLimits = response["age_limits"];
			res.ObsceneFilter = response["obscene_filter"];
			res.ObsceneStopwords = response["obscene_stopwords"];
			res.ObsceneWords = response["obscene_words"].ToReadOnlyCollectionOf<string>(o => o);
			res.MainSection = response["main_section"];
			res.SecondarySection = response["secondary_section"];
			res.Articles = response["articles"];
			res.Addresses = response["addresses"];
			res.Country = response["country"];
			res.City = response["city"];

			#region Market
			var market = response["market"];
			if (market != null && market["enabled"] != null)
			{
				res.MarketEnabled = market["enabled"];
				res.MarketCommentsEnabled = market["comments_enabled"];
				res.MarketCountry = market["country_ids"].ToReadOnlyCollectionOf<ulong>(o => o);
				res.MarketCity = market["city_ids"].ToReadOnlyCollectionOf<ulong>(o => o);
				res.MarketContact = market["contact_id"];
				res.MarketCurrency = market["currency"];
			} else
			{
				// Older version
				res.MarketEnabled = response["market"];
				res.MarketCommentsEnabled = response["market_comments"];
				res.MarketCountry = response["market_country"].ToReadOnlyCollectionOf<ulong>(o => o);
				res.MarketCity = response["market_city"].ToReadOnlyCollectionOf<ulong>(o => o);
				res.MarketCurrency = response["market_currency"];
				res.MarketContact = response["market_contact"];
#pragma warning disable CS0618 // Тип или член устарел
				res.MarketWiki = response["market_wiki"];
#pragma warning restore CS0618 // Тип или член устарел
			}
			#endregion

			return res;
		}
	}
}