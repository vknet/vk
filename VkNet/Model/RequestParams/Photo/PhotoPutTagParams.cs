namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.putTag
	/// </summary>
	public class PhotoPutTagParams
	{
		/// <summary>
		/// идентификатор пользователя, которому принадлежит фотография. положительное число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public ulong? owner_id
		{ get; set; }

		/// <summary>
		/// идентификатор фотографии. положительное число, обязательный параметр.
		/// </summary>
		public ulong photo_id
		{ get; set; }

		/// <summary>
		/// идентификатор пользователя, которого нужно отметить на фотографии. целое число, обязательный параметр.
		/// </summary>
		public ulong user_id
		{ get; set; }

		/// <summary>
		/// координата верхнего левого угла области с отметкой в % от ширины фотографии. дробное число.
		/// </summary>
		public decimal? x
		{ get; set; }

		/// <summary>
		/// координата верхнего левого угла области с отметкой в % от высоты фотографии. дробное число.
		/// </summary>
		public decimal? y
		{ get; set; }

		/// <summary>
		/// координата правого нижнего угла области с отметкой в % от ширины фотографии. дробное число.
		/// </summary>
		public decimal? x2
		{ get; set; }

		/// <summary>
		/// координата правого нижнего угла области с отметкой в % от высоты фотографии. дробное число.
		/// </summary>
		public decimal? y2
		{ get; set; }
	}
}