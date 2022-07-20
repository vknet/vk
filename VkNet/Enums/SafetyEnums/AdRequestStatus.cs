namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Текущий статус запроса
	/// </summary>
	public sealed class AdRequestStatus : SafetyEnum<AdRequestStatus>
	{
		/// <summary>
		/// Поиск выполняется.
		/// </summary>
		public static readonly AdRequestStatus SearchInProgress = RegisterPossibleValue("search_in_progress");

		/// <summary>
		/// Поиск завершён.
		/// </summary>
		public static readonly AdRequestStatus SearchDone = RegisterPossibleValue("search_done");

		/// <summary>
		/// Ошибка поиска.
		/// </summary>
		public static readonly AdRequestStatus SearchFailed = RegisterPossibleValue("search_failed");

		/// <summary>
		/// Сохранение выполняется.
		/// </summary>
		public static readonly AdRequestStatus SaveInProgress = RegisterPossibleValue("save_in_progress");

		/// <summary>
		/// Сохранение завершено.
		/// </summary>
		public static readonly AdRequestStatus SaveDone = RegisterPossibleValue("save_done");

		/// <summary>
		/// Ошибка сохранения.
		/// </summary>
		public static readonly AdRequestStatus SaveFailed = RegisterPossibleValue("save_failed");
	}
}
