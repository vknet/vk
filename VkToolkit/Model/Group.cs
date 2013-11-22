using System;

using VkToolkit.Enums;
using VkToolkit.Utils;

namespace VkToolkit.Model
{    
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool? IsClosed { get; set; }
        public bool IsAdmin { get; set; }
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

        internal static Group FromJson(VkResponse group)
        {
            var result = new Group();

            result.Id = @group["gid"];
            result.Name = @group["name"];
            result.Link = @group["link"];
            result.Photo = @group["photo"];
            result.PhotoMedium = @group["photo_medium"];
            result.PhotoBig = @group["photo_big"];
            result.ScreenName = @group["screen_name"];
            result.Description = @group["description"];
            result.WikiPage = @group["wiki_page"];
            result.CityId = @group["city"];
            result.CountryId = @group["country"];
            result.StartDate = @group["start_date"];
            result.IsClosed = @group["is_closed"];
            result.IsMember = @group["is_member"];
            result.IsAdmin = @group["is_admin"];
            result.Type = GetGroupType(@group["type"]);

            return result;
        }

        internal static GroupType GetGroupType(string type)
        {
            switch (type)
            {
                case "page":
                    return GroupType.Page;
                case "event":
                    return GroupType.Event;
                case "group":
                    return GroupType.Group;
                default:
                    return GroupType.Undefined;
            }
        }
    }
}