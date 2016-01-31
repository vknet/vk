﻿namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Порядок сортировки членов группы.
	/// </summary>
	public sealed class FeedType : SafetyEnum<FeedType>
	{
		/// <summary>
		/// По возрастанию численных значений идентификаторов.
		/// </summary>
		public static readonly FeedType Photo = RegisterPossibleValue("photo");

		/// <summary>
		/// По убыванию численных значений идентификаторов.
		/// </summary>
		public static readonly FeedType PhotoTag = RegisterPossibleValue("photo_tag");
	}
}