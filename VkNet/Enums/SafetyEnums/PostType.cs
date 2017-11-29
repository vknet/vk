using System;
using System.Runtime.Serialization;

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
		public static readonly PostType Post = RegisterPossibleValue("post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Copy = RegisterPossibleValue("copy");

        /// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Reply = RegisterPossibleValue("reply");

        /// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Postpone = RegisterPossibleValue("postpone");

        /// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Suggest = RegisterPossibleValue("suggest");
	}
}