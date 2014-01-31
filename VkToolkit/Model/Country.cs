using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Информация о стране
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Идентификатор страны
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Title { get; set; }

        #region Internal Methods
        internal static Country FromJson(VkResponse response)
        {
            var country = new Country();

            country.Id = response["cid"];
            country.Title = response["title"] ?? response["name"];

            return country;
        }
        #endregion
    }
}