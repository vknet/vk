using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода LeadForm.Create
/// </summary>
[Serializable]
public class LeadFormCreateResult
{
	/// <summary>
	/// Идентификатор формы
	/// </summary>
	[JsonProperty("form_id")]
	public long? FormId { get; set; }

	/// <summary>
	/// Ссылка на форму
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }
}