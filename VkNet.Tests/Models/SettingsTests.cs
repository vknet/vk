using FluentAssertions;
using VkNet.Enums.Filters;
using Xunit;

namespace VkNet.Tests.Models;

public class SettingsTests : BaseTest
{
	[Fact]
	public void All()
	{
		var settings = Settings.All;

		settings.ToUInt64()
			.Should()
			.Be(140422623);
	}

	[Fact]
	public void All_Offline()
	{
		var settings = Settings.All|Settings.Offline;

		settings.ToUInt64()
			.Should()
			.Be(140488159);
	}

	[Fact]
	public void FromJson()
	{
		Json = "'notify'";
		var response = GetResponse();

		Settings.Notify.Should()
			.Be(Settings.FromJson(response));
	}

	[Fact]
	public void Notify_Friends()
	{
		var settings = Settings.Notify|Settings.Friends;

		settings.ToUInt64()
			.Should()
			.Be(3);
	}

	[Fact]
	public void Notify_Friends_Photos()
	{
		var settings = Settings.Notify|Settings.Friends|Settings.Photos;

		settings.ToUInt64()
			.Should()
			.Be(7);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio()
	{
		var settings = Settings.Notify|Settings.Friends|Settings.Photos|Settings.Audio;

		settings.ToUInt64()
			.Should()
			.Be(15);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video()
	{
		var settings = Settings.Notify|Settings.Friends|Settings.Photos|Settings.Audio|Settings.Video;

		settings.ToUInt64()
			.Should()
			.Be(31);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages;

		settings.ToUInt64()
			.Should()
			.Be(159);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu;

		settings.ToUInt64()
			.Should()
			.Be(415);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status;

		settings.ToUInt64()
			.Should()
			.Be(1439);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes;

		settings.ToUInt64()
			.Should()
			.Be(3487);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages;

		settings.ToUInt64()
			.Should()
			.Be(7583);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall;

		settings.ToUInt64()
			.Should()
			.Be(15775);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads;

		settings.ToUInt64()
			.Should()
			.Be(48543);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents;

		settings.ToUInt64()
			.Should()
			.Be(179615);
	}

	[Fact]
	public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents
						|Settings.Groups;

		settings.ToUInt64()
			.Should()
			.Be(441759);
	}

	[Fact]
	public void
		Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents
						|Settings.Groups
						|Settings.Notifications;

		settings.ToUInt64()
			.Should()
			.Be(966047);
	}

	[Fact]
	public void
		Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents
						|Settings.Groups
						|Settings.Notifications
						|Settings.Stats;

