using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Улица
    /// </summary>
    public class Street
    {
        /// <summary>
        /// Идентификатор улицы
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название улицы
        /// </summary>
        public string Title { get; set; }

        #region Internal Methods

        internal static Street FromJson(VkResponse response)
		{
			var street = new Street
			{
				Id = response["sid"],
				Title = response["name"]
			};

			return street;
		}

		#endregion
	}
}