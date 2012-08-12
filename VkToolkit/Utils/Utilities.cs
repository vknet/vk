using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;

namespace VkToolkit.Utils
{
    internal static class Utilities
    {
        public static Lyrics GetLyrics(JObject lyrics)
        {
            var output = new Lyrics
                             {
                                 Id = (long) lyrics["lyrics_id"],
                                 Text = (string) lyrics["text"]
                             };
            return output;
        }

        public static Attachment GetAttachment(JObject att)
        {
            // UNDONE Complete it later
            var output = new Attachment();
            var type = (string) att["type"];
            switch (type)
            {
                case "audio":
                    output.Type = typeof (Audio);
                    output.Audio = GetAudioFromJObject((JObject)att["audio"]);
                    break;

                case "photo":
                    output.Type = typeof (Photo);
                    output.Photo = GetPhoto((JObject)att["photo"]);
                    break;

                case "posted_photo":
                    output.Type = typeof (Photo);
                    output.Photo = GetPhoto((JObject)att["posted_photo"]);
                    break;

                case "video":
                    output.Type = typeof (Video);
                    output.Video = GetVideo((JObject) att["video"]);
                    break;

                case "doc":
                    output.Type = typeof (Document);
                    output.Document = GetDocument((JObject)att["doc"]);
                    break;

                case "graffiti":
                    throw new NotImplementedException();
                    break;

                case "link":
                    throw new NotImplementedException();
                    break;

                case "note":
                    output.Type = typeof (Note);
                    output.Note = GetNote((JObject) att["note"]);
                    break;

                case "app":
                    throw new NotImplementedException();
                    break;

                case "poll":
                    throw new NotImplementedException();
                    break;

                case "page":
                    output.Type = typeof (Page);
                    output.Page = GetPage((JObject) att["page"]);
                    break;

                default:
                    throw new InvalidParamException("The type of attachment is not defined.");
            }

            return output;
        }

        public static Page GetPage(JObject page)
        {
            var output = new Page();
            output.Id = (long?) page["pid"];
            output.GroupId = (long?) page["group_id"];
            output.CreatorId = (long?) page["creator_id"];
            output.Title = (string) page["title"];
            output.Source = (string) page["source"];

            if (page["current_user_can_edit"] != null)
            {
                output.CurrentUserCanEdit = (int)page["current_user_can_edit"] == 1;
            }
            else
                output.CurrentUserCanEdit = false;

            if (page["current_user_can_edit_access"] != null)
                output.CurrentUserCanEditAccess = (int)page["current_user_can_edit_access"] == 1;
            else
                output.CurrentUserCanEditAccess = false;

            output.WhoCanView = (int?) page["who_can_view"];
            output.WhoCanEdit = (int?) page["who_can_edit"];
            output.EditorId = (long?) page["editor_id"];
            output.Parent = (string) page["parent"];
            output.Parent2 = (string) page["parent2"];

            if (page["edited"] != null)
                output.Edited = UnixTimeStampToDateTime((long) page["edited"]);

            if (page["created"] != null)
                output.Created = UnixTimeStampToDateTime((long) page["created"]);

            return output;
        }

        // TODO TEST IT!!!!!
        public static Note GetNote(JObject note)
        {
            var output = new Note();
            output.Id = (long?) note["nid"];
            output.UserId = (long?) note["uid"];
            output.Title = (string) note["title"];
            output.Text = (string) note["text"];

            if (note["date"] != null)
                output.Date = UnixTimeStampToDateTime((long) note["date"]);

            if (note["ncom"] != null)
                output.CommentsCount = (int?) note["ncom"];

            if (note["read_ncom"] != null)
                output.ReadCommentsCount = (int?) note["read_ncom"];

            return output;
        }

        public static Document GetDocument(JObject doc)
        {
            var output = new Document();
            output.Id = (long?) doc["did"];
            output.OwnerId = (long?) doc["owner_id"];
            output.Title = (string) doc["title"];
            output.Size = (long?) doc["size"];
            output.Ext = (string) doc["ext"];
            output.Url = (string) doc["url"];

            return output;
        }

        public static Video GetVideo(JObject video)
        {
            var output = new Video();
            output.Id = (long?) video["vid"];
            output.OwnerId = (long?) video["owner_id"];
            output.Title = (string) video["title"];
            output.Description = (string) video["description"];
            output.Duration = (int?) video["duration"];
            output.Link = (string) video["video-4363_136089719"];

            if (video["image"] != null)
                output.Image = new Uri((string)video["image"]);
            if (video["date"] != null)
                output.Date = UnixTimeStampToDateTime((long) video["date"]);
            if (video["player"] != null)
                output.Player = new Uri((string)video["player"]);

            return output;
        }

