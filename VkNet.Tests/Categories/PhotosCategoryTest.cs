using System.Resources;
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
            const string url = "https://api.vk.com/method/photos.getProfileUploadServer?access_token=token";
            const string json =
                @"{
                    'response': {
                      'upload_url': 'http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNhdmUiOjEsImFwaV93cmFwI'
                    }
                  }";

            UploadServerInfo info = GetMockedPhotosCategory(url, json).GetProfileUploadServer();

            info.UploadUrl.ShouldEqual(
                "http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNhdmUiOjEsImFwaV93cmFwI");
        }

        [Test]
        public void GetMessagesUploadServer_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.getMessagesUploadServer?access_token=token";
            const string json =
                        @"{
                            'response': {
                                'upload_url': 'http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1',
                                'aid': -3,
                                'mid': 234695118
                            }
                            }";

            UploadServerInfo info = GetMockedPhotosCategory(url, json).GetMessagesUploadServer();
            info.UploadUrl.ShouldEqual("http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1");
        }


    }
}