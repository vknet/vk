using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Типы нестандартных вопросов
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class NonStandardQuestion : SafetyEnum<NonStandardQuestion>
	{
		/// <summary>
		/// Простое текстовое поле (строка)
		/// </summary>
		public static readonly NonStandardQuestion Input = RegisterPossibleValue("input");

		/// <summary>
		/// Большое текстовое поле (абзац)
		/// </summary>
		public static readonly NonStandardQuestion Textarea = RegisterPossibleValue("textarea");

		/// <summary>
		/// Выбор одного из нескольких вариантов
		/// </summary>
		public static readonly NonStandardQuestion Radio = RegisterPossibleValue("radio");

		/// <summary>
		/// Выбор нескольких вариантов
		/// </summary>
		public static readonly NonStandardQuestion Checkbox = RegisterPossibleValue("checkbox");

		/// <summary>
		/// Выбор одного варианта из выпадающего списка
		/// </summary>
		/// <remarks>
		/// options должен быть массивом структур, описывающих варианты ответа
		/// </remarks>
		public static readonly NonStandardQuestion Select = RegisterPossibleValue("select");

		/// <summary>
		/// Текст ответа
		/// </summary>
		public static readonly NonStandardQuestion Label = RegisterPossibleValue("label");

		/// <summary>
		/// Ключ ответа (необязательно)
		/// </summary>
		public static readonly NonStandardQuestion Key = RegisterPossibleValue("key");
	}
}