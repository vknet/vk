using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Действие кнопки
    /// </summary>
    public class LinkButtonAction
    {
        /// <summary>
		/// Тип действия. Возможные значения.
		/// </summary>
		public string Type { get; set; }

        /// <summary>
        /// Ссылка на которую ведет кнопка.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static LinkButtonAction FromJson(VkResponse response)
        {
            return new LinkButtonAction
            {
                Type = response["type"],
                Uri = response["url"]
            };
        }
    }
}
