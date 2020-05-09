using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class GetOfficeUsersResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("accesses")]
		public ReadOnlyCollection<OfficeUsersAccesses> Accesses { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetOfficeUsersResult FromJson(VkResponse response)
		{
			return new GetOfficeUsersResult
			{
				UserId = response["user_id"],
				Accesses = response["accesses"].ToReadOnlyCollectionOf<OfficeUsersAccesses>()
			};
		}
	}
}