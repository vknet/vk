namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип канала новостей.
	/// </summary>
	public sealed class PhotoFeedType : SafetyEnum<PhotoFeedType>
	{
		/// <summary>
		/// Фото.
		/// </summary>
		public static PhotoFeedType Photo = RegisterPossibleValue("photo");

		/// <summary>
		/// Тег фото.
		/// </summary>
		public static PhotoFeedType PhotoTag = RegisterPossibleValue("photo_tag");
	}
}