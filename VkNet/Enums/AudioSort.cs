namespace VkNet.Enums
{
	/// <summary>
	/// Способ сортировки аудиозаписей.
	/// </summary>
	public enum AudioSort
	{
		/// <summary>
		/// Сортировать по дате добавления.
		/// </summary>
		AddedDate = 0

		, /// <summary>
		/// Сортировать подлительности.
		/// </summary>
		Duration = 1

		, /// <summary>
		/// Сортировать по популярности.
		/// </summary>
		Popularity = 2
	}
}