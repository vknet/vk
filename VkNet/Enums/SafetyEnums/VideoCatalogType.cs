using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Возможные значения параметра VideoCatalogType, задающего внешний вид окна
	/// авторизации.
	/// </summary>
	public sealed class VideoCatalogType : SafetyEnum<VideoCatalogType>
	{
		/// <summary>
		/// Видеозаписи сообщества.
		/// </summary>
		[DefaultValue]
		public static readonly VideoCatalogType Channel = RegisterPossibleValue(value: "channel");

		/// <summary>
		/// Подборки видеозаписей.
		/// </summary>
		public static readonly VideoCatalogType Category = RegisterPossibleValue(value: "category");
	}
}