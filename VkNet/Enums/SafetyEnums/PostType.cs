using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Тип записи post, copy, reply, postpone, suggest
    /// </summary>
    public sealed class PostType : SafetyEnum<PostType>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly PostType Post = RegisterPossibleValue("post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Copy = RegisterPossibleValue("copy");

        /// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Reply = RegisterPossibleValue("reply");

        /// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Postpone = RegisterPossibleValue("postpone");

        /// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostType Suggest = RegisterPossibleValue("suggest");
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        internal static PostType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "post":
					{
						return Post;
					}
				case "copy":
					{
						return Copy;
					}
                case "reply":
                    {
                        return Reply;
                    }
                case "postpone":
                    {
                        return Postpone;
                    }
                case "suggest":
                    {
                        return Suggest;
                    }
                default:
					{
						return null;
					}
			}
		}
	}
}