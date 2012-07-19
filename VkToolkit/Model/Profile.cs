namespace VkToolkit.Model
{
    public class Profile
    {
        public long Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string ScreenName { get; set; }
        public int? Sex { get; set; }
        public string BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Timezone { get; set; }
        public string Photo { get; set; }
        public string PhotoMedium { get; set; }
        public string PhotoBig { get; set; }
        public int? HasMobile { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Rate { get; set; }
        public string Contacts { get; set; }
        public Education Education { get; set; }
        public int? Online { get; set; }
        public Counters Counters { get; set; }
        public string NameGen { get; set; }
    }
}