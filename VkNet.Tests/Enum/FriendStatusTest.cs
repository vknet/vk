

namespace VkNet.Tests.Enum
{
    using System;

    using NUnit.Framework;

    using Enums;
    using VkNet.Utils;

    [TestFixture]
    public class FriendStatusTest
    {
        [Test]
        public void GetFriendStatus_WrongInput_ThrowArgumentException()
        {
			Assert.Throws<ArgumentException>(() => Utilities.EnumFrom<FriendStatus>(5));
		}

        [Test]
        public void GetFriendStatus_IterateAllValues_Success()
        {
            var notFriend = Utilities.EnumFrom<FriendStatus>(0);
            var outputRequest = Utilities.EnumFrom<FriendStatus>(1);
            var inputRequest = Utilities.EnumFrom<FriendStatus>(2);
            var friend = Utilities.EnumFrom<FriendStatus>(3);

            Assert.That(notFriend, Is.EqualTo(FriendStatus.NotFriend));
            Assert.That(outputRequest, Is.EqualTo(FriendStatus.OutputRequest));
            Assert.That(inputRequest, Is.EqualTo(FriendStatus.InputRequest));
            Assert.That(friend, Is.EqualTo(FriendStatus.Friend));
        }
    }
}