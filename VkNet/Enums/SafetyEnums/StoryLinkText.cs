using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Текст ссылки для перехода из истории (только для историй сообществ).
/// </summary>.ToSnakeCase()
public enum StoryLinkText
{
	/// <summary>
	/// В магазин
	/// </summary>
	ToStore,

	/// <summary>
	/// Голосовать
	/// </summary>
	Vote,

	/// <summary>
	/// Ещё
	/// </summary>
	More,

	/// <summary>
	/// Забронировать
	/// </summary>
	Book,

	/// <summary>
	/// Заказать
	/// </summary>
	Order,

	/// <summary>
	/// Записаться
	/// </summary>
	Enroll,

	/// <summary>
	/// Заполнить
	/// </summary>
	Fill,

	/// <summary>
	/// Зарегистрироваться
	/// </summary>
	Signup,

	/// <summary>
	/// Купить
	/// </summary>
	Buy,

	/// <summary>
	/// Купить билет
	/// </summary>
	Ticket,

	/// <summary>
	/// Написать
	/// </summary>
	Write,

	/// <summary>
	/// Открыть
	/// </summary>
	Open,

	/// <summary>
	/// Подробнее
	/// </summary>
	[DefaultValue]
	LearnMore,

	/// <summary>
	/// Посмотреть
	/// </summary>
	View,

	/// <summary>
	/// Перейти
	/// </summary>
	GoTo,

	/// <summary>
	/// Связаться
	/// </summary>
	Contact,

	/// <summary>
	/// Смотреть
	/// </summary>
	Watch,

	/// <summary>
	/// Слушать
	/// </summary>
	Play,

	/// <summary>
	/// Установить
	/// </summary>
	Install,

	/// <summary>
	/// Читать
	/// </summary>
	Read
}