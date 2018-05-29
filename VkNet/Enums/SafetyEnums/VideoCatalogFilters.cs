namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Фильтры для видео каталога
	/// </summary>
	public class VideoCatalogFilters : SafetyEnum<VideoCatalogFilters>
	{
		/// <summary>
		/// Видео из ленты новостей пользователя
		/// </summary>
		public static readonly VideoCatalogFilters Feed = RegisterPossibleValue(value: "feed");

		/// <summary>
		/// популярное
		/// </summary>
		public static readonly VideoCatalogFilters Ugc = RegisterPossibleValue(value: "ugc");

		/// <summary>
		/// выбор редакции
		/// </summary>
		public static readonly VideoCatalogFilters Top = RegisterPossibleValue(value: "top");

		/// <summary>
		/// сериалы и телешоу
		/// </summary>
		public static readonly VideoCatalogFilters Series = RegisterPossibleValue(value: "series");

		/// <summary>
		/// прочие блоки
		/// </summary>
		public static readonly VideoCatalogFilters Other = RegisterPossibleValue(value: "other");
	}
}