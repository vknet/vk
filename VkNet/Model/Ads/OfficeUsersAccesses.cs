using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class OfficeUsersAccesses
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("client_id")]
		public long ClientId { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("role")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AccessRole Role { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static OfficeUsersAccesses FromJson(VkResponse response)
		{
			return new OfficeUsersAccesses
			{
				ClientId = response["client_id"],
				Role = response["role"]
			};
		}
	}
}