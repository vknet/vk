namespace VkNet.Enums
{
    /// <summary>
    /// Фильтр для задания типов сообщений, которые необходимо получить со стены.
    /// </summary>
    public enum WallFilter
    {
        /// <summary>
        /// Необходимо получить сообщения на стене только от ее владельца.
        /// </summary>
        Owner,

        /// <summary>
        /// Необходимо получить сообщения на стене не от владельца стены.
        /// </summary>
        Others,

        /// <summary>
		/// Необходимо получить все сообщения на стене (Owner + Others).
        /// </summary>
        All,

		/// <summary>
		/// Отложенные записи
		/// </summary>
		Suggests,

		/// <summary>
		/// Предложенные записи на стене сообщества
		/// </summary>
		Postponed
    }
}