using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Кнопка для карусели
/// </summary>
public class Button : SafetyEnum<Button>
{
	/// <summary>
	/// Текст: Запустить
	/// Действие: Переход по ссылке
	/// Ссылка: Приложения и игры
	/// </summary>
	[EnumMember(Value = "app_join")]
	public static readonly Button AppJoin = RegisterPossibleValue(value: "app_join");

	/// <summary>
	/// Текст: Играть
	/// Действие: Переход по ссылке
	/// Ссылка: Игры
	/// </summary>
	[EnumMember(Value = "app_game_join")]
	public static readonly Button AppGameJoin = RegisterPossibleValue(value: "app_game_join");

	/// <summary>
	/// Текст: Перейти
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты, сообщества, приложения
	/// </summary>
	[EnumMember(Value = "open_url")]
	public static readonly Button OpenUrl = RegisterPossibleValue(value: "open_url");

	/// <summary>
	/// Текст: Открыть
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "open")]
	public static readonly Button Open = RegisterPossibleValue(value: "open");

	/// <summary>
	/// Текст: Позвонить
	/// Действие: Набор номера
	/// Ссылка: Телефонные номера
	/// </summary>
	[EnumMember(Value = "call")]
	public static readonly Button Call = RegisterPossibleValue(value: "call");

	/// <summary>
	/// Текст: Забронировать
	/// Действие: Набор номера
	/// Ссылка: Телефонные номера
	/// </summary>
	[EnumMember(Value = "book")]
	public static readonly Button Book = RegisterPossibleValue(value: "book");

	/// <summary>
	/// Текст: Записаться
	/// Действие: Переход по ссылке или набор номера
	/// Ссылка: Внешние сайты, телефонные номера
	/// </summary>
	[EnumMember(Value = "enroll")]
	public static readonly Button Enroll = RegisterPossibleValue(value: "enroll");

	/// <summary>
	/// Текст: Зарегистрироваться
	/// Действие: Набор номера
	/// Ссылка: Телефонные номера
	/// </summary>
	[EnumMember(Value = "register")]
	public static readonly Button Register = RegisterPossibleValue(value: "register");

	/// <summary>
	/// Текст: Купить
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "buy")]
	public static readonly Button Buy = RegisterPossibleValue(value: "buy");

	/// <summary>
	/// Текст: Купить билет
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "buy_ticket")]
	public static readonly Button BuyTicket = RegisterPossibleValue(value: "buy_ticket");

	/// <summary>
	/// Текст: В магазин
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "to_shop")]
	public static readonly Button ToShop = RegisterPossibleValue(value: "to_shop");

	/// <summary>
	/// Текст: Заказать
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "order")]
	public static readonly Button Order = RegisterPossibleValue(value: "order");

	/// <summary>
	/// Текст: Создать
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "create")]
	public static readonly Button Create = RegisterPossibleValue(value: "create");

	/// <summary>
	/// Текст: Установить
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "install")]
	public static readonly Button Install = RegisterPossibleValue(value: "install");

	/// <summary>
	/// Текст: Связаться
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "contact")]
	public static readonly Button Contact = RegisterPossibleValue(value: "contact");

	/// <summary>
	/// Текст: Заполнить
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "fill")]
	public static readonly Button Fill = RegisterPossibleValue(value: "fill");

	/// <summary>
	/// Текст: Выбрать
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "choose")]
	public static readonly Button Choose = RegisterPossibleValue(value: "choose");

	/// <summary>
	/// Текст: Попробовать
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "try")]
	public static readonly Button Try = RegisterPossibleValue(value: "try");

	/// <summary>
	/// Текст: Подписаться
	/// Действие: Подписка на публичную страницу
	/// Ссылка: Публичные страницы
	/// </summary>
	[EnumMember(Value = "join_public")]
	public static readonly Button JoinPublic = RegisterPossibleValue(value: "join_public");

	/// <summary>
	/// Текст: Я пойду
	/// Действие: Участие в мероприятии
	/// Ссылка: События
	/// </summary>
	[EnumMember(Value = "join_event")]
	public static readonly Button JoinEvent = RegisterPossibleValue(value: "join_event");

	/// <summary>
	/// Текст: Вступить
	/// Действие: Вступление в сообщество
	/// Ссылка: Сообщества
	/// </summary>
	[EnumMember(Value = "join_group")]
	public static readonly Button JoinGroup = RegisterPossibleValue(value: "join_group");

	/// <summary>
	/// Текст: Связаться
	/// Действие: Переход к диалогу с сообществом
	/// Ссылка: Сообщества, публичные страницы, события
	/// </summary>
	[EnumMember(Value = "im_group")]
	public static readonly Button ImGroup = RegisterPossibleValue(value: "im_group");

	/// <summary>
	/// Текст: Написать
	/// Действие: Переход к диалогу с сообществом
	/// Ссылка: Сообщества, публичные страницы, события
	/// </summary>
	[EnumMember(Value = "im_group2")]
	public static readonly Button ImGroup2 = RegisterPossibleValue(value: "im_group2");

	/// <summary>
	/// Текст: Начать
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "begin")]
	public static readonly Button Begin = RegisterPossibleValue(value: "begin");

	/// <summary>
	/// Текст: Получить
	/// Действие: Переход по ссылке
	/// Ссылка: Внешние сайты
	/// </summary>
	[EnumMember(Value = "get")]
	public static readonly Button Get = RegisterPossibleValue(value: "get");
}