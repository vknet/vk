using NUnit.Framework;
using VkToolkit.Enums;

namespace VkToolkit.Tests.Enum
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
            Settings s = Settings.Friends;
            Assert.That(s.ToString(), Is.EqualTo("friends"));
        }

        [Test]
        public void ToString_DuplicateSettings_NoDuplicates()
        {
            var s = Settings.Friends | Settings.Video | Settings.Audio | Settings.Friends;
            Assert.That(s.ToString(), Is.EqualTo("friends,video,audio"));
        }

        [Test]
        public void Value_Iterate_InitializedValues()
        {
            Assert.That(Settings.Notify.Value, Is.EqualTo(1));
            Assert.That(Settings.Friends.Value, Is.EqualTo(2));
            Assert.That(Settings.Photos.Value, Is.EqualTo(4));
            Assert.That(Settings.Audio.Value, Is.EqualTo(8));
            Assert.That(Settings.Video.Value, Is.EqualTo(16));
            Assert.That(Settings.Offers.Value, Is.EqualTo(32));
            Assert.That(Settings.Questions.Value, Is.EqualTo(64));
            Assert.That(Settings.Pages.Value, Is.EqualTo(128));
            Assert.That(Settings.AddLinkToLeftMenu.Value, Is.EqualTo(256));
            Assert.That(Settings.AddLinkToWallPost.Value, Is.EqualTo(512));
            Assert.That(Settings.Status.Value, Is.EqualTo(1024));
            Assert.That(Settings.Notes.Value, Is.EqualTo(2048));
            Assert.That(Settings.Messages.Value, Is.EqualTo(4096));
            Assert.That(Settings.Wall.Value, Is.EqualTo(8192));
            Assert.That(Settings.Ads.Value, Is.EqualTo(32768));
            Assert.That(Settings.Docs.Value, Is.EqualTo(131072));
            Assert.That(Settings.Groups.Value, Is.EqualTo(262144));
            Assert.That(Settings.Notifications.Value, Is.EqualTo(524288));
            Assert.That(Settings.Statistic.Value, Is.EqualTo(1048576));
        }

        [Test]
        public void ToString_NotPrintEmptyNames_EmptyStrings()
        {
            var leftMenu = Settings.AddLinkToLeftMenu;
            var wallPost = Settings.AddLinkToWallPost;

            Assert.That(leftMenu.ToString(), Is.Empty);
            Assert.That(wallPost.ToString(), Is.Empty);
        }

        [Test]
        public void ToString_ComplexExpresstion_NotPrintEmptyNames()
        {
            var one = Settings.Friends | Settings.AddLinkToLeftMenu | Settings.Messages;
            var two = Settings.Audio | Settings.AddLinkToWallPost | Settings.Notes;

            Assert.That(one.Value, Is.EqualTo(4354));
            Assert.That(two.Value, Is.EqualTo(2568));

            Assert.That(one.ToString(), Is.EqualTo("friends,messages"));
            Assert.That(two.ToString(), Is.EqualTo("audio,notes"));
        }

        [Test]
        public void Value_OffersPagesFriends_162()
        {
            Settings s = Settings.Offers | Settings.Pages | Settings.Friends;
            Assert.That(s.Value, Is.EqualTo(162));
        }

        [Test]
        public void ToString_MulitpleItems()
        {
            var s = Settings.Friends | Settings.Video | Settings.Audio;
            Assert.That(s.ToString(), Is.EqualTo("friends,video,audio"));
        }

        [Test]
        public void ToString_All()
        {
            Settings s = Settings.All;
            const string expected = "notify,friends,photos,audio,video,docs,notes," +
                                    "pages,status,wall,offers,questions,groups," +
                                    "messages,notifications,stats,ads";

            Assert.That(s.ToString(), Is.EqualTo(expected));
        }
    }
}