using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Метка в списке друзей
    /// </summary>
    public class FriendList
    {
        /// <summary>
        /// Идентификатор метки
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название метки
        /// </summary>
        public string Name { get; set; }

        #region Internal Methods

        internal static FriendList FromJson(VkResponse response)
        {
            var list = new FriendList();

            list.Id = response["lid"];
            list.Name = response["name"];

            return list;
        }

        #endregion
    }
}