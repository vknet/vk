namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Cписок критериев, по которым требуется отфильтровать видео.
	/// </summary>
	public sealed class VideoFilters : MultivaluedFilter<VideoFilters>
	{
		/// <summary>
		/// Возвращать видео в формате mp4 (воспроиводимое на iOS).
		/// </summary>
		public static readonly VideoFilters Mp4 = RegisterPossibleValue(mask: 1 << 0, value: "mp4");

		/// <summary>
		/// Возвращать youtube видео.
		/// </summary>
		public static readonly VideoFilters Youtube = RegisterPossibleValue(mask: 1 << 1, value: "youtube");

		/// <summary>
		/// Возвращать vimeo видео.
		/// </summary>
		public static readonly VideoFilters Vimeo = RegisterPossibleValue(mask: 1 << 2, value: "vimeo");

		/// <summary>
		/// Возвращать короткие видеозаписи.
		/// </summary>
		public static readonly VideoFilters Short = RegisterPossibleValue(mask: 1 << 3, value: "short");

		/// <summary>
		/// Возвращать длинные видеозаписи
		/// </summary>
		public static readonly VideoFilters Long = RegisterPossibleValue(mask: 1 << 4, value: "long");

		/// <summary>
		/// Возвращать все доступные виды видео.
		/// </summary>
		public static readonly VideoFilters All = Mp4|Youtube|Vimeo|Short|Long;
	}
}