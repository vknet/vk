
namespace VkNet.Model
{
    using System;
    using System.Diagnostics;

    using Utils;
    using Enums;

    /// <summary>
    /// Информация о забанненом (добавленном в черный список) пользователе сообщества.
    /// </summary>
    /// <remarks>
    /// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getBanned"/>.
    /// </remarks>
    [DebuggerDisplay("[{AdminId}] {Comment} ({Reason})")]
    [Serializable]
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
			var info = new BanInfo
			{

				AdminId = response["admin_id"],
				Date = response["date"],
				Comment = response["comment"],
				EndDate = response["end_date"],
				Reason = response["reason"]
			};

			return info;
		}

		#endregion
	}
}