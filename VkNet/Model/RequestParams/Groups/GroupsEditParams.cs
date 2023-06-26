using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Параметры метода groups.edit
/// </summary>
[Serializable]
public class GroupsEditParams
{
	/// <summary>
	/// Название сообщества. строка.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Place
	/// </summary>
	[JsonProperty("place")]
	public Place Place { get; set; }

	/// <summary>
	/// MarketServices
	/// </summary>
	[JsonProperty("market_services")]
	public MarketServices MarketServices { get; set; }

	/// <summary>
	/// Описание сообщества. строка.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Короткий адрес.
	/// </summary>
	[JsonProperty("address")]
	public string Address { get; set; }

	/// <summary>
	/// Стена.
	/// </summary>
	[JsonProperty("wall")]
	public WallContentAccess? Wall { get; set; }

	/// <summary>
	/// Фотографии.
	/// </summary>
	[JsonProperty("photos")]
	public ContentAccess? Photos { get; set; }

	/// <summary>
	/// Видеозаписи.
	/// </summary>
	[JsonProperty("video")]
	public ContentAccess? Video { get; set; }

	/// <summary>
	/// Аудиозаписи.
	/// </summary>
	[JsonProperty("audio")]
	public ContentAccess? Audio { get; set; }

	/// <summary>
	/// Документы сообщества.
	/// </summary>
	[JsonProperty("docs")]
	public ContentAccess? Docs { get; set; }

	/// <summary>
	/// Обсуждения.
	/// </summary>
	[JsonProperty("topics")]
	public ContentAccess? Topics { get; set; }

	/// <summary>
	/// Wiki-материалы сообщества.
	/// </summary>
	[JsonProperty("wiki")]
	public ContentAccess? Wiki { get; set; }

	/// <summary>
	/// Сообщения сообщества.
	/// </summary>
	[JsonProperty("messages")]
	public bool? Messages { get; set; }

	/// <summary>
	/// Фильтр нецензурных выражений в комментариях.
	/// </summary>
	[JsonProperty("obscene_filter")]
	public bool? ObsceneFilter { get; set; }

	/// <summary>
	/// Фильтр по ключевым словам в комментариях.
	/// </summary>
	[JsonProperty("obscene_stopwords")]
	public bool? ObsceneStopwords { get; set; }

	/// <summary>
	/// Ключевые слова для фильтра комментариев. список слов, разделенных через
	/// запятую.
	/// </summary>
	[JsonProperty("obscene_words")]
	public IEnumerable<string> ObsceneWords { get; set; }

	/// <summary>
	/// Категория публичной страницы. положительное число.
	/// </summary>
	[JsonProperty("public_category")]
	public ulong? PublicCategory { get; set; }

	/// <summary>
	/// Подкатегория публичной станицы. положительное число.
	/// </summary>
	[JsonProperty("public_subcategory")]
	public ulong? PublicSubcategory { get; set; }

	/// <summary>
	/// Список возможных категорий для публичных страниц.
	/// </summary>
	[JsonProperty("public_category_list")]
	public ReadOnlyCollection<long> PublicCategoryList { get; set; }

	/// <summary>
	/// Тип группы.
	/// </summary>
	[JsonProperty("access")]
	public GroupAccess? Access { get; set; }

	/// <summary>
	/// Тематика сообщества. строка.
	/// </summary>
	[JsonProperty("subject")]
	public GroupSubjects? Subject { get; set; }

	/// <summary>
	/// Список возможных тематик.
	/// </summary>
	[JsonProperty("subject_list")]
	public IEnumerable<SubjectListItem> SubjectList { get; set; }

	/// <summary>
	/// Адрес rss для импорта новостей (доступен только группам, получившим
	/// соответствующее разрешение, обратитесь в
	/// http://vk.com/support для получения разрешения). строка.
	/// </summary>
	[JsonProperty("rss")]
	public string Rss { get; set; }

	/// <summary>
	/// Адрес сайта, который будет указан в информации о группе. строка.
	/// </summary>
	[JsonProperty("website")]
	public string Website { get; set; }

