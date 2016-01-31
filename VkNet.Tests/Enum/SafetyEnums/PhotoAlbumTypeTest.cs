using FluentNUnit;
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

			wall.ToString().ShouldEqual("wall");
            profile.ToString().ShouldEqual("profile");
            saved.ToString().ShouldEqual("saved");
        }
    }
}