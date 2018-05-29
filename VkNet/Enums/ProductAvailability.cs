using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Статус доступности товара
	/// </summary>
	[Serializable]
	public enum ProductAvailability
	{
		/// <summary>
		/// Товар доступен
		/// </summary>
		Available = 0

		, /// <summary>
		/// Товар удален
		/// </summary>
		Removed

		, /// <summary>
		/// Товар недоступен
		/// </summary>
		[DefaultValue]
		Unavailable
	}
}