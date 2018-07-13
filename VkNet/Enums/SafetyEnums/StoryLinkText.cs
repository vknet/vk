using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Текст ссылки для перехода из истории (только для историй сообществ). 
	/// </summary>
	[Serializable]
	public sealed class StoryLinkText : SafetyEnum<StoryLinkText>
	{
		/// <summary>
		/// В магазин
		/// </summary>
		public static readonly StoryLinkText ToStore = RegisterPossibleValue(value: "to_store");
		/// <summary>
		/// Голосовать
		/// </summary>
		public static readonly StoryLinkText Vote = RegisterPossibleValue(value: "vote");
		/// <summary>
		/// Ещё
		/// </summary>
		public static readonly StoryLinkText More = RegisterPossibleValue(value: "more");
		/// <summary>
		/// Забронировать
		/// </summary>
		public static readonly StoryLinkText Book = RegisterPossibleValue(value: "book");
		/// <summary>
		/// Заказать
		/// </summary>
		public static readonly StoryLinkText Order = RegisterPossibleValue(value: "order");
		/// <summary>
		/// Записаться
		/// </summary>
		public static readonly StoryLinkText Enroll = RegisterPossibleValue(value: "enroll");
		/// <summary>
		/// Заполнить
		/// </summary>
		public static readonly StoryLinkText Fill = RegisterPossibleValue(value: "fill");
		/// <summary>
		/// Зарегистрироваться
		/// </summary>
		public static readonly StoryLinkText Signup = RegisterPossibleValue(value: "signup");
		/// <summary>
		/// Купить
		/// </summary>
		public static readonly StoryLinkText Buy = RegisterPossibleValue(value: "buy");
		/// <summary>
		/// Купить билет
		/// </summary>
		public static readonly StoryLinkText Ticket = RegisterPossibleValue(value: "ticket");
		/// <summary>
		/// Написать
		/// </summary>
		public static readonly StoryLinkText Write = RegisterPossibleValue(value: "write");
		/// <summary>
		/// Открыть
		/// </summary>
		public static readonly StoryLinkText Open = RegisterPossibleValue(value: "open");
		/// <summary>
		/// Подробнее
		/// </summary>
		[DefaultValue]
		public static readonly StoryLinkText LearnMore = RegisterPossibleValue(value: "learn_more");
		/// <summary>
		/// Посмотреть
		/// </summary>
		public static readonly StoryLinkText View = RegisterPossibleValue(value: "view");
		/// <summary>
		/// Перейти
		/// </summary>
		public static readonly StoryLinkText GoTo = RegisterPossibleValue(value: "go_to");
		/// <summary>
		/// Связаться
		/// </summary>
		public static readonly StoryLinkText Contact = RegisterPossibleValue(value: "contact");
		/// <summary>
		/// Смотреть
		/// </summary>
		public static readonly StoryLinkText Watch = RegisterPossibleValue(value: "watch");
		/// <summary>
		/// Слушать
		/// </summary>
		public static readonly StoryLinkText Play = RegisterPossibleValue(value: "play");
		/// <summary>
		/// Установить
		/// </summary>
		public static readonly StoryLinkText Install = RegisterPossibleValue(value: "install");
		/// <summary>
		/// Читать
		/// </summary>
		public static readonly StoryLinkText Read = RegisterPossibleValue(value: "read");
	}
}
