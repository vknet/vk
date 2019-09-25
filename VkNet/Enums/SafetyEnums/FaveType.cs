using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Тип объекта, добавленного в закладки.
	/// </summary>
	public sealed class FaveType : SafetyEnum<FaveType>
	{
		/// <summary>
		/// Запись на стене.
		/// </summary>
		public static readonly FaveType Post = RegisterPossibleValue("post");

		/// <summary>
		/// Видеозапись.
		/// </summary>
		public static readonly FaveType Video = RegisterPossibleValue("video");

		/// <summary>
		/// Товар.
		/// </summary>
		public static readonly FaveType Product = RegisterPossibleValue("product");

		/// <summary>
		/// Статья.
		/// </summary>
		public static readonly FaveType Article = RegisterPossibleValue("article");

		/// <summary>
		/// Ссылки.
		/// </summary>
		public static readonly FaveType Link = RegisterPossibleValue("link");

		/// <summary>
		/// Подкаст.
		/// </summary>
		public static readonly FaveType Podcast = RegisterPossibleValue("podcast");
	}
}