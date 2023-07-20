using FluentAssertions;
using VkNet.Enums.Filters;
using Xunit;

namespace VkNet.Tests.Enum.Filters;

public class MultivaluedFilterTest
{
	[Fact]
	public void AccountFieldsTest()
	{
		// get test
		AccountFields.Country.ToString()
			.Should()
			.Be("country");

		AccountFields.HttpsRequired.ToString()
			.Should()
			.Be("https_required");

		AccountFields.OwnPostsDefault.ToString()
			.Should()
			.Be("own_posts_default");

		AccountFields.NoWallReplies.ToString()
			.Should()
			.Be("no_wall_replies");

		AccountFields.Intro.ToString()
			.Should()
			.Be("intro");

		AccountFields.Language.ToString()
			.Should()
			.Be("lang");

		// parse test
		AccountFields.FromJsonString("country")
			.Should()
			.Be(AccountFields.Country);

		AccountFields.FromJsonString("https_required")
			.Should()
			.Be(AccountFields.HttpsRequired);

		AccountFields.FromJsonString("own_posts_default")
			.Should()
			.Be(AccountFields.OwnPostsDefault);

		AccountFields.FromJsonString("no_wall_replies")
			.Should()
			.Be(AccountFields.NoWallReplies);

		AccountFields.FromJsonString("intro")
			.Should()
			.Be(AccountFields.Intro);

		AccountFields.FromJsonString("lang")
			.Should()
			.Be(AccountFields.Language);
	}

	[Fact]
	public void CountersFilterTest()
	{
		// get test
		CountersFilter.Friends.ToString()
			.Should()
			.Be("friends");

		CountersFilter.Messages.ToString()
			.Should()
			.Be("messages");

		CountersFilter.Photos.ToString()
			.Should()
			.Be("photos");

		CountersFilter.Videos.ToString()
			.Should()
			.Be("videos");

		CountersFilter.Gifts.ToString()
			.Should()
			.Be("gifts");

		CountersFilter.Events.ToString()
			.Should()
			.Be("events");

		CountersFilter.Groups.ToString()
			.Should()
			.Be("groups");

		CountersFilter.Notifications.ToString()
			.Should()
			.Be("notifications");

		CountersFilter.All.ToString()
			.Should()
			.Be("app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos");

		// parse test
		CountersFilter.FromJsonString("friends")
			.Should()
			.Be(CountersFilter.Friends);

		CountersFilter.FromJsonString("messages")
			.Should()
			.Be(CountersFilter.Messages);

		CountersFilter.FromJsonString("photos")
			.Should()
			.Be(CountersFilter.Photos);

		CountersFilter.FromJsonString("videos")
			.Should()
			.Be(CountersFilter.Videos);

		CountersFilter.FromJsonString("gifts")
			.Should()
			.Be(CountersFilter.Gifts);

		CountersFilter.FromJsonString("events")
			.Should()
			.Be(CountersFilter.Events);

		CountersFilter.FromJsonString("groups")
			.Should()
			.Be(CountersFilter.Groups);

		CountersFilter.FromJsonString("notifications")
			.Should()
			.Be(CountersFilter.Notifications);

		CountersFilter
			.FromJsonString("app_requests,events,friends,friends_suggestions,gifts,groups,messages,notifications,photos,sdk,videos")
			.Should()
			.Be(CountersFilter.All);
	}

