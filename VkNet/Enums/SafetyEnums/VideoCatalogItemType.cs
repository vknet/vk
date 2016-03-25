namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип элемента каталога.
	/// </summary>
	public sealed class VideoCatalogItemType : SafetyEnum<VideoCatalogItemType>
	{
		/// <summary>
		/// Видеоролик.
		/// </summary>
		public static readonly VideoCatalogItemType Video = RegisterPossibleValue("video");

		/// <summary>
		/// Альбом.
		/// </summary>
		public static readonly VideoCatalogItemType Album = RegisterPossibleValue("album");
	}
}