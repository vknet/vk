using System;
using VkToolkit.Enum;

namespace VkToolkit.Model
{
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsMember { get; set; }
        public string Photo { get; set; }
        public string PhotoMedium { get; set; }
        public string PhotoBig { get; set; }
        public string ScreenName { get; set; }
        public GroupType Type { get; set; }

        // additional information
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public string WikiPage { get; set; }
    }
}