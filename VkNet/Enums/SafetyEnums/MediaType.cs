namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип медиавложения.
	/// </summary>
	public sealed class MediaType : SafetyEnum<MediaType>
	{
		/// <summary>
		/// Фотографии.
		/// </summary>
		public static readonly MediaType Photo = RegisterPossibleValue(value: "photo");

		/// <summary>
		/// Видеозаписи.
		/// </summary>
		public static readonly MediaType Video = RegisterPossibleValue(value: "video");

		/// <summary>
		/// Аудиозаписи.
		/// </summary>
		public static readonly MediaType Audio = RegisterPossibleValue(value: "audio");

		/// <summary>
		/// Документы.
		/// </summary>
		public static readonly MediaType Doc = RegisterPossibleValue(value: "doc");

		/// <summary>
		/// Ссылки.
		/// </summary>
		public static readonly MediaType Link = RegisterPossibleValue(value: "link");

		/// <summary>
		/// Товары.
		/// </summary>
		public static readonly MediaType Market = RegisterPossibleValue(value: "market");

		/// <summary>
		/// Записи.
		/// </summary>
		public static readonly MediaType Wall = RegisterPossibleValue(value: "wall");

		/// <summary>
		/// Ссылки, товары и записи.
		/// </summary>
		public static readonly MediaType Share = RegisterPossibleValue(value: "share");
	}
}