using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода UpdateCampaigns
/// </summary>
[Serializable]
public class UpdateClientsResult
{
	/// <summary>
	/// Идентификатор обновляемой кампании.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Код ошибки
	/// </summary>
	[JsonProperty("error_code")]
	public long ErrorCode { get; set; }

	/// <summary>
	/// Описание ошибки
	/// </summary>
	[JsonProperty("error_desc")]
	public string ErrorDesc { get; set; }
}