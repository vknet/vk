using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
    public class GroupTypeTest
    {
        [Test]
        public void GetGroupType_IterateAllValues_Success()
        {
			Assert.That(GroupType.Page.ToString(), Is.EqualTo("page"));
			Assert.That(GroupType.Group.ToString(), Is.EqualTo("group"));
			Assert.That(GroupType.Event.ToString(), Is.EqualTo("event")); 
			Assert.That(GroupType.Undefined.ToString(), Is.EqualTo("undefined"));
        }
    }
}