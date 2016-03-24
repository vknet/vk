using NUnit.Framework;
using VkNet.Enums.Filters;


namespace VkNet.Tests.Enum.Filters
{
	[TestFixture]
    public class SettingsTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ToString_OneSetting()
        {
			Assert.That(Settings.Friends.ToString(), Is.EqualTo("friends"));
        }

        [Test]
        public void ToString_DuplicateSettings_NoDuplicates()
        {
            var settings = Settings.Friends | Settings.Video | Settings.Audio | Settings.Friends;
			Assert.That(settings.ToString(), Is.EqualTo("friends,audio,video"));
        }

        [Test]
        public void Value_Iterate_InitializedValues()
        {
			Assert.That(Settings.Notify.Value, Is.EqualTo(1));
			Assert.That(Settings.Friends.Value, Is.EqualTo(2));
			Assert.That(Settings.Photos.Value, Is.EqualTo(4));
			Assert.That(Settings.Audio.Value, Is.EqualTo(8));
			Assert.That(Settings.Video.Value, Is.EqualTo(16));
			Assert.That(Settings.Documents.Value, Is.EqualTo(131072));
			Assert.That(Settings.Notes.Value, Is.EqualTo(2048));
			Assert.That(Settings.Pages.Value, Is.EqualTo(128));
			Assert.That(Settings.AddLinkToLeftMenu.Value, Is.EqualTo(256));
			Assert.That(Settings.Status.Value, Is.EqualTo(1024));
			Assert.That(Settings.Wall.Value, Is.EqualTo(8192));
			Assert.That(Settings.Groups.Value, Is.EqualTo(262144));
			Assert.That(Settings.Messages.Value, Is.EqualTo(4096));
			Assert.That(Settings.Email.Value, Is.EqualTo(4194304));
			Assert.That(Settings.Notifications.Value, Is.EqualTo(524288));
			Assert.That(Settings.Statistic.Value, Is.EqualTo(1048576));
			Assert.That(Settings.Ads.Value, Is.EqualTo(32768));
			Assert.That(Settings.Offline.Value, Is.EqualTo(65536));
		}

        [Test]
        public void ToString_ComplexExpresstion_NotPrintEmptyNames()
        {
            var one = Settings.Friends | Settings.Messages;
            var two = Settings.Audio | Settings.Notes;

            Assert.That(one.Value, Is.EqualTo(4098));
            Assert.That(two.Value, Is.EqualTo(2056));

            Assert.That(one.ToString(), Is.EqualTo("friends,messages"));
            Assert.That(two.ToString(), Is.EqualTo("audio,notes"));
        }

        [Test]
        public void Value_OffersPagesFriends_162()
        {
            var settings = Settings.Pages | Settings.Friends;
			Assert.That(settings.Value, Is.EqualTo(130));
        }

        [Test]
        public void ToString_MulitpleItems()
        {
            var settings = Settings.Friends | Settings.Video | Settings.Audio;
			Assert.That(settings.ToString(), Is.EqualTo("friends,audio,video"));
        }

        [Test]
        public void ToString_All()
        {
            var settings = Settings.All;
			const string expected = "notify,friends,photos,audio,video,pages,status,notes,messages,wall," +
									"ads,docs,groups,notifications,stats,email,market";

            Assert.That(settings.ToString(), Is.EqualTo(expected));
        }
    }
}