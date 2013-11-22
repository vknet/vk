namespace VkToolkit.Tests.Enum
{
    using NUnit.Framework;

    using VkToolkit.Enums;
    using VkToolkit.Model;

    [TestFixture]
    public class GroupTypeTest
    {
        [Test]
        public void GetGroupType_IterateAllValues_Success()
        {
            GroupType page = Group.GetGroupType("page");
            GroupType eventType = Group.GetGroupType("event");
            GroupType group = Group.GetGroupType("group");
            GroupType undefined = Group.GetGroupType("NotExistentType");

            Assert.That(page, Is.EqualTo(GroupType.Page));
            Assert.That(eventType, Is.EqualTo(GroupType.Event));
            Assert.That(group, Is.EqualTo(GroupType.Group));
            Assert.That(undefined, Is.EqualTo(GroupType.Undefined));
        }
    }
}