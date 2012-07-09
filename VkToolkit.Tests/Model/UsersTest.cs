using NUnit.Framework;
using VkToolkit.Exception;
using VkToolkit.Model;

namespace VkToolkit.Tests.Model
{
    [TestFixture]
    public class UsersTest
    {
        private Users users;

        [SetUp]
        public void SetUp()
        {
            users = new Users(new VkApi());       
        }

        [Test]
        [ExpectedException(typeof(AccessTokenNotSetException))]
        public void GetProfiles_EmptyAccessToken_ThrowAccessTokenNotSetException()
        {
            users.GetProfiles(1);
        }
    }
}