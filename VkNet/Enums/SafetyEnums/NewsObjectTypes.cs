using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Названия списков новостей, которые необходимо получить.
	/// </summary>
	public sealed class NewsObjectTypes : SafetyEnum<NewsObjectTypes>
	{
		/// <summary>
		/// запись на стене;.
		/// </summary>
		public static readonly NewsObjectTypes Wall = RegisterPossibleValue("wall");


		/// <summary>
		/// отметка на фотографии;.
		/// </summary>
		public static readonly NewsObjectTypes Tag = RegisterPossibleValue("tag");


		/// <summary>
		/// фотография профиля;.
		/// </summary>
		public static readonly NewsObjectTypes ProfilePhoto = RegisterPossibleValue("profilephoto");


		/// <summary>
		/// видеозапись;.
		/// </summary>
		public static readonly NewsObjectTypes Video = RegisterPossibleValue("video");


		/// <summary>
		/// фотография;.
		/// </summary>
		public static readonly NewsObjectTypes Photo = RegisterPossibleValue("photo");


		/// <summary>
		/// аудиозапись..
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
					return Wall;
				case "tag":
					return Tag;
				case "profilephoto":
					return ProfilePhoto;
				case "video":
					return Video;
				case "photo":
					return Photo;
				case "audio":
					return Audio;
			}

			return null;
		}
	}
}