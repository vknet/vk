using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Model;
using VkNet.Utils;
using VkNet.Utils.Tests;

namespace VkNet.Tests.Categories
{
    [TestFixture]
    public class PhotosCategoryTest
    {
        public PhotosCategory GetMockedPhotosCategory(string url, string json)
        {
            var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
            return new PhotosCategory(new VkApi{Browser = browser, AccessToken = "token"});
        }

        [Test]
        public void GetProfileUploadServer_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.getProfileUploadServer?v=5.9&access_token=token";
            const string json =
                @"{
                    'response': {
                      'upload_url': 'http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNh'
                    }
                  }";

            UploadServerInfo info = GetMockedPhotosCategory(url, json).GetProfileUploadServer();

            info.UploadUrl.ShouldEqual("http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNh");
        }

        [Test]
        public void GetMessagesUploadServer_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.getMessagesUploadServer?v=5.9&access_token=token";
            const string json =
                @"{
                    'response': {
                      'upload_url': 'http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=de2523dd173af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1',
                      'album_id': -3,
                      'user_id': 234618
                    }
                  }";

            UploadServerInfo info = GetMockedPhotosCategory(url, json).GetMessagesUploadServer();

            info.UploadUrl.ShouldEqual("http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=de2523dd173af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1");
            info.AlbumId.ShouldEqual(-3);
            info.UserId.ShouldEqual(234618);
        }


    }
}