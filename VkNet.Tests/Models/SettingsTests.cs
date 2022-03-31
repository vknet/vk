using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class SettingsTests : BaseTest
	{
		[Test]
		public void All()
		{
			var settings = Settings.All;
			settings.ToUInt64().Should().Be(140422623);
		}

		[Test]
		public void All_Offline()
		{
			var settings = Settings.All | Settings.Offline;
			settings.ToUInt64().Should().Be(140488159);
		}

		[Test]
		public void FromJson()
		{
			Json = "'notify'";
			var response = GetResponse();
			Settings.Notify.Should().Be(Settings.FromJson(response));
		}

		[Test]
		public void Notify_Friends()
		{
			var settings = Settings.Notify|Settings.Friends;
			settings.ToUInt64().Should().Be(3);
		}

		[Test]
		public void Notify_Friends_Photos()
		{
			var settings = Settings.Notify|Settings.Friends|Settings.Photos;
			settings.ToUInt64().Should().Be(7);
		}

		[Test]
		public void Notify_Friends_Photos_Audio()
		{
			var settings = Settings.Notify|Settings.Friends|Settings.Photos|Settings.Audio;
			settings.ToUInt64().Should().Be(15);
		}

		[Test]
		public void Notify_Friends_Photos_Audio_Video()
		{
			var settings = Settings.Notify|Settings.Friends|Settings.Photos|Settings.Audio|Settings.Video;
			settings.ToUInt64().Should().Be(31);
		}

		[Test]
		public void Notify_Friends_Photos_Audio_Video_Pages()
		{
			var settings = Settings.Notify
							|Settings.Friends
							|Settings.Photos
							|Settings.Audio
							|Settings.Video
							|Settings.Pages;

			settings.ToUInt64().Should().Be(159);
		}

		[Test]
		public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu()
		{
			var settings = Settings.Notify
							|Settings.Friends
							|Settings.Photos
							|Settings.Audio
							|Settings.Video
							|Settings.Pages
							|Settings.AddLinkToLeftMenu;

			settings.ToUInt64().Should().Be(415);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(1439);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(3487);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(7583);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(15775);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(48543);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(179615);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(441759);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(966047);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(2014623);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(6208927);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(140426655);
		}

		[Test]
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

			settings.ToUInt64().Should().Be(140426719);
		}

		[Test]
		public void OperatorOrDuplicateSettings()
		{
		#pragma warning disable S1764
			var settings = Settings.Notify|Settings.Notify;
			settings.ToUInt64().Should().Be(1);
		#pragma warning restore S1764
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
			Assert.That(Settings.AddLinkToLeftMenu.ToString(), Is.EqualTo("addlinktoleftmenu"));
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

			Assert.That(Settings.All.ToString(),
				Is.EqualTo(
					"addlinktoleftmenu,ads,app_widget,audio,docs,email,friends,groups,market,notes,notifications,notify,pages,photos,stats,status,video,wall"));

			// parse test
			Assert.That(Settings.FromJsonString("notify"), Is.EqualTo(Settings.Notify));
			Assert.That(Settings.FromJsonString("friends"), Is.EqualTo(Settings.Friends));
			Assert.That(Settings.FromJsonString("photos"), Is.EqualTo(Settings.Photos));
			Assert.That(Settings.FromJsonString("audio"), Is.EqualTo(Settings.Audio));
			Assert.That(Settings.FromJsonString("video"), Is.EqualTo(Settings.Video));
			Assert.That(Settings.FromJsonString("pages"), Is.EqualTo(Settings.Pages));

			Assert.That(Settings.FromJsonString("addlinktoleftmenu"), Is.EqualTo(Settings.AddLinkToLeftMenu));

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

			Assert.That(Settings.FromJsonString(
					"addlinktoleftmenu,ads,audio,app_widget,docs,email,friends,groups,market,notes,notifications,notify,pages,photos,stats,status,video,wall"),
				Is.EqualTo(Settings.All));
		}
	}
}