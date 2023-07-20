using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Информация о заявке на смену имени.
/// </summary>
[Serializable]
public class NameRequest
{
	/// <summary>
	/// Идентификатор заявки, необходимый для её отмены (только если
	/// ChangeNameRequest.Status
	/// </summary>
	[JsonProperty("id")]
	public int? Id { get; set; }

	/// <summary>
	/// Статус заявки
	/// </summary>
	[JsonProperty("status")]
	public ChangeNameStatus Status { get; set; }

	/// <summary>
	/// Дата, после которой возможна повторная подача заявки.
	/// </summary>
	[JsonProperty("repeat_date")]
	public string RepeatDate { get; set; }

	/// <summary>
	/// Имя пользователя, указанное в заявке
	/// </summary>
	[JsonProperty("first_name")]
	public string FirstName { get; set; }

	/// <summary>
	/// Фамилия пользователя, указанная в заявке.
	/// </summary>
	[JsonProperty("last_name")]
	public string LastName { get; set; }
}