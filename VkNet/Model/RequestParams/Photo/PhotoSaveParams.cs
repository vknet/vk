using System;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.save
	/// </summary>
	[Serializable]
	public class PhotoSaveParams
	{
		/// <summary>
		/// Идентификатор альбома, в который необходимо сохранить фотографии.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Идентификатор сообщества, в которое необходимо сохранить фотографии.
		/// </summary>
		public long? GroupId { get; set; }

		/// <summary>
		/// Параметр, возвращаемый в результате загрузки фотографий на сервер.
		/// </summary>
		public string SaveFileResponse { get; set; }

		/// <summary>
		/// Географическая широта, заданная в градусах (от -90 до 90);
		/// </summary>
		public decimal? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота, заданная в градусах (от -180 до 180);
		/// </summary>
		public decimal? Longitude { get; set; }

		/// <summary>
		/// Текст описания фотографии.
		/// </summary>
		public string Caption { get; set; }
	}
}