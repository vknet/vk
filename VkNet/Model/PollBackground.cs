using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Фон сниппета опроса.
	/// </summary>
	[Serializable]
	public class PollBackground
	{
		/// <summary>
		/// Идентификатор фона.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Тип фона.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PollBackgroundType Type { get; set; }

		/// <summary>
		/// (для type = gradient) угол градиента по оси X.
		/// </summary>
		public int? Angle { get; set; }

		/// <summary>
		/// HEX-код замещающего цвета (без #).
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// (для type = tile) ширина плитки паттерна.
		/// </summary>
		public int? Width { get; set; }

		/// <summary>
		/// (для type = tile) высота плитки паттерна.
		/// </summary>
		public int? Height { get; set; }

		/// <summary>
		/// (для type = tile) изображение плитки паттерна. Массив объектов изображений.
		/// </summary>
		public ReadOnlyCollection<Photo> Images { get; set; }

		/// <summary>
		/// (для type = gradient) точки градиента.
		/// </summary>
		public ReadOnlyCollection<PollBackgroundPoint> Points { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PollBackground FromJson(VkResponse response)
		{
			return new PollBackground
			{
				Id = response["id"],
				Type = response["type"],
				Angle = response["angle"],
				Color = response["color"],
				Width = response["width"],
				Height = response["height"],
				Images = response["images"].ToReadOnlyCollectionOf<Photo>(),
				Points = response["points"].ToReadOnlyCollectionOf<PollBackgroundPoint>()
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="PollBackground" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="PollBackground" /></returns>
		public static implicit operator PollBackground(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}