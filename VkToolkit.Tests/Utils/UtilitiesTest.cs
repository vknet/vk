using System;
using NUnit.Framework;
using VkToolkit.Enums;
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

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFriendStatus_WrongInput_ThrowArgumentException()
        {
            Utilities.GetFriendStatus(5);
        }

        [Test]
        public void GetFriendStatus_IterateAllValues_Success()
        {
            FriendStatus notFriend = Utilities.GetFriendStatus(0);
            FriendStatus outputRequest = Utilities.GetFriendStatus(1);
            FriendStatus inputRequest = Utilities.GetFriendStatus(2);
            FriendStatus friend = Utilities.GetFriendStatus(3);

            Assert.That(notFriend, Is.EqualTo(FriendStatus.NotFriend));
            Assert.That(outputRequest, Is.EqualTo(FriendStatus.OutputRequest));
            Assert.That(inputRequest, Is.EqualTo(FriendStatus.InputRequest));
            Assert.That(friend, Is.EqualTo(FriendStatus.Friend));
        }
    }
}