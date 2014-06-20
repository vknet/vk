using System;
using System.Collections.ObjectModel;
using FluentNUnit;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Model;
using VkNet.Utils;

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

        #region GetProfileUploadServer
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
        #endregion

        #region GetMessagesUploadServer
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
        #endregion

        #region CreateAlbum

        [Test]
        public void CreateAlbum_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.createAlbum?title=hello world&description=description for album&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': {
                      'id': 197266686,
                      'thumb_id': -1,
                      'owner_id': 234698,
                      'title': 'hello world',
                      'description': 'description for album',
                      'created': 1403185184,
                      'updated': 1403185184,
                      'privacy': 0,
                      'comment_privacy': 0,
                      'size': 0
                    }
                  }";

            PhotoAlbum album = GetMockedPhotosCategory(url, json)
                .CreateAlbum(title: "hello world", description: "description for album");

            album.Id.ShouldEqual(197266686);
            album.ThumbId.ShouldEqual(-1);
            album.OwnerId.ShouldEqual(234698);
            album.Title.ShouldEqual("hello world");
            album.Description.ShouldEqual("description for album");
            album.Created.ShouldEqual(new DateTime(2014, 6, 19, 17, 39, 44));
            album.Updated.ShouldEqual(new DateTime(2014, 6, 19, 17, 39, 44));
            album.Privacy.ShouldEqual(0);
            album.CommentPrivacy.ShouldEqual(0);
            album.Size.ShouldEqual(0);
        }

        #endregion

        #region EditAlbum
        [Test]
        public void EditAlbum_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.editAlbum?album_id=19726&title=new album title&description=new description&v=5.9&access_token=token";


            const string json =
                @"{
                    'response': 1
                  }";

            bool result = GetMockedPhotosCategory(url, json).EditAlbum(19726, "new album title", "new description");
            result.ShouldBeTrue();
        }
        #endregion

        #region GetAlbums
        [Test]
        public void GetAlbums_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.getAlbums?owner_id=1&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': {
                      'count': 1,
                      'items': [
                        {
                          'id': 136592355,
                          'thumb_id': 321112194,
                          'owner_id': 1,
                          'title': 'Здесь будут новые фотографии для прессы-службы',
                          'description': '',
                          'created': 1307628778,
                          'updated': 1398625473,
                          'size': 8
                        }
                      ]
                    }
                  }";

            ReadOnlyCollection<PhotoAlbum> albums = GetMockedPhotosCategory(url, json).GetAlbums(1);
            albums.Count.ShouldEqual(1);

            albums[0].Id.ShouldEqual(136592355);
            albums[0].ThumbId.ShouldEqual(321112194);
            albums[0].OwnerId.ShouldEqual(1);
            albums[0].Title.ShouldEqual("Здесь будут новые фотографии для прессы-службы");
            albums[0].Description.ShouldEqual(string.Empty);
            albums[0].Created.ShouldEqual(new DateTime(2011, 6, 9, 19, 12, 58));
            albums[0].Updated.ShouldEqual(new DateTime(2014, 4, 27, 23, 4, 33));
            albums[0].Size.ShouldEqual(8);
        }
        #endregion

        #region GetAlbumsCount
        [Test]
        public void GetAlbumsCount_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.getAlbumsCount?user_id=1&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            int count = GetMockedPhotosCategory(url, json).GetAlbumsCount(1);
            count.ShouldEqual(1);
        }
        #endregion

        #region DeleteAlbum
        [Test]
        public void DeleteAlbum_NormalCase()
        {
            const string url = "https://api.vk.com/method/photos.deleteAlbum?album_id=197303&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            bool result = GetMockedPhotosCategory(url, json).DeleteAlbum(197303);
            result.ShouldBeTrue();
        }
        #endregion

    }
}