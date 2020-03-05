using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода Ads.CreateTargetPixel
	/// </summary>
	[Serializable]
	public class CreateTargetPixelResult
	{
		/// <summary>
		/// Идентификатор пикселя
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Код для размещения на сайте рекламодателя
		/// </summary>
		[JsonProperty("pixel")]
		public string Pixel { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CreateTargetPixelResult FromJson(VkResponse response)
		{
			return new CreateTargetPixelResult
			{
				Id = response["id"],
				Pixel = response["pixel"]
			};
		}
	}
}