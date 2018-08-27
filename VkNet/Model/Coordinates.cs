using System;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Координаты места, в котором была сделана запись.
	/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo" />.
	/// Официальная страница http://vk.com/dev/post
	/// молчит о том, что возвращаются географические координаты.
	/// </summary>
	[Serializable]
	public class Coordinates
	{
		/// <summary>
		/// Географическая широта.
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// Географическая долгота.
		/// </summary>
		public double Longitude { get; set; }

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Coordinates FromJsonAttachments(VkResponse response)
		{
			// TODO: TEST IT!!!!!

			double latitude = response["latitude"];
			double longitude = response["longitude"];

			var coordinates = new Coordinates
			{
				Latitude = latitude,
				Longitude = longitude
			};
			return coordinates;
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Coordinates FromJson(VkResponse response)
		{
			// TODO: TEST IT!!!!!
			var latitudeWithLongitude = ((string) response).Split(' ');

			if (latitudeWithLongitude.Length != 2)
			{
				throw new VkApiException(message: "Coordinates must have latitude and longitude!");
			}

			if (!double.TryParse(s: latitudeWithLongitude[0].Replace(oldValue: ".", newValue: ","), result: out double latitude))
			{
				throw new VkApiException(message: "Invalid latitude!");
			}

			if (!double.TryParse(s: latitudeWithLongitude[1].Replace(oldValue: ".", newValue: ","), result: out double longitude))
			{
				throw new VkApiException(message: "Invalid longitude!");
			}

			var coordinates = new Coordinates
			{
				Latitude = latitude,
				Longitude = longitude
			};

			return coordinates;
		}

		#endregion
	}
}