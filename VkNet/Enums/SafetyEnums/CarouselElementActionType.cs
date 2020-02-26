namespace VkNet.Enums.SafetyEnums
{
	/// <inheritdoc />
	public class CarouselElementActionType : SafetyEnum<CarouselElementActionType>
	{
		/// <summary>
		/// Открывает указанную ссылку.
		/// </summary>
		public static readonly CarouselElementActionType OpenLink = RegisterPossibleValue("open_link");

		/// <summary>
		/// Открывает фото текущего элемента карусели.
		/// </summary>
		public static readonly CarouselElementActionType OpenPhoto = RegisterPossibleValue("open_photo");
	}
}