        public static WallRecord GetWallRecord(JObject wall)
        {
            var output = new WallRecord();

            output.Id = (long?) wall["id"];
            output.FromId = (long?) wall["from_id"];
            output.ToId = (long?) wall["to_id"];
            output.Date = UnixTimeStampToDateTime((long) wall["date"]);
            output.Text = (string) wall["text"];
            output.CopyOwnerId = (long?) wall["copy_owner_id"];
            output.CopyPostId = (long?) wall["copy_post_id"];
            output.ReplyCount = (int?) wall["reply_count"];

            if (wall["online"] != null)
                output.Online = (int) wall["online"] == 1;
            else
                output.Online = false;

            if (wall["post_source"] != null)
            {
                output.PostSource = new PostSource {Type = (string) wall["post_source"]["type"]};
            }

            if (wall["comments"] != null)
            {
                output.Comments = new Comments
                {
                    Count = (int) wall["comments"]["count"],
                    CanPost = (int) wall["comments"]["can_post"] == 1
                };
            }

            if (wall["likes"] != null)
            {
                output.Likes = new Like
                {
                    Count = (int) wall["likes"]["count"],
                    UserLikes = (int) wall["likes"]["user_likes"] == 1,
                    CanLike = (int) wall["likes"]["can_like"] == 1,
                    CanPublish = (int) wall["likes"]["can_publish"] == 1
                };
            }

            if (wall["reposts"] != null)
            {
                output.Reposts = new Reposts
                {
                    Count = (int)wall["reposts"]["count"],
                    UserReposted = (int)wall["reposts"]["user_reposted"] == 1
                };
            }

            if (wall["attachment"] != null)
            {
                output.Attachment = GetAttachment((JObject) wall["attachment"]);
            }

            if (wall["attachments"] != null)
            {
                var arr = (JArray) wall["attachments"];
                output.Attachments = arr.Select(attach => GetAttachment((JObject)attach)).ToList();
            }

            return output;
        }

        public static Photo GetPhoto(JObject audio)
        {
            var output = new Photo();
            output.Id = (long?)audio["pid"];
            output.AlbumId = (long?) audio["aid"];
            output.OwnerId = (long?) audio["owner_id"];
            output.Text = (string) audio["text"];
            output.Width = (int?) audio["width"];
            output.Height = (int?) audio["height"];
            output.AccessKey = (string) audio["access_key"];

            if (audio["src"] != null)
                output.Src = new Uri((string) audio["src"]);

            if (audio["src_small"] != null)
                output.SrcSmall = new Uri((string)audio["src_small"]);

            if (audio["src_big"] != null)
                output.SrcBig = new Uri((string)audio["src_big"]);

            if (audio["created"] != null)
                output.Created = UnixTimeStampToDateTime((long) audio["created"]);

            if (audio["src_xbig"] != null)
                output.SrcXBig = new Uri((string)audio["src_xbig"]);

            if (audio["src_xxbig"] != null)
                output.SrcXxBig = new Uri((string)audio["src_xxbig"]);

            return output;
        }

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
                                 Performer = (string) audio["performer"]
                             };

            if (audio["url"] != null)
                output.Url = new Uri((string) audio["url"]);

            if (audio["lyrics_id"] != null)
                output.LyricsId = Convert.ToInt64((string) audio["lyrics_id"]);

            if (audio["album"] != null)
                output.AlbumId = Convert.ToInt64((string) audio["album"]);
            
            return output;
        }

        public static Message GetMessage(JObject current)
        {
            var msg = new Message();
            msg.Id = (long?) current["mid"];
            msg.UserId = (long?) current["uid"];
            msg.Title = (string) current["title"];
            msg.Body = (string) current["body"];
            msg.ChatId = (long?) current["chat_id"];
            msg.UsersCount = (int?) current["users_count"];
            msg.AdminId = (long?) current["admin_id"];
            msg.FromUserId = (long?) current["from_id"];

            if (current["deleted"] != null)
                msg.IsDeleted = (int) current["deleted"] == 1;

            if (current["date"] != null)
                msg.Date = UnixTimeStampToDateTime((long) current["date"]);

            if (current["read_state"] != null)
            {
                int state = (int) current["read_state"];
                switch (state)
                {
                    case 0:
                        msg.ReadState = MessageReadState.Unreaded;
                        break;

                    case 1:
                        msg.ReadState = MessageReadState.Readed;
                        break;
                }
            }

            if (current["out"] != null)
            {
                int type = (int) current["out"];
                switch (type)
                {
                    case 0:
                        msg.Type = MessageType.Recived;
                        break;

                    case 1:
                        msg.Type = MessageType.Sended;
                        break;
                }
            }

            if (current["attachments"] != null)
            {
                var arr = (JArray)current["attachments"];
                msg.Attachments = arr.Select(attach => GetAttachment((JObject)attach)).ToList();
            }

            if (current["fwd_messages"] != null)
                throw new NotImplementedException();

            if (current["chat_active"] != null)
                throw new NotImplementedException();

            return msg;
        }

        public static Chat GetChat(JObject el)
        {
            var chat = new Chat();
            chat.Id = (long?) el["chat_id"];
            chat.Title = (string) el["title"];
            if (el["users"] != null)
            {
#if WINDOWS_PHONE
                chat.UserIds = JArrayToIEnumerable((JArray)el["users"]);
#else
                chat.UserIds = JArrayToIEnumerable<long>((JArray)el["users"]);
#endif
            }
            
            if (el["admin_id"] != null)
                chat.AdminId = Convert.ToInt64((string)el["admin_id"]);

            return chat;
        }
        
