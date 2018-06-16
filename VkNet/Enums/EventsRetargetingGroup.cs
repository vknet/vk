namespace VkNet.Enums {
	/// <summary>
	/// Только для ad_format = 9. Описание событий, собираемых в группы ретаргетинга. Массив объектов, где ключом является id группы ретаргетинга, а значением - массив событий.
	/// </summary>
	public enum EventsRetargetingGroup {
		/// <summary>
		/// текстовые документы
		/// </summary>
		Text = 1,
		/// <summary>
		/// архивы
		/// </summary>
		Archive,
		/// <summary>
		/// gif
		/// </summary>
		Gif,
		/// <summary>
		/// изображения
		/// </summary>
		Image,
		/// <summary>
		/// аудио
		/// </summary>
		Audio,
		/// <summary>
		/// видео
		/// </summary>
		Video,
		/// <summary>
		/// электронные книги
		/// </summary>
		EBook,
		/// <summary>
		/// неизвестно
		/// </summary>
		Undefined
	}
}
