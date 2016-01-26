using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Возможные значения параметра VideoCatalogType, задающего внешний вид окна авторизации.
	/// </summary>
	public sealed class VideoCatalogType : SafetyEnum<VideoCatalogType>
	{
		/// <summary>
		/// Видеозаписи сообщества.
		/// </summary>
		[DefaultValue]
		public static readonly VideoCatalogType Channel = RegisterPossibleValue("channel");

		/// <summary>
		/// Подборки видеозаписей.
		/// </summary>
		public static readonly VideoCatalogType Category = RegisterPossibleValue("category");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static VideoCatalogType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "channel":
					{
						return Channel;
					}
				case "category":
					{
						return Category;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}