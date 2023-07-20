using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

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