using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Models
{
    [TestFixture]
    public class SettingsTests: BaseTest
    {
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
			Assert.That(Settings.All.ToString(), Is.EqualTo("addlinktoleftmenu,ads,audio,app_widget,docs,email,friends,groups,market,messages,notes,notifications,notify,pages,photos,stats,status,video,wall"));
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
			Assert.That(Settings.FromJsonString("addlinktoleftmenu,ads,audio,app_widget,docs,email,friends,groups,market,messages,notes,notifications,notify,pages,photos,stats,status,video,wall"), Is.EqualTo(Settings.All));
		}

	    [Test]
	    public void Notify_Friends()
	    {
		    var settings = Settings.Notify | Settings.Friends;
		    Assert.AreEqual(3, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos;
		    Assert.AreEqual(7, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio;
		    Assert.AreEqual(15, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video;
		    Assert.AreEqual(31, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages;
		    Assert.AreEqual(159, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu;
		    Assert.AreEqual(415, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status;
		    Assert.AreEqual(1439, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes;
		    Assert.AreEqual(3487, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages;
		    Assert.AreEqual(7583, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall;
		    Assert.AreEqual(15775, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads;
		    Assert.AreEqual(48543, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents;
		    Assert.AreEqual(179615, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents | Settings.Groups;
		    Assert.AreEqual(441759, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents | Settings.Groups | Settings.Notifications;
		    Assert.AreEqual(966047, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents | Settings.Groups | Settings.Notifications
			    | Settings.Stats;
		    Assert.AreEqual(2014623, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats_Email()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents | Settings.Groups | Settings.Notifications
			    | Settings.Stats | Settings.Email;
		    Assert.AreEqual(6208927, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats_Email_Market()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents | Settings.Groups | Settings.Notifications
			    | Settings.Stats | Settings.Email | Settings.Market;
		    Assert.AreEqual(140426655, settings.ToUInt64());
	    }

	    [Test]
	    public void Notify_Friends_Photos_Audio_Video_Pages_AddLinkToLeftMenu_Status_Notes_Messages_Wall_Ads_Documents_Groups_Notifications_Stats_Email_Market_AppWidget()
	    {
		    var settings = Settings.Notify | Settings.Friends | Settings.Photos | Settings.Audio | Settings.Video
			    | Settings.Pages | Settings.AddLinkToLeftMenu | Settings.Status | Settings.Notes | Settings.Messages
			    | Settings.Wall | Settings.Ads | Settings.Documents | Settings.Groups | Settings.Notifications
			    | Settings.Stats | Settings.Email | Settings.Market | Settings.AppWidget;
		    Assert.AreEqual(140426719, settings.ToUInt64());
	    }

	    [Test]
	    public void All()
	    {
		    var settings = Settings.All;
		    Assert.AreEqual(140426719, settings.ToUInt64());
	    }

	    [Test]
	    public void OperatorOrDuplicateSettings()
	    {
#pragma warning disable S1764
		    var settings = Settings.Notify | Settings.Notify;
		    Assert.AreEqual(1, settings.ToUInt64());
#pragma warning restore S1764
	    }

	    [Test]
	    public void FromJson()
	    {
		    Json = "'notify'";
		    var response = GetResponse();
		    Assert.AreEqual(Settings.FromJson(response), Settings.Notify);
	    }
    }
}