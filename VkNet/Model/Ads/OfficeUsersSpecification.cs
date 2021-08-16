using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
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
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
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

		public OfficeUsersSpecification FromJson(VkResponse response)
		{
			return new OfficeUsersSpecification
			{
				UserId = response["user_id"],
				Role = response["role"],
				ClientsIds = response["client_ids"].ToListOf<int>(x => x).ToArray(),
				GrantAccessToAllClients = response["grant_access_to_all_clients"]
			};
		}
	}
}