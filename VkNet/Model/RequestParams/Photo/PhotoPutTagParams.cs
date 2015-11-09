namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.putTag
	/// </summary>
	public class PhotoPutTagParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому принадлежит фотография.
		/// </summary>
		public ulong? owner_id
		{ get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong photo_id
		{ get; set; }

		/// <summary>
		/// Идентификатор пользователя, которого нужно отметить на фотографии.
		/// </summary>
		public ulong user_id
		{ get; set; }

		/// <summary>
		/// Координата верхнего левого угла области с отметкой в % от ширины фотографии.
		/// </summary>
		public decimal? x
		{ get; set; }

		/// <summary>
		/// Координата верхнего левого угла области с отметкой в % от высоты фотографии.
		/// </summary>
		public decimal? y
		{ get; set; }

		/// <summary>
		/// Координата правого нижнего угла области с отметкой в % от ширины фотографии.
		/// </summary>
		public decimal? x2
		{ get; set; }

		/// <summary>
		/// Координата правого нижнего угла области с отметкой в % от высоты фотографии.
		/// </summary>
		public decimal? y2
		{ get; set; }
	}
}