namespace VkNet.Enums
{
    /// <summary>
    /// Тип жалобы
    /// </summary>
    public class ReportType
    {
        private readonly string _name;

        private ReportType(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        /// <summary>
        /// Порнография
        /// </summary>
        public static readonly ReportType Porn = new ReportType("porn");

        /// <summary>
        /// Рассылка спама
        /// </summary>
        public static readonly ReportType Spam = new ReportType("spam");

        /// <summary>
        /// Оскорбительное поведение
        /// </summary>
        public static readonly ReportType Insult = new ReportType("insult");

        /// <summary>
        /// Рекламная страница, засоряющая поиск
        /// </summary>
        public static readonly ReportType Advertisment = new ReportType("advertisment");
    }
}