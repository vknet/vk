using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о географическом месте, в котором была сделана запись.
	/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo" />.
	/// </summary>
	[Serializable]
	public class Geo
	{
		/// <summary>
		/// Имя типа информации о географическом месте (в настоящий момент поддерживается
		/// единственный тип "place", это
		/// означает,
		/// что запись привязана к определенному географическому месту в базе мест.)
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Координаты места, в котором была сделана запись.
		/// </summary>
		[JsonConverter(typeof(CoordinatesJsonConverter))]
		public Coordinates Coordinates { get; set; }

		/// <summary>
		/// Информация о месте, в котором была сделана запись.
		/// </summary>
		public Place Place { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Geo FromJson(VkResponse response)
		{
			// TODO: TEST IT!!!!!
			var geo = new Geo
			{
					Place = response[key: "place"]
					, Coordinates = response[key: "coordinates"]
					, Type = response[key: "type"]
			};

			return geo;
		}

	#endregion
	}
}