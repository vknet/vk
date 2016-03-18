
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Enum.SafetyEnums
{
    [TestFixture]
    public class PhotoAlbumTypeTest
    {
        [Test]
        public void PhotoAlbumType_ToString_NormalCase()
        {
            var wall = PhotoAlbumType.Wall;
			var profile = PhotoAlbumType.Profile;
            var saved = PhotoAlbumType.Saved;

			Assert.That(wall.ToString(), Is.EqualTo("wall"));
			Assert.That(profile.ToString(), Is.EqualTo("profile"));
			Assert.That(saved.ToString(), Is.EqualTo("saved"));
		}
    }
}