using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Область
        /// </summary>
        public string Region { get; set; }
        public bool Important { get; set; }

        #region Inernal Methods

        internal static City FromJson(VkResponse response)
        {
            var city = new City();

            city.Id = response["cid"];
            city.Title = response["title"] ?? response["name"];
            city.Area = response["area"];
            city.Region = response["region"];
            city.Important = response["important"] ?? false;

            return city;
        }

        #endregion
    }
}