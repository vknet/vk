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
			Assert.That(actual: AccountFields.Country.ToString(), expression: Is.EqualTo(expected: "country"));
			Assert.That(actual: AccountFields.HttpsRequired.ToString(), expression: Is.EqualTo(expected: "https_required"));
			Assert.That(actual: AccountFields.OwnPostsDefault.ToString(), expression: Is.EqualTo(expected: "own_posts_default"));
			Assert.That(actual: AccountFields.NoWallReplies.ToString(), expression: Is.EqualTo(expected: "no_wall_replies"));
			Assert.That(actual: AccountFields.Intro.ToString(), expression: Is.EqualTo(expected: "intro"));
			Assert.That(actual: AccountFields.Language.ToString(), expression: Is.EqualTo(expected: "lang"));

			// parse test
			Assert.That(actual: AccountFields.FromJsonString(val: "country"), expression: Is.EqualTo(expected: AccountFields.Country));

			Assert.That(actual: AccountFields.FromJsonString(val: "https_required")
					, expression: Is.EqualTo(expected: AccountFields.HttpsRequired));

			Assert.That(actual: AccountFields.FromJsonString(val: "own_posts_default")
					, expression: Is.EqualTo(expected: AccountFields.OwnPostsDefault));

			Assert.That(actual: AccountFields.FromJsonString(val: "no_wall_replies")
					, expression: Is.EqualTo(expected: AccountFields.NoWallReplies));

			Assert.That(actual: AccountFields.FromJsonString(val: "intro"), expression: Is.EqualTo(expected: AccountFields.Intro));
			Assert.That(actual: AccountFields.FromJsonString(val: "lang"), expression: Is.EqualTo(expected: AccountFields.Language));
		}

		[Test]
		public void CountersFilterTest()
		{
			// get test
			Assert.That(actual: CountersFilter.Friends.ToString(), expression: Is.EqualTo(expected: "friends"));
			Assert.That(actual: CountersFilter.Messages.ToString(), expression: Is.EqualTo(expected: "messages"));
			Assert.That(actual: CountersFilter.Photos.ToString(), expression: Is.EqualTo(expected: "photos"));
			Assert.That(actual: CountersFilter.Videos.ToString(), expression: Is.EqualTo(expected: "videos"));
			Assert.That(actual: CountersFilter.Gifts.ToString(), expression: Is.EqualTo(expected: "gifts"));
			Assert.That(actual: CountersFilter.Events.ToString(), expression: Is.EqualTo(expected: "events"));
			Assert.That(actual: CountersFilter.Groups.ToString(), expression: Is.EqualTo(expected: "groups"));
			Assert.That(actual: CountersFilter.Notifications.ToString(), expression: Is.EqualTo(expected: "notifications"));

			Assert.That(actual: CountersFilter.All.ToString()
					, expression: Is.EqualTo(expected:
							"app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos"));

			// parse test
			Assert.That(actual: CountersFilter.FromJsonString(val: "friends"), expression: Is.EqualTo(expected: CountersFilter.Friends));
			Assert.That(actual: CountersFilter.FromJsonString(val: "messages"), expression: Is.EqualTo(expected: CountersFilter.Messages));
			Assert.That(actual: CountersFilter.FromJsonString(val: "photos"), expression: Is.EqualTo(expected: CountersFilter.Photos));
			Assert.That(actual: CountersFilter.FromJsonString(val: "videos"), expression: Is.EqualTo(expected: CountersFilter.Videos));
			Assert.That(actual: CountersFilter.FromJsonString(val: "gifts"), expression: Is.EqualTo(expected: CountersFilter.Gifts));
			Assert.That(actual: CountersFilter.FromJsonString(val: "events"), expression: Is.EqualTo(expected: CountersFilter.Events));
			Assert.That(actual: CountersFilter.FromJsonString(val: "groups"), expression: Is.EqualTo(expected: CountersFilter.Groups));

			Assert.That(actual: CountersFilter.FromJsonString(val: "notifications")
					, expression: Is.EqualTo(expected: CountersFilter.Notifications));

			Assert.That(actual: CountersFilter.FromJsonString(
							val: "app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos")
					, expression: Is.EqualTo(expected: CountersFilter.All));
		}

		[Test]
		public void GroupsFieldsTest()
		{
			// get test
			Assert.That(actual: GroupsFields.CityId.ToString(), expression: Is.EqualTo(expected: "city"));
			Assert.That(actual: GroupsFields.CountryId.ToString(), expression: Is.EqualTo(expected: "country"));
			Assert.That(actual: GroupsFields.Place.ToString(), expression: Is.EqualTo(expected: "place"));
			Assert.That(actual: GroupsFields.Description.ToString(), expression: Is.EqualTo(expected: "description"));
			Assert.That(actual: GroupsFields.WikiPage.ToString(), expression: Is.EqualTo(expected: "wiki_page"));
			Assert.That(actual: GroupsFields.MembersCount.ToString(), expression: Is.EqualTo(expected: "members_count"));
			Assert.That(actual: GroupsFields.Counters.ToString(), expression: Is.EqualTo(expected: "counters"));
			Assert.That(actual: GroupsFields.StartDate.ToString(), expression: Is.EqualTo(expected: "start_date"));
			Assert.That(actual: GroupsFields.EndDate.ToString(), expression: Is.EqualTo(expected: "end_date"));
			Assert.That(actual: GroupsFields.CanPost.ToString(), expression: Is.EqualTo(expected: "can_post"));
			Assert.That(actual: GroupsFields.CanSeelAllPosts.ToString(), expression: Is.EqualTo(expected: "can_see_all_posts"));
			Assert.That(actual: GroupsFields.CanUploadDocuments.ToString(), expression: Is.EqualTo(expected: "can_upload_doc"));
			Assert.That(actual: GroupsFields.CanCreateTopic.ToString(), expression: Is.EqualTo(expected: "can_create_topic"));
			Assert.That(actual: GroupsFields.Activity.ToString(), expression: Is.EqualTo(expected: "activity"));
			Assert.That(actual: GroupsFields.Status.ToString(), expression: Is.EqualTo(expected: "status"));
			Assert.That(actual: GroupsFields.Contacts.ToString(), expression: Is.EqualTo(expected: "contacts"));
			Assert.That(actual: GroupsFields.Links.ToString(), expression: Is.EqualTo(expected: "links"));
			Assert.That(actual: GroupsFields.FixedPostId.ToString(), expression: Is.EqualTo(expected: "fixed_post"));
			Assert.That(actual: GroupsFields.IsVerified.ToString(), expression: Is.EqualTo(expected: "verified"));
			Assert.That(actual: GroupsFields.Site.ToString(), expression: Is.EqualTo(expected: "site"));
			Assert.That(actual: GroupsFields.BanInfo.ToString(), expression: Is.EqualTo(expected: "ban_info"));

			Assert.That(actual: GroupsFields.All.ToString()
					, expression: Is.EqualTo(expected:
							"activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"));

			Assert.That(actual: GroupsFields.AllUndocumented.ToString()
					, expression: Is.EqualTo(expected:
							"activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page"));

			// parse test
			Assert.That(actual: GroupsFields.FromJsonString(val: "city"), expression: Is.EqualTo(expected: GroupsFields.CityId));
			Assert.That(actual: GroupsFields.FromJsonString(val: "country"), expression: Is.EqualTo(expected: GroupsFields.CountryId));
			Assert.That(actual: GroupsFields.FromJsonString(val: "place"), expression: Is.EqualTo(expected: GroupsFields.Place));

			Assert.That(actual: GroupsFields.FromJsonString(val: "description")
					, expression: Is.EqualTo(expected: GroupsFields.Description));

			Assert.That(actual: GroupsFields.FromJsonString(val: "wiki_page"), expression: Is.EqualTo(expected: GroupsFields.WikiPage));

			Assert.That(actual: GroupsFields.FromJsonString(val: "members_count")
					, expression: Is.EqualTo(expected: GroupsFields.MembersCount));

			Assert.That(actual: GroupsFields.FromJsonString(val: "counters"), expression: Is.EqualTo(expected: GroupsFields.Counters));
			Assert.That(actual: GroupsFields.FromJsonString(val: "start_date"), expression: Is.EqualTo(expected: GroupsFields.StartDate));
			Assert.That(actual: GroupsFields.FromJsonString(val: "end_date"), expression: Is.EqualTo(expected: GroupsFields.EndDate));
			Assert.That(actual: GroupsFields.FromJsonString(val: "can_post"), expression: Is.EqualTo(expected: GroupsFields.CanPost));

			Assert.That(actual: GroupsFields.FromJsonString(val: "can_see_all_posts")
					, expression: Is.EqualTo(expected: GroupsFields.CanSeelAllPosts));

			Assert.That(actual: GroupsFields.FromJsonString(val: "can_upload_doc")
					, expression: Is.EqualTo(expected: GroupsFields.CanUploadDocuments));

			Assert.That(actual: GroupsFields.FromJsonString(val: "can_create_topic")
					, expression: Is.EqualTo(expected: GroupsFields.CanCreateTopic));

			Assert.That(actual: GroupsFields.FromJsonString(val: "activity"), expression: Is.EqualTo(expected: GroupsFields.Activity));
			Assert.That(actual: GroupsFields.FromJsonString(val: "status"), expression: Is.EqualTo(expected: GroupsFields.Status));
			Assert.That(actual: GroupsFields.FromJsonString(val: "contacts"), expression: Is.EqualTo(expected: GroupsFields.Contacts));
			Assert.That(actual: GroupsFields.FromJsonString(val: "links"), expression: Is.EqualTo(expected: GroupsFields.Links));
			Assert.That(actual: GroupsFields.FromJsonString(val: "fixed_post"), expression: Is.EqualTo(expected: GroupsFields.FixedPostId));
			Assert.That(actual: GroupsFields.FromJsonString(val: "verified"), expression: Is.EqualTo(expected: GroupsFields.IsVerified));
			Assert.That(actual: GroupsFields.FromJsonString(val: "site"), expression: Is.EqualTo(expected: GroupsFields.Site));
			Assert.That(actual: GroupsFields.FromJsonString(val: "ban_info"), expression: Is.EqualTo(expected: GroupsFields.BanInfo));

			Assert.That(actual: GroupsFields.FromJsonString(val:
							"activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page")
					, expression: Is.EqualTo(expected: GroupsFields.All));

			Assert.That(actual: GroupsFields.FromJsonString(val:
							"activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,end_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page")
					, expression: Is.EqualTo(expected: GroupsFields.AllUndocumented));
		}

		[Test]
		public void GroupsFiltersTest()
		{
			// get test
			Assert.That(actual: GroupsFilters.Administrator.ToString(), expression: Is.EqualTo(expected: "admin"));
			Assert.That(actual: GroupsFilters.Editor.ToString(), expression: Is.EqualTo(expected: "editor"));
			Assert.That(actual: GroupsFilters.Moderator.ToString(), expression: Is.EqualTo(expected: "moder"));
			Assert.That(actual: GroupsFilters.Groups.ToString(), expression: Is.EqualTo(expected: "groups"));
			Assert.That(actual: GroupsFilters.Publics.ToString(), expression: Is.EqualTo(expected: "publics"));
			Assert.That(actual: GroupsFilters.Events.ToString(), expression: Is.EqualTo(expected: "events"));
			Assert.That(actual: GroupsFilters.All.ToString(), expression: Is.EqualTo(expected: "admin,editor,events,groups,moder,publics"));

			// parse test
			Assert.That(actual: GroupsFilters.FromJsonString(val: "admin"), expression: Is.EqualTo(expected: GroupsFilters.Administrator));
			Assert.That(actual: GroupsFilters.FromJsonString(val: "editor"), expression: Is.EqualTo(expected: GroupsFilters.Editor));
			Assert.That(actual: GroupsFilters.FromJsonString(val: "moder"), expression: Is.EqualTo(expected: GroupsFilters.Moderator));
			Assert.That(actual: GroupsFilters.FromJsonString(val: "groups"), expression: Is.EqualTo(expected: GroupsFilters.Groups));
			Assert.That(actual: GroupsFilters.FromJsonString(val: "publics"), expression: Is.EqualTo(expected: GroupsFilters.Publics));
			Assert.That(actual: GroupsFilters.FromJsonString(val: "events"), expression: Is.EqualTo(expected: GroupsFilters.Events));

			Assert.That(actual: GroupsFilters.FromJsonString(val: "admin,editor,moder,groups,publics,events")
					, expression: Is.EqualTo(expected: GroupsFilters.All));
		}

		[Test]
		public void SubscribeFilterTest()
		{
			// get test
			Assert.That(actual: SubscribeFilter.Message.ToString(), expression: Is.EqualTo(expected: "msg"));
			Assert.That(actual: SubscribeFilter.Friend.ToString(), expression: Is.EqualTo(expected: "friend"));
			Assert.That(actual: SubscribeFilter.Call.ToString(), expression: Is.EqualTo(expected: "call"));
			Assert.That(actual: SubscribeFilter.Reply.ToString(), expression: Is.EqualTo(expected: "reply"));
			Assert.That(actual: SubscribeFilter.Mention.ToString(), expression: Is.EqualTo(expected: "mention"));
			Assert.That(actual: SubscribeFilter.Group.ToString(), expression: Is.EqualTo(expected: "group"));
			Assert.That(actual: SubscribeFilter.Like.ToString(), expression: Is.EqualTo(expected: "like"));

			Assert.That(actual: SubscribeFilter.All.ToString()
					, expression: Is.EqualTo(expected: "call,friend,group,like,mention,msg,reply"));

			// parse test
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "msg"), expression: Is.EqualTo(expected: SubscribeFilter.Message));
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "friend"), expression: Is.EqualTo(expected: SubscribeFilter.Friend));
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "call"), expression: Is.EqualTo(expected: SubscribeFilter.Call));
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "reply"), expression: Is.EqualTo(expected: SubscribeFilter.Reply));
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "mention"), expression: Is.EqualTo(expected: SubscribeFilter.Mention));
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "group"), expression: Is.EqualTo(expected: SubscribeFilter.Group));
			Assert.That(actual: SubscribeFilter.FromJsonString(val: "like"), expression: Is.EqualTo(expected: SubscribeFilter.Like));

			Assert.That(actual: SubscribeFilter.FromJsonString(val: "msg,friend,call,reply,mention,group,like")
					, expression: Is.EqualTo(expected: SubscribeFilter.All));
		}

		[Test]
		public void UsersFieldsTest()
		{
			// get test
			Assert.That(actual: UsersFields.Nickname.ToString(), expression: Is.EqualTo(expected: "nickname"));
			Assert.That(actual: UsersFields.Domain.ToString(), expression: Is.EqualTo(expected: "domain"));
			Assert.That(actual: UsersFields.Sex.ToString(), expression: Is.EqualTo(expected: "sex"));
			Assert.That(actual: UsersFields.BirthDate.ToString(), expression: Is.EqualTo(expected: "bdate"));
			Assert.That(actual: UsersFields.City.ToString(), expression: Is.EqualTo(expected: "city"));
			Assert.That(actual: UsersFields.Country.ToString(), expression: Is.EqualTo(expected: "country"));
			Assert.That(actual: UsersFields.Timezone.ToString(), expression: Is.EqualTo(expected: "timezone"));
			Assert.That(actual: UsersFields.Photo50.ToString(), expression: Is.EqualTo(expected: "photo_50"));
			Assert.That(actual: UsersFields.Photo100.ToString(), expression: Is.EqualTo(expected: "photo_100"));
			Assert.That(actual: UsersFields.Photo200Orig.ToString(), expression: Is.EqualTo(expected: "photo_200_orig"));
			Assert.That(actual: UsersFields.Photo200.ToString(), expression: Is.EqualTo(expected: "photo_200"));
			Assert.That(actual: UsersFields.Photo400Orig.ToString(), expression: Is.EqualTo(expected: "photo_400_orig"));
			Assert.That(actual: UsersFields.PhotoMax.ToString(), expression: Is.EqualTo(expected: "photo_max"));
			Assert.That(actual: UsersFields.PhotoMaxOrig.ToString(), expression: Is.EqualTo(expected: "photo_max_orig"));
			Assert.That(actual: UsersFields.HasMobile.ToString(), expression: Is.EqualTo(expected: "has_mobile"));
			Assert.That(actual: UsersFields.Contacts.ToString(), expression: Is.EqualTo(expected: "contacts"));
			Assert.That(actual: UsersFields.Education.ToString(), expression: Is.EqualTo(expected: "education"));
			Assert.That(actual: UsersFields.Online.ToString(), expression: Is.EqualTo(expected: "online"));
			Assert.That(actual: UsersFields.OnlineMobile.ToString(), expression: Is.EqualTo(expected: "online_mobile"));
			Assert.That(actual: UsersFields.FriendLists.ToString(), expression: Is.EqualTo(expected: "lists"));
			Assert.That(actual: UsersFields.Relation.ToString(), expression: Is.EqualTo(expected: "relation"));
			Assert.That(actual: UsersFields.LastSeen.ToString(), expression: Is.EqualTo(expected: "last_seen"));
			Assert.That(actual: UsersFields.Status.ToString(), expression: Is.EqualTo(expected: "status"));

			Assert.That(actual: UsersFields.CanWritePrivateMessage.ToString()
					, expression: Is.EqualTo(expected: "can_write_private_message"));

			Assert.That(actual: UsersFields.CanSeeAllPosts.ToString(), expression: Is.EqualTo(expected: "can_see_all_posts"));
			Assert.That(actual: UsersFields.CanPost.ToString(), expression: Is.EqualTo(expected: "can_post"));
			Assert.That(actual: UsersFields.Universities.ToString(), expression: Is.EqualTo(expected: "universities"));
			Assert.That(actual: UsersFields.Connections.ToString(), expression: Is.EqualTo(expected: "connections"));
			Assert.That(actual: UsersFields.Site.ToString(), expression: Is.EqualTo(expected: "site"));
			Assert.That(actual: UsersFields.Schools.ToString(), expression: Is.EqualTo(expected: "schools"));
			Assert.That(actual: UsersFields.CanSeeAudio.ToString(), expression: Is.EqualTo(expected: "can_see_audio"));
			Assert.That(actual: UsersFields.CommonCount.ToString(), expression: Is.EqualTo(expected: "common_count"));
			Assert.That(actual: UsersFields.Relatives.ToString(), expression: Is.EqualTo(expected: "relatives"));
			Assert.That(actual: UsersFields.Counters.ToString(), expression: Is.EqualTo(expected: "counters"));

			Assert.That(actual: UsersFields.All.ToString()
					, expression: Is.EqualTo(expected:
							"bdate,can_post,can_see_all_posts,can_see_audio,can_write_private_message,city,common_count,connections,contacts,counters,country,domain,education,has_mobile,last_seen,lists,nickname,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,sex,site,status,timezone,universities"));

			// parse test
			Assert.That(actual: UsersFields.FromJsonString(val: "nickname"), expression: Is.EqualTo(expected: UsersFields.Nickname));
			Assert.That(actual: UsersFields.FromJsonString(val: "domain"), expression: Is.EqualTo(expected: UsersFields.Domain));
			Assert.That(actual: UsersFields.FromJsonString(val: "sex"), expression: Is.EqualTo(expected: UsersFields.Sex));
			Assert.That(actual: UsersFields.FromJsonString(val: "bdate"), expression: Is.EqualTo(expected: UsersFields.BirthDate));
			Assert.That(actual: UsersFields.FromJsonString(val: "city"), expression: Is.EqualTo(expected: UsersFields.City));
			Assert.That(actual: UsersFields.FromJsonString(val: "country"), expression: Is.EqualTo(expected: UsersFields.Country));
			Assert.That(actual: UsersFields.FromJsonString(val: "timezone"), expression: Is.EqualTo(expected: UsersFields.Timezone));
			Assert.That(actual: UsersFields.FromJsonString(val: "photo_50"), expression: Is.EqualTo(expected: UsersFields.Photo50));
			Assert.That(actual: UsersFields.FromJsonString(val: "photo_100"), expression: Is.EqualTo(expected: UsersFields.Photo100));

			Assert.That(actual: UsersFields.FromJsonString(val: "photo_200_orig")
					, expression: Is.EqualTo(expected: UsersFields.Photo200Orig));

			Assert.That(actual: UsersFields.FromJsonString(val: "photo_200"), expression: Is.EqualTo(expected: UsersFields.Photo200));

			Assert.That(actual: UsersFields.FromJsonString(val: "photo_400_orig")
					, expression: Is.EqualTo(expected: UsersFields.Photo400Orig));

			Assert.That(actual: UsersFields.FromJsonString(val: "photo_max"), expression: Is.EqualTo(expected: UsersFields.PhotoMax));

			Assert.That(actual: UsersFields.FromJsonString(val: "photo_max_orig")
					, expression: Is.EqualTo(expected: UsersFields.PhotoMaxOrig));

			Assert.That(actual: UsersFields.FromJsonString(val: "has_mobile"), expression: Is.EqualTo(expected: UsersFields.HasMobile));
			Assert.That(actual: UsersFields.FromJsonString(val: "contacts"), expression: Is.EqualTo(expected: UsersFields.Contacts));
			Assert.That(actual: UsersFields.FromJsonString(val: "education"), expression: Is.EqualTo(expected: UsersFields.Education));
			Assert.That(actual: UsersFields.FromJsonString(val: "online"), expression: Is.EqualTo(expected: UsersFields.Online));

			Assert.That(actual: UsersFields.FromJsonString(val: "online_mobile")
					, expression: Is.EqualTo(expected: UsersFields.OnlineMobile));

			Assert.That(actual: UsersFields.FromJsonString(val: "lists"), expression: Is.EqualTo(expected: UsersFields.FriendLists));
			Assert.That(actual: UsersFields.FromJsonString(val: "relation"), expression: Is.EqualTo(expected: UsersFields.Relation));
			Assert.That(actual: UsersFields.FromJsonString(val: "last_seen"), expression: Is.EqualTo(expected: UsersFields.LastSeen));
			Assert.That(actual: UsersFields.FromJsonString(val: "status"), expression: Is.EqualTo(expected: UsersFields.Status));

			Assert.That(actual: UsersFields.FromJsonString(val: "can_write_private_message")
					, expression: Is.EqualTo(expected: UsersFields.CanWritePrivateMessage));

			Assert.That(actual: UsersFields.FromJsonString(val: "can_see_all_posts")
					, expression: Is.EqualTo(expected: UsersFields.CanSeeAllPosts));

			Assert.That(actual: UsersFields.FromJsonString(val: "can_post"), expression: Is.EqualTo(expected: UsersFields.CanPost));

			Assert.That(actual: UsersFields.FromJsonString(val: "universities")
					, expression: Is.EqualTo(expected: UsersFields.Universities));

			Assert.That(actual: UsersFields.FromJsonString(val: "connections"), expression: Is.EqualTo(expected: UsersFields.Connections));
			Assert.That(actual: UsersFields.FromJsonString(val: "site"), expression: Is.EqualTo(expected: UsersFields.Site));
			Assert.That(actual: UsersFields.FromJsonString(val: "schools"), expression: Is.EqualTo(expected: UsersFields.Schools));

			Assert.That(actual: UsersFields.FromJsonString(val: "can_see_audio")
					, expression: Is.EqualTo(expected: UsersFields.CanSeeAudio));

			Assert.That(actual: UsersFields.FromJsonString(val: "common_count"), expression: Is.EqualTo(expected: UsersFields.CommonCount));
			Assert.That(actual: UsersFields.FromJsonString(val: "relatives"), expression: Is.EqualTo(expected: UsersFields.Relatives));
			Assert.That(actual: UsersFields.FromJsonString(val: "counters"), expression: Is.EqualTo(expected: UsersFields.Counters));

			Assert.That(actual: UsersFields.FromJsonString(val:
							"nickname,domain,sex,bdate,city,country,timezone,photo_50,photo_100,photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,has_mobile,contacts,education,online,online_mobile,lists,relation,last_seen,status,can_write_private_message,can_see_all_posts,can_post,universities,connections,site,schools,can_see_audio,common_count,relatives,counters")
					, expression: Is.EqualTo(expected: UsersFields.All));
		}

		[Test]
		public void VideoFiltersTest()
		{
			// get test
			Assert.That(actual: VideoFilters.Mp4.ToString(), expression: Is.EqualTo(expected: "mp4"));
			Assert.That(actual: VideoFilters.Youtube.ToString(), expression: Is.EqualTo(expected: "youtube"));
			Assert.That(actual: VideoFilters.Vimeo.ToString(), expression: Is.EqualTo(expected: "vimeo"));
			Assert.That(actual: VideoFilters.Short.ToString(), expression: Is.EqualTo(expected: "short"));
			Assert.That(actual: VideoFilters.Long.ToString(), expression: Is.EqualTo(expected: "long"));
			Assert.That(actual: VideoFilters.All.ToString(), expression: Is.EqualTo(expected: "long,mp4,short,vimeo,youtube"));

			// parse test
			Assert.That(actual: VideoFilters.FromJsonString(val: "mp4"), expression: Is.EqualTo(expected: VideoFilters.Mp4));
			Assert.That(actual: VideoFilters.FromJsonString(val: "youtube"), expression: Is.EqualTo(expected: VideoFilters.Youtube));
			Assert.That(actual: VideoFilters.FromJsonString(val: "vimeo"), expression: Is.EqualTo(expected: VideoFilters.Vimeo));
			Assert.That(actual: VideoFilters.FromJsonString(val: "short"), expression: Is.EqualTo(expected: VideoFilters.Short));
			Assert.That(actual: VideoFilters.FromJsonString(val: "long"), expression: Is.EqualTo(expected: VideoFilters.Long));

			Assert.That(actual: VideoFilters.FromJsonString(val: "mp4,youtube,vimeo,short,long")
					, expression: Is.EqualTo(expected: VideoFilters.All));
		}
	}
}