	[Fact]
	public void GroupsFieldsTest()
	{
		// get test
		GroupsFields.CityId.ToString()
			.Should()
			.Be("city");

		GroupsFields.CountryId.ToString()
			.Should()
			.Be("country");

		GroupsFields.Place.ToString()
			.Should()
			.Be("place");

		GroupsFields.Description.ToString()
			.Should()
			.Be("description");

		GroupsFields.WikiPage.ToString()
			.Should()
			.Be("wiki_page");

		GroupsFields.MembersCount.ToString()
			.Should()
			.Be("members_count");

		GroupsFields.Counters.ToString()
			.Should()
			.Be("counters");

		GroupsFields.StartDate.ToString()
			.Should()
			.Be("start_date");

		GroupsFields.EndDate.ToString()
			.Should()
			.Be("finish_date");

		GroupsFields.CanPost.ToString()
			.Should()
			.Be("can_post");

		GroupsFields.CanSeeAllPosts.ToString()
			.Should()
			.Be("can_see_all_posts");

		GroupsFields.CanUploadDocuments.ToString()
			.Should()
			.Be("can_upload_doc");

		GroupsFields.CanCreateTopic.ToString()
			.Should()
			.Be("can_create_topic");

		GroupsFields.Activity.ToString()
			.Should()
			.Be("activity");

		GroupsFields.Status.ToString()
			.Should()
			.Be("status");

		GroupsFields.Contacts.ToString()
			.Should()
			.Be("contacts");

		GroupsFields.Links.ToString()
			.Should()
			.Be("links");

		GroupsFields.FixedPostId.ToString()
			.Should()
			.Be("fixed_post");

		GroupsFields.IsVerified.ToString()
			.Should()
			.Be("verified");

		GroupsFields.Site.ToString()
			.Should()
			.Be("site");

		GroupsFields.BanInfo.ToString()
			.Should()
			.Be("ban_info");

		GroupsFields.All.ToString()
			.Should()
			.Be(
				"activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page");

		GroupsFields.AllUndocumented.ToString()
			.Should()
			.Be(
				"activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page");

		// parse test
		GroupsFields.FromJsonString("city")
			.Should()
			.Be(GroupsFields.CityId);

		GroupsFields.FromJsonString("country")
			.Should()
			.Be(GroupsFields.CountryId);

		GroupsFields.FromJsonString("place")
			.Should()
			.Be(GroupsFields.Place);

		GroupsFields.FromJsonString("description")
			.Should()
			.Be(GroupsFields.Description);

		GroupsFields.FromJsonString("wiki_page")
			.Should()
			.Be(GroupsFields.WikiPage);

		GroupsFields.FromJsonString("members_count")
			.Should()
			.Be(GroupsFields.MembersCount);

		GroupsFields.FromJsonString("counters")
			.Should()
			.Be(GroupsFields.Counters);

		GroupsFields.FromJsonString("start_date")
			.Should()
			.Be(GroupsFields.StartDate);

		GroupsFields.FromJsonString("finish_date")
			.Should()
			.Be(GroupsFields.EndDate);

		GroupsFields.FromJsonString("can_post")
			.Should()
			.Be(GroupsFields.CanPost);

		GroupsFields.FromJsonString("can_see_all_posts")
			.Should()
			.Be(GroupsFields.CanSeeAllPosts);

		GroupsFields.FromJsonString("can_upload_doc")
			.Should()
			.Be(GroupsFields.CanUploadDocuments);

		GroupsFields.FromJsonString("can_create_topic")
			.Should()
			.Be(GroupsFields.CanCreateTopic);

		GroupsFields.FromJsonString("activity")
			.Should()
			.Be(GroupsFields.Activity);

		GroupsFields.FromJsonString("status")
			.Should()
			.Be(GroupsFields.Status);

		GroupsFields.FromJsonString("contacts")
			.Should()
			.Be(GroupsFields.Contacts);

		GroupsFields.FromJsonString("links")
			.Should()
			.Be(GroupsFields.Links);

		GroupsFields.FromJsonString("fixed_post")
			.Should()
			.Be(GroupsFields.FixedPostId);

		GroupsFields.FromJsonString("verified")
			.Should()
			.Be(GroupsFields.IsVerified);

		GroupsFields.FromJsonString("site")
			.Should()
			.Be(GroupsFields.Site);

		GroupsFields.FromJsonString("ban_info")
			.Should()
			.Be(GroupsFields.BanInfo);

		GroupsFields.FromJsonString(
				"activity,ban_info,can_create_topic,can_post,can_see_all_posts,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page")
			.Should()
			.Be(GroupsFields.All);

		GroupsFields.FromJsonString(
				"activity,ban_info,can_create_topic,can_post,can_see_all_posts,can_upload_doc,city,contacts,counters,country,description,finish_date,fixed_post,links,members_count,place,site,start_date,status,verified,wiki_page")
			.Should()
			.Be(GroupsFields.AllUndocumented);
	}

