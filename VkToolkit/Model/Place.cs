namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    public class Place
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long TypeId { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public string Address { get; set; }

        internal static Place FromJson(VkResponse place)
        {
            // TODO: TEST IT!!!!!
            var result = new Place();

            result.Id = place["place_id"];
            result.Title = place["title"];
            result.TypeId = place["type"];
            result.CountryId = place["country_id"];
            result.CityId = place["city_id"];
            result.Address = place["address"];

            return result;
        }
    }
}