using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
    /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
    /// </summary>
    public sealed class LinkAccessType : SafetyEnum<LinkAccessType>
	{
        /// <summary>
        /// Cсылка не заблокирована
        /// </summary>
        public static readonly LinkAccessType NotBanned = RegisterPossibleValue("not_banned");

        /// <summary>
        /// Cсылка заблокирована
        /// </summary>
        public static readonly LinkAccessType Banned = RegisterPossibleValue("banned");

        /// <summary>
        /// Cсылка проверяется; необходимо выполнить повторный запрос через несколько секунд
        /// </summary>
        public static readonly LinkAccessType Processing = RegisterPossibleValue("processing");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static LinkAccessType FromJson (VkResponse response)
        {
            string status = response["status"];

			switch (status)
			{
				case "banned":
					{
						return Banned;
					}
				case "not_banned":
					{
						return NotBanned;
					}
				case "processing":
					{
						return Processing;
					}
				default:
					{
						return null;
					}
			}
		}
    }
}