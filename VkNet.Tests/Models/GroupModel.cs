using NUnit.Framework;
using VkNet.Model;

namespace VkNet.Tests.Models
{
    [TestFixture]
    public class GroupModel: BaseTest
    {
        [Test]
        public void ShouldHaveField_Trending()
        {
            var @group = new Group();
            Assert.That(@group, Has.Property("Trending"));
        }
        
        [Test]
        public void Trending_ShouldBeTrue()
        {
            var response = GetResponse("{'trending':1}");
            var @group = Group.FromJson(response);
            Assert.That(@group.Trending, Is.True);
        }
        
        [Test]
        public void Trending_ShouldBeFalse()
        {
            var response = GetResponse("{'trending':0}");
            var @group = Group.FromJson(response);
            Assert.That(@group.Trending, Is.False);
        }
        
        [Test]
        public void Trending_ShouldBeFalse2()
        {
            var response = GetResponse("{}");
            var @group = Group.FromJson(response);
            Assert.That(@group.Trending, Is.False);
        }
    }
}