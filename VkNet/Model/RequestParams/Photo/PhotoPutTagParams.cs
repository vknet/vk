using System;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.putTag
	/// </summary>
	[Serializable]
	public class PhotoPutTagParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому принадлежит фотография.
		/// </summary>
		public ulong? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong PhotoId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, которого нужно отметить на фотографии.
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// Координата верхнего левого угла области с отметкой в % от ширины фотографии.
		/// </summary>
		public decimal? X { get; set; }

		/// <summary>
		/// Координата верхнего левого угла области с отметкой в % от высоты фотографии.
		/// </summary>
		public decimal? Y { get; set; }

		/// <summary>
		/// Координата правого нижнего угла области с отметкой в % от ширины фотографии.
		/// </summary>
		public decimal? X2 { get; set; }

		/// <summary>
		/// Координата правого нижнего угла области с отметкой в % от высоты фотографии.
		/// </summary>
		public decimal? Y2 { get; set; }
	}
}