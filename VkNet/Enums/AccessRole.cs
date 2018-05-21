namespace VkNet.Enums
{
    /// <summary>
    /// Права пользователя в рекламном кабинете.
    /// </summary>
    public enum AccessRole
    {
        /// <summary>
        /// Главный администратор
        /// </summary>
        Admin = 0,
        /// <summary>
        /// Администратор
        /// </summary>
        Manager = 1,
        /// <summary>
        /// Наблюдатель
        /// </summary>
        Reports = 2
    }
}
