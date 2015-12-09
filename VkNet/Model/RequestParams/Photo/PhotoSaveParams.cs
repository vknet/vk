using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.save
	/// </summary>
	public struct PhotoSaveParams
	{
		/// <summary>
		/// Идентификатор альбома, в который необходимо сохранить фотографии.
		/// </summary>
		public long? AlbumId
		{ get; set; }

		/// <summary>
		/// Идентификатор сообщества, в которое необходимо сохранить фотографии.
		/// </summary>
		public long? GroupId
		{ get; set; }

		/// <summary>
		/// Параметр, возвращаемый в результате загрузки фотографий на сервер.
		/// </summary>
		public long? Server
		{ get; set; }

		/// <summary>
		/// Параметр, возвращаемый в результате загрузки фотографий на сервер.
		/// </summary>
		public string PhotosList
		{ get; set; }

		/// <summary>
		/// Параметр, возвращаемый в результате загрузки фотографий на сервер.
		/// </summary>
		public string Hash
		{ get; set; }

		/// <summary>
		/// Географическая широта, заданная в градусах (от -90 до 90);
		/// </summary>
		public decimal? Latitude
		{ get; set; }

		/// <summary>
		/// Географическая долгота, заданная в градусах (от -180 до 180);
		/// </summary>
		public decimal? Longitude
		{ get; set; }

		/// <summary>
		/// Текст описания фотографии.
		/// </summary>
		public string Caption
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(PhotoSaveParams p)
		{
			var parameters = new VkParameters
			{
				{ "album_id", p.AlbumId },
				{ "group_id", p.GroupId },
				{ "server", p.Server },
				{ "photos_list", p.PhotosList },
				{ "hash", p.Hash },
				{ "latitude", p.Latitude },
				{ "longitude", p.Longitude },
				{ "caption", p.Caption }
			};

			return parameters;
		}
	}
}
