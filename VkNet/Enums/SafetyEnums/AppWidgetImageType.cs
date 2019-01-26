using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип изображения для виджета приложения
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class AppWidgetImageType : SafetyEnum<AppWidgetImageType>
	{
		/// <summary>
		/// 24x24
		/// </summary>
		public static readonly AppWidgetImageType TwentyFourOnTwentyFour = RegisterPossibleValue("24x24");

		/// <summary>
		/// 50x50
		/// </summary>
		public static readonly AppWidgetImageType FiftyOnFifty = RegisterPossibleValue("50x50");

		/// <summary>
		/// 160x160
		/// </summary>
		public static readonly AppWidgetImageType OneHundredAndSixtyOnOneHundredAndSixty = RegisterPossibleValue("160x160");

		/// <summary>
		/// 160x240
		/// </summary>
		public static readonly AppWidgetImageType OneHundredAndSixtyOnTwoHundredAndForty = RegisterPossibleValue("160x240");

		/// <summary>
		/// 510x128
		/// </summary>
		public static readonly AppWidgetImageType FiveHundredAndTenOnOneHundredAndTwentyEight = RegisterPossibleValue("510x128");
	}
}