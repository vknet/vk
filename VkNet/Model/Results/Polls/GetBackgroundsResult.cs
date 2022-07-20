using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода GetBackgrounds
	/// </summary>
	[Serializable]
	public class GetBackgroundsResult
	{
		/// <summary>
		/// Тип фона.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PollBackgroundType Type { get; set; }

		/// <summary>
		/// Угол градиента по оси X.
		/// </summary>
		[JsonProperty("angle")]
		public string Angle { get; set; }

		/// <summary>
		/// HEX-код замещающего цвета (без #).
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// Ширина плитки паттерна.
		/// </summary>
		[JsonProperty("width")]
		public long Width { get; set; }

		/// <summary>
		/// Высота плитки паттерна.
		/// </summary>
		[JsonProperty("height")]
		public long Height { get; set; }

		/// <summary>
		/// Точки градиента.
		/// </summary>
		[JsonProperty("points")]
		public PollBackgroundPoint[] Points { get; set; }

		/// <summary>
		/// Идентификатор фона.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Разобрать из Json
		/// </summary>
		/// <param name="response">Ответ сервераю</param>
		/// <returns></returns>
		public static GetBackgroundsResult FromJson(VkResponse response)
		{
			return new GetBackgroundsResult
			{
				Type = response["type"],
				Angle = response["angle"],
				Color = response["color"],
				Width = response["width"],
				Height = response["height"],
				Points = response["points"].ToListOf<PollBackgroundPoint>(x => x).ToArray(),
				Id = response["id"]
			};
		}
	}
}