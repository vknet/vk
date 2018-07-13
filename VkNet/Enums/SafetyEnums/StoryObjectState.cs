using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Доступность значения.
	/// </summary>
	[Serializable]
	public sealed class StoryObjectState : SafetyEnum<StoryObjectState>
	{
		/// <summary>
		/// Доступно.
		/// </summary>
		public static readonly StoryObjectState On = RegisterPossibleValue("on");

		/// <summary>
		/// Недоступно.
		/// </summary>
		public static readonly StoryObjectState Off = RegisterPossibleValue("off");

		/// <summary>
		/// Недоступно.
		/// </summary>
		public static readonly StoryObjectState Hidden = RegisterPossibleValue("hidden");
	}
}
