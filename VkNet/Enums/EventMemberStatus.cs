namespace VkNet.Enums
{
	/// <summary>
	/// Идёт ли текущий пользователь на встречу.
	/// </summary>
	public enum EventMemberStatus
	{
		/// <summary>
		/// Точно идёт
		/// </summary>
		Exactly = 1,

		/// <summary>
		/// Возможно пойдёт
		/// </summary>
		Possible = 2,

		/// <summary>
		/// Не идёт
		/// </summary>
		NotGoing = 3
	}
}