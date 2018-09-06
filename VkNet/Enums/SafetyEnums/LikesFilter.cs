namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Указывает, следует ли вернуть всех пользователей, добавивших объект в список
	/// "Мне нравится" или только тех, которые
	/// рассказали о нем друзьям
	/// </summary>
	public sealed class LikesFilter : SafetyEnum<LikesFilter>
	{
		/// <summary>
		/// Возвращать информацию обо всех пользователях
		/// </summary>
		public static readonly LikesFilter Likes = RegisterPossibleValue(value: "likes");

		/// <summary>
		/// Возвращать информацию только о пользователях, рассказавших об объекте друзьям.
		/// </summary>
		public static readonly LikesFilter Copies = RegisterPossibleValue(value: "copies");
	}
}