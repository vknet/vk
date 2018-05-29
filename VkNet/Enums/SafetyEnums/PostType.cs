using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип записи post, copy, reply, postpone, suggest
	/// </summary>
	[Serializable]
	public sealed class PostType : SafetyEnum<PostType>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly PostType Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Copy = RegisterPossibleValue(value: "copy");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Reply = RegisterPossibleValue(value: "reply");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Postpone = RegisterPossibleValue(value: "postpone");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Suggest = RegisterPossibleValue(value: "suggest");
	}
}