	[Fact]
	public void GroupsFiltersTest()
	{
		// get test
		GroupsFilters.Administrator.ToString()
			.Should()
			.Be("admin");

		GroupsFilters.Editor.ToString()
			.Should()
			.Be("editor");

		GroupsFilters.Moderator.ToString()
			.Should()
			.Be("moder");

		GroupsFilters.Groups.ToString()
			.Should()
			.Be("groups");

		GroupsFilters.Publics.ToString()
			.Should()
			.Be("publics");

		GroupsFilters.Events.ToString()
			.Should()
			.Be("events");

		GroupsFilters.All.ToString()
			.Should()
			.Be("admin,editor,events,groups,moder,publics");

		// parse test
		GroupsFilters.FromJsonString("admin")
			.Should()
			.Be(GroupsFilters.Administrator);

		GroupsFilters.FromJsonString("editor")
			.Should()
			.Be(GroupsFilters.Editor);

		GroupsFilters.FromJsonString("moder")
			.Should()
			.Be(GroupsFilters.Moderator);

		GroupsFilters.FromJsonString("groups")
			.Should()
			.Be(GroupsFilters.Groups);

		GroupsFilters.FromJsonString("publics")
			.Should()
			.Be(GroupsFilters.Publics);

		GroupsFilters.FromJsonString("events")
			.Should()
			.Be(GroupsFilters.Events);

		GroupsFilters.FromJsonString("admin,editor,moder,groups,publics,events")
			.Should()
			.Be(GroupsFilters.All);
	}

	[Fact]
	public void SubscribeFilterTest()
	{
		// get test
		SubscribeFilter.Message.ToString()
			.Should()
			.Be("msg");

		SubscribeFilter.Friend.ToString()
			.Should()
			.Be("friend");

		SubscribeFilter.Call.ToString()
			.Should()
			.Be("call");

		SubscribeFilter.Reply.ToString()
			.Should()
			.Be("reply");

		SubscribeFilter.Mention.ToString()
			.Should()
			.Be("mention");

		SubscribeFilter.Group.ToString()
			.Should()
			.Be("group");

		SubscribeFilter.Like.ToString()
			.Should()
			.Be("like");

		SubscribeFilter.All.ToString()
			.Should()
			.Be("call,friend,group,like,mention,msg,reply");

		// parse test
		SubscribeFilter.FromJsonString("msg")
			.Should()
			.Be(SubscribeFilter.Message);

		SubscribeFilter.FromJsonString("friend")
			.Should()
			.Be(SubscribeFilter.Friend);

		SubscribeFilter.FromJsonString("call")
			.Should()
			.Be(SubscribeFilter.Call);

		SubscribeFilter.FromJsonString("reply")
			.Should()
			.Be(SubscribeFilter.Reply);

		SubscribeFilter.FromJsonString("mention")
			.Should()
			.Be(SubscribeFilter.Mention);

		SubscribeFilter.FromJsonString("group")
			.Should()
			.Be(SubscribeFilter.Group);

		SubscribeFilter.FromJsonString("like")
			.Should()
			.Be(SubscribeFilter.Like);

		SubscribeFilter.FromJsonString("msg,friend,call,reply,mention,group,like")
			.Should()
			.Be(SubscribeFilter.All);
	}

