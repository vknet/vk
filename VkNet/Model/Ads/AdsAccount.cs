using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Описание рекламного аккаунта.
/// </summary>
/// <remarks>
/// См. описание https://vk.com/dev/ads.getAccounts
/// </remarks>
[Serializable]
public class AdsAccount
{
	/// <summary>
	/// Идентификатор рекламного кабинета.
	/// </summary>
	[JsonProperty(propertyName: "account_id")]
	public ulong AccountId { get; set; }

	/// <summary>
	/// Тип рекламного кабинета.
	/// </summary>
	[JsonProperty(propertyName: "account_type")]
	public AccountType? AccountType { get; set; }

	/// <summary>
	/// Cтатус рекламного кабинета.
	/// </summary>
	[JsonProperty(propertyName: "account_status")]
	public AccountStatus AccountStatus { get; set; }

	/// <summary>
	/// Название аккаунта
	/// </summary>
	[JsonProperty(propertyName: "account_name")]
	public string AccountName { get; set; }

	/// <summary>
	/// Права пользователя в рекламном кабинете.
	/// </summary>
	[JsonProperty(propertyName: "access_role")]
	public AccessRole? AccessRole { get; set; }
}