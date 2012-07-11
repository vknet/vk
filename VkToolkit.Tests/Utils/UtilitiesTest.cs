using NUnit.Framework;
using VkToolkit.Enum;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Utils
{
    [TestFixture]
    public class UtilitiesTest
    {
        [SetUp]
        public void SetUp()
        {
             
        }

        [Test]
        public void GetGroupType_IterateAllValues_Success()
        {
            GroupType page = Utilities.GetGroupType("page");
            GroupType eventType = Utilities.GetGroupType("event");
            GroupType group = Utilities.GetGroupType("group");
            GroupType undefined = Utilities.GetGroupType("NotExistentType");

            Assert.That(page, Is.EqualTo(GroupType.Page));
            Assert.That(eventType, Is.EqualTo(GroupType.Event));
            Assert.That(group, Is.EqualTo(GroupType.Group));
            Assert.That(undefined, Is.EqualTo(GroupType.Undefined));
        }
    }
}