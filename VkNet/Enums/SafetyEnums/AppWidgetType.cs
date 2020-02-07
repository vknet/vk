using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип виджета приложения
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class AppWidgetType : SafetyEnum<AppWidgetType>
	{
		/// <summary>
		/// Text - Выводит текст.
		/// </summary>
		public static readonly AppWidgetType Text = RegisterPossibleValue("text");

		/// <summary>
		/// List - Выводит список объектов с описанием и
		/// кнопками для действий. Список может содержать
		/// до 6 объектов,
		/// если не указан сопроводительный текст (поле text),
		/// и до 3 объектов, если текст указан.
		/// </summary>
		public static readonly AppWidgetType List = RegisterPossibleValue("list");

		/// <summary>
		/// Table - Выводит таблицу с данными.
		/// В первом столбце текст и ссылки могут
		/// сопровождаться иконками.
		/// Таблица может содержать от 1 до 6 столбцов
		/// и от 1 до 11 строк (включая строку с названиями колонок).
		/// </summary>
		public static readonly AppWidgetType Table = RegisterPossibleValue("table");

		/// <summary>
		/// Tiles - Выводит плитки с изображением и кратким описанием.
		/// Количество плиток — от 3 до 10 для мобильных приложений,
		/// 3 для десктопной версии.
		/// </summary>
		public static readonly AppWidgetType Tiles = RegisterPossibleValue("tiles");

		/// <summary>
		/// Compact List - Выводит список элементов в компактном виде.
		/// Аналогичен виджету List, за исключением того,
		/// что кнопка располагается справа.
		/// </summary>
		public static readonly AppWidgetType CompactList = RegisterPossibleValue("compact_list");

		/// <summary>
		/// Cover List - Выводит список изображений (от 1 до 3)
		/// с кнопкой для действия, заголовком и описанием.
		/// </summary>
		public static readonly AppWidgetType CoverList = RegisterPossibleValue("cover_list");

		/// <summary>
		/// Match - Выводит текущий результат спортивного матча.
		/// </summary>
		public static readonly AppWidgetType Match = RegisterPossibleValue("match");

		/// <summary>
		/// Matches - Выводит список спортивных матчей.
		/// </summary>
		public static readonly AppWidgetType Matches = RegisterPossibleValue("matches");

		/// <summary>
		/// Donation - Выводит прогресс пожертвований.
		/// </summary>
		public static readonly AppWidgetType Donation = RegisterPossibleValue("donation");
	}
}