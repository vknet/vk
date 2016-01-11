using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Статус доступности товара
	/// </summary>
	public enum ProductAvailability
	{
		/// <summary>
		/// Товар доступен
		/// </summary>
		Available = 0,
		/// <summary>
		/// Товар удален
		/// </summary>
		Removed,
		/// <summary>
		/// Товар недоступен
		/// </summary>
		[DefaultValue]
		Unavailable
	}
}