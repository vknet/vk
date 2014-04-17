namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Падеж.
    /// </summary>
    public sealed class NameCase : SafetyEnum<NameCase>
    {
        /// <summary>
        /// Именительный.
        /// </summary>
        public static readonly NameCase Nom = RegisterPossibleValue("nom");

        /// <summary>
        /// Родительный.
        /// </summary>
        public static readonly NameCase Gen = RegisterPossibleValue("gen");

        /// <summary>
        /// Дательный.
        /// </summary>
        public static readonly NameCase Dat = RegisterPossibleValue("dat");

        /// <summary>
        /// Винительный.
        /// </summary>
        public static readonly NameCase Acc = RegisterPossibleValue("acc");

        /// <summary>
        /// Творительный.
        /// </summary>
        public static readonly NameCase Ins = RegisterPossibleValue("ins");

        /// <summary>
        /// Предложный.
        /// </summary>
        public static readonly NameCase Abl = RegisterPossibleValue("abl");
    }
}