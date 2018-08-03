namespace VkNet.Enums
{
	/// <summary>
	/// Только для ad_format = 9. Описание событий, собираемых в группы ретаргетинга. Массив объектов, где ключом является id группы ретаргетинга, а значением - массив событий.
	/// </summary>
	public enum EventsRetargetingGroup
	{
		/// <summary>
		/// Просмотр промопоста
		/// </summary>
		ViewOfPromoPost = 1,

		/// <summary>
		/// Переход по ссылке или переход в сообщество
		/// </summary>
		Click,

		/// <summary>
		/// Переход в сообщество
		/// </summary>
		PublicClick,

		/// <summary>
		/// Подписка на сообщество
		/// </summary>
		Subscription,

		/// <summary>
		/// Отписка от новостей сообщества
		/// </summary>
		PublicNewsUnsubscription,

		/// <summary>
		/// Cкрытие или жалоба
		/// </summary>
		HidingOrComplaint,

		/// <summary>
		/// Запуск видео;
		/// </summary>
		VideoStarting = 10,

		/// <summary>
		/// досмотр видео до 3с
		/// </summary>
		Watching3S,

		/// <summary>
		/// Досмотр видео до 25%
		/// </summary>
		Watching25Perc,

		/// <summary>
		/// Досмотр видео до 50%
		/// </summary>
		Watching50Perc,

		/// <summary>
		/// Досмотр видео до 75%
		/// </summary>
		Watching75Perc,

		/// <summary>
		/// Досмотр видео до 100%
		/// </summary>
		Watching100Perc,

		/// <summary>
		/// Лайк продвигаемой записи
		/// </summary>
		Like = 20,

		/// <summary>
		/// Репост продвигаемой записи
		/// </summary>
		Repost
	}
}