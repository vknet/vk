using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Текст ссылки для перехода из истории (только для историй сообществ).
/// </summary>
[Serializable]
public sealed class StoryLinkText : SafetyEnum<StoryLinkText>
{
	/// <summary>
	/// В магазин
	/// </summary>
	[EnumMember(Value = "to_store")]
	public static readonly StoryLinkText ToStore = RegisterPossibleValue(value: "to_store");

	/// <summary>
	/// Голосовать
	/// </summary>
	[EnumMember(Value = "vote")]
	public static readonly StoryLinkText Vote = RegisterPossibleValue(value: "vote");

	/// <summary>
	/// Ещё
	/// </summary>
	[EnumMember(Value = "more")]
	public static readonly StoryLinkText More = RegisterPossibleValue(value: "more");

	/// <summary>
	/// Забронировать
	/// </summary>
	[EnumMember(Value = "book")]
	public static readonly StoryLinkText Book = RegisterPossibleValue(value: "book");

	/// <summary>
	/// Заказать
	/// </summary>
	[EnumMember(Value = "order")]
	public static readonly StoryLinkText Order = RegisterPossibleValue(value: "order");

	/// <summary>
	/// Записаться
	/// </summary>
	[EnumMember(Value = "enroll")]
	public static readonly StoryLinkText Enroll = RegisterPossibleValue(value: "enroll");

	/// <summary>
	/// Заполнить
	/// </summary>
	[EnumMember(Value = "fill")]
	public static readonly StoryLinkText Fill = RegisterPossibleValue(value: "fill");

	/// <summary>
	/// Зарегистрироваться
	/// </summary>
	[EnumMember(Value = "signup")]
	public static readonly StoryLinkText Signup = RegisterPossibleValue(value: "signup");

	/// <summary>
	/// Купить
	/// </summary>
	[EnumMember(Value = "buy")]
	public static readonly StoryLinkText Buy = RegisterPossibleValue(value: "buy");

	/// <summary>
	/// Купить билет
	/// </summary>
	[EnumMember(Value = "ticket")]
	public static readonly StoryLinkText Ticket = RegisterPossibleValue(value: "ticket");

	/// <summary>
	/// Написать
	/// </summary>
	[EnumMember(Value = "write")]
	public static readonly StoryLinkText Write = RegisterPossibleValue(value: "write");

	/// <summary>
	/// Открыть
	/// </summary>
	[EnumMember(Value = "open")]
	public static readonly StoryLinkText Open = RegisterPossibleValue(value: "open");

	/// <summary>
	/// Подробнее
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "learn_more")]
	public static readonly StoryLinkText LearnMore = RegisterPossibleValue(value: "learn_more");

	/// <summary>
	/// Посмотреть
	/// </summary>
	[EnumMember(Value = "view")]
	public static readonly StoryLinkText View = RegisterPossibleValue(value: "view");

	/// <summary>
	/// Перейти
	/// </summary>
	[EnumMember(Value = "go_to")]
	public static readonly StoryLinkText GoTo = RegisterPossibleValue(value: "go_to");

	/// <summary>
	/// Связаться
	/// </summary>
	[EnumMember(Value = "contact")]
	public static readonly StoryLinkText Contact = RegisterPossibleValue(value: "contact");

	/// <summary>
	/// Смотреть
	/// </summary>
	[EnumMember(Value = "watch")]
	public static readonly StoryLinkText Watch = RegisterPossibleValue(value: "watch");

	/// <summary>
	/// Слушать
	/// </summary>
	[EnumMember(Value = "play")]
	public static readonly StoryLinkText Play = RegisterPossibleValue(value: "play");

	/// <summary>
	/// Установить
	/// </summary>
	[EnumMember(Value = "install")]
	public static readonly StoryLinkText Install = RegisterPossibleValue(value: "install");

	/// <summary>
	/// Читать
	/// </summary>
	[EnumMember(Value = "read")]
	public static readonly StoryLinkText Read = RegisterPossibleValue(value: "read");
}