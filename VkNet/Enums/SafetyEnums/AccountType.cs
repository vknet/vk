namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Тип рекламного кабинета.
    /// </summary>
    public sealed class AccountType : SafetyEnum<AccountType>
    {
        /// <summary>
        /// Обычный
        /// </summary>
        public static readonly AccountType General = RegisterPossibleValue("general");

        /// <summary>
        /// Обычный
        /// </summary>
        public static readonly AccountType Agency = RegisterPossibleValue("agency");
    }
}
