namespace VkToolkit.Model
{
    public class Place
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long TypeId { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public string Address { get; set; }
    }
}