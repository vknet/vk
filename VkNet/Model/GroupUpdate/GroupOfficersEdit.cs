using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Infrastructure;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Редактирование списка руководителей
	/// </summary>
	[Serializable]
	public class GroupOfficersEdit : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор администратора, который внёс пользователя в чёрный список
		/// </summary>
		[JsonProperty("admin_id")]
		public long? AdminId { get; set; }

		/// <summary>
		/// Новый уровень полномочий
		/// </summary>
		[JsonProperty("level_new")]
		public GroupOfficerLevel? LevelNew { get; set; }

		/// <summary>
		/// Старый уровень полномочий
		/// </summary>
		[JsonProperty("level_old")]
		public GroupOfficerLevel? LevelOld { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static GroupOfficersEdit FromJson(VkResponse response)
		{
			return JsonConvert.DeserializeObject<GroupOfficersEdit>(response.ToString(), JsonConfigure.JsonSerializerSettings);
		}

		/// <summary>
		/// Преобразование класса <see cref="GroupOfficersEdit" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="GroupOfficersEdit" /> </returns>
		public static implicit operator GroupOfficersEdit(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}