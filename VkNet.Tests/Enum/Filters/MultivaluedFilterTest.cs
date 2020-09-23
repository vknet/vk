using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Enum.Filters
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

			Assert.That(AccountFields.FromJsonString("https_required")
					, Is.EqualTo(AccountFields.HttpsRequired));

			Assert.That(AccountFields.FromJsonString("own_posts_default")
					, Is.EqualTo(AccountFields.OwnPostsDefault));

			Assert.That(AccountFields.FromJsonString("no_wall_replies")
					, Is.EqualTo(AccountFields.NoWallReplies));

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

			Assert.That(CountersFilter.All.ToString()
					, Is.EqualTo("app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos"));

			// parse test
			Assert.That(CountersFilter.FromJsonString("friends"), Is.EqualTo(CountersFilter.Friends));
			Assert.That(CountersFilter.FromJsonString("messages"), Is.EqualTo(CountersFilter.Messages));
			Assert.That(CountersFilter.FromJsonString("photos"), Is.EqualTo(CountersFilter.Photos));
			Assert.That(CountersFilter.FromJsonString("videos"), Is.EqualTo(CountersFilter.Videos));
			Assert.That(CountersFilter.FromJsonString("gifts"), Is.EqualTo(CountersFilter.Gifts));
			Assert.That(CountersFilter.FromJsonString("events"), Is.EqualTo(CountersFilter.Events));
			Assert.That(CountersFilter.FromJsonString("groups"), Is.EqualTo(CountersFilter.Groups));

			Assert.That(CountersFilter.FromJsonString("notifications")
					, Is.EqualTo(CountersFilter.Notifications));

			Assert.That(CountersFilter.FromJsonString(
							"app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos")
					, Is.EqualTo(CountersFilter.All));
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
			Assert.That(GroupsFields.EndDate.ToString(), Is.EqualTo("finish_date"));
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

			Assert.That(GroupsFields.All.ToString()
					, Is.EqualTo("activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"));

			Assert.That(GroupsFields.AllUndocumented.ToString()
					, Is.EqualTo("activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"));

			// parse test
			Assert.That(GroupsFields.FromJsonString("city"), Is.EqualTo(GroupsFields.CityId));
			Assert.That(GroupsFields.FromJsonString("country"), Is.EqualTo(GroupsFields.CountryId));
			Assert.That(GroupsFields.FromJsonString("place"), Is.EqualTo(GroupsFields.Place));

			Assert.That(GroupsFields.FromJsonString("description")
					, Is.EqualTo(GroupsFields.Description));

			Assert.That(GroupsFields.FromJsonString("wiki_page"), Is.EqualTo(GroupsFields.WikiPage));

			Assert.That(GroupsFields.FromJsonString("members_count")
					, Is.EqualTo(GroupsFields.MembersCount));

			Assert.That(GroupsFields.FromJsonString("counters"), Is.EqualTo(GroupsFields.Counters));
			Assert.That(GroupsFields.FromJsonString("start_date"), Is.EqualTo(GroupsFields.StartDate));
			Assert.That(GroupsFields.FromJsonString("finish_date"), Is.EqualTo(GroupsFields.EndDate));
			Assert.That(GroupsFields.FromJsonString("can_post"), Is.EqualTo(GroupsFields.CanPost));

			Assert.That(GroupsFields.FromJsonString("can_see_all_posts")
					, Is.EqualTo(GroupsFields.CanSeelAllPosts));

			Assert.That(GroupsFields.FromJsonString("can_upload_doc")
					, Is.EqualTo(GroupsFields.CanUploadDocuments));

			Assert.That(GroupsFields.FromJsonString("can_create_topic")
					, Is.EqualTo(GroupsFields.CanCreateTopic));

			Assert.That(GroupsFields.FromJsonString("activity"), Is.EqualTo(GroupsFields.Activity));
			Assert.That(GroupsFields.FromJsonString("status"), Is.EqualTo(GroupsFields.Status));
			Assert.That(GroupsFields.FromJsonString("contacts"), Is.EqualTo(GroupsFields.Contacts));
			Assert.That(GroupsFields.FromJsonString("links"), Is.EqualTo(GroupsFields.Links));
			Assert.That(GroupsFields.FromJsonString("fixed_post"), Is.EqualTo(GroupsFields.FixedPostId));
			Assert.That(GroupsFields.FromJsonString("verified"), Is.EqualTo(GroupsFields.IsVerified));
			Assert.That(GroupsFields.FromJsonString("site"), Is.EqualTo(GroupsFields.Site));
			Assert.That(GroupsFields.FromJsonString("ban_info"), Is.EqualTo(GroupsFields.BanInfo));

			Assert.That(GroupsFields.FromJsonString("activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page")
					, Is.EqualTo(GroupsFields.All));

			Assert.That(GroupsFields.FromJsonString("activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page")
					, Is.EqualTo(GroupsFields.AllUndocumented));
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

			Assert.That(GroupsFilters.FromJsonString("admin,editor,moder,groups,publics,events")
					, Is.EqualTo(GroupsFilters.All));
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

			Assert.That(SubscribeFilter.All.ToString()
					, Is.EqualTo("call,friend,group,like,mention,msg,reply"));

			// parse test
			Assert.That(SubscribeFilter.FromJsonString("msg"), Is.EqualTo(SubscribeFilter.Message));
			Assert.That(SubscribeFilter.FromJsonString("friend"), Is.EqualTo(SubscribeFilter.Friend));
			Assert.That(SubscribeFilter.FromJsonString("call"), Is.EqualTo(SubscribeFilter.Call));
			Assert.That(SubscribeFilter.FromJsonString("reply"), Is.EqualTo(SubscribeFilter.Reply));
			Assert.That(SubscribeFilter.FromJsonString("mention"), Is.EqualTo(SubscribeFilter.Mention));
			Assert.That(SubscribeFilter.FromJsonString("group"), Is.EqualTo(SubscribeFilter.Group));
			Assert.That(SubscribeFilter.FromJsonString("like"), Is.EqualTo(SubscribeFilter.Like));

			Assert.That(SubscribeFilter.FromJsonString("msg,friend,call,reply,mention,group,like")
					, Is.EqualTo(SubscribeFilter.All));
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

			Assert.That(UsersFields.CanWritePrivateMessage.ToString()
					, Is.EqualTo("can_write_private_message"));

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
			Assert.That(UsersFields.CanAccessClosed.ToString(), Is.EqualTo("can_access_closed"));
			Assert.That(UsersFields.IsClosed.ToString(), Is.EqualTo("is_closed"));
			Assert.That(UsersFields.FirstNameNom.ToString(), Is.EqualTo("first_name_nom"));
			Assert.That(UsersFields.FirstNameGen.ToString(), Is.EqualTo("first_name_gen"));
			Assert.That(UsersFields.FirstNameDat.ToString(), Is.EqualTo("first_name_dat"));
			Assert.That(UsersFields.FirstNameAcc.ToString(), Is.EqualTo("first_name_acc"));
			Assert.That(UsersFields.FirstNameIns.ToString(), Is.EqualTo("first_name_ins"));
			Assert.That(UsersFields.FirstNameAbl.ToString(), Is.EqualTo("first_name_abl"));
			Assert.That(UsersFields.LastNameNom.ToString(), Is.EqualTo("last_name_nom"));
			Assert.That(UsersFields.LastNameGen.ToString(), Is.EqualTo("last_name_gen"));
			Assert.That(UsersFields.LastNameDat.ToString(), Is.EqualTo("last_name_dat"));
			Assert.That(UsersFields.LastNameAcc.ToString(), Is.EqualTo("last_name_acc"));
			Assert.That(UsersFields.LastNameIns.ToString(), Is.EqualTo("last_name_ins"));
			Assert.That(UsersFields.LastNameAbl.ToString(), Is.EqualTo("last_name_abl"));

			Assert.That(UsersFields.All.ToString()
					, Is.EqualTo("bdate,can_access_closed,can_post,can_see_all_posts,can_see_audio,can_write_private_message,city,common_count,connections,contacts,counters,country,domain,education,first_name_abl,first_name_acc,first_name_dat,first_name_gen,first_name_ins,first_name_nom,has_mobile,is_closed,last_name_abl,last_name_acc,last_name_dat,last_name_gen,last_name_ins,last_name_nom,last_seen,lists,nickname,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,sex,site,status,timezone,universities"));

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

			Assert.That(UsersFields.FromJsonString("photo_200_orig")
					, Is.EqualTo(UsersFields.Photo200Orig));

			Assert.That(UsersFields.FromJsonString("photo_200"), Is.EqualTo(UsersFields.Photo200));

			Assert.That(UsersFields.FromJsonString("photo_400_orig")
					, Is.EqualTo(UsersFields.Photo400Orig));

			Assert.That(UsersFields.FromJsonString("photo_max"), Is.EqualTo(UsersFields.PhotoMax));

			Assert.That(UsersFields.FromJsonString("photo_max_orig")
					, Is.EqualTo(UsersFields.PhotoMaxOrig));

			Assert.That(UsersFields.FromJsonString("has_mobile"), Is.EqualTo(UsersFields.HasMobile));
			Assert.That(UsersFields.FromJsonString("contacts"), Is.EqualTo(UsersFields.Contacts));
			Assert.That(UsersFields.FromJsonString("education"), Is.EqualTo(UsersFields.Education));
			Assert.That(UsersFields.FromJsonString("online"), Is.EqualTo(UsersFields.Online));

			Assert.That(UsersFields.FromJsonString("online_mobile")
					, Is.EqualTo(UsersFields.OnlineMobile));

			Assert.That(UsersFields.FromJsonString("lists"), Is.EqualTo(UsersFields.FriendLists));
			Assert.That(UsersFields.FromJsonString("relation"), Is.EqualTo(UsersFields.Relation));
			Assert.That(UsersFields.FromJsonString("last_seen"), Is.EqualTo(UsersFields.LastSeen));
			Assert.That(UsersFields.FromJsonString("status"), Is.EqualTo(UsersFields.Status));

			Assert.That(UsersFields.FromJsonString("can_write_private_message")
					, Is.EqualTo(UsersFields.CanWritePrivateMessage));

			Assert.That(UsersFields.FromJsonString("can_see_all_posts")
					, Is.EqualTo(UsersFields.CanSeeAllPosts));

			Assert.That(UsersFields.FromJsonString("can_post"), Is.EqualTo(UsersFields.CanPost));

			Assert.That(UsersFields.FromJsonString("universities")
					, Is.EqualTo(UsersFields.Universities));

			Assert.That(UsersFields.FromJsonString("connections"), Is.EqualTo(UsersFields.Connections));
			Assert.That(UsersFields.FromJsonString("site"), Is.EqualTo(UsersFields.Site));
			Assert.That(UsersFields.FromJsonString("schools"), Is.EqualTo(UsersFields.Schools));

			Assert.That(UsersFields.FromJsonString("can_see_audio")
					, Is.EqualTo(UsersFields.CanSeeAudio));

			Assert.That(UsersFields.FromJsonString("common_count"), Is.EqualTo(UsersFields.CommonCount));
			Assert.That(UsersFields.FromJsonString("relatives"), Is.EqualTo(UsersFields.Relatives));
			Assert.That(UsersFields.FromJsonString("counters"), Is.EqualTo(UsersFields.Counters));

			Assert.That(UsersFields.FromJsonString("can_access_closed"), Is.EqualTo(UsersFields.CanAccessClosed));
			Assert.That(UsersFields.FromJsonString("is_closed"), Is.EqualTo(UsersFields.IsClosed));
			Assert.That(UsersFields.FromJsonString("first_name_nom"), Is.EqualTo(UsersFields.FirstNameNom));
			Assert.That(UsersFields.FromJsonString("first_name_gen"), Is.EqualTo(UsersFields.FirstNameGen));
			Assert.That(UsersFields.FromJsonString("first_name_dat"), Is.EqualTo(UsersFields.FirstNameDat));
			Assert.That(UsersFields.FromJsonString("first_name_acc"), Is.EqualTo(UsersFields.FirstNameAcc));
			Assert.That(UsersFields.FromJsonString("first_name_ins"), Is.EqualTo(UsersFields.FirstNameIns));
			Assert.That(UsersFields.FromJsonString("first_name_abl"), Is.EqualTo(UsersFields.FirstNameAbl));
			Assert.That(UsersFields.FromJsonString("last_name_nom"), Is.EqualTo(UsersFields.LastNameNom));
			Assert.That(UsersFields.FromJsonString("last_name_gen"), Is.EqualTo(UsersFields.LastNameGen));
			Assert.That(UsersFields.FromJsonString("last_name_dat"), Is.EqualTo(UsersFields.LastNameDat));
			Assert.That(UsersFields.FromJsonString("last_name_acc"), Is.EqualTo(UsersFields.LastNameAcc));
			Assert.That(UsersFields.FromJsonString("last_name_ins"), Is.EqualTo(UsersFields.LastNameIns));
			Assert.That(UsersFields.FromJsonString("last_name_abl"), Is.EqualTo(UsersFields.LastNameAbl));

			Assert.That(UsersFields.FromJsonString("bdate,can_access_closed,can_post,can_see_all_posts,can_see_audio,can_write_private_message,city,common_count,connections,contacts,counters,country,domain,education,first_name_abl,first_name_acc,first_name_dat,first_name_gen,first_name_ins,first_name_nom,has_mobile,is_closed,last_name_abl,last_name_acc,last_name_dat,last_name_gen,last_name_ins,last_name_nom,last_seen,lists,nickname,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,sex,site,status,timezone,universities")
					, Is.EqualTo(UsersFields.All));
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

			Assert.That(VideoFilters.FromJsonString("mp4,youtube,vimeo,short,long")
					, Is.EqualTo(VideoFilters.All));
		}

		[Test]
		public void AudioBroadcastFilterTest()
		{
			// get test
			Assert.That(actual: AudioBroadcastFilter.All.ToString(), expression: Is.EqualTo(expected: "all"));
			Assert.That(actual: AudioBroadcastFilter.Friends.ToString(), expression: Is.EqualTo(expected: "friends"));
			Assert.That(actual: AudioBroadcastFilter.Groups.ToString(), expression: Is.EqualTo(expected: "groups"));
			// parse test
			Assert.That(actual: AudioBroadcastFilter.FromJsonString(val: "all"), expression: Is.EqualTo(expected: AudioBroadcastFilter.All));
			Assert.That(actual: AudioBroadcastFilter.FromJsonString(val: "friends"), expression: Is.EqualTo(expected: AudioBroadcastFilter.Friends));
			Assert.That(actual: AudioBroadcastFilter.FromJsonString(val: "groups"), expression: Is.EqualTo(expected: AudioBroadcastFilter.Groups));
		}
	}
}