using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Способ сортировки приложений
	/// </summary>
	[Serializable]
	public sealed class PostTypeOrder : SafetyEnum<PostTypeOrder>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly PostTypeOrder Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostTypeOrder Copy = RegisterPossibleValue(value: "copy");
	}
}