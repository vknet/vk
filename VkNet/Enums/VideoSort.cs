namespace VkNet.Enums
{
	/// <summary>
	/// Способ сортировки видеозаписей.
	/// </summary>
	public enum VideoSort
	{
		/// <summary>
		/// По дате добавления видеозаписи.
		/// </summary>
		AddedDate = 0

		, /// <summary>
		/// По длительности видеозаписи.
		/// </summary>
		Duration = 1

		, /// <summary>
		/// По релевантности видеозаписи запросу.
		/// </summary>
		Relevance = 2
	}
}