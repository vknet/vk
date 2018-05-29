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
			Assert.AreEqual(expected: 140426719, actual: settings.ToUInt64());
		}

		[Test]
		public void FromJson()
		{
			Json = "'notify'";
			var response = GetResponse();
			Assert.AreEqual(expected: Settings.FromJson(response: response), actual: Settings.Notify);
		}

		[Test]
		public void Notify_Friends()
		{
			var settings = Settings.Notify|Settings.Friends;
			Assert.AreEqual(expected: 3, actual: settings.ToUInt64());
		}

		[Test]
		public void Notify_Friends_Photos()
		{
			var settings = Settings.Notify|Settings.Friends|Settings.Photos;
			Assert.AreEqual(expected: 7, actual: settings.ToUInt64());
		}

		[Test]
		public void Notify_Friends_Photos_Audio()
		{
			var settings = Settings.Notify|Settings.Friends|Settings.Photos|Settings.Audio;
			Assert.AreEqual(expected: 15, actual: settings.ToUInt64());
		}

		[Test]
		public void Notify_Friends_Photos_Audio_Video()
		{
			var settings = Settings.Notify|Settings.Friends|Settings.Photos|Settings.Audio|Settings.Video;
			Assert.AreEqual(expected: 31, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 159, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 415, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 1439, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 3487, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 7583, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 15775, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 48543, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 179615, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 441759, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 966047, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 2014623, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 6208927, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 140426655, actual: settings.ToUInt64());
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

			Assert.AreEqual(expected: 140426719, actual: settings.ToUInt64());
		}

		[Test]
		public void OperatorOrDuplicateSettings()
		{
		#pragma warning disable S1764
			var settings = Settings.Notify|Settings.Notify;
			Assert.AreEqual(expected: 1, actual: settings.ToUInt64());
		#pragma warning restore S1764
		}

		[Test]
		public void SettingsTest()
		{
			// get test
			Assert.That(actual: Settings.Notify.ToString(), expression: Is.EqualTo(expected: "notify"));
			Assert.That(actual: Settings.Friends.ToString(), expression: Is.EqualTo(expected: "friends"));
			Assert.That(actual: Settings.Photos.ToString(), expression: Is.EqualTo(expected: "photos"));
			Assert.That(actual: Settings.Audio.ToString(), expression: Is.EqualTo(expected: "audio"));
			Assert.That(actual: Settings.Video.ToString(), expression: Is.EqualTo(expected: "video"));
			Assert.That(actual: Settings.Pages.ToString(), expression: Is.EqualTo(expected: "pages"));
			Assert.That(actual: Settings.AddLinkToLeftMenu.ToString(), expression: Is.EqualTo(expected: "addlinktoleftmenu"));
			Assert.That(actual: Settings.Status.ToString(), expression: Is.EqualTo(expected: "status"));
			Assert.That(actual: Settings.Notes.ToString(), expression: Is.EqualTo(expected: "notes"));
			Assert.That(actual: Settings.Messages.ToString(), expression: Is.EqualTo(expected: "messages"));
			Assert.That(actual: Settings.Wall.ToString(), expression: Is.EqualTo(expected: "wall"));
			Assert.That(actual: Settings.Ads.ToString(), expression: Is.EqualTo(expected: "ads"));
			Assert.That(actual: Settings.Offline.ToString(), expression: Is.EqualTo(expected: "offline"));
			Assert.That(actual: Settings.Documents.ToString(), expression: Is.EqualTo(expected: "docs"));
			Assert.That(actual: Settings.Groups.ToString(), expression: Is.EqualTo(expected: "groups"));
			Assert.That(actual: Settings.Notifications.ToString(), expression: Is.EqualTo(expected: "notifications"));
			Assert.That(actual: Settings.Statistic.ToString(), expression: Is.EqualTo(expected: "stats"));
			Assert.That(actual: Settings.Email.ToString(), expression: Is.EqualTo(expected: "email"));
			Assert.That(actual: Settings.Market.ToString(), expression: Is.EqualTo(expected: "market"));

			Assert.That(actual: Settings.All.ToString()
					, expression: Is.EqualTo(expected:
							"addlinktoleftmenu,ads,audio,app_widget,docs,email,friends,groups,market,messages,notes,notifications,notify,pages,photos,stats,status,video,wall"));

			// parse test
			Assert.That(actual: Settings.FromJsonString(val: "notify"), expression: Is.EqualTo(expected: Settings.Notify));
			Assert.That(actual: Settings.FromJsonString(val: "friends"), expression: Is.EqualTo(expected: Settings.Friends));
			Assert.That(actual: Settings.FromJsonString(val: "photos"), expression: Is.EqualTo(expected: Settings.Photos));
			Assert.That(actual: Settings.FromJsonString(val: "audio"), expression: Is.EqualTo(expected: Settings.Audio));
			Assert.That(actual: Settings.FromJsonString(val: "video"), expression: Is.EqualTo(expected: Settings.Video));
			Assert.That(actual: Settings.FromJsonString(val: "pages"), expression: Is.EqualTo(expected: Settings.Pages));

			Assert.That(actual: Settings.FromJsonString(val: "addlinktoleftmenu")
					, expression: Is.EqualTo(expected: Settings.AddLinkToLeftMenu));

			Assert.That(actual: Settings.FromJsonString(val: "status"), expression: Is.EqualTo(expected: Settings.Status));
			Assert.That(actual: Settings.FromJsonString(val: "notes"), expression: Is.EqualTo(expected: Settings.Notes));
			Assert.That(actual: Settings.FromJsonString(val: "messages"), expression: Is.EqualTo(expected: Settings.Messages));
			Assert.That(actual: Settings.FromJsonString(val: "wall"), expression: Is.EqualTo(expected: Settings.Wall));
			Assert.That(actual: Settings.FromJsonString(val: "ads"), expression: Is.EqualTo(expected: Settings.Ads));
			Assert.That(actual: Settings.FromJsonString(val: "offline"), expression: Is.EqualTo(expected: Settings.Offline));
			Assert.That(actual: Settings.FromJsonString(val: "docs"), expression: Is.EqualTo(expected: Settings.Documents));
			Assert.That(actual: Settings.FromJsonString(val: "groups"), expression: Is.EqualTo(expected: Settings.Groups));
			Assert.That(actual: Settings.FromJsonString(val: "notifications"), expression: Is.EqualTo(expected: Settings.Notifications));
			Assert.That(actual: Settings.FromJsonString(val: "stats"), expression: Is.EqualTo(expected: Settings.Statistic));
			Assert.That(actual: Settings.FromJsonString(val: "email"), expression: Is.EqualTo(expected: Settings.Email));
			Assert.That(actual: Settings.FromJsonString(val: "market"), expression: Is.EqualTo(expected: Settings.Market));

			Assert.That(actual: Settings.FromJsonString(val:
							"addlinktoleftmenu,ads,audio,app_widget,docs,email,friends,groups,market,messages,notes,notifications,notify,pages,photos,stats,status,video,wall")
					, expression: Is.EqualTo(expected: Settings.All));
		}
	}
}