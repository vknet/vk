using System;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.edit
	/// </summary>
	[Serializable]
	public class PhotoEditParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong PhotoId { get; set; }

		/// <summary>
		/// Новый текст описания к фотографии. Если параметр не задан, то считается, что он
		/// равен пустой строке.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Широта.
		/// </summary>
		public decimal? Latitude { get; set; }

		/// <summary>
		/// Долгота.
		/// </summary>
		public decimal? Longitude { get; set; }

		/// <summary>
		/// Место.
		/// </summary>
		public string PlaceStr { get; set; }

		/// <summary>
		/// Идентификатор квадрата.
		/// </summary>
		public string FoursquareId { get; set; }

		/// <summary>
		/// Место удалено.
		/// </summary>
		public bool? DeletePlace { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		public string CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(PhotoEditParams p)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "photo_id", p.PhotoId }
					, { "caption", p.Caption }
					, { "latitude", p.Latitude }
					, { "longitude", p.Longitude }
					, { "place_str", p.PlaceStr }
					, { "foursquare_id", p.FoursquareId }
					, { "delete_place", p.DeletePlace }
					, { "captcha_sid", p.CaptchaSid }
					, { "captcha_key", p.CaptchaKey }
			};

			return parameters;
		}
	}
}