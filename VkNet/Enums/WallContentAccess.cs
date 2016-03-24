namespace VkNet.Enums
{
	/// <summary>
	/// Уровень доступа к содержимому.
	/// </summary>
	public enum WallContentAccess
	{
		/// <summary>
		/// Выключены
		/// </summary>
		Off = 0,
		/// <summary>
		/// Открытые
		/// </summary>
		Opened,
		/// <summary>
		/// Ограниченные
		/// </summary>
		Restricted,
		/// <summary>
		/// Закрытая
		/// </summary>
		Closed
	}
}