using NUnit.Framework;
using VkToolkit.Enum;

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
            var s = Settings.Friends | Settings.Video | Settings.Offline | Settings.Friends;
            Assert.That(s.ToString(), Is.EqualTo("friends,video,offline"));
        }

        [Test]
        public void ToString_MulitpleItems()
        {
            var s = Settings.Friends | Settings.Video | Settings.Offline;
            Assert.That(s.ToString(), Is.EqualTo("friends,video,offline"));
        }

        [Test]
        public void ToString_All()
        {
            Settings s = Settings.All;
            const string expected = "notify,friends,photos,audio,video,docs,notes," +
                                    "pages,status,wall,offers,questions,groups," +
                                    "messages,notifications,stats,ads,offline";

            Assert.That(s.ToString(), Is.EqualTo(expected));
        }
    }
}