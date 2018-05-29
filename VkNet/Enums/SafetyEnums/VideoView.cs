namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// предпочтительный способ отображения контента
	/// </summary>
	public class VideoView : SafetyEnum<VideoView>
	{
		/// <summary>
		/// горизонтально с дополнительной информацией
		/// </summary>
		public static readonly VideoView Horizontal = RegisterPossibleValue(value: "horizontal");

		/// <summary>
		/// оризонтально без дополнительной информации
		/// </summary>
		public static readonly VideoView HorizontalCompact = RegisterPossibleValue(value: "horizontal_compact");

		/// <summary>
		/// вертикально с дополнительной информацией
		/// </summary>
		public static readonly VideoView Vertical = RegisterPossibleValue(value: "vertical");

		/// <summary>
		/// вертикально с дополнительной информацией
		/// </summary>
		public static readonly VideoView VerticalCompact = RegisterPossibleValue(value: "vertical_compact");
	}
}