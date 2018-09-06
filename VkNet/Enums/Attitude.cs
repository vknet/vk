using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Отношение к чему-либо (алкоголю, курению и т.п.).
	/// </summary>
	public enum Attitude
	{
		/// <summary>
		/// Не указано.
		/// </summary>
		[DefaultValue]
		Unknown = 0

		, /// <summary>
		/// Резко негативное.
		/// </summary>
		VeryNegative = 1

		, /// <summary>
		/// Негативное.
		/// </summary>
		Negative = 2

		, /// <summary>
		/// Компромиссное.
		/// </summary>
		Compromise = 3

		, /// <summary>
		/// Нейтральное.
		/// </summary>
		Neutral = 4

		, /// <summary>
		/// Положительное.
		/// </summary>
		Positive = 5
	}
}