using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Способ сортировки приложений
	/// </summary>
	[DataContract]
	public sealed class PostTypeOrder : SafetyEnum<PostTypeOrder>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly PostTypeOrder Post = RegisterPossibleValue("post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostTypeOrder Copy = RegisterPossibleValue("copy");
	}
}