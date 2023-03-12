using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип виджета приложения
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AppWidgetType
{
	/// <summary>
	/// Text - Выводит текст.
	/// </summary>
	Text,

	/// <summary>
	/// List - Выводит список объектов с описанием и
	/// кнопками для действий. Список может содержать
	/// до 6 объектов,
	/// если не указан сопроводительный текст (поле text),
	/// и до 3 объектов, если текст указан.
	/// </summary>
	List,

	/// <summary>
	/// Table - Выводит таблицу с данными.
	/// В первом столбце текст и ссылки могут
	/// сопровождаться иконками.
	/// Таблица может содержать от 1 до 6 столбцов
	/// и от 1 до 11 строк (включая строку с названиями колонок).
	/// </summary>
	Table,

	/// <summary>
	/// Tiles - Выводит плитки с изображением и кратким описанием.
	/// Количество плиток — от 3 до 10 для мобильных приложений,
	/// 3 для десктопной версии.
	/// </summary>
	Tiles,

	/// <summary>
	/// Compact List - Выводит список элементов в компактном виде.
	/// Аналогичен виджету List, за исключением того,
	/// что кнопка располагается справа.
	/// </summary>
	CompactList,

	/// <summary>
	/// Cover List - Выводит список изображений (от 1 до 3)
	/// с кнопкой для действия, заголовком и описанием.
	/// </summary>
	CoverList,

	/// <summary>
	/// Match - Выводит текущий результат спортивного матча.
	/// </summary>
	Match,

	/// <summary>
	/// Matches - Выводит список спортивных матчей.
	/// </summary>
	Matches,

	/// <summary>
	/// Donation - Выводит прогресс пожертвований.
	/// </summary>
	Donation
}