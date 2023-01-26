using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Описание рекламного аккаунта.
/// </summary>
/// <remarks>
/// См. описание https://vk.com/dev/ads.getAccounts
/// </remarks>
[Serializable]
public class GetClientsResult
{
	/// <summary>
	/// Идентификатор рекламного объявления.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Общий лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("all_limit")]
	public long AllLimit { get; set; }
}