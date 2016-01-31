using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Способ сортировки приложений
	/// </summary>
	public sealed class PostTypeOrder : SafetyEnum<PostTypeOrder>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly PostTypeOrder Post = RegisterPossibleValue("post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostTypeOrder Copy = RegisterPossibleValue("copy");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PostTypeOrder FromJson(VkResponse response)
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
				default:
					{
						return null;
					}
			}
		}
	}
}