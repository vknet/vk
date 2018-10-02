using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип фона опроса.
	/// </summary>
	[Serializable]
	public class PollBackgroundType: SafetyEnum<PollBackgroundType>
	{
		/// <summary>
		/// Gradient.
		/// </summary>
		public static readonly PollBackgroundType Gradient = RegisterPossibleValue("gradient");
		/// <summary>
		/// tile.
		/// </summary>
		public static readonly PollBackgroundType Tile = RegisterPossibleValue("tile");
	}
}