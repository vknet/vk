namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о месте, в котором была сделана запись.
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Идентификатор места.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название места.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Идентификатор типа места.
        /// </summary>
        public long TypeId { get; set; }
        /// <summary>
        /// Идентификатор страны, в котором находится место.
        /// </summary>
        public long? CountryId { get; set; }
        /// <summary>
        /// Страна, в которой находится место.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Идентификатор города.
        /// </summary>
        public long? CityId { get; set; }
        /// <summary>
        /// Город, в котором находится место.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Адрес места в городе.
        /// </summary>
        public string Address { get; set; }

        internal static Place FromJson(VkResponse place)
        {
            // TODO: TEST IT!!!!!
            var result = new Place();

            result.Id = place["place_id"];
            result.Title = place["title"];
            result.TypeId = place["type"];
            result.CountryId = place["country_id"];
            result.Country = place["country"];
            result.CityId = place["city_id"];
            result.City = place["city"];
            result.Address = place["address"];

            return result;
        }
    }
}