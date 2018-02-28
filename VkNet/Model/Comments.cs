using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Информация о количестве комментариев к записи.
    /// См. описание http://vk.com/dev/post
    /// </summary>
    [Serializable]
    public class Comments
    {
        /// <summary>
        /// Количество комментариев к записи.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Признак может ли текущий пользователь добавить комментарий к записи.
        /// </summary>
        public bool CanPost { get; set; }

        /// <summary>
        /// Информация о том, могут ли сообщества комментировать запись..
        /// </summary>
        public bool GroupsCanPost { get; set; }

        #region Методы

        #endregion

        /// <summary>
        /// Разобрать из JSON.
        /// </summary>
        /// <param name="response">Ответ от vk.</param>
        /// <returns></returns>
        public static Comments FromJson(VkResponse response)
        {
            return new Comments
            {
                Count = response["count"],
                CanPost = response["can_post"],
                GroupsCanPost = response["groups_can_post"]
            };
        }
    }
}