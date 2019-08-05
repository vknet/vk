namespace VkNet.Enums
{
	/// <summary>
	/// </summary>
	public enum MemberStatus
	{
		/// <summary>
		/// не является участником
		/// </summary>
		NotParticipiant = 0,

		/// <summary>
		/// является участником
		/// </summary>
		Participiant = 1,

		/// <summary>
		/// не уверен, что посетит мероприятие
		/// </summary>
		NotShureThatVisist = 2,

		/// <summary>
		/// отклонил приглашение
		/// </summary>
		Rejected = 3,

		/// <summary>
		/// подал заявку на вступление
		/// </summary>
		SendRequest = 4,

		/// <summary>
		/// приглашен
		/// </summary>
		Invited = 5
	}
}