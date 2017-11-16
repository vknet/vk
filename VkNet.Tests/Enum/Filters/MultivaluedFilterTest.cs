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
			Assert.That(AccountFields.FromJson("country"), Is.EqualTo(AccountFields.Country));
			Assert.That(AccountFields.FromJson("https_required"), Is.EqualTo(AccountFields.HttpsRequired));
			Assert.That(AccountFields.FromJson("own_posts_default"), Is.EqualTo(AccountFields.OwnPostsDefault));
			Assert.That(AccountFields.FromJson("no_wall_replies"), Is.EqualTo(AccountFields.NoWallReplies));
			Assert.That(AccountFields.FromJson("intro"), Is.EqualTo(AccountFields.Intro));
			Assert.That(AccountFields.FromJson("lang"), Is.EqualTo(AccountFields.Language));
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
			Assert.That(CountersFilter.FromJson("friends"), Is.EqualTo(CountersFilter.Friends));
			Assert.That(CountersFilter.FromJson("messages"), Is.EqualTo(CountersFilter.Messages));
			Assert.That(CountersFilter.FromJson("photos"), Is.EqualTo(CountersFilter.Photos));
	        Assert.That(CountersFilter.FromJson("videos"), Is.EqualTo(CountersFilter.Videos));
			Assert.That(CountersFilter.FromJson("gifts"), Is.EqualTo(CountersFilter.Gifts));
			Assert.That(CountersFilter.FromJson("events"), Is.EqualTo(CountersFilter.Events));
			Assert.That(CountersFilter.FromJson("groups"), Is.EqualTo(CountersFilter.Groups));
			Assert.That(CountersFilter.FromJson("notifications"), Is.EqualTo(CountersFilter.Notifications));
			Assert.That(CountersFilter.FromJson("app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos"), Is.EqualTo(CountersFilter.All));
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
			Assert.That(GroupsFields.FromJson("city"), Is.EqualTo(GroupsFields.CityId));
			Assert.That(GroupsFields.FromJson("country"), Is.EqualTo(GroupsFields.CountryId));
			Assert.That(GroupsFields.FromJson("place"), Is.EqualTo(GroupsFields.Place));
			Assert.That(GroupsFields.FromJson("description"), Is.EqualTo(GroupsFields.Description));
			Assert.That(GroupsFields.FromJson("wiki_page"), Is.EqualTo(GroupsFields.WikiPage));
			Assert.That(GroupsFields.FromJson("members_count"), Is.EqualTo(GroupsFields.MembersCount));
			Assert.That(GroupsFields.FromJson("counters"), Is.EqualTo(GroupsFields.Counters));
			Assert.That(GroupsFields.FromJson("start_date"), Is.EqualTo(GroupsFields.StartDate));
			Assert.That(GroupsFields.FromJson("end_date"), Is.EqualTo(GroupsFields.EndDate));
			Assert.That(GroupsFields.FromJson("can_post"), Is.EqualTo(GroupsFields.CanPost));
			Assert.That(GroupsFields.FromJson("can_see_all_posts"), Is.EqualTo(GroupsFields.CanSeelAllPosts));
			Assert.That(GroupsFields.FromJson("can_upload_doc"), Is.EqualTo(GroupsFields.CanUploadDocuments));
			Assert.That(GroupsFields.FromJson("can_create_topic"), Is.EqualTo(GroupsFields.CanCreateTopic));
			Assert.That(GroupsFields.FromJson("activity"), Is.EqualTo(GroupsFields.Activity));
			Assert.That(GroupsFields.FromJson("status"), Is.EqualTo(GroupsFields.Status));
			Assert.That(GroupsFields.FromJson("contacts"), Is.EqualTo(GroupsFields.Contacts));
			Assert.That(GroupsFields.FromJson("links"), Is.EqualTo(GroupsFields.Links));
			Assert.That(GroupsFields.FromJson("fixed_post"), Is.EqualTo(GroupsFields.FixedPostId));
			Assert.That(GroupsFields.FromJson("verified"), Is.EqualTo(GroupsFields.IsVerified));
			Assert.That(GroupsFields.FromJson("site"), Is.EqualTo(GroupsFields.Site));
			Assert.That(GroupsFields.FromJson("ban_info"), Is.EqualTo(GroupsFields.BanInfo));
			Assert.That(GroupsFields.FromJson("activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"), Is.EqualTo(GroupsFields.All));
			Assert.That(GroupsFields.FromJson("activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"), Is.EqualTo(GroupsFields.AllUndocumented));
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
			Assert.That(GroupsFilters.FromJson("admin"), Is.EqualTo(GroupsFilters.Administrator));
			Assert.That(GroupsFilters.FromJson("editor"), Is.EqualTo(GroupsFilters.Editor));
			Assert.That(GroupsFilters.FromJson("moder"), Is.EqualTo(GroupsFilters.Moderator));
			Assert.That(GroupsFilters.FromJson("groups"), Is.EqualTo(GroupsFilters.Groups));
			Assert.That(GroupsFilters.FromJson("publics"), Is.EqualTo(GroupsFilters.Publics));
			Assert.That(GroupsFilters.FromJson("events"), Is.EqualTo(GroupsFilters.Events));
			Assert.That(GroupsFilters.FromJson("admin,editor,moder,groups,publics,events"), Is.EqualTo(GroupsFilters.All));
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
			Assert.That(ProfileFields.FromJson("user_id"), Is.EqualTo(ProfileFields.Uid));
			Assert.That(ProfileFields.FromJson("first_name"), Is.EqualTo(ProfileFields.FirstName));
			Assert.That(ProfileFields.FromJson("last_name"), Is.EqualTo(ProfileFields.LastName));
			Assert.That(ProfileFields.FromJson("sex"), Is.EqualTo(ProfileFields.Sex));
			Assert.That(ProfileFields.FromJson("bdate"), Is.EqualTo(ProfileFields.BirthDate));
			Assert.That(ProfileFields.FromJson("city"), Is.EqualTo(ProfileFields.City));
			Assert.That(ProfileFields.FromJson("country"), Is.EqualTo(ProfileFields.Country));
			Assert.That(ProfileFields.FromJson("photo_50"), Is.EqualTo(ProfileFields.Photo50));
			Assert.That(ProfileFields.FromJson("photo_100"), Is.EqualTo(ProfileFields.Photo100));
			Assert.That(ProfileFields.FromJson("photo_200"), Is.EqualTo(ProfileFields.Photo200));
			Assert.That(ProfileFields.FromJson("photo_200_orig"), Is.EqualTo(ProfileFields.Photo200Orig));
			Assert.That(ProfileFields.FromJson("photo_400_orig"), Is.EqualTo(ProfileFields.Photo400Orig));
			Assert.That(ProfileFields.FromJson("photo_max"), Is.EqualTo(ProfileFields.PhotoMax));
			Assert.That(ProfileFields.FromJson("photo_max_orig"), Is.EqualTo(ProfileFields.PhotoMaxOrig));
			Assert.That(ProfileFields.FromJson("online"), Is.EqualTo(ProfileFields.Online));
			Assert.That(ProfileFields.FromJson("lists"), Is.EqualTo(ProfileFields.FriendLists));
			Assert.That(ProfileFields.FromJson("domain"), Is.EqualTo(ProfileFields.Domain));
			Assert.That(ProfileFields.FromJson("has_mobile"), Is.EqualTo(ProfileFields.HasMobile));
			Assert.That(ProfileFields.FromJson("contacts"), Is.EqualTo(ProfileFields.Contacts));
			Assert.That(ProfileFields.FromJson("connections"), Is.EqualTo(ProfileFields.Connections));
			Assert.That(ProfileFields.FromJson("site"), Is.EqualTo(ProfileFields.Site));
			Assert.That(ProfileFields.FromJson("education"), Is.EqualTo(ProfileFields.Education));
			Assert.That(ProfileFields.FromJson("universities"), Is.EqualTo(ProfileFields.Universities));
			Assert.That(ProfileFields.FromJson("schools"), Is.EqualTo(ProfileFields.Schools));
			Assert.That(ProfileFields.FromJson("can_post"), Is.EqualTo(ProfileFields.CanPost));
			Assert.That(ProfileFields.FromJson("can_see_all_posts"), Is.EqualTo(ProfileFields.CanSeeAllPosts));
			Assert.That(ProfileFields.FromJson("can_see_audio"), Is.EqualTo(ProfileFields.CanSeeAudio));
			Assert.That(ProfileFields.FromJson("can_write_private_message"), Is.EqualTo(ProfileFields.CanWritePrivateMessage));
			Assert.That(ProfileFields.FromJson("status"), Is.EqualTo(ProfileFields.Status));
			Assert.That(ProfileFields.FromJson("last_seen"), Is.EqualTo(ProfileFields.LastSeen));
			Assert.That(ProfileFields.FromJson("common_count"), Is.EqualTo(ProfileFields.CommonCount));
			Assert.That(ProfileFields.FromJson("relation"), Is.EqualTo(ProfileFields.Relation));
			Assert.That(ProfileFields.FromJson("relatives"), Is.EqualTo(ProfileFields.Relatives));
			Assert.That(ProfileFields.FromJson("counters"), Is.EqualTo(ProfileFields.Counters));
			Assert.That(ProfileFields.FromJson("nickname"), Is.EqualTo(ProfileFields.Nickname));
			Assert.That(ProfileFields.FromJson("timezone"), Is.EqualTo(ProfileFields.Timezone));
			Assert.That(ProfileFields.FromJson("lang"), Is.EqualTo(ProfileFields.Language));
			Assert.That(ProfileFields.FromJson("online_mobile"), Is.EqualTo(ProfileFields.OnlineMobile));
			Assert.That(ProfileFields.FromJson("online_app"), Is.EqualTo(ProfileFields.OnlineApp));
			Assert.That(ProfileFields.FromJson("relation_partner"), Is.EqualTo(ProfileFields.RelationPartner));
			Assert.That(ProfileFields.FromJson("personal"), Is.EqualTo(ProfileFields.StandInLife));
			Assert.That(ProfileFields.FromJson("interests"), Is.EqualTo(ProfileFields.Interests));
			Assert.That(ProfileFields.FromJson("music"), Is.EqualTo(ProfileFields.Music));
			Assert.That(ProfileFields.FromJson("activities"), Is.EqualTo(ProfileFields.Activities));
			Assert.That(ProfileFields.FromJson("movies"), Is.EqualTo(ProfileFields.Movies));
			Assert.That(ProfileFields.FromJson("tv"), Is.EqualTo(ProfileFields.Tv));
			Assert.That(ProfileFields.FromJson("books"), Is.EqualTo(ProfileFields.Books));
			Assert.That(ProfileFields.FromJson("games"), Is.EqualTo(ProfileFields.Games));
			Assert.That(ProfileFields.FromJson("about"), Is.EqualTo(ProfileFields.About));
			Assert.That(ProfileFields.FromJson("quotes"), Is.EqualTo(ProfileFields.Quotes));
			Assert.That(ProfileFields.FromJson("invited_by"), Is.EqualTo(ProfileFields.InvitedBy));
			Assert.That(ProfileFields.FromJson("blacklisted_by_me"), Is.EqualTo(ProfileFields.BlacklistedByMe));
			Assert.That(ProfileFields.FromJson("blacklisted"), Is.EqualTo(ProfileFields.Blacklisted));
			Assert.That(ProfileFields.FromJson("military"), Is.EqualTo(ProfileFields.Military));
			Assert.That(ProfileFields.FromJson("career"), Is.EqualTo(ProfileFields.Career));
			Assert.That(ProfileFields.FromJson("friend_status"), Is.EqualTo(ProfileFields.FriendStatus));
			Assert.That(ProfileFields.FromJson("is_friend"), Is.EqualTo(ProfileFields.IsFriend));
			Assert.That(ProfileFields.FromJson("screen_name"), Is.EqualTo(ProfileFields.ScreenName));
			Assert.That(ProfileFields.FromJson("is_hidden_from_feed"), Is.EqualTo(ProfileFields.IsHiddenFromFeed));
			Assert.That(ProfileFields.FromJson("is_favorite"), Is.EqualTo(ProfileFields.IsFavorite));
			Assert.That(ProfileFields.FromJson("can_send_friend_request"), Is.EqualTo(ProfileFields.CanSendFriendRequest));
			Assert.That(ProfileFields.FromJson("wall_comments"), Is.EqualTo(ProfileFields.WallComments));
			Assert.That(ProfileFields.FromJson("verified"), Is.EqualTo(ProfileFields.Verified));
			Assert.That(ProfileFields.FromJson("bdate,blacklisted,blacklisted_by_me,can_post,can_see_all_posts,can_see_audio,can_send_friend_request,can_write_private_message,career,city,common_count,connections,contacts,counters,country,crop_photo,domain,education,first_name,followers_count,friend_status,has_mobile,is_favorite,is_friend,is_hidden_from_feed,last_name,last_seen,lists,military,nickname,online,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,screen_name,sex,site,status,timezone,universities,user_id,verified,wall_comments"), Is.EqualTo(ProfileFields.All));
			Assert.That(ProfileFields.FromJson("about,activities,bdate,blacklisted,blacklisted_by_me,books,can_post,can_see_all_posts,can_see_audio,can_send_friend_request,can_write_private_message,career,city,common_count,connections,contacts,counters,country,crop_photo,domain,education,first_name,followers_count,friend_status,games,has_mobile,interests,invited_by,is_favorite,is_friend,is_hidden_from_feed,lang,last_name,last_seen,lists,military,movies,music,nickname,online,online_app,online_mobile,personal,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,quotes,relation,relation_partner,relatives,schools,screen_name,sex,site,status,timezone,tv,universities,user_id,verified,wall_comments"), Is.EqualTo(ProfileFields.AllUndocumented));
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
			Assert.That(Settings.FromJson("notify"), Is.EqualTo(Settings.Notify));
			Assert.That(Settings.FromJson("friends"), Is.EqualTo(Settings.Friends));
			Assert.That(Settings.FromJson("photos"), Is.EqualTo(Settings.Photos));
			Assert.That(Settings.FromJson("audio"), Is.EqualTo(Settings.Audio));
			Assert.That(Settings.FromJson("video"), Is.EqualTo(Settings.Video));
			Assert.That(Settings.FromJson("pages"), Is.EqualTo(Settings.Pages));
			Assert.That(Settings.FromJson("addLinkToLeftMenu"), Is.EqualTo(Settings.AddLinkToLeftMenu));
			Assert.That(Settings.FromJson("status"), Is.EqualTo(Settings.Status));
			Assert.That(Settings.FromJson("notes"), Is.EqualTo(Settings.Notes));
			Assert.That(Settings.FromJson("messages"), Is.EqualTo(Settings.Messages));
			Assert.That(Settings.FromJson("wall"), Is.EqualTo(Settings.Wall));
			Assert.That(Settings.FromJson("ads"), Is.EqualTo(Settings.Ads));
			Assert.That(Settings.FromJson("offline"), Is.EqualTo(Settings.Offline));
			Assert.That(Settings.FromJson("docs"), Is.EqualTo(Settings.Documents));
			Assert.That(Settings.FromJson("groups"), Is.EqualTo(Settings.Groups));
			Assert.That(Settings.FromJson("notifications"), Is.EqualTo(Settings.Notifications));
			Assert.That(Settings.FromJson("stats"), Is.EqualTo(Settings.Statistic));
			Assert.That(Settings.FromJson("email"), Is.EqualTo(Settings.Email));
			Assert.That(Settings.FromJson("market"), Is.EqualTo(Settings.Market));
			Assert.That(Settings.FromJson("notify,friends,photos,audio,video,pages,status,notes,messages,wall,ads,docs,groups,notifications,stats,email,market"), Is.EqualTo(Settings.All));
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
			Assert.That(SubscribeFilter.FromJson("msg"), Is.EqualTo(SubscribeFilter.Message));
			Assert.That(SubscribeFilter.FromJson("friend"), Is.EqualTo(SubscribeFilter.Friend));
			Assert.That(SubscribeFilter.FromJson("call"), Is.EqualTo(SubscribeFilter.Call));
			Assert.That(SubscribeFilter.FromJson("reply"), Is.EqualTo(SubscribeFilter.Reply));
			Assert.That(SubscribeFilter.FromJson("mention"), Is.EqualTo(SubscribeFilter.Mention));
			Assert.That(SubscribeFilter.FromJson("group"), Is.EqualTo(SubscribeFilter.Group));
			Assert.That(SubscribeFilter.FromJson("like"), Is.EqualTo(SubscribeFilter.Like));
			Assert.That(SubscribeFilter.FromJson("msg,friend,call,reply,mention,group,like"), Is.EqualTo(SubscribeFilter.All));
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
			Assert.That(UsersFields.FromJson("nickname"), Is.EqualTo(UsersFields.Nickname));
			Assert.That(UsersFields.FromJson("domain"), Is.EqualTo(UsersFields.Domain));
			Assert.That(UsersFields.FromJson("sex"), Is.EqualTo(UsersFields.Sex));
			Assert.That(UsersFields.FromJson("bdate"), Is.EqualTo(UsersFields.BirthDate));
			Assert.That(UsersFields.FromJson("city"), Is.EqualTo(UsersFields.City));
			Assert.That(UsersFields.FromJson("country"), Is.EqualTo(UsersFields.Country));
			Assert.That(UsersFields.FromJson("timezone"), Is.EqualTo(UsersFields.Timezone));
			Assert.That(UsersFields.FromJson("photo_50"), Is.EqualTo(UsersFields.Photo50));
			Assert.That(UsersFields.FromJson("photo_100"), Is.EqualTo(UsersFields.Photo100));
			Assert.That(UsersFields.FromJson("photo_200_orig"), Is.EqualTo(UsersFields.Photo200Orig));
			Assert.That(UsersFields.FromJson("photo_200"), Is.EqualTo(UsersFields.Photo200));
			Assert.That(UsersFields.FromJson("photo_400_orig"), Is.EqualTo(UsersFields.Photo400Orig));
			Assert.That(UsersFields.FromJson("photo_max"), Is.EqualTo(UsersFields.PhotoMax));
			Assert.That(UsersFields.FromJson("photo_max_orig"), Is.EqualTo(UsersFields.PhotoMaxOrig));
			Assert.That(UsersFields.FromJson("has_mobile"), Is.EqualTo(UsersFields.HasMobile));
			Assert.That(UsersFields.FromJson("contacts"), Is.EqualTo(UsersFields.Contacts));
			Assert.That(UsersFields.FromJson("education"), Is.EqualTo(UsersFields.Education));
			Assert.That(UsersFields.FromJson("online"), Is.EqualTo(UsersFields.Online));
			Assert.That(UsersFields.FromJson("online_mobile"), Is.EqualTo(UsersFields.OnlineMobile));
			Assert.That(UsersFields.FromJson("lists"), Is.EqualTo(UsersFields.FriendLists));
			Assert.That(UsersFields.FromJson("relation"), Is.EqualTo(UsersFields.Relation));
			Assert.That(UsersFields.FromJson("last_seen"), Is.EqualTo(UsersFields.LastSeen));
			Assert.That(UsersFields.FromJson("status"), Is.EqualTo(UsersFields.Status));
			Assert.That(UsersFields.FromJson("can_write_private_message"), Is.EqualTo(UsersFields.CanWritePrivateMessage));
			Assert.That(UsersFields.FromJson("can_see_all_posts"), Is.EqualTo(UsersFields.CanSeeAllPosts));
			Assert.That(UsersFields.FromJson("can_post"), Is.EqualTo(UsersFields.CanPost));
			Assert.That(UsersFields.FromJson("universities"), Is.EqualTo(UsersFields.Universities));
			Assert.That(UsersFields.FromJson("connections"), Is.EqualTo(UsersFields.Connections));
			Assert.That(UsersFields.FromJson("site"), Is.EqualTo(UsersFields.Site));
			Assert.That(UsersFields.FromJson("schools"), Is.EqualTo(UsersFields.Schools));
			Assert.That(UsersFields.FromJson("can_see_audio"), Is.EqualTo(UsersFields.CanSeeAudio));
			Assert.That(UsersFields.FromJson("common_count"), Is.EqualTo(UsersFields.CommonCount));
			Assert.That(UsersFields.FromJson("relatives"), Is.EqualTo(UsersFields.Relatives));
			Assert.That(UsersFields.FromJson("counters"), Is.EqualTo(UsersFields.Counters));
			Assert.That(UsersFields.FromJson("nickname,domain,sex,bdate,city,country,timezone,photo_50,photo_100,photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,has_mobile,contacts,education,online,online_mobile,lists,relation,last_seen,status,can_write_private_message,can_see_all_posts,can_post,universities,connections,site,schools,can_see_audio,common_count,relatives,counters"), Is.EqualTo(UsersFields.All));
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
			Assert.That(VideoFilters.FromJson("mp4"), Is.EqualTo(VideoFilters.Mp4));
			Assert.That(VideoFilters.FromJson("youtube"), Is.EqualTo(VideoFilters.Youtube));
			Assert.That(VideoFilters.FromJson("vimeo"), Is.EqualTo(VideoFilters.Vimeo));
			Assert.That(VideoFilters.FromJson("short"), Is.EqualTo(VideoFilters.Short));
			Assert.That(VideoFilters.FromJson("long"), Is.EqualTo(VideoFilters.Long));
			Assert.That(VideoFilters.FromJson("mp4,youtube,vimeo,short,long"), Is.EqualTo(VideoFilters.All));
		}

	}
}

