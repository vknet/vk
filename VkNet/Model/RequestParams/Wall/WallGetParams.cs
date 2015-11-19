using VkNet.Enums;

namespace VkNet.Model.RequestParams.Wall
{
	/// <summary>
	/// Список параметров для метода photos.createAlbum
	/// </summary>
	public class WallGetParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, со стены которого необходимо получить записи (по умолчанию — текущий пользователь).
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// Короткий адрес пользователя или сообщества.
		/// </summary>
		public string Domain
		{ get; set; }

        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества записей.
        /// </summary>
        public ulong Offset
        { get; set; } = 0;

        /// <summary>
        /// Количество записей, которое необходимо получить (но не более 100).
        /// </summary>
        public ulong Count
        { get; set; } = 20;

        /// <summary>
        /// Определяет, какие типы записей на стене необходимо получить. Возможны следующие значения параметра: Если параметр не задан, то считается, что он равен all.
        /// </summary>
        public WallFilter Filter
        { get; set; } = WallFilter.All;

        /// <summary>
        /// <c>true</c> — будут возвращены три массива wall, profiles и groups. По умолчанию дополнительные поля не возвращаются.
        /// </summary>
        public bool Extended
        { get; set; } = false;

		/// <summary>
		/// Список дополнительных полей для профилей и групп, которые необходимо вернуть. См. описание полей объекта user и описание полей объекта group. Обратите внимание, этот параметр учитывается только при extended=1.
		/// </summary>
		public object Fields
		{ get; set; }
	}
}