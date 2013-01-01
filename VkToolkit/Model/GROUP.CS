using VkToolkit.Enum;

namespace VkToolkit.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsAdmin { get; set; }
        public string Photo { get; set; }
        public string PhotoMedium { get; set; }
        public string PhotoBig { get; set; }
        public string ScreenName { get; set; }
        public GroupType Type { get; set; }
    }
}