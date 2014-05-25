using NUnit.Framework;
using VkNet.Enums.Filters;
using FluentNUnit;

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
            Settings s = Settings.Friends;
            Assert.That(s.ToString(), Is.EqualTo("friends"));
        }

        [Test]
        public void ToString_DuplicateSettings_NoDuplicates()
        {
            var s = Settings.Friends | Settings.Video | Settings.Audio | Settings.Friends;
			Assert.That(s.ToString(), Is.EqualTo("friends,audio,video"));
        }

        [Test]
        public void Value_Iterate_InitializedValues()
        {
            Settings.Notify.Value.ShouldEqual((ulong)1);
			Settings.Friends.Value.ShouldEqual((ulong)2);
			Settings.Photos.Value.ShouldEqual((ulong)4);
			Settings.Audio.Value.ShouldEqual((ulong)8);
			Settings.Video.Value.ShouldEqual((ulong)16);
			Settings.Documents.Value.ShouldEqual((ulong)131072);
			Settings.Notes.Value.ShouldEqual((ulong)2048);
			Settings.Pages.Value.ShouldEqual((ulong)128);
			Settings.AddLinkToLeftMenu.Value.ShouldEqual((ulong)256);
			Settings.Status.Value.ShouldEqual((ulong)1024);
			Settings.Wall.Value.ShouldEqual((ulong)8192);
			Settings.Groups.Value.ShouldEqual((ulong)262144);
			Settings.Messages.Value.ShouldEqual((ulong)4096);
			Settings.Email.Value.ShouldEqual((ulong)4194304);
			Settings.Notifications.Value.ShouldEqual((ulong)524288);
			Settings.Statistic.Value.ShouldEqual((ulong)1048576);
			Settings.Ads.Value.ShouldEqual((ulong)32768);
			Settings.Offline.Value.ShouldEqual((ulong)65536);
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
			Assert.That(s.ToString(), Is.EqualTo("friends,audio,video"));
        }

        [Test]
        public void ToString_All()
        {
            Settings s = Settings.All;
            const string expected = "notify,friends,photos,audio,video,pages,status,notes,messages,wall," +
									"ads,docs,groups,notifications,stats";

            Assert.That(s.ToString(), Is.EqualTo(expected));
        }
    }
}