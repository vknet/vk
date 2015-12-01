using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Способ сортировки приложений
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
				case "Copy":
					{
						return Copy;
					}
			}

			return null;
		}
	}
}