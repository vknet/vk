namespace VkNet.Model
{
	using VkNet.Utils;

	/// <summary>
	/// Информация о сообществе (группе).
	/// См. описание <see href="http://vk.com/dev/fields_groups"/>.
	/// </summary>
	public class GroupMember
	{
		#region Стандартные поля

		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		public long UserId
		{ get; set; }

		/// <summary>
		/// Название сообщества.
		/// </summary>
		public bool Member
		{ get; set; }

		/// <summary>
		/// Короткий адрес страницы сообщества, например, apiclub. Если он не назначен, то 'club'+gid, например, club35828305.
		/// </summary>
		public bool Request
		{ get; set; }

		/// <summary>
		/// Публичность группы.
		/// </summary>
		public bool Invitation
		{ get; set; }
		#endregion

		#region Методы

		/// <summary>
		/// Десериализовать из Json.
		/// </summary>
		/// <param name="response">Jndtn.</param>
		/// <returns></returns>
		internal static GroupMember FromJson(VkResponse response)
		{
			var group = new GroupMember();

			group.UserId = response["user_id"];
			group.Member = response["member"];
			group.Request = response["request"];
			group.Invitation = response["invitation"];

			return group;
		}

		#endregion
	}
}