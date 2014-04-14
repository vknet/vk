namespace VkNet.Tests.Enum
{
    using NUnit.Framework;
    using VkNet.Utils.Tests;
    using Enums;

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
            Settings.Notify.Value.ShouldEqual(1);
            Settings.Friends.Value.ShouldEqual(2);
            Settings.Photos.Value.ShouldEqual(4);
            Settings.Audio.Value.ShouldEqual(8);
            Settings.Video.Value.ShouldEqual(16);
            Settings.Documents.Value.ShouldEqual(131072);
            Settings.Notes.Value.ShouldEqual(2048);
            Settings.Pages.Value.ShouldEqual(128);
            Settings.AddLinkToLeftMenu.Value.ShouldEqual(256);
            Settings.Status.Value.ShouldEqual(1024);
            Settings.Wall.Value.ShouldEqual(8192);
            Settings.Groups.Value.ShouldEqual(262144);
            Settings.Messages.Value.ShouldEqual(4096);
            Settings.Email.Value.ShouldEqual(4194304);
            Settings.Notifications.Value.ShouldEqual(524288);
            Settings.Statistic.Value.ShouldEqual(1048576);
            Settings.Ads.Value.ShouldEqual(32768);
            Settings.Offline.Value.ShouldEqual(65536);
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
            Settings s = Settings.Pages | Settings.Friends;
            Assert.That(s.Value, Is.EqualTo(130));
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
            const string expected = "notify,friends,photos,audio,video,docs,notes,pages,status,wall,groups,messages,notifications," + 
                "stats,ads";

            Assert.That(s.ToString(), Is.EqualTo(expected));
        }
    }
}