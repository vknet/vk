using System;
using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Тип виджета приложения
/// </summary>
[Serializable]
public enum AppWidgetType
{
	/// <summary>
	/// Text - Выводит текст.
	/// </summary>
	[EnumMember(Value = "text")]
	Text,

	/// <summary>
	/// List - Выводит список объектов с описанием и
	/// кнопками для действий. Список может содержать
	/// до 6 объектов,
	/// если не указан сопроводительный текст (поле text),
	/// и до 3 объектов, если текст указан.
	/// </summary>
	[EnumMember(Value = "list")]
	List,

	/// <summary>
	/// Table - Выводит таблицу с данными.
	/// В первом столбце текст и ссылки могут
	/// сопровождаться иконками.
	/// Таблица может содержать от 1 до 6 столбцов
	/// и от 1 до 11 строк (включая строку с названиями колонок).
	/// </summary>
	[EnumMember(Value = "table")]
	Table,

	/// <summary>
	/// Tiles - Выводит плитки с изображением и кратким описанием.
	/// Количество плиток — от 3 до 10 для мобильных приложений,
	/// 3 для десктопной версии.
	/// </summary>
	[EnumMember(Value = "tiles")]
	Tiles,

	/// <summary>
	/// Compact List - Выводит список элементов в компактном виде.
	/// Аналогичен виджету List, за исключением того,
	/// что кнопка располагается справа.
	/// </summary>
	[EnumMember(Value = "compact_list")]
	CompactList,

	/// <summary>
	/// Cover List - Выводит список изображений (от 1 до 3)
	/// с кнопкой для действия, заголовком и описанием.
	/// </summary>
	[EnumMember(Value = "cover_list")]
	CoverList,

	/// <summary>
	/// Match - Выводит текущий результат спортивного матча.
	/// </summary>
	[EnumMember(Value = "match")]
	Match,

	/// <summary>
	/// Matches - Выводит список спортивных матчей.
	/// </summary>
	[EnumMember(Value = "matches")]
	Matches,

	/// <summary>
	/// Donation - Выводит прогресс пожертвований.
	/// </summary>
	[EnumMember(Value = "donation")]
	Donation
}