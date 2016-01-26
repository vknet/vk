using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип элемента каталога.
	/// </summary>
	public sealed class VideoCatalogItemType : SafetyEnum<VideoCatalogItemType>
	{
		/// <summary>
		/// Видеоролик.
		/// </summary>
		public static readonly VideoCatalogItemType Video = RegisterPossibleValue("video");

		/// <summary>
		/// Альбом.
		/// </summary>
		public static readonly VideoCatalogItemType Album = RegisterPossibleValue("album");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static VideoCatalogItemType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "video":
					{
						return Video;
					}
				case "album":
					{
						return Album;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}