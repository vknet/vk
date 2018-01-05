using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
    public class MultivaluedFilterTest
    {

		[Test]
        public void AccountFieldsTest()
        {
			// get test
			Assert.That(AccountFields.Country.ToString(), Is.EqualTo("country"));
			Assert.That(AccountFields.HttpsRequired.ToString(), Is.EqualTo("https_required"));
			Assert.That(AccountFields.OwnPostsDefault.ToString(), Is.EqualTo("own_posts_default"));
			Assert.That(AccountFields.NoWallReplies.ToString(), Is.EqualTo("no_wall_replies"));
			Assert.That(AccountFields.Intro.ToString(), Is.EqualTo("intro"));
			Assert.That(AccountFields.Language.ToString(), Is.EqualTo("lang"));
			// parse test
			Assert.That(AccountFields.FromJsonString("country"), Is.EqualTo(AccountFields.Country));
			Assert.That(AccountFields.FromJsonString("https_required"), Is.EqualTo(AccountFields.HttpsRequired));
			Assert.That(AccountFields.FromJsonString("own_posts_default"), Is.EqualTo(AccountFields.OwnPostsDefault));
			Assert.That(AccountFields.FromJsonString("no_wall_replies"), Is.EqualTo(AccountFields.NoWallReplies));
			Assert.That(AccountFields.FromJsonString("intro"), Is.EqualTo(AccountFields.Intro));
			Assert.That(AccountFields.FromJsonString("lang"), Is.EqualTo(AccountFields.Language));
		}

		[Test]
        public void CountersFilterTest()
        {
			// get test
			Assert.That(CountersFilter.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(CountersFilter.Messages.ToString(), Is.EqualTo("messages"));
			Assert.That(CountersFilter.Photos.ToString(), Is.EqualTo("photos"));
			Assert.That(CountersFilter.Videos.ToString(), Is.EqualTo("videos"));
			Assert.That(CountersFilter.Gifts.ToString(), Is.EqualTo("gifts"));
			Assert.That(CountersFilter.Events.ToString(), Is.EqualTo("events"));
			Assert.That(CountersFilter.Groups.ToString(), Is.EqualTo("groups"));
			Assert.That(CountersFilter.Notifications.ToString(), Is.EqualTo("notifications"));
			Assert.That(CountersFilter.All.ToString(), Is.EqualTo("app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos"));
			// parse test
			Assert.That(CountersFilter.FromJsonString("friends"), Is.EqualTo(CountersFilter.Friends));
			Assert.That(CountersFilter.FromJsonString("messages"), Is.EqualTo(CountersFilter.Messages));
			Assert.That(CountersFilter.FromJsonString("photos"), Is.EqualTo(CountersFilter.Photos));
	        Assert.That(CountersFilter.FromJsonString("videos"), Is.EqualTo(CountersFilter.Videos));
			Assert.That(CountersFilter.FromJsonString("gifts"), Is.EqualTo(CountersFilter.Gifts));
			Assert.That(CountersFilter.FromJsonString("events"), Is.EqualTo(CountersFilter.Events));
			Assert.That(CountersFilter.FromJsonString("groups"), Is.EqualTo(CountersFilter.Groups));
			Assert.That(CountersFilter.FromJsonString("notifications"), Is.EqualTo(CountersFilter.Notifications));
			Assert.That(CountersFilter.FromJsonString("app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos"), Is.EqualTo(CountersFilter.All));
		}

		[Test]
        public void GroupsFieldsTest()
        {
			// get test
			Assert.That(GroupsFields.CityId.ToString(), Is.EqualTo("city"));
			Assert.That(GroupsFields.CountryId.ToString(), Is.EqualTo("country"));
			Assert.That(GroupsFields.Place.ToString(), Is.EqualTo("place"));
			Assert.That(GroupsFields.Description.ToString(), Is.EqualTo("description"));
			Assert.That(GroupsFields.WikiPage.ToString(), Is.EqualTo("wiki_page"));
			Assert.That(GroupsFields.MembersCount.ToString(), Is.EqualTo("members_count"));
			Assert.That(GroupsFields.Counters.ToString(), Is.EqualTo("counters"));
			Assert.That(GroupsFields.StartDate.ToString(), Is.EqualTo("start_date"));
			Assert.That(GroupsFields.EndDate.ToString(), Is.EqualTo("end_date"));
			Assert.That(GroupsFields.CanPost.ToString(), Is.EqualTo("can_post"));
			Assert.That(GroupsFields.CanSeelAllPosts.ToString(), Is.EqualTo("can_see_all_posts"));
			Assert.That(GroupsFields.CanUploadDocuments.ToString(), Is.EqualTo("can_upload_doc"));
			Assert.That(GroupsFields.CanCreateTopic.ToString(), Is.EqualTo("can_create_topic"));
			Assert.That(GroupsFields.Activity.ToString(), Is.EqualTo("activity"));
			Assert.That(GroupsFields.Status.ToString(), Is.EqualTo("status"));
			Assert.That(GroupsFields.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(GroupsFields.Links.ToString(), Is.EqualTo("links"));
			Assert.That(GroupsFields.FixedPostId.ToString(), Is.EqualTo("fixed_post"));
			Assert.That(GroupsFields.IsVerified.ToString(), Is.EqualTo("verified"));
			Assert.That(GroupsFields.Site.ToString(), Is.EqualTo("site"));
			Assert.That(GroupsFields.BanInfo.ToString(), Is.EqualTo("ban_info"));
			Assert.That(GroupsFields.All.ToString(), Is.EqualTo("activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"));
			Assert.That(GroupsFields.AllUndocumented.ToString(), Is.EqualTo("activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"));
			// parse test
			Assert.That(GroupsFields.FromJsonString("city"), Is.EqualTo(GroupsFields.CityId));
			Assert.That(GroupsFields.FromJsonString("country"), Is.EqualTo(GroupsFields.CountryId));
			Assert.That(GroupsFields.FromJsonString("place"), Is.EqualTo(GroupsFields.Place));
			Assert.That(GroupsFields.FromJsonString("description"), Is.EqualTo(GroupsFields.Description));
			Assert.That(GroupsFields.FromJsonString("wiki_page"), Is.EqualTo(GroupsFields.WikiPage));
			Assert.That(GroupsFields.FromJsonString("members_count"), Is.EqualTo(GroupsFields.MembersCount));
			Assert.That(GroupsFields.FromJsonString("counters"), Is.EqualTo(GroupsFields.Counters));
			Assert.That(GroupsFields.FromJsonString("start_date"), Is.EqualTo(GroupsFields.StartDate));
			Assert.That(GroupsFields.FromJsonString("end_date"), Is.EqualTo(GroupsFields.EndDate));
			Assert.That(GroupsFields.FromJsonString("can_post"), Is.EqualTo(GroupsFields.CanPost));
			Assert.That(GroupsFields.FromJsonString("can_see_all_posts"), Is.EqualTo(GroupsFields.CanSeelAllPosts));
			Assert.That(GroupsFields.FromJsonString("can_upload_doc"), Is.EqualTo(GroupsFields.CanUploadDocuments));
			Assert.That(GroupsFields.FromJsonString("can_create_topic"), Is.EqualTo(GroupsFields.CanCreateTopic));
			Assert.That(GroupsFields.FromJsonString("activity"), Is.EqualTo(GroupsFields.Activity));
			Assert.That(GroupsFields.FromJsonString("status"), Is.EqualTo(GroupsFields.Status));
			Assert.That(GroupsFields.FromJsonString("contacts"), Is.EqualTo(GroupsFields.Contacts));
			Assert.That(GroupsFields.FromJsonString("links"), Is.EqualTo(GroupsFields.Links));
			Assert.That(GroupsFields.FromJsonString("fixed_post"), Is.EqualTo(GroupsFields.FixedPostId));
			Assert.That(GroupsFields.FromJsonString("verified"), Is.EqualTo(GroupsFields.IsVerified));
			Assert.That(GroupsFields.FromJsonString("site"), Is.EqualTo(GroupsFields.Site));
			Assert.That(GroupsFields.FromJsonString("ban_info"), Is.EqualTo(GroupsFields.BanInfo));
			Assert.That(GroupsFields.FromJsonString("activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"), Is.EqualTo(GroupsFields.All));
			Assert.That(GroupsFields.FromJsonString("activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"), Is.EqualTo(GroupsFields.AllUndocumented));
		}

		[Test]
        public void GroupsFiltersTest()
        {
			// get test
			Assert.That(GroupsFilters.Administrator.ToString(), Is.EqualTo("admin"));
			Assert.That(GroupsFilters.Editor.ToString(), Is.EqualTo("editor"));
			Assert.That(GroupsFilters.Moderator.ToString(), Is.EqualTo("moder"));
			Assert.That(GroupsFilters.Groups.ToString(), Is.EqualTo("groups"));
			Assert.That(GroupsFilters.Publics.ToString(), Is.EqualTo("publics"));
			Assert.That(GroupsFilters.Events.ToString(), Is.EqualTo("events"));
			Assert.That(GroupsFilters.All.ToString(), Is.EqualTo("admin,editor,events,groups,moder,publics"));
			// parse test
			Assert.That(GroupsFilters.FromJsonString("admin"), Is.EqualTo(GroupsFilters.Administrator));
			Assert.That(GroupsFilters.FromJsonString("editor"), Is.EqualTo(GroupsFilters.Editor));
			Assert.That(GroupsFilters.FromJsonString("moder"), Is.EqualTo(GroupsFilters.Moderator));
			Assert.That(GroupsFilters.FromJsonString("groups"), Is.EqualTo(GroupsFilters.Groups));
			Assert.That(GroupsFilters.FromJsonString("publics"), Is.EqualTo(GroupsFilters.Publics));
			Assert.That(GroupsFilters.FromJsonString("events"), Is.EqualTo(GroupsFilters.Events));
			Assert.That(GroupsFilters.FromJsonString("admin,editor,moder,groups,publics,events"), Is.EqualTo(GroupsFilters.All));
		}

		[Test]
        public void ProfileFieldsTest()
        {
			// get test
			Assert.That(ProfileFields.Uid.ToString(), Is.EqualTo("user_id"));
			Assert.That(ProfileFields.FirstName.ToString(), Is.EqualTo("first_name"));
			Assert.That(ProfileFields.LastName.ToString(), Is.EqualTo("last_name"));
			Assert.That(ProfileFields.Sex.ToString(), Is.EqualTo("sex"));
			Assert.That(ProfileFields.BirthDate.ToString(), Is.EqualTo("bdate"));
			Assert.That(ProfileFields.City.ToString(), Is.EqualTo("city"));
			Assert.That(ProfileFields.Country.ToString(), Is.EqualTo("country"));
			Assert.That(ProfileFields.Photo50.ToString(), Is.EqualTo("photo_50"));
			Assert.That(ProfileFields.Photo100.ToString(), Is.EqualTo("photo_100"));
			Assert.That(ProfileFields.Photo200.ToString(), Is.EqualTo("photo_200"));
			Assert.That(ProfileFields.Photo200Orig.ToString(), Is.EqualTo("photo_200_orig"));
			Assert.That(ProfileFields.Photo400Orig.ToString(), Is.EqualTo("photo_400_orig"));
			Assert.That(ProfileFields.PhotoMax.ToString(), Is.EqualTo("photo_max"));
			Assert.That(ProfileFields.PhotoMaxOrig.ToString(), Is.EqualTo("photo_max_orig"));
			Assert.That(ProfileFields.Online.ToString(), Is.EqualTo("online"));
			Assert.That(ProfileFields.FriendLists.ToString(), Is.EqualTo("lists"));
			Assert.That(ProfileFields.Domain.ToString(), Is.EqualTo("domain"));
			Assert.That(ProfileFields.HasMobile.ToString(), Is.EqualTo("has_mobile"));
			Assert.That(ProfileFields.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(ProfileFields.Connections.ToString(), Is.EqualTo("connections"));
			Assert.That(ProfileFields.Site.ToString(), Is.EqualTo("site"));
			Assert.That(ProfileFields.Education.ToString(), Is.EqualTo("education"));
			Assert.That(ProfileFields.Universities.ToString(), Is.EqualTo("universities"));
			Assert.That(ProfileFields.Schools.ToString(), Is.EqualTo("schools"));
			Assert.That(ProfileFields.CanPost.ToString(), Is.EqualTo("can_post"));
			Assert.That(ProfileFields.CanSeeAllPosts.ToString(), Is.EqualTo("can_see_all_posts"));
			Assert.That(ProfileFields.CanSeeAudio.ToString(), Is.EqualTo("can_see_audio"));
			Assert.That(ProfileFields.CanWritePrivateMessage.ToString(), Is.EqualTo("can_write_private_message"));
			Assert.That(ProfileFields.Status.ToString(), Is.EqualTo("status"));
			Assert.That(ProfileFields.LastSeen.ToString(), Is.EqualTo("last_seen"));
			Assert.That(ProfileFields.CommonCount.ToString(), Is.EqualTo("common_count"));
			Assert.That(ProfileFields.Relation.ToString(), Is.EqualTo("relation"));
			Assert.That(ProfileFields.Relatives.ToString(), Is.EqualTo("relatives"));
			Assert.That(ProfileFields.Counters.ToString(), Is.EqualTo("counters"));
			Assert.That(ProfileFields.Nickname.ToString(), Is.EqualTo("nickname"));
			Assert.That(ProfileFields.Timezone.ToString(), Is.EqualTo("timezone"));
			Assert.That(ProfileFields.Language.ToString(), Is.EqualTo("lang"));
			Assert.That(ProfileFields.OnlineMobile.ToString(), Is.EqualTo("online_mobile"));
			Assert.That(ProfileFields.OnlineApp.ToString(), Is.EqualTo("online_app"));
			Assert.That(ProfileFields.RelationPartner.ToString(), Is.EqualTo("relation_partner"));
			Assert.That(ProfileFields.StandInLife.ToString(), Is.EqualTo("personal"));
			Assert.That(ProfileFields.Interests.ToString(), Is.EqualTo("interests"));
			Assert.That(ProfileFields.Music.ToString(), Is.EqualTo("music"));
			Assert.That(ProfileFields.Activities.ToString(), Is.EqualTo("activities"));
			Assert.That(ProfileFields.Movies.ToString(), Is.EqualTo("movies"));
			Assert.That(ProfileFields.Tv.ToString(), Is.EqualTo("tv"));
			Assert.That(ProfileFields.Books.ToString(), Is.EqualTo("books"));
			Assert.That(ProfileFields.Games.ToString(), Is.EqualTo("games"));
			Assert.That(ProfileFields.About.ToString(), Is.EqualTo("about"));
			Assert.That(ProfileFields.Quotes.ToString(), Is.EqualTo("quotes"));
			Assert.That(ProfileFields.InvitedBy.ToString(), Is.EqualTo("invited_by"));
			Assert.That(ProfileFields.BlacklistedByMe.ToString(), Is.EqualTo("blacklisted_by_me"));
			Assert.That(ProfileFields.Blacklisted.ToString(), Is.EqualTo("blacklisted"));
			Assert.That(ProfileFields.Military.ToString(), Is.EqualTo("military"));
			Assert.That(ProfileFields.Career.ToString(), Is.EqualTo("career"));
			Assert.That(ProfileFields.FriendStatus.ToString(), Is.EqualTo("friend_status"));
			Assert.That(ProfileFields.IsFriend.ToString(), Is.EqualTo("is_friend"));
			Assert.That(ProfileFields.ScreenName.ToString(), Is.EqualTo("screen_name"));
			Assert.That(ProfileFields.IsHiddenFromFeed.ToString(), Is.EqualTo("is_hidden_from_feed"));
			Assert.That(ProfileFields.IsFavorite.ToString(), Is.EqualTo("is_favorite"));
			Assert.That(ProfileFields.CanSendFriendRequest.ToString(), Is.EqualTo("can_send_friend_request"));
			Assert.That(ProfileFields.WallComments.ToString(), Is.EqualTo("wall_comments"));
			Assert.That(ProfileFields.Verified.ToString(), Is.EqualTo("verified"));
			Assert.That(ProfileFields.All.ToString(), Is.EqualTo("bdate,blacklisted,blacklisted_by_me,can_post,can_see_all_posts,can_see_audio,can_send_friend_request,can_write_private_message,career,city,common_count,connections,contacts,counters,country,crop_photo,domain,education,first_name,followers_count,friend_status,has_mobile,is_favorite,is_friend,is_hidden_from_feed,last_name,last_seen,lists,military,nickname,online,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,screen_name,sex,site,status,timezone,universities,user_id,verified,wall_comments"));
			Assert.That(ProfileFields.AllUndocumented.ToString(), Is.EqualTo("about,activities,bdate,blacklisted,blacklisted_by_me,books,can_post,can_see_all_posts,can_see_audio,can_send_friend_request,can_write_private_message,career,city,common_count,connections,contacts,counters,country,crop_photo,domain,education,first_name,followers_count,friend_status,games,has_mobile,interests,invited_by,is_favorite,is_friend,is_hidden_from_feed,lang,last_name,last_seen,lists,military,movies,music,nickname,online,online_app,online_mobile,personal,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,quotes,relation,relation_partner,relatives,schools,screen_name,sex,site,status,timezone,tv,universities,user_id,verified,wall_comments"));
			// parse test
			Assert.That(ProfileFields.FromJsonString("user_id"), Is.EqualTo(ProfileFields.Uid));
			Assert.That(ProfileFields.FromJsonString("first_name"), Is.EqualTo(ProfileFields.FirstName));
			Assert.That(ProfileFields.FromJsonString("last_name"), Is.EqualTo(ProfileFields.LastName));
			Assert.That(ProfileFields.FromJsonString("sex"), Is.EqualTo(ProfileFields.Sex));
			Assert.That(ProfileFields.FromJsonString("bdate"), Is.EqualTo(ProfileFields.BirthDate));
			Assert.That(ProfileFields.FromJsonString("city"), Is.EqualTo(ProfileFields.City));
			Assert.That(ProfileFields.FromJsonString("country"), Is.EqualTo(ProfileFields.Country));
			Assert.That(ProfileFields.FromJsonString("photo_50"), Is.EqualTo(ProfileFields.Photo50));
			Assert.That(ProfileFields.FromJsonString("photo_100"), Is.EqualTo(ProfileFields.Photo100));
			Assert.That(ProfileFields.FromJsonString("photo_200"), Is.EqualTo(ProfileFields.Photo200));
			Assert.That(ProfileFields.FromJsonString("photo_200_orig"), Is.EqualTo(ProfileFields.Photo200Orig));
			Assert.That(ProfileFields.FromJsonString("photo_400_orig"), Is.EqualTo(ProfileFields.Photo400Orig));
			Assert.That(ProfileFields.FromJsonString("photo_max"), Is.EqualTo(ProfileFields.PhotoMax));
			Assert.That(ProfileFields.FromJsonString("photo_max_orig"), Is.EqualTo(ProfileFields.PhotoMaxOrig));
			Assert.That(ProfileFields.FromJsonString("online"), Is.EqualTo(ProfileFields.Online));
			Assert.That(ProfileFields.FromJsonString("lists"), Is.EqualTo(ProfileFields.FriendLists));
			Assert.That(ProfileFields.FromJsonString("domain"), Is.EqualTo(ProfileFields.Domain));
			Assert.That(ProfileFields.FromJsonString("has_mobile"), Is.EqualTo(ProfileFields.HasMobile));
			Assert.That(ProfileFields.FromJsonString("contacts"), Is.EqualTo(ProfileFields.Contacts));
			Assert.That(ProfileFields.FromJsonString("connections"), Is.EqualTo(ProfileFields.Connections));
			Assert.That(ProfileFields.FromJsonString("site"), Is.EqualTo(ProfileFields.Site));
			Assert.That(ProfileFields.FromJsonString("education"), Is.EqualTo(ProfileFields.Education));
			Assert.That(ProfileFields.FromJsonString("universities"), Is.EqualTo(ProfileFields.Universities));
			Assert.That(ProfileFields.FromJsonString("schools"), Is.EqualTo(ProfileFields.Schools));
			Assert.That(ProfileFields.FromJsonString("can_post"), Is.EqualTo(ProfileFields.CanPost));
			Assert.That(ProfileFields.FromJsonString("can_see_all_posts"), Is.EqualTo(ProfileFields.CanSeeAllPosts));
			Assert.That(ProfileFields.FromJsonString("can_see_audio"), Is.EqualTo(ProfileFields.CanSeeAudio));
			Assert.That(ProfileFields.FromJsonString("can_write_private_message"), Is.EqualTo(ProfileFields.CanWritePrivateMessage));
			Assert.That(ProfileFields.FromJsonString("status"), Is.EqualTo(ProfileFields.Status));
			Assert.That(ProfileFields.FromJsonString("last_seen"), Is.EqualTo(ProfileFields.LastSeen));
			Assert.That(ProfileFields.FromJsonString("common_count"), Is.EqualTo(ProfileFields.CommonCount));
			Assert.That(ProfileFields.FromJsonString("relation"), Is.EqualTo(ProfileFields.Relation));
			Assert.That(ProfileFields.FromJsonString("relatives"), Is.EqualTo(ProfileFields.Relatives));
			Assert.That(ProfileFields.FromJsonString("counters"), Is.EqualTo(ProfileFields.Counters));
			Assert.That(ProfileFields.FromJsonString("nickname"), Is.EqualTo(ProfileFields.Nickname));
			Assert.That(ProfileFields.FromJsonString("timezone"), Is.EqualTo(ProfileFields.Timezone));
			Assert.That(ProfileFields.FromJsonString("lang"), Is.EqualTo(ProfileFields.Language));
			Assert.That(ProfileFields.FromJsonString("online_mobile"), Is.EqualTo(ProfileFields.OnlineMobile));
			Assert.That(ProfileFields.FromJsonString("online_app"), Is.EqualTo(ProfileFields.OnlineApp));
			Assert.That(ProfileFields.FromJsonString("relation_partner"), Is.EqualTo(ProfileFields.RelationPartner));
			Assert.That(ProfileFields.FromJsonString("personal"), Is.EqualTo(ProfileFields.StandInLife));
			Assert.That(ProfileFields.FromJsonString("interests"), Is.EqualTo(ProfileFields.Interests));
			Assert.That(ProfileFields.FromJsonString("music"), Is.EqualTo(ProfileFields.Music));
			Assert.That(ProfileFields.FromJsonString("activities"), Is.EqualTo(ProfileFields.Activities));
			Assert.That(ProfileFields.FromJsonString("movies"), Is.EqualTo(ProfileFields.Movies));
			Assert.That(ProfileFields.FromJsonString("tv"), Is.EqualTo(ProfileFields.Tv));
			Assert.That(ProfileFields.FromJsonString("books"), Is.EqualTo(ProfileFields.Books));
			Assert.That(ProfileFields.FromJsonString("games"), Is.EqualTo(ProfileFields.Games));
			Assert.That(ProfileFields.FromJsonString("about"), Is.EqualTo(ProfileFields.About));
			Assert.That(ProfileFields.FromJsonString("quotes"), Is.EqualTo(ProfileFields.Quotes));
			Assert.That(ProfileFields.FromJsonString("invited_by"), Is.EqualTo(ProfileFields.InvitedBy));
			Assert.That(ProfileFields.FromJsonString("blacklisted_by_me"), Is.EqualTo(ProfileFields.BlacklistedByMe));
			Assert.That(ProfileFields.FromJsonString("blacklisted"), Is.EqualTo(ProfileFields.Blacklisted));
			Assert.That(ProfileFields.FromJsonString("military"), Is.EqualTo(ProfileFields.Military));
			Assert.That(ProfileFields.FromJsonString("career"), Is.EqualTo(ProfileFields.Career));
			Assert.That(ProfileFields.FromJsonString("friend_status"), Is.EqualTo(ProfileFields.FriendStatus));
			Assert.That(ProfileFields.FromJsonString("is_friend"), Is.EqualTo(ProfileFields.IsFriend));
			Assert.That(ProfileFields.FromJsonString("screen_name"), Is.EqualTo(ProfileFields.ScreenName));
			Assert.That(ProfileFields.FromJsonString("is_hidden_from_feed"), Is.EqualTo(ProfileFields.IsHiddenFromFeed));
			Assert.That(ProfileFields.FromJsonString("is_favorite"), Is.EqualTo(ProfileFields.IsFavorite));
			Assert.That(ProfileFields.FromJsonString("can_send_friend_request"), Is.EqualTo(ProfileFields.CanSendFriendRequest));
			Assert.That(ProfileFields.FromJsonString("wall_comments"), Is.EqualTo(ProfileFields.WallComments));
			Assert.That(ProfileFields.FromJsonString("verified"), Is.EqualTo(ProfileFields.Verified));
			Assert.That(ProfileFields.FromJsonString("bdate,blacklisted,blacklisted_by_me,can_post,can_see_all_posts,can_see_audio,can_send_friend_request,can_write_private_message,career,city,common_count,connections,contacts,counters,country,crop_photo,domain,education,first_name,followers_count,friend_status,has_mobile,is_favorite,is_friend,is_hidden_from_feed,last_name,last_seen,lists,military,nickname,online,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,screen_name,sex,site,status,timezone,universities,user_id,verified,wall_comments"), Is.EqualTo(ProfileFields.All));
			Assert.That(ProfileFields.FromJsonString("about,activities,bdate,blacklisted,blacklisted_by_me,books,can_post,can_see_all_posts,can_see_audio,can_send_friend_request,can_write_private_message,career,city,common_count,connections,contacts,counters,country,crop_photo,domain,education,first_name,followers_count,friend_status,games,has_mobile,interests,invited_by,is_favorite,is_friend,is_hidden_from_feed,lang,last_name,last_seen,lists,military,movies,music,nickname,online,online_app,online_mobile,personal,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,quotes,relation,relation_partner,relatives,schools,screen_name,sex,site,status,timezone,tv,universities,user_id,verified,wall_comments"), Is.EqualTo(ProfileFields.AllUndocumented));
		}

		[Test]
        public void SettingsTest()
        {
			// get test
			Assert.That(Settings.Notify.ToString(), Is.EqualTo("notify"));
			Assert.That(Settings.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(Settings.Photos.ToString(), Is.EqualTo("photos"));
			Assert.That(Settings.Audio.ToString(), Is.EqualTo("audio"));
			Assert.That(Settings.Video.ToString(), Is.EqualTo("video"));
			Assert.That(Settings.Pages.ToString(), Is.EqualTo("pages"));
			Assert.That(Settings.AddLinkToLeftMenu.ToString(), Is.EqualTo("addLinkToLeftMenu"));
			Assert.That(Settings.Status.ToString(), Is.EqualTo("status"));
			Assert.That(Settings.Notes.ToString(), Is.EqualTo("notes"));
			Assert.That(Settings.Messages.ToString(), Is.EqualTo("messages"));
			Assert.That(Settings.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(Settings.Ads.ToString(), Is.EqualTo("ads"));
			Assert.That(Settings.Offline.ToString(), Is.EqualTo("offline"));
			Assert.That(Settings.Documents.ToString(), Is.EqualTo("docs"));
			Assert.That(Settings.Groups.ToString(), Is.EqualTo("groups"));
			Assert.That(Settings.Notifications.ToString(), Is.EqualTo("notifications"));
			Assert.That(Settings.Statistic.ToString(), Is.EqualTo("stats"));
			Assert.That(Settings.Email.ToString(), Is.EqualTo("email"));
			Assert.That(Settings.Market.ToString(), Is.EqualTo("market"));
			Assert.That(Settings.All.ToString(), Is.EqualTo("ads,audio,docs,email,friends,groups,market,messages,notes,notifications,notify,pages,photos,stats,status,video,wall"));
			// parse test
			Assert.That(Settings.FromJsonString("notify"), Is.EqualTo(Settings.Notify));
			Assert.That(Settings.FromJsonString("friends"), Is.EqualTo(Settings.Friends));
			Assert.That(Settings.FromJsonString("photos"), Is.EqualTo(Settings.Photos));
			Assert.That(Settings.FromJsonString("audio"), Is.EqualTo(Settings.Audio));
			Assert.That(Settings.FromJsonString("video"), Is.EqualTo(Settings.Video));
			Assert.That(Settings.FromJsonString("pages"), Is.EqualTo(Settings.Pages));
			Assert.That(Settings.FromJsonString("addLinkToLeftMenu"), Is.EqualTo(Settings.AddLinkToLeftMenu));
			Assert.That(Settings.FromJsonString("status"), Is.EqualTo(Settings.Status));
			Assert.That(Settings.FromJsonString("notes"), Is.EqualTo(Settings.Notes));
			Assert.That(Settings.FromJsonString("messages"), Is.EqualTo(Settings.Messages));
			Assert.That(Settings.FromJsonString("wall"), Is.EqualTo(Settings.Wall));
			Assert.That(Settings.FromJsonString("ads"), Is.EqualTo(Settings.Ads));
			Assert.That(Settings.FromJsonString("offline"), Is.EqualTo(Settings.Offline));
			Assert.That(Settings.FromJsonString("docs"), Is.EqualTo(Settings.Documents));
			Assert.That(Settings.FromJsonString("groups"), Is.EqualTo(Settings.Groups));
			Assert.That(Settings.FromJsonString("notifications"), Is.EqualTo(Settings.Notifications));
			Assert.That(Settings.FromJsonString("stats"), Is.EqualTo(Settings.Statistic));
			Assert.That(Settings.FromJsonString("email"), Is.EqualTo(Settings.Email));
			Assert.That(Settings.FromJsonString("market"), Is.EqualTo(Settings.Market));
			Assert.That(Settings.FromJsonString("notify,friends,photos,audio,video,pages,status,notes,messages,wall,ads,docs,groups,notifications,stats,email,market"), Is.EqualTo(Settings.All));
		}

		[Test]
        public void SubscribeFilterTest()
        {
			// get test
			Assert.That(SubscribeFilter.Message.ToString(), Is.EqualTo("msg"));
			Assert.That(SubscribeFilter.Friend.ToString(), Is.EqualTo("friend"));
			Assert.That(SubscribeFilter.Call.ToString(), Is.EqualTo("call"));
			Assert.That(SubscribeFilter.Reply.ToString(), Is.EqualTo("reply"));
			Assert.That(SubscribeFilter.Mention.ToString(), Is.EqualTo("mention"));
			Assert.That(SubscribeFilter.Group.ToString(), Is.EqualTo("group"));
			Assert.That(SubscribeFilter.Like.ToString(), Is.EqualTo("like"));
			Assert.That(SubscribeFilter.All.ToString(), Is.EqualTo("call,friend,group,like,mention,msg,reply"));
			// parse test
			Assert.That(SubscribeFilter.FromJsonString("msg"), Is.EqualTo(SubscribeFilter.Message));
			Assert.That(SubscribeFilter.FromJsonString("friend"), Is.EqualTo(SubscribeFilter.Friend));
			Assert.That(SubscribeFilter.FromJsonString("call"), Is.EqualTo(SubscribeFilter.Call));
			Assert.That(SubscribeFilter.FromJsonString("reply"), Is.EqualTo(SubscribeFilter.Reply));
			Assert.That(SubscribeFilter.FromJsonString("mention"), Is.EqualTo(SubscribeFilter.Mention));
			Assert.That(SubscribeFilter.FromJsonString("group"), Is.EqualTo(SubscribeFilter.Group));
			Assert.That(SubscribeFilter.FromJsonString("like"), Is.EqualTo(SubscribeFilter.Like));
			Assert.That(SubscribeFilter.FromJsonString("msg,friend,call,reply,mention,group,like"), Is.EqualTo(SubscribeFilter.All));
		}

		[Test]
        public void UsersFieldsTest()
        {
			// get test
			Assert.That(UsersFields.Nickname.ToString(), Is.EqualTo("nickname"));
			Assert.That(UsersFields.Domain.ToString(), Is.EqualTo("domain"));
			Assert.That(UsersFields.Sex.ToString(), Is.EqualTo("sex"));
			Assert.That(UsersFields.BirthDate.ToString(), Is.EqualTo("bdate"));
			Assert.That(UsersFields.City.ToString(), Is.EqualTo("city"));
			Assert.That(UsersFields.Country.ToString(), Is.EqualTo("country"));
			Assert.That(UsersFields.Timezone.ToString(), Is.EqualTo("timezone"));
			Assert.That(UsersFields.Photo50.ToString(), Is.EqualTo("photo_50"));
			Assert.That(UsersFields.Photo100.ToString(), Is.EqualTo("photo_100"));
			Assert.That(UsersFields.Photo200Orig.ToString(), Is.EqualTo("photo_200_orig"));
			Assert.That(UsersFields.Photo200.ToString(), Is.EqualTo("photo_200"));
			Assert.That(UsersFields.Photo400Orig.ToString(), Is.EqualTo("photo_400_orig"));
			Assert.That(UsersFields.PhotoMax.ToString(), Is.EqualTo("photo_max"));
			Assert.That(UsersFields.PhotoMaxOrig.ToString(), Is.EqualTo("photo_max_orig"));
			Assert.That(UsersFields.HasMobile.ToString(), Is.EqualTo("has_mobile"));
			Assert.That(UsersFields.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(UsersFields.Education.ToString(), Is.EqualTo("education"));
			Assert.That(UsersFields.Online.ToString(), Is.EqualTo("online"));
			Assert.That(UsersFields.OnlineMobile.ToString(), Is.EqualTo("online_mobile"));
			Assert.That(UsersFields.FriendLists.ToString(), Is.EqualTo("lists"));
			Assert.That(UsersFields.Relation.ToString(), Is.EqualTo("relation"));
			Assert.That(UsersFields.LastSeen.ToString(), Is.EqualTo("last_seen"));
			Assert.That(UsersFields.Status.ToString(), Is.EqualTo("status"));
			Assert.That(UsersFields.CanWritePrivateMessage.ToString(), Is.EqualTo("can_write_private_message"));
			Assert.That(UsersFields.CanSeeAllPosts.ToString(), Is.EqualTo("can_see_all_posts"));
			Assert.That(UsersFields.CanPost.ToString(), Is.EqualTo("can_post"));
			Assert.That(UsersFields.Universities.ToString(), Is.EqualTo("universities"));
			Assert.That(UsersFields.Connections.ToString(), Is.EqualTo("connections"));
			Assert.That(UsersFields.Site.ToString(), Is.EqualTo("site"));
			Assert.That(UsersFields.Schools.ToString(), Is.EqualTo("schools"));
			Assert.That(UsersFields.CanSeeAudio.ToString(), Is.EqualTo("can_see_audio"));
			Assert.That(UsersFields.CommonCount.ToString(), Is.EqualTo("common_count"));
			Assert.That(UsersFields.Relatives.ToString(), Is.EqualTo("relatives"));
			Assert.That(UsersFields.Counters.ToString(), Is.EqualTo("counters"));
			Assert.That(UsersFields.All.ToString(), Is.EqualTo("bdate,can_post,can_see_all_posts,can_see_audio,can_write_private_message,city,common_count,connections,contacts,counters,country,domain,education,has_mobile,last_seen,lists,nickname,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,sex,site,status,timezone,universities"));
			// parse test
			Assert.That(UsersFields.FromJsonString("nickname"), Is.EqualTo(UsersFields.Nickname));
			Assert.That(UsersFields.FromJsonString("domain"), Is.EqualTo(UsersFields.Domain));
			Assert.That(UsersFields.FromJsonString("sex"), Is.EqualTo(UsersFields.Sex));
			Assert.That(UsersFields.FromJsonString("bdate"), Is.EqualTo(UsersFields.BirthDate));
			Assert.That(UsersFields.FromJsonString("city"), Is.EqualTo(UsersFields.City));
			Assert.That(UsersFields.FromJsonString("country"), Is.EqualTo(UsersFields.Country));
			Assert.That(UsersFields.FromJsonString("timezone"), Is.EqualTo(UsersFields.Timezone));
			Assert.That(UsersFields.FromJsonString("photo_50"), Is.EqualTo(UsersFields.Photo50));
			Assert.That(UsersFields.FromJsonString("photo_100"), Is.EqualTo(UsersFields.Photo100));
			Assert.That(UsersFields.FromJsonString("photo_200_orig"), Is.EqualTo(UsersFields.Photo200Orig));
			Assert.That(UsersFields.FromJsonString("photo_200"), Is.EqualTo(UsersFields.Photo200));
			Assert.That(UsersFields.FromJsonString("photo_400_orig"), Is.EqualTo(UsersFields.Photo400Orig));
			Assert.That(UsersFields.FromJsonString("photo_max"), Is.EqualTo(UsersFields.PhotoMax));
			Assert.That(UsersFields.FromJsonString("photo_max_orig"), Is.EqualTo(UsersFields.PhotoMaxOrig));
			Assert.That(UsersFields.FromJsonString("has_mobile"), Is.EqualTo(UsersFields.HasMobile));
			Assert.That(UsersFields.FromJsonString("contacts"), Is.EqualTo(UsersFields.Contacts));
			Assert.That(UsersFields.FromJsonString("education"), Is.EqualTo(UsersFields.Education));
			Assert.That(UsersFields.FromJsonString("online"), Is.EqualTo(UsersFields.Online));
			Assert.That(UsersFields.FromJsonString("online_mobile"), Is.EqualTo(UsersFields.OnlineMobile));
			Assert.That(UsersFields.FromJsonString("lists"), Is.EqualTo(UsersFields.FriendLists));
			Assert.That(UsersFields.FromJsonString("relation"), Is.EqualTo(UsersFields.Relation));
			Assert.That(UsersFields.FromJsonString("last_seen"), Is.EqualTo(UsersFields.LastSeen));
			Assert.That(UsersFields.FromJsonString("status"), Is.EqualTo(UsersFields.Status));
			Assert.That(UsersFields.FromJsonString("can_write_private_message"), Is.EqualTo(UsersFields.CanWritePrivateMessage));
			Assert.That(UsersFields.FromJsonString("can_see_all_posts"), Is.EqualTo(UsersFields.CanSeeAllPosts));
			Assert.That(UsersFields.FromJsonString("can_post"), Is.EqualTo(UsersFields.CanPost));
			Assert.That(UsersFields.FromJsonString("universities"), Is.EqualTo(UsersFields.Universities));
			Assert.That(UsersFields.FromJsonString("connections"), Is.EqualTo(UsersFields.Connections));
			Assert.That(UsersFields.FromJsonString("site"), Is.EqualTo(UsersFields.Site));
			Assert.That(UsersFields.FromJsonString("schools"), Is.EqualTo(UsersFields.Schools));
			Assert.That(UsersFields.FromJsonString("can_see_audio"), Is.EqualTo(UsersFields.CanSeeAudio));
			Assert.That(UsersFields.FromJsonString("common_count"), Is.EqualTo(UsersFields.CommonCount));
			Assert.That(UsersFields.FromJsonString("relatives"), Is.EqualTo(UsersFields.Relatives));
			Assert.That(UsersFields.FromJsonString("counters"), Is.EqualTo(UsersFields.Counters));
			Assert.That(UsersFields.FromJsonString("nickname,domain,sex,bdate,city,country,timezone,photo_50,photo_100,photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,has_mobile,contacts,education,online,online_mobile,lists,relation,last_seen,status,can_write_private_message,can_see_all_posts,can_post,universities,connections,site,schools,can_see_audio,common_count,relatives,counters"), Is.EqualTo(UsersFields.All));
		}

		[Test]
        public void VideoFiltersTest()
        {
			// get test
			Assert.That(VideoFilters.Mp4.ToString(), Is.EqualTo("mp4"));
			Assert.That(VideoFilters.Youtube.ToString(), Is.EqualTo("youtube"));
			Assert.That(VideoFilters.Vimeo.ToString(), Is.EqualTo("vimeo"));
			Assert.That(VideoFilters.Short.ToString(), Is.EqualTo("short"));
			Assert.That(VideoFilters.Long.ToString(), Is.EqualTo("long"));
			Assert.That(VideoFilters.All.ToString(), Is.EqualTo("long,mp4,short,vimeo,youtube"));
			// parse test
			Assert.That(VideoFilters.FromJsonString("mp4"), Is.EqualTo(VideoFilters.Mp4));
			Assert.That(VideoFilters.FromJsonString("youtube"), Is.EqualTo(VideoFilters.Youtube));
			Assert.That(VideoFilters.FromJsonString("vimeo"), Is.EqualTo(VideoFilters.Vimeo));
			Assert.That(VideoFilters.FromJsonString("short"), Is.EqualTo(VideoFilters.Short));
			Assert.That(VideoFilters.FromJsonString("long"), Is.EqualTo(VideoFilters.Long));
			Assert.That(VideoFilters.FromJsonString("mp4,youtube,vimeo,short,long"), Is.EqualTo(VideoFilters.All));
		}

	}
}