	[Fact]
	public void UsersFieldsTest()
	{
		// get test
		UsersFields.Nickname.ToString()
			.Should()
			.Be("nickname");

		UsersFields.Domain.ToString()
			.Should()
			.Be("domain");

		UsersFields.Sex.ToString()
			.Should()
			.Be("sex");

		UsersFields.BirthDate.ToString()
			.Should()
			.Be("bdate");

		UsersFields.City.ToString()
			.Should()
			.Be("city");

		UsersFields.Country.ToString()
			.Should()
			.Be("country");

		UsersFields.Timezone.ToString()
			.Should()
			.Be("timezone");

		UsersFields.Photo50.ToString()
			.Should()
			.Be("photo_50");

		UsersFields.Photo100.ToString()
			.Should()
			.Be("photo_100");

		UsersFields.Photo200Orig.ToString()
			.Should()
			.Be("photo_200_orig");

		UsersFields.Photo200.ToString()
			.Should()
			.Be("photo_200");

		UsersFields.Photo400Orig.ToString()
			.Should()
			.Be("photo_400_orig");

		UsersFields.PhotoMax.ToString()
			.Should()
			.Be("photo_max");

		UsersFields.PhotoMaxOrig.ToString()
			.Should()
			.Be("photo_max_orig");

		UsersFields.HasMobile.ToString()
			.Should()
			.Be("has_mobile");

		UsersFields.Contacts.ToString()
			.Should()
			.Be("contacts");

		UsersFields.Education.ToString()
			.Should()
			.Be("education");

		UsersFields.Online.ToString()
			.Should()
			.Be("online");

		UsersFields.OnlineMobile.ToString()
			.Should()
			.Be("online_mobile");

		UsersFields.FriendLists.ToString()
			.Should()
			.Be("lists");

		UsersFields.Relation.ToString()
			.Should()
			.Be("relation");

		UsersFields.LastSeen.ToString()
			.Should()
			.Be("last_seen");

		UsersFields.Status.ToString()
			.Should()
			.Be("status");

		UsersFields.CanWritePrivateMessage.ToString()
			.Should()
			.Be("can_write_private_message");

		UsersFields.CanSeeAllPosts.ToString()
			.Should()
			.Be("can_see_all_posts");

		UsersFields.CanPost.ToString()
			.Should()
			.Be("can_post");

		UsersFields.Universities.ToString()
			.Should()
			.Be("universities");

		UsersFields.Connections.ToString()
			.Should()
			.Be("connections");

		UsersFields.Site.ToString()
			.Should()
			.Be("site");

		UsersFields.Schools.ToString()
			.Should()
			.Be("schools");

		UsersFields.CanSeeAudio.ToString()
			.Should()
			.Be("can_see_audio");

		UsersFields.CommonCount.ToString()
			.Should()
			.Be("common_count");

		UsersFields.Relatives.ToString()
			.Should()
			.Be("relatives");

		UsersFields.Counters.ToString()
			.Should()
			.Be("counters");

		UsersFields.CanAccessClosed.ToString()
			.Should()
			.Be("can_access_closed");

		UsersFields.IsClosed.ToString()
			.Should()
			.Be("is_closed");

		UsersFields.FirstNameNom.ToString()
			.Should()
			.Be("first_name_nom");

		UsersFields.FirstNameGen.ToString()
			.Should()
			.Be("first_name_gen");

		UsersFields.FirstNameDat.ToString()
			.Should()
			.Be("first_name_dat");

		UsersFields.FirstNameAcc.ToString()
			.Should()
			.Be("first_name_acc");

		UsersFields.FirstNameIns.ToString()
			.Should()
			.Be("first_name_ins");

		UsersFields.FirstNameAbl.ToString()
			.Should()
			.Be("first_name_abl");

		UsersFields.LastNameNom.ToString()
			.Should()
			.Be("last_name_nom");

		UsersFields.LastNameGen.ToString()
			.Should()
			.Be("last_name_gen");

		UsersFields.LastNameDat.ToString()
			.Should()
			.Be("last_name_dat");

		UsersFields.LastNameAcc.ToString()
			.Should()
			.Be("last_name_acc");

		UsersFields.LastNameIns.ToString()
			.Should()
			.Be("last_name_ins");

		UsersFields.LastNameAbl.ToString()
			.Should()
			.Be("last_name_abl");

		UsersFields.All.ToString()
			.Should()
			.Be(
				"bdate,can_access_closed,can_post,can_see_all_posts,can_see_audio,can_write_private_message,city,common_count,connections,contacts,counters,country,domain,education,first_name_abl,first_name_acc,first_name_dat,first_name_gen,first_name_ins,first_name_nom,has_mobile,is_closed,last_name_abl,last_name_acc,last_name_dat,last_name_gen,last_name_ins,last_name_nom,last_seen,lists,nickname,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,sex,site,status,timezone,universities");

		// parse test
		UsersFields.FromJsonString("nickname")
			.Should()
			.Be(UsersFields.Nickname);

		UsersFields.FromJsonString("domain")
			.Should()
			.Be(UsersFields.Domain);

		UsersFields.FromJsonString("sex")
			.Should()
			.Be(UsersFields.Sex);

		UsersFields.FromJsonString("bdate")
			.Should()
			.Be(UsersFields.BirthDate);

		UsersFields.FromJsonString("city")
			.Should()
			.Be(UsersFields.City);

		UsersFields.FromJsonString("country")
			.Should()
			.Be(UsersFields.Country);

		UsersFields.FromJsonString("timezone")
			.Should()
			.Be(UsersFields.Timezone);

		UsersFields.FromJsonString("photo_50")
			.Should()
			.Be(UsersFields.Photo50);

		UsersFields.FromJsonString("photo_100")
			.Should()
			.Be(UsersFields.Photo100);

		UsersFields.FromJsonString("photo_200_orig")
			.Should()
			.Be(UsersFields.Photo200Orig);

		UsersFields.FromJsonString("photo_200")
			.Should()
			.Be(UsersFields.Photo200);

		UsersFields.FromJsonString("photo_400_orig")
			.Should()
			.Be(UsersFields.Photo400Orig);

		UsersFields.FromJsonString("photo_max")
			.Should()
			.Be(UsersFields.PhotoMax);

		UsersFields.FromJsonString("photo_max_orig")
			.Should()
			.Be(UsersFields.PhotoMaxOrig);

		UsersFields.FromJsonString("has_mobile")
			.Should()
			.Be(UsersFields.HasMobile);

		UsersFields.FromJsonString("contacts")
			.Should()
			.Be(UsersFields.Contacts);

		UsersFields.FromJsonString("education")
			.Should()
			.Be(UsersFields.Education);

		UsersFields.FromJsonString("online")
			.Should()
			.Be(UsersFields.Online);

		UsersFields.FromJsonString("online_mobile")
			.Should()
			.Be(UsersFields.OnlineMobile);

		UsersFields.FromJsonString("lists")
			.Should()
			.Be(UsersFields.FriendLists);

		UsersFields.FromJsonString("relation")
			.Should()
			.Be(UsersFields.Relation);

		UsersFields.FromJsonString("last_seen")
			.Should()
			.Be(UsersFields.LastSeen);

		UsersFields.FromJsonString("status")
			.Should()
			.Be(UsersFields.Status);

		UsersFields.FromJsonString("can_write_private_message")
			.Should()
			.Be(UsersFields.CanWritePrivateMessage);

		UsersFields.FromJsonString("can_see_all_posts")
			.Should()
			.Be(UsersFields.CanSeeAllPosts);

		UsersFields.FromJsonString("can_post")
			.Should()
			.Be(UsersFields.CanPost);

		UsersFields.FromJsonString("universities")
			.Should()
			.Be(UsersFields.Universities);

		UsersFields.FromJsonString("connections")
			.Should()
			.Be(UsersFields.Connections);

		UsersFields.FromJsonString("site")
			.Should()
			.Be(UsersFields.Site);

		UsersFields.FromJsonString("schools")
			.Should()
			.Be(UsersFields.Schools);

		UsersFields.FromJsonString("can_see_audio")
			.Should()
			.Be(UsersFields.CanSeeAudio);

		UsersFields.FromJsonString("common_count")
			.Should()
			.Be(UsersFields.CommonCount);

		UsersFields.FromJsonString("relatives")
			.Should()
			.Be(UsersFields.Relatives);

		UsersFields.FromJsonString("counters")
			.Should()
			.Be(UsersFields.Counters);

		UsersFields.FromJsonString("can_access_closed")
			.Should()
			.Be(UsersFields.CanAccessClosed);

		UsersFields.FromJsonString("is_closed")
			.Should()
			.Be(UsersFields.IsClosed);

		UsersFields.FromJsonString("first_name_nom")
			.Should()
			.Be(UsersFields.FirstNameNom);

		UsersFields.FromJsonString("first_name_gen")
			.Should()
			.Be(UsersFields.FirstNameGen);

		UsersFields.FromJsonString("first_name_dat")
			.Should()
			.Be(UsersFields.FirstNameDat);

		UsersFields.FromJsonString("first_name_acc")
			.Should()
			.Be(UsersFields.FirstNameAcc);

		UsersFields.FromJsonString("first_name_ins")
			.Should()
			.Be(UsersFields.FirstNameIns);

		UsersFields.FromJsonString("first_name_abl")
			.Should()
			.Be(UsersFields.FirstNameAbl);

		UsersFields.FromJsonString("last_name_nom")
			.Should()
			.Be(UsersFields.LastNameNom);

		UsersFields.FromJsonString("last_name_gen")
			.Should()
			.Be(UsersFields.LastNameGen);

		UsersFields.FromJsonString("last_name_dat")
			.Should()
			.Be(UsersFields.LastNameDat);

		UsersFields.FromJsonString("last_name_acc")
			.Should()
			.Be(UsersFields.LastNameAcc);

		UsersFields.FromJsonString("last_name_ins")
			.Should()
			.Be(UsersFields.LastNameIns);

		UsersFields.FromJsonString("last_name_abl")
			.Should()
			.Be(UsersFields.LastNameAbl);

		UsersFields.FromJsonString(
				"bdate,can_access_closed,can_post,can_see_all_posts,can_see_audio,can_write_private_message,city,common_count,connections,contacts,counters,country,domain,education,first_name_abl,first_name_acc,first_name_dat,first_name_gen,first_name_ins,first_name_nom,has_mobile,is_closed,last_name_abl,last_name_acc,last_name_dat,last_name_gen,last_name_ins,last_name_nom,last_seen,lists,nickname,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50,photo_max,photo_max_orig,relation,relatives,schools,sex,site,status,timezone,universities")
			.Should()
			.Be(UsersFields.All);
	}

