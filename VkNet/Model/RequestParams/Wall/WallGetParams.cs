﻿namespace VkNet.Model.RequestParams
{
    using Enums;

    using Utils;

    /// <summary>
    /// Список параметров для метода Wall.Get
    /// </summary>
    public struct WallGetParams
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
        { get; set; }

        /// <summary>
        /// Количество записей, которое необходимо получить (но не более 100).
        /// </summary>
        public ulong Count
        { get; set; }

        /// <summary>
        /// Определяет, какие типы записей на стене необходимо получить. Возможны следующие значения параметра: Если параметр не задан, то считается, что он равен all.
        /// </summary>
        public WallFilter Filter
        { get; set; }

        /// <summary>
        /// <c>true</c> — будут возвращены три массива wall, profiles и groups. По умолчанию дополнительные поля не возвращаются.
        /// </summary>
        public bool Extended
        { get; set; }

		/// <summary>
		/// Список дополнительных полей для профилей и групп, которые необходимо вернуть. См. описание полей объекта user и описание полей объекта group. Обратите внимание, этот параметр учитывается только при extended=1.
		/// </summary>
		public object Fields
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(WallGetParams p)
        {
            return new VkParameters
            {
                { "owner_id", p.OwnerId },
                { "domain", p.Domain },
                { "offset", p.Offset },
                { "count", p.Count },
                { "filter", p.Filter },
                { "extended", p.Extended },
                { "fields", p.Fields }
            };
        }
    }
}