namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Фильтры для видео каталога
    /// </summary>
    public class VideoCatalogFilters: SafetyEnum<VideoCatalogFilters>
    {
        /// <summary>
        /// Видео из ленты новостей пользователя
        /// </summary>
        public static readonly VideoCatalogFilters Feed = RegisterPossibleValue("feed");
        
        /// <summary>
        /// популярное
        /// </summary>
        public static readonly VideoCatalogFilters Ugc = RegisterPossibleValue("ugc");
        
        /// <summary>
        /// выбор редакции
        /// </summary>
        public static readonly VideoCatalogFilters Top = RegisterPossibleValue("top");

        /// <summary>
        /// сериалы и телешоу
        /// </summary>
        public static readonly VideoCatalogFilters Series = RegisterPossibleValue("series");
        
        /// <summary>
        /// прочие блоки
        /// </summary>
        public static readonly VideoCatalogFilters Other = RegisterPossibleValue("other");
        
    }
}