using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Template.Carousel;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Template
{
	/// <summary>
	/// Объект шаблона, отправляемый ботом.
	/// </summary>
	[Serializable]
	[JsonObject(MemberSerialization.OptOut)]
	public class MessageTemplate
	{
		/// <summary>
		/// Тип шаблона.
		/// </summary>
		[JsonProperty(propertyName: "type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public TemplateType Type { get; set; }

		/// <summary>
		/// Массив элементов шаблона.
		/// </summary>
		[JsonProperty(propertyName: "elements")]
		public IEnumerable<CarouselElement> Elements { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MessageTemplate FromJson(VkResponse response)
		{
			return new MessageTemplate
			{
				Type = response[key: "type"],
				Elements = response[key: "elements"].ToReadOnlyCollectionOf<CarouselElement>(selector: x => x)
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageTemplate(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}