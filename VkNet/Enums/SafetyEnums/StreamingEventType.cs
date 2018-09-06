using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип событий
	/// </summary>
	[Serializable]
	[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
	public class StreamingEventType : SafetyEnum<StreamingEventType>
	{
		/// <summary>
		/// Записи на стене;
		/// </summary>
		public static readonly StreamingEventType Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// Комментарии;
		/// </summary>
		public static readonly StreamingEventType Comment = RegisterPossibleValue(value: "comment");

		/// <summary>
		/// Репосты;
		/// </summary>
		public static readonly StreamingEventType Share = RegisterPossibleValue(value: "share");
	}
}