using NUnit.Framework;
using VkApiGenerator.Model;
using VkNet.Utils.Tests;

namespace VkApiGenerator.Test.Model
{
    [TestFixture]
    public class VkMethodInfoTest
    {
        [Test]
        public void CanonicalName_NormalCase()
        {
            var method = new VkMethodInfo {Name = "fave.getPosts"};
            method.CanonicalName.ShouldEqual("GetPosts");
        }

        [Test]
        public void CanonicalName_EmptyName()
        {
            var method = new VkMethodInfo();
            method.CanonicalName.ShouldEqual(string.Empty);
        }
    }
}