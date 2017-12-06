using NUnit.Framework;
using VkNet.Model;

namespace VkNet.Tests.Models
{
    [TestFixture]
    public class FriendsGetRequestsResultModel: BaseTest
    {
        [Test]
        public void ShouldHaveField_UserId()
        {
            Json = "{'user_id':221634238}";
            var response = GetResponse();
            var result = FriendsGetRequestsResult.FromJson(response);
            Assert.That(result.UserId, Is.EqualTo(221634238L));
        }
        
        [Test]
        public void ShouldHaveField_Message()
        {
            Json = "{'user_id':221634238, 'message':'text'}";
            var response = GetResponse();
            var result = FriendsGetRequestsResult.FromJson(response);
            Assert.That(result.Message, Is.EqualTo("text"));
        }
        
        [Test]
        public void ShouldHaveField_Mutual()
        {
            Json = @"
            {
                'user_id':221634238,
                'mutual': {
                    'count': 3,
                    'users': [227457746, 228907945, 229634083]
                }
            }";
            var response = GetResponse();
            var result = FriendsGetRequestsResult.FromJson(response);
            Assert.IsNotEmpty(result.Mutual);
        }
    }
}