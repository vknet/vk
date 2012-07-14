using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Exception;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class GroupsCategoryTest
    {   
        [SetUp]
        public void SetUp()
        {
             
        }

        [Test]
        public void Join_WrongGid_()
        {
            Assert.Fail();
        }

        [Test]
        public void Leave_WrongGid_()
        {
            Assert.Fail();
        }

        [Test]
        public void Leave_UserNotAMemberOfAGroup_()
        {
            Assert.Fail();
        }

        [Test]
        public void Join_NormalCase_ReturnTrue()
        {
            Assert.Fail();
        }

        [Test]
        public void Leave_NormalCase_ReturnTrue()
        {
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Join_AccessDenied_ThrowAccessDeniedException()
        {
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Leave_AccessDenied_ThrowAccessDeniedException()
        {
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.Join(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.Leave(1);
        }
    }
}