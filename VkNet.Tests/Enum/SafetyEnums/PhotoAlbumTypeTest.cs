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
            PhotoAlbumType wall = PhotoAlbumType.Wall;
            PhotoAlbumType profile = PhotoAlbumType.Profile;
            PhotoAlbumType saved = PhotoAlbumType.Saved;

            wall.ToString().ShouldEqual("wall");
            profile.ToString().ShouldEqual("profile");
            saved.ToString().ShouldEqual("saved");
        }
    }
}