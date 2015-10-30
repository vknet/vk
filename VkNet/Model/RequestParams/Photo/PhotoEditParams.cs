namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.edit
	/// </summary>
	public class PhotoEditParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
		/// </summary>
		public long OwnerId
		{ get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong PhotoId
		{ get; set; }

		/// <summary>
		/// Новый текст описания к фотографии. Если параметр не задан, то считается, что он равен пустой строке.
		/// </summary>
		public string Caption
		{ get; set; }

		/// <summary>
		/// Широта.
		/// </summary>
		public decimal? Latitude
		{ get; set; }

		/// <summary>
		/// Долгота.
		/// </summary>
		public decimal? Longitude
		{ get; set; }

		/// <summary>
		/// Место.
		/// </summary>
		public string PlaceStr
		{ get; set; }

		/// <summary>
		/// Идентификатор квадрата.
		/// </summary>
		public string FoursquareId
		{ get; set; }

		/// <summary>
		/// Место удалено.
		/// </summary>
		public bool? DeletePlace
		{ get; set; }
	}
}
