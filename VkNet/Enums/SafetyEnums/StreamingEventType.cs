using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип событий
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class StreamingEventType : SafetyEnum<StreamingEventType>
	{
		/// <summary>
		/// Записи на стене;
		/// </summary>
		public static readonly StreamingEventType Post = RegisterPossibleValue("post");

		/// <summary>
		/// Комментарии;
		/// </summary>
		public static readonly StreamingEventType Comment = RegisterPossibleValue("comment");

		/// <summary>
		/// Репосты;
		/// </summary>
		public static readonly StreamingEventType Share = RegisterPossibleValue("share");
	}
}