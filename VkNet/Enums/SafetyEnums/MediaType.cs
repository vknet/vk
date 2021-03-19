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
		public static readonly MediaType Photo = RegisterPossibleValue("photo");

		/// <summary>
		/// Видеозаписи.
		/// </summary>
		public static readonly MediaType Video = RegisterPossibleValue("video");

		/// <summary>
		/// Аудиозаписи.
		/// </summary>
		public static readonly MediaType Audio = RegisterPossibleValue("audio");

		/// <summary>
		/// Аудио сообщение
		/// </summary>
		public static readonly MediaType AudioMessage = RegisterPossibleValue("audio_message");

		/// <summary>
		/// Документы.
		/// </summary>
		public static readonly MediaType Doc = RegisterPossibleValue("doc");

		/// <summary>
		/// Ссылки.
		/// </summary>
		public static readonly MediaType Link = RegisterPossibleValue("link");

		/// <summary>
		/// Товары.
		/// </summary>
		public static readonly MediaType Market = RegisterPossibleValue("market");

		/// <summary>
		/// Записи.
		/// </summary>
		public static readonly MediaType Wall = RegisterPossibleValue("wall");

		/// <summary>
		/// Ссылки, товары и записи.
		/// </summary>
		public static readonly MediaType Share = RegisterPossibleValue("share");

		/// <summary>
		/// Граффити.
		/// </summary>
		public static readonly MediaType Graffiti = RegisterPossibleValue("graffiti");
	}
}