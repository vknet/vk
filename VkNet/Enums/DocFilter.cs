namespace VkNet.Enums
{
	/// <summary>
	/// Фильтр по типу документа.
	/// </summary>
	public enum DocFilter
	{
		/// <summary>
		/// 1 - текстовые документы
		/// </summary>
		Text = 1

		, /// <summary>
		/// 2 - архивы
		/// </summary>
		Archive

		, /// <summary>
		/// 3 - gif
		/// </summary>
		Gif

		, /// <summary>
		/// 4 - изображения
		/// </summary>
		Image

		, /// <summary>
		/// 5 - аудио
		/// </summary>
		Audio

		, /// <summary>
		/// 6 - видео
		/// </summary>
		Video

		, /// <summary>
		/// 7 - электронные книги
		/// </summary>
		EBook

		, /// <summary>
		/// 8 - неизвестно
		/// </summary>
		Unknown
	}
}