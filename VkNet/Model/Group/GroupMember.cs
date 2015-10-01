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
		/// Является ли пользователь участником сообщества;
		/// </summary>
		public bool Member
		{ get; set; }

		/// <summary>
		/// Есть ли непринятая заявка от пользователя на вступление в группу (такую заявку можно отозвать методом groups.leave).
		/// </summary>
		public bool Request
		{ get; set; }

		/// <summary>
		/// Приглашён ли пользователь в группу или встречу.
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
			var group = new GroupMember()
			{
				UserId = response["user_id"],
				Member = response["member"],
				Request = response["request"],
				Invitation = response["invitation"]
			};

			return group;
		}

		#endregion
	}
}