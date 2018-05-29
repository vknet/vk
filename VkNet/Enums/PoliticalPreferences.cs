using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Политические предпочтения.
	/// </summary>
	public enum PoliticalPreferences
	{
		/// <summary>
		/// Не указаны.
		/// </summary>
		[DefaultValue]
		Unknown = 0

		, /// <summary>
		/// Коммунистические.
		/// </summary>
		Communist = 1

		, /// <summary>
		/// Социалистические.
		/// </summary>
		Socialist = 2

		, /// <summary>
		/// Умеренные.
		/// </summary>
		Moderate = 3

		, /// <summary>
		/// Либеральные.
		/// </summary>
		Liberal = 4

		, /// <summary>
		/// Консервативные.
		/// </summary>
		Conservative = 5

		, /// <summary>
		/// Монархические.
		/// </summary>
		Monarchist = 6

		, /// <summary>
		/// Ультраконсервативные.
		/// </summary>
		Ultraconservative = 7

		, /// <summary>
		/// Индифферентные.
		/// </summary>
		Apathetic = 8

		, /// <summary>
		/// Либертантские.
		/// </summary>
		Libertarian = 9
	}
}