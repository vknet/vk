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
		BigImage = 2,

		/// <summary>
		/// Эксклюзивный формат
		/// </summary>
		ExclusiveFormat = 3,

		/// <summary>
		/// Продвижение сообществ или приложений, квадратное изображение
		/// </summary>
		SquareImage = 4,

		/// <summary>
		/// Приложение в новостной ленте (устаревший)
		/// </summary>
		NewsfeedApp = 5,

		/// <summary>
		/// мобильное приложение;
		/// </summary>
		MobileApp = 6,

		///<summary>
		/// Адаптивный формат
		/// </summary>
		AdaptiveFormat = 11,

		/// <summary>
		/// запись в сообществе.
		/// </summary>
		Public = 9
	}
}