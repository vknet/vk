using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Infrastructure;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о кадрах предпросмотра. Часть объекта
	/// <see cref="Video"> Video </see>
	/// Представляет из себя набор изображений, состоящих из сетки картинок
	/// предпросмотров
	/// </summary>
	[Serializable]
	public class TimelineThumbs
	{
		/// <summary>
		/// Количество картинок предпросмотра на одном изображении
		/// </summary>
		[JsonProperty("count_per_image")]
		public int? CountPerImage { get; set; }

		/// <summary>
		/// Количество картинок в одной строке изображения
		/// </summary>
		[JsonProperty("count_per_row")]
		public int? CountPerRow { get; set; }

		/// <summary>
		/// Количество картинок предпросмотра в видео.
		/// <remarks>
		/// Равно длине видео в секундах (<see cref="Video.Duration"> Video.Duration </see>
		/// ) разделённого на частоту (<see cref="Frequency" />) смены картинок,
		/// округлённое в большую сторону до целого
		/// </remarks>
		/// </summary>
		[JsonProperty("count_total")]
		public int? CountTotal { get; set; }

		/// <summary>
		/// Высота одного предпросмотра на изображении в пикселях
		/// </summary>
		[JsonProperty("frame_height")]
		public int? FrameHeight { get; set; }

		/// <summary>
		/// Ширина одного предпросмотра на изображении в пикселях
		/// </summary>
		[JsonProperty("frame_width")]
		public float? FrameWidth { get; set; }

		/// <summary>
		/// Ссылки на изображения предпросмотров
		/// <remarks>
		/// Каждое изображение предпросмотра представляет из себя сетку
		/// <see cref="CountPerRow" /> на (<see cref="CountPerImage" /> /
		/// <see cref="CountPerRow" />) картинок
		/// размером <see cref="FrameWidth" /> на <see cref="FrameHeight" />
		/// В тестах изображения были в формате <c> .jfif </c> (aka. <c> .jpeg </c>),
		/// Однако <c> Content-Type </c> был <c> image/jpeg </c>
		/// </remarks>
		/// </summary>
		[JsonProperty("links")]
		public ReadOnlyCollection<Uri> Links { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// In my tests it was always true
		/// </remarks>
		/// </summary>
		[JsonProperty("is_uv")]
		public bool? IsUv { get; set; }

		/// <summary>
		/// Частота смены картинок предпросмотра
		/// </summary>
		[JsonProperty("frequency")]
		public int? Frequency { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static TimelineThumbs FromJson(VkResponse response)
		{
			return JsonConvert.DeserializeObject<TimelineThumbs>(response.ToString(), JsonConfigure.JsonSerializerSettings);
		}

	#endregion
	}
}