using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Template.Carousel;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Template;

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
	public TemplateType Type { get; set; }

	/// <summary>
	/// Массив элементов шаблона.
	/// </summary>
	[JsonProperty(propertyName: "elements")]
	public IEnumerable<CarouselElement> Elements { get; set; }
}