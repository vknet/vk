using VkNet.Utils;

namespace VkNet.Model
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
			var list = new FriendList
			{
				Id = response["lid"],
				Name = response["name"]
			};

			return list;
		}

		#endregion
	}
}