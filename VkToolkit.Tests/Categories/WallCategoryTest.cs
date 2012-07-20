using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Exception;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class WallCategoryTest
    {
        private WallCategory _defaultWall;

        [SetUp]
        public void SetUp()
        {
            _defaultWall = new WallCategory(new VkApi());
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.Get();   
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetComments_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.GetComments();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.GetById();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Post_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.Post();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Edit_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.Edit();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.Delete();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.Restore();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void AddComment_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.AddComment();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void RestoreComment_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.RestoreComment();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void DeleteComment_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.DeleteComment();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void AddLike_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.AddLike();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void DeleteLike_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            _defaultWall.DeleteLike();
        }
    }
}