	[Fact]
	public void VideoFiltersTest()
	{
		// get test
		VideoFilters.Mp4.ToString()
			.Should()
			.Be("mp4");

		VideoFilters.Youtube.ToString()
			.Should()
			.Be("youtube");

		VideoFilters.Vimeo.ToString()
			.Should()
			.Be("vimeo");

		VideoFilters.Short.ToString()
			.Should()
			.Be("short");

		VideoFilters.Long.ToString()
			.Should()
			.Be("long");

		VideoFilters.All.ToString()
			.Should()
			.Be("long,mp4,short,vimeo,youtube");

		// parse test
		VideoFilters.FromJsonString("mp4")
			.Should()
			.Be(VideoFilters.Mp4);

		VideoFilters.FromJsonString("youtube")
			.Should()
			.Be(VideoFilters.Youtube);

		VideoFilters.FromJsonString("vimeo")
			.Should()
			.Be(VideoFilters.Vimeo);

		VideoFilters.FromJsonString("short")
			.Should()
			.Be(VideoFilters.Short);

		VideoFilters.FromJsonString("long")
			.Should()
			.Be(VideoFilters.Long);

		VideoFilters.FromJsonString("mp4,youtube,vimeo,short,long")
			.Should()
			.Be(VideoFilters.All);
	}

	[Fact]
	public void AudioBroadcastFilterTest()
	{
		// get test
		AudioBroadcastFilter.All.ToString()
			.Should()
			.Be("all");

		AudioBroadcastFilter.Friends.ToString()
			.Should()
			.Be("friends");

		AudioBroadcastFilter.Groups.ToString()
			.Should()
			.Be("groups");

		// parse test
		AudioBroadcastFilter.FromJsonString(val: "all")
			.Should()
			.Be(AudioBroadcastFilter.All);

		AudioBroadcastFilter.FromJsonString(val: "friends")
			.Should()
			.Be(AudioBroadcastFilter.Friends);

		AudioBroadcastFilter.FromJsonString(val: "groups")
			.Should()
			.Be(AudioBroadcastFilter.Groups);
	}
}