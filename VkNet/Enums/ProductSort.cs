using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Вид сортировки товаров.
	/// </summary>
	public enum ProductSort
	{
		/// <summary>
		/// 0 — пользовательская расстановка
		/// </summary>
		[DefaultValue]
		UserSort = 0

		, /// <summary>
		/// 1 — по дате добавления товара
		/// </summary>
		ByAdd

		, /// <summary>
		/// 2 — по цене
		/// </summary>
		ByCost

		, /// <summary>
		/// 3 — по популярности
		/// </summary>
		ByPopularity
	}
}