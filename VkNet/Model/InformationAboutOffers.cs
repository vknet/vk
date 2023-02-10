using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Информация о предложениях.
/// </summary>
[Serializable]
public class InformationAboutOffers
{
	/// <summary>
	/// Идентификатор.
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	/// Заголовок.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Инструкция.
	/// </summary>
	[JsonProperty("instruction")]
	public string Instruction { get; set; }

	/// <summary>
	/// Инструкция с html разметкой.
	/// </summary>
	/// <value>
	/// The instruction_html.
	/// </value>
	[JsonProperty("instruction_html")]
	public string InstructionHtml { get; set; }

	/// <summary>
	/// Краткое описание.
	/// </summary>
	[JsonProperty("short_description")]
	public string ShortDescription { get; set; }

	/// <summary>
	/// Описание.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Ссылка на изображение.
	/// </summary>
	[JsonProperty("img")]
	public Uri Img { get; set; }

	/// <summary>
	/// Тег.
	/// </summary>
	[JsonProperty("tag")]
	public string Tag { get; set; }

	/// <summary>
	/// Цена.
	/// </summary>
	[JsonProperty("price")]
	public long Price { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static InformationAboutOffers FromJson(VkResponse response) => new()
	{
		Id = response[key: "id"],
		Title = response[key: "title"],
		Instruction = response[key: "instruction"],
		InstructionHtml = response[key: "instruction_html"],
		ShortDescription = response[key: "short_description"],
		Description = response[key: "description"],
		Img = new(uriString: response[key: "img"]),
		Tag = response[key: "tag"],
		Price = response[key: "price"]
	};
}