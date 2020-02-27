using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Template.Carousel
{
	/// <summary>
	/// Объект, описывающий действие, которое необходимо выполнить при нажатии на элемент карусели.
	/// Поддерживается два действия:
	/// open_link - открыть ссылку из поля "link".
	/// open_photo - открыть фото текущего элемента карусели.
	/// </summary>
	[Serializable]
	public class CarouselElementAction
	{
		/// <summary>
		/// Тип клавиши.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public CarouselElementActionType Type { get; set; }

		/// <summary>
		/// ссылка, которую необходимо открыть по нажатию на кнопку.
		/// </summary>
		[JsonProperty("link")]
		public Uri Link { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CarouselElementAction FromJson(VkResponse response)
		{
			return new CarouselElementAction
			{
				Type = response[key: "type"],
				Link = response[key: "link"]
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CarouselElementAction(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}