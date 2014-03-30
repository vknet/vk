namespace VkNet.Enums
{
    using Utils;

    /// <summary>
    /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
    /// </summary>
    public sealed class LinkAccessType
    {
        private readonly string _name;

        /// <summary>
        /// Cсылка не заблокирована
        /// </summary>
        public static readonly LinkAccessType NotBanned = new LinkAccessType("not_banned");

        /// <summary>
        /// Cсылка заблокирована
        /// </summary>
        public static readonly LinkAccessType Banned = new LinkAccessType("banned");

        /// <summary>
        /// Cсылка проверяется; необходимо выполнить повторный запрос через несколько секунд
        /// </summary>
        public static readonly LinkAccessType Processing = new LinkAccessType("processing");


        private LinkAccessType(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Возвращает в виде строки информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
        /// </summary>
        /// <returns>
        /// Строка информацией о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
        /// </returns>
        public override string ToString()
        {
            return _name;
        }

        internal static LinkAccessType FromJson (VkResponse response)
        {
            string status = response["status"];

            switch (status)
            {
                case "banned":
                    return Banned;

                case "not_banned":
                    return NotBanned;

                case "processing":
                    return Processing;
            }

            return null;
        }
    }
}