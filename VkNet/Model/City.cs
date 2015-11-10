using VkNet.Utils;

namespace VkNet.Model
{
    using System;

    /// <summary>
    /// Город.
    /// </summary>
    /// <remarks>
    /// Страница документации ВКонтакте <see href="http://vk.com/dev/database.getCities"/>.
    /// </remarks>
    [Serializable]
    public class City
    {
        /// <summary>
        /// Идентификатор города.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Район.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Область.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Является ли город основным.
        /// </summary>
        public bool Important { get; set; }

        #region Inernal Methods

        internal static City FromJson(VkResponse response)
        {
            var city = new City();

            VkResponse id = response["cid"] ?? response["id"];
            city.Id = Convert.ToInt64(id.ToString());
            city.Title = response["title"] ?? response["name"];
            city.Area = response["area"];
            city.Region = response["region"];
            city.Important = response["important"] ?? false;

            return city;
        }

        #endregion
    }
}