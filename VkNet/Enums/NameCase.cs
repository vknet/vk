namespace VkNet.Enums
{
    /// <summary>
    /// Падеж
    /// </summary>
    public class NameCase
    {
        private readonly string _name;

        /// <summary>
        /// Именительный
        /// </summary>
        public static readonly NameCase Nom = new NameCase("nom");

        /// <summary>
        /// Родительный
        /// </summary>
        public static readonly NameCase Gen = new NameCase("gen");

        /// <summary>
        /// Дательный
        /// </summary>
        public static readonly NameCase Dat = new NameCase("dat");

        /// <summary>
        /// Винительный
        /// </summary>
        public static readonly NameCase Acc = new NameCase("acc");

        /// <summary>
        /// Творительный
        /// </summary>
        public static readonly NameCase Ins = new NameCase("ins");

        /// <summary>
        /// Предложный
        /// </summary>
        public static readonly NameCase Abl = new NameCase("abl");

        private NameCase(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}