
namespace VkNet.Model
{
    using System;
    using System.Diagnostics;

    using Utils;
    using Enums;

    [DebuggerDisplay("[{AdminId}] {Comment} ({Reason})")][Serializable]
    /// <summary>
    /// Информация о забанненом (добавленном в черный список) пользователе сообщества.
    /// </summary>
    /// <remarks>
    /// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getBanned"/>.
    /// </remarks>
    public class BanInfo
    {
        /// <summary>
        /// Идентификатор администратора, который добавил пользователя в черный список.
        /// </summary>
        public long? AdminId { get; set; }

        /// <summary>
        /// Дата добавления пользователя в черный список.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Текст комментария к бану.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата, когда пользователь будет разбанен.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Причина добавления пользователя в черный список.
        /// </summary>
        public BanReason Reason { get; set; }

        #region Методы

        internal static BanInfo FromJson(VkResponse response)
        {
            var info = new BanInfo();

            info.AdminId = response["admin_id"];
            info.Date = response["date"];
            info.Comment = response["comment"];
            info.EndDate = response["end_date"];
            info.Reason = response["reason"];

            return info;
        }

        #endregion
    }
}