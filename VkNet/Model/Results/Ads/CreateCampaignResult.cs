using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения метода ads.createCampaigns
/// </summary>
[Serializable]
public class CreateCampaignResult
{
	/// <summary>
	/// Идентификатор созданного объявления.
	/// </summary>
	/// <remarks>Выполнение этого метода может вернуть id = null в случае ошибки</remarks>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Массив объектов UserSpecification
	/// </summary>
	[JsonProperty("error_code")]
	public long ErrorCode { get; set; }

	/// <summary>
	/// Массив объектов UserSpecification
	/// </summary>
	[JsonProperty("error_desc")]
	public string ErrorDesc { get; set; }
}