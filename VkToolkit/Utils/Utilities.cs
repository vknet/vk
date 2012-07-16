using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Model;

namespace VkToolkit.Utils
{
    public static class Utilities
    {
        public static Audio GetAudioFromJObject(JObject audio)
        {
            // todo case when album id is not null
            var output = new Audio
                             {
                                 Id = (long)audio["aid"],
                                 OwnerId = (long)audio["owner_id"],
                                 Duration = (int)audio["duration"],
                                 Artist = (string)audio["artist"],
                                 Title = (string)audio["title"],
                                 Url = new Uri((string)audio["url"]),
                                 Performer = (string) audio["performer"]
                             };

            if (audio["lyrics_id"] != null)
                output.LyricsId = Convert.ToInt64((string) audio["lyrics_id"]);
            
            return output;
        }

        public static Profile GetProfileFromJObject(JObject current)
        {
            var profile = new Profile
            {
                Uid = (long) current["uid"],
                FirstName = (string) current["first_name"],
                LastName = (string) current["last_name"],
                Nickname = (string) current["nickname"],
                ScreenName = (string) current["screen_name"],
                Sex = (int?) current["sex"],
                BirthDate = (string) current["bdate"],
                City = (string) current["city"],
                Country = (string) current["country"],
                Timezone = (int?) current["timezone"],
                Photo = (string) current["photo"],
                PhotoMedium = (string) current["photo_medium"],
                PhotoBig = (string) current["photo_big"],
                HasMobile = (int?) current["has_mobile"],
                Rate = (string) current["rate"],
                MobilePhone = (string) current["mobile_phone"],
                HomePhone = (string) current["home_phone"],
                Online = (int?) current["online"]
            };

            if (current["university"] != null)
            {
                profile.Education = new Education
                {
                    UniversityId = (string)current["university"],
                    UniversityName = (string)current["university_name"],
                    FacultyId = (string)current["faculty"],
                    FacultyName = (string)current["faculty_name"],
                    Graduation = (string)current["graduation"]
                };
            }

            if (current["counters"] != null)
            {
                var counters = (JObject)current["counters"];

                profile.Counters = new Counters
                {
                    Albums = (int)counters["albums"],
                    Videos = (int)counters["videos"],
                    Audios = (int)counters["audios"],
                    Notes = (int)counters["notes"],
                    Photos = (int)counters["photos"],
                    Groups = (int)counters["groups"],
                    Friends = (int)counters["friends"],
                    OnlineFriends = (int)counters["online_friends"],
                    UserPhotos = (int)counters["user_photos"],
                    UserVideos = (int)counters["user_videos"],
                    Followers = (int)counters["followers"],
                    Subscriptions = (int)counters["subscriptions"]
                };
            }

            return profile;
        }

        public static Group GetGroupFromJObject(JObject group)
        {
            var output = new Group
            {
                Id = (long)group["gid"],
                Name = (string)group["name"],
                Link = (string)group["link"],
                Photo = (string)group["photo"],
                PhotoMedium = (string)group["photo_medium"],
                PhotoBig = (string)group["photo_big"],
                ScreenName = (string)group["screen_name"],
            };

            var isClosed = (int?)group["is_closed"];
            var isAdmin = (int?)group["is_admin"];

            if (isClosed.HasValue)
            {
                output.IsClosed = isClosed.Value == 1;
            }

            if (isAdmin.HasValue)
            {
                output.IsAdmin = isAdmin.Value == 1;
            }
            else
                output.IsAdmin = false;

            output.Type = GetGroupType((string)group["type"]);

            return output;
        }

        public static GroupType GetGroupType(string type)
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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();
            return dt;
        }

        public static FriendStatus GetFriendStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return FriendStatus.NotFriend;

                case 1:
                    return FriendStatus.OutputRequest;

                case 2:
                    return FriendStatus.InputRequest;

                case 3:
                    return FriendStatus.Friend;
                    
                default:
                    throw new ArgumentException("friend_status not defined!", "status");
            }
        }

        public static string GetEnumerationAsString(IEnumerable<long> uids)
        {
            var uidsLst = uids.ToList();
            string ids = "";
            for (int i = 0; i < uidsLst.Count; i++)
            {
                ids += uidsLst[i];
                if (i != uidsLst.Count - 1)
                    ids += ",";
            }

            return ids;
        }
    }
}