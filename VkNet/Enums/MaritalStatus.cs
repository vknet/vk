namespace VkNet.Enums
{
	/// <summary>
	/// Семейное положение: 1 — Не женат, 2 — Встречается, 3 — Помолвлен, 4 — Женат, 7
	/// — Влюблён, 5 — Всё сложно, 6 — В
	/// активном поиске.
	/// </summary>
	public enum MaritalStatus
	{
		/// <summary>
		/// Не женат
		/// </summary>
		Single = 1

		, /// <summary>
		/// Встречается
		/// </summary>
		Meets

		, /// <summary>
		/// Помолвлен
		/// </summary>
		Engaged

		, /// <summary>
		/// Женат
		/// </summary>
		Married

		, /// <summary>
		/// Всё сложно
		/// </summary>
		ItsComplicated

		, /// <summary>
		/// В активном поиске
		/// </summary>
		TheActiveSearch

		, /// <summary>
		/// Влюблён
		/// </summary>
		InLove
	}
}