#if WINDOWS_PHONE
        public static IEnumerable<long> JArrayToIEnumerable(JArray array)
        {
            return array.Select(el => (long) el).ToList();
        }
#else
        public static IEnumerable<T> JArrayToIEnumerable<T>(JArray array)
        {
            return array.Select(el => el as dynamic).Select(item => (T)item).ToList();
        }
#endif

        public static LastActivity GetLastActivity(JObject activity)
        {
            var result = new LastActivity();
            if (activity["online"] != null)
                result.IsOnline = (int) activity["online"] == 1;

            if (activity["time"] != null)
                result.Time = UnixTimeStampToDateTime((long) activity["time"]);
            return result;
        }

        public static User GetProfileFromJObject(JObject current)
        {
            var profile = new User();

            profile.FirstName = (string) current["first_name"];
            profile.LastName = (string) current["last_name"];
            profile.Nickname = (string) current["nickname"];
            profile.ScreenName = (string) current["screen_name"];
            profile.Sex = (int?) current["sex"];
            profile.BirthDate = (string) current["bdate"];
            profile.City = (string) current["city"];
            profile.Country = (string) current["country"];
            profile.Photo = (string) current["photo"];
            profile.PhotoMedium = (string) current["photo_medium"];
            profile.PhotoBig = (string) current["photo_big"];
            profile.HasMobile = (int?) current["has_mobile"];
            profile.Rate = (string) current["rate"];
            profile.MobilePhone = (string) current["mobile_phone"];
            profile.HomePhone = (string) current["home_phone"];
            profile.Online = (int?) current["online"];
            profile.NameGen = (string) current["name_gen"];
            profile.InvitedBy = (long?) current["invited_by"];

            if (current["timezone"] != null)
            {
                double timezone;
                profile.Timezone = double.TryParse(current["timezone"].ToString(), out timezone) ? timezone : 0;
            }

            if (current["uid"] != null)
                profile.Id = (long) current["uid"];
            else if (current["id"] != null)
            {
                long id;
                profile.Id = long.TryParse((string)current["id"], out id) ? id : 0;
            }

            if (current["name"] != null)
            {
                // split for name and surname
                string[] parts = ((string) current["name"]).Split(' ');
                profile.FirstName = parts[0];
                profile.LastName = parts[1];
            }

            if (current["university"] != null && current["university"].ToString() != "0")
            {
                profile.Education = new Education();

                long univerId;
                if (long.TryParse(current["university"].ToString(), out univerId) && univerId != 0)
                    profile.Education.UniversityId = univerId;
                
                long facultyId;
                if (long.TryParse(current["faculty"].ToString(), out facultyId) && facultyId != 0) 
                    profile.Education.FacultyId = facultyId;

                int graduation;
                if (current["graduation"] != null && int.TryParse(current["graduation"].ToString(), out graduation) && graduation != 0)
                    profile.Education.Graduation = graduation;

                profile.Education.UniversityName = (string)current["university_name"];
                profile.Education.FacultyName = (string) current["faculty_name"];
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
                Description = (string)group["description"],
                WikiPage = (string)group["wiki_page"]
            };

            var isClosed = (int?)group["is_closed"];
            var isAdmin = (int?)group["is_admin"];
            var isMember = (int?) group["is_member"];

            output.CityId = (long?)group["city"];
            output.CountryId = (long?)group["country"];

            long datetime;
            if (long.TryParse((string)group["start_date"], out datetime) && datetime > 0)
                output.StartDate = UnixTimeStampToDateTime(datetime);

            if (isClosed.HasValue)
            {
                output.IsClosed = isClosed.Value == 1;
            }

            if (isMember.HasValue)
            {
                output.IsMember = isMember.Value == 1;
            }
            //else
            //    output.IsMember = false;
            
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

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();
            return dt;
        }

        public static long DateTimeToUnixTimeStamp(DateTime date)
        {
            TimeSpan span = DateTime.Now - date;
            return (long) span.TotalSeconds;
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

        public static string GetEnumerationAsString<T>(IEnumerable<T> uids)
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