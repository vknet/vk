namespace VkNet.Enums
{
    /// <summary>
    /// Формат объявления.
    /// </summary>
    public enum AdFormat
    {
        /// <summary>
        /// Изображение и текст
        /// </summary>
        ImageAndText = 1,
        /// <summary>
        /// Большое изображение
        /// </summary>
        BigImage,
        /// <summary>
        /// Эксклюзивный формат
        /// </summary>
        ExclusiveFormat,
        /// <summary>
        /// Продвижение сообществ или приложений, квадратное изображение
        /// </summary>
        SquareImage,
        /// <summary>
        /// Приложение в новостной ленте (устаревший)
        /// </summary>
        NewsfeedApp,
        /// <summary>
        /// мобильное приложение;
        /// </summary>
        MobileApp,
        /// <summary>
        /// запись в сообществе.
        /// </summary>
        Public = 9
    }
}