using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Тип документа.
/// </summary>
[Serializable]
public class DocumentType
{
	/// <summary>
	/// Идентификатор полученного подарка.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Текст сообщения, приложенного к подарку.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Количество документов данного типа.
	/// </summary>
	[JsonProperty("count")]
	public long Count { get; set; }
}