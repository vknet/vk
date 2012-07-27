using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Utils;

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

        private WallCategory GetMockedWallCategory(string url, string json)
        {
            var mock = new Mock<IBrowser>();
            mock.Setup(m => m.GetJson(url)).Returns(json);

            return new WallCategory(new VkApi { AccessToken = "token", Browser = mock.Object });
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            int totalCount;
            _defaultWall.Get(1, out totalCount);
        }

        [Test]
        public void Get_DefaultFields_ReturnBasicInfo()
        {
            const string url = "https://api.vk.com/method/wall.get?owner_id=1&count=3&offset=5&filter=owner&access_token=token";
            string json = "{\"response\":[137,{\"id\":619,\"from_id\":4793858,\"to_id\":4793858,\"date\":1341145268,\"text\":\"Фильмы ужасов, основанные на реальных событиях.\",\"copy_owner_id\":50915841,\"copy_post_id\":1374,\"media\":{\"type\":\"photo\",\"owner_id\":50915841,\"item_id\":283337039,\"thumb_src\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126e\\/H5W0B96fSVM.jpg\"},\"attachment\":{\"type\":\"photo\",\"photo\":{\"pid\":283337039,\"aid\":-7,\"owner_id\":50915841,\"src\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126e\\/H5W0B96fSVM.jpg\",\"src_big\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126f\\/35YS_xcXCJk.jpg\",\"src_small\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126d\\/qYeAGOiA5kY.jpg\",\"width\":450,\"height\":320,\"text\":\"\",\"created\":1337542384,\"access_key\":\"e377d6e0b55e299741\"}},\"attachments\":[{\"type\":\"photo\",\"photo\":{\"pid\":283337039,\"aid\":-7,\"owner_id\":50915841,\"src\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126e\\/H5W0B96fSVM.jpg\",\"src_big\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126f\\/35YS_xcXCJk.jpg\",\"src_small\":\"http:\\/\\/cs303810.userapi.com\\/v303810841\\/126d\\/qYeAGOiA5kY.jpg\",\"width\":450,\"height\":320,\"text\":\"\",\"created\":1337542384,\"access_key\":\"e377d6e0b55e299741\"}}],\"comments\":{\"count\":0,\"can_post\":1},\"likes\":{\"count\":1,\"user_likes\":1,\"can_like\":0,\"can_publish\":0},\"reposts\":{\"count\":0,\"user_reposted\":0},\"post_source\":{\"type\":\"api\"},\"online\":0,\"reply_count\":0},{\"id\":617,\"from_id\":4793858,\"to_id\":4793858,\"date\":1339684666,\"text\":\"\",\"media\":{\"type\":\"audio\",\"owner_id\":4793858,\"item_id\":154701206},\"attachment\":{\"type\":\"audio\",\"audio\":{\"aid\":154701206,\"owner_id\":4793858,\"performer\":\"Мук\",\"title\":\"Дорогою добра\",\"duration\":130}},\"attachments\":[{\"type\":\"audio\",\"audio\":{\"aid\":154701206,\"owner_id\":4793858,\"performer\":\"Мук\",\"title\":\"Дорогою добра\",\"duration\":130}}],\"comments\":{\"count\":0,\"can_post\":1},\"likes\":{\"count\":0,\"user_likes\":0,\"can_like\":1,\"can_publish\":0},\"reposts\":{\"count\":0,\"user_reposted\":0},\"post_source\":{\"type\":\"vk\"},\"online\":0,\"reply_count\":0},{\"id\":616,\"from_id\":4793858,\"to_id\":4793858,\"date\":1339227157,\"text\":\"Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было.\",\"comments\":{\"count\":0,\"can_post\":1},\"likes\":{\"count\":1,\"user_likes\":0,\"can_like\":1,\"can_publish\":0},\"reposts\":{\"count\":0,\"user_reposted\":0},\"post_source\":{\"type\":\"vk\"},\"online\":0,\"reply_count\":0}]}";

            int totalCount;
            var records = GetMockedWallCategory(url, json).Get(1, out totalCount, 3, 5, WallFilter.Owner).ToList();

            Assert.That(totalCount, Is.EqualTo(137));
            Assert.That(records.Count == 3);

            Assert.That(records[2].Id, Is.EqualTo(616));
            Assert.That(records[2].ReplyCount, Is.EqualTo(0));
            Assert.That(records[2].Online, Is.False);
            Assert.That(records[2].FromId, Is.EqualTo(4793858));
            Assert.That(records[2].ToId, Is.EqualTo(4793858));
            Assert.That(records[2].Date, Is.EqualTo(new DateTime(2012, 6, 9, 11, 32, 37)));
            Assert.That(records[2].Text, Is.EqualTo("Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было."));
            Assert.That(records[2].Comments.Count, Is.EqualTo(0));
            Assert.That(records[2].Comments.CanPost, Is.True);
            Assert.That(records[2].Likes.Count, Is.EqualTo(1));
            Assert.That(records[2].Likes.UserLikes, Is.False);
            Assert.That(records[2].Likes.CanLike, Is.True);
            Assert.That(records[2].Likes.CanPublish, Is.False);
            Assert.That(records[2].Reposts.Count, Is.EqualTo(0));
            Assert.That(records[2].Reposts.UserReposted, Is.False);
            Assert.That(records[2].PostSource.Type, Is.EqualTo("vk"));

            Assert.That(records[0].Id, Is.EqualTo(619));
            Assert.That(records[0].FromId, Is.EqualTo(4793858));
            Assert.That(records[0].ToId, Is.EqualTo(4793858));
            Assert.That(records[0].Date, Is.EqualTo(new DateTime(2012, 7, 1, 16, 21, 8)));
            Assert.That(records[0].Text, Is.EqualTo("Фильмы ужасов, основанные на реальных событиях."));
            Assert.That(records[0].CopyOwnerId, Is.EqualTo(50915841));
            Assert.That(records[0].CopyPostId, Is.EqualTo(1374));
            //Assert.That(records[0]., Is.EqualTo());
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