using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model;

/// <summary>
///
/// </summary>
[Serializable]
public class OfficeUsersSpecification
{
	/// <summary>
	/// Идентификатор пользователя, добавляемого как администратор/наблюдатель.
	/// </summary>
	[JsonProperty("user_id")]
	public long UserId { get; set; }

	/// <summary>
	/// Тип полномочий.
	/// </summary>
	[JsonProperty("role")]
	public AccessRole Role { get; set; }

	/// <summary>
	/// Массив идентификаторов клиента.
	/// </summary>
	[JsonProperty("clients_ids")]
	public int[] ClientsIds { get; set; }

	/// <summary>
	/// Доступ ко всем текущим и новым клиентам этого кабинета.
	/// </summary>
	[JsonProperty("grant_access_to_all_clients")]
	public bool GrantAccessToAllClients { get; set; }

	/// <summary>
	/// Показывать ли бюджет пользователю.
	/// </summary>
	[JsonProperty("view_budget")]
	public bool? ViewBudget { get; set; }
}