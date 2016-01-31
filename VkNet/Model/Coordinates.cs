namespace VkNet.Model
{
	using System;

	using Exception;
	using Utils;

	/// <summary>
	/// Координаты места, в котором была сделана запись.
	/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo"/>.
	/// Официальная страница <see href="http://vk.com/dev/post"/>, описывающая запись на стене и объект Geo в нем, почему то
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Coordinates FromJson(VkResponse response)
		{
			// TODO: TEST IT!!!!!
			var latitudeWithLongitude = ((string)response).Split(' ');
			if (latitudeWithLongitude.Length != 2)
				throw new VkApiException("Coordinates must have latitude and longitude!");

			double latitude;
			if (!double.TryParse(latitudeWithLongitude[0].Replace(".", ","), out latitude))
				throw new VkApiException("Invalid latitude!");

			double longitude;
			if (!double.TryParse(latitudeWithLongitude[1].Replace(".", ","), out longitude))
				throw new VkApiException("Invalid longitude!");

			var coordinates = new Coordinates { Latitude = latitude, Longitude = longitude };

			return coordinates;
		}

		#endregion
	}
}