		settings.ToUInt64()
			.Should()
			.Be(2014623);
	}

	[Fact]
	public void
		Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats_Email()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents
						|Settings.Groups
						|Settings.Notifications
						|Settings.Stats
						|Settings.Email;

		settings.ToUInt64()
			.Should()
			.Be(6208927);
	}

	[Fact]
	public void
		Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats_Email_Market()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents
						|Settings.Groups
						|Settings.Notifications
						|Settings.Stats
						|Settings.Email
						|Settings.Market;

		settings.ToUInt64()
			.Should()
			.Be(140426655);
	}

	[Fact]
	public void
		Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats_Email_Market_AppWidget()
	{
		var settings = Settings.Notify
						|Settings.Friends
						|Settings.Photos
						|Settings.Audio
						|Settings.Video
						|Settings.Pages
						|Settings.AddLinkToLeftMenu
						|Settings.Status
						|Settings.Notes
						|Settings.Messages
						|Settings.Wall
						|Settings.Ads
						|Settings.Documents
						|Settings.Groups
						|Settings.Notifications
						|Settings.Stats
						|Settings.Email
						|Settings.Market
						|Settings.AppWidget;

		settings.ToUInt64()
			.Should()
			.Be(140426719);
	}

	[Fact]
	public void OperatorOrDuplicateSettings()
	{
		#pragma warning disable S1764
		var settings = Settings.Notify|Settings.Notify;

		settings.ToUInt64()
			.Should()
			.Be(1);
		#pragma warning restore S1764
	}

	[Fact]
	public void SettingsTest()
	{
		// get test
		Settings.Notify.ToString()
			.Should()
			.Be("notify");

		Settings.Friends.ToString()
			.Should()
			.Be("friends");

		Settings.Photos.ToString()
			.Should()
			.Be("photos");

		Settings.Audio.ToString()
			.Should()
			.Be("audio");

		Settings.Video.ToString()
			.Should()
			.Be("video");

		Settings.Pages.ToString()
			.Should()
			.Be("pages");

		Settings.AddLinkToLeftMenu.ToString()
			.Should()
			.Be("addlinktoleftmenu");

		Settings.Status.ToString()
			.Should()
			.Be("status");

		Settings.Notes.ToString()
			.Should()
			.Be("notes");

		Settings.Messages.ToString()
			.Should()
			.Be("messages");

		Settings.Wall.ToString()
			.Should()
			.Be("wall");

		Settings.Ads.ToString()
			.Should()
			.Be("ads");

		Settings.Offline.ToString()
			.Should()
			.Be("offline");

		Settings.Documents.ToString()
			.Should()
			.Be("docs");

		Settings.Groups.ToString()
			.Should()
			.Be("groups");

		Settings.Notifications.ToString()
			.Should()
			.Be("notifications");

		Settings.Statistic.ToString()
			.Should()
			.Be("stats");

		Settings.Email.ToString()
			.Should()
			.Be("email");

		Settings.Market.ToString()
			.Should()
			.Be("market");

		Settings.All.ToString()
			.Should()
			.Be(
				"addlinktoleftmenu,ads,app_widget,audio,docs,email,friends,groups,market,notes,notifications,notify,pages,photos,stats,status,video,wall");

		// parse test
		Settings.FromJsonString("notify")
			.Should()
			.Be(Settings.Notify);

		Settings.FromJsonString("friends")
			.Should()
			.Be(Settings.Friends);

		Settings.FromJsonString("photos")
			.Should()
			.Be(Settings.Photos);

		Settings.FromJsonString("audio")
			.Should()
			.Be(Settings.Audio);

		Settings.FromJsonString("video")
			.Should()
			.Be(Settings.Video);

		Settings.FromJsonString("pages")
			.Should()
			.Be(Settings.Pages);

		Settings.FromJsonString("addlinktoleftmenu")
			.Should()
			.Be(Settings.AddLinkToLeftMenu);

		Settings.FromJsonString("status")
			.Should()
			.Be(Settings.Status);

		Settings.FromJsonString("notes")
			.Should()
			.Be(Settings.Notes);

		Settings.FromJsonString("messages")
			.Should()
			.Be(Settings.Messages);

		Settings.FromJsonString("wall")
			.Should()
			.Be(Settings.Wall);

		Settings.FromJsonString("ads")
			.Should()
			.Be(Settings.Ads);

		Settings.FromJsonString("offline")
			.Should()
			.Be(Settings.Offline);

		Settings.FromJsonString("docs")
			.Should()
			.Be(Settings.Documents);

		Settings.FromJsonString("groups")
			.Should()
			.Be(Settings.Groups);

		Settings.FromJsonString("notifications")
			.Should()
			.Be(Settings.Notifications);

		Settings.FromJsonString("stats")
			.Should()
			.Be(Settings.Statistic);

		Settings.FromJsonString("email")
			.Should()
			.Be(Settings.Email);

		Settings.FromJsonString("market")
			.Should()
			.Be(Settings.Market);

		Settings.FromJsonString(
				"addlinktoleftmenu,ads,audio,app_widget,docs,email,friends,groups,market,notes,notifications,notify,pages,photos,stats,status,video,wall")
			.Should()
			.Be(Settings.All);
	}
}