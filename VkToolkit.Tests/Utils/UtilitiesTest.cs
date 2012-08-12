using System;
using System.Linq;
using NUnit.Framework;
using VkToolkit.Enums;
using VkToolkit.Utils;
using Newtonsoft.Json.Linq;

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
        public void JArrayToIEnumerable_JArray_LongArray()
        {
            string json = "{\"response\":[{\"type\":\"profile\",\"uid\":1708231,\"first_name\":\"Григорий\",\"last_name\":\"Клюшников\"},{\"type\":\"chat\",\"chat_id\":109,\"title\":\"Андрей, Григорий\",\"users\":[66748,6492,1708231]}]}";

            JObject obj = JObject.Parse(json);

            var response = (JArray)obj["response"];

            var arr = (JArray) response[1]["users"];

            var result = Utilities.JArrayToIEnumerable<long>(arr).ToList();
            
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(66748));
            Assert.That(result[1], Is.EqualTo(6492));
            Assert.That(result[2], Is.EqualTo(1708231));
        }

        [Test]
        public void JArrayToIEnumerable_JArray_StringArray()
        {
            string json = "{\"response\":[{\"type\":\"profile\",\"uid\":1708231,\"first_name\":\"Григорий\",\"last_name\":\"Клюшников\"},{\"type\":\"chat\",\"chat_id\":109,\"title\":\"Андрей, Григорий\",\"users\":[66748,6492,1708231]}]}";

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];
            var arr = (JArray)response[1]["users"];

            var result = Utilities.JArrayToIEnumerable<string>(arr).ToList();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("66748"));
            Assert.That(result[1], Is.EqualTo("6492"));
            Assert.That(result[2], Is.EqualTo("1708231"));
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