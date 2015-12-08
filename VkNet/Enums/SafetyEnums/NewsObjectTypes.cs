using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Названия списков новостей, которые необходимо получить.
	/// </summary>
	public sealed class NewsObjectTypes : SafetyEnum<NewsObjectTypes>
	{
		/// <summary>
		/// Запись на стене.
		/// </summary>
		public static readonly NewsObjectTypes Wall = RegisterPossibleValue("wall");


		/// <summary>
		/// Отметка на фотографии.
		/// </summary>
		public static readonly NewsObjectTypes Tag = RegisterPossibleValue("tag");


		/// <summary>
		/// Фотография профиля.
		/// </summary>
		public static readonly NewsObjectTypes ProfilePhoto = RegisterPossibleValue("profilephoto");


		/// <summary>
		/// Видеозапись.
		/// </summary>
		public static readonly NewsObjectTypes Video = RegisterPossibleValue("video");


		/// <summary>
		/// Фотография.
		/// </summary>
		public static readonly NewsObjectTypes Photo = RegisterPossibleValue("photo");


		/// <summary>
		/// Аудиозапись.
		/// </summary>
		public static readonly NewsObjectTypes Audio = RegisterPossibleValue("audio");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static NewsObjectTypes FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "wall":
					{
						return Wall;
					}
				case "tag":
					{
						return Tag;
					}
				case "profilephoto":
					{
						return ProfilePhoto;
					}
				case "video":
					{
						return Video;
					}
				case "photo":
					{
						return Photo;
					}
				case "audio":
					{
						return Audio;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}