	/// <summary>
	/// Возрастное ограничение для сообщества. положительное число, по умолчанию 1.
	/// </summary>
	[JsonProperty("age_limits")]
	public AgeLimit? AgeLimits { get; set; }

	/// <summary>
	/// настройки блока товаров.
	/// </summary>
	[JsonProperty("market")]
	public GroupMarketSettings Market { get; set; }

	/// <summary>
	/// Идентификатор сообщества. положительное число, обязательный параметр.
	/// </summary>
	[JsonProperty("group_id")]
	public ulong GroupId { get; set; }

	/// <summary>
	/// Короткое имя сообщества. строка.
	/// </summary>
	[JsonProperty("screen_name")]
	public string ScreenName { get; set; }

	/// <summary>
	/// Электронный адрес организатора (для мероприятий). строка.
	/// </summary>
	[JsonProperty("email")]
	public string Email { get; set; }

	/// <summary>
	/// Номер телефона организатора (для мероприятий). строка.
	/// </summary>
	[JsonProperty("phone")]
	public string Phone { get; set; }

	/// <summary>
	/// Дата начала события. положительное число.
	/// </summary>
	[JsonProperty("event_start_date")]
	public ulong? EventStartDate { get; set; }

	/// <summary>
	/// Дата окончания события. положительное число.
	/// </summary>
	[JsonProperty("event_finish_date")]
	public ulong? EventFinishDate { get; set; }

	/// <summary>
	/// Идентификатор группы, которая является организатором события (только для
	/// событий). положительное число.
	/// </summary>
	[JsonProperty("event_group_id")]
	public ulong? EventGroupId { get; set; }

	/// <summary>
	/// Дата основания компании, организации, которой посвящена публичная страница в
	/// виде строки формата "dd.mm.YYYY".
	/// строка.
	/// </summary>
	[JsonProperty("public_date")]
	public string PublicDate { get; set; }

	/// <summary>
	/// Ссылки (доступно только для публичных страниц).
	/// </summary>
	[JsonProperty("links")]
	public bool? Links { get; set; }

	/// <summary>
	/// События (доступно только для публичных страниц).
	/// </summary>
	[JsonProperty("events")]
	public bool? Events { get; set; }

	/// <summary>
	/// Места (доступно только для публичных страниц).
	/// </summary>
	[JsonProperty("places")]
	public bool? Places { get; set; }

	/// <summary>
	/// Контакты (доступно только для публичных страниц).
	/// </summary>
	[JsonProperty("contacts")]
	public bool? Contacts { get; set; }

	/// <summary>
	/// Товары включены.
	/// </summary>
	[JsonProperty("market_enabled")]
	public bool? MarketEnabled { get; set; }

	/// <summary>
	/// Комментарии к товарам включены.
	/// </summary>
	[JsonProperty("market_comments_enabled")]
	public bool? MarketCommentsEnabled { get; set; }

	/// <summary>
	/// Регионы доставки товаров. список положительных чисел, разделенных запятыми.
	/// </summary>
	[JsonProperty("market_country")]
	public IEnumerable<ulong> MarketCountry { get; set; }

	/// <summary>
	/// Города доставки товаров (в случае если указана одна страна). список
	/// положительных чисел, разделенных запятыми.
	/// </summary>
	[JsonProperty("market_city")]
	public IEnumerable<ulong> MarketCity { get; set; }

	/// <summary>
	/// Идентификатор валюты магазина.
	/// </summary>
	[JsonProperty("market_currency")]
	public MarketCurrencyId? MarketCurrency { get; set; }

	/// <summary>
	/// Контакт для связи для продавцом.
	/// Для использования сообщений сообщества следует включить их и передать значение
	/// 0. положительное число.
	/// </summary>
	[JsonProperty("market_contact")]
	public ulong? MarketContact { get; set; }

	/// <summary>
	/// Идентификатор wiki-страницы с описанием магазина. положительное число.
	/// </summary>
	[Obsolete("This property does not exist in API v5")]
	public ulong? MarketWiki { get; set; }

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
}