using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
    [TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class PhotosCategoryTest : BaseTest
	{
        public PhotoCategory GetMockedPhotosCategory(string url, string json)
        {
            Json = json;
            Url = url;
            return new PhotoCategory(Api);
        }

        #region GetProfileUploadServer
        [Test]
        public void GetProfileUploadServer_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.getOwnerPhotoUploadServer";
            const string json =
                @"{
                    'response': {
                      'upload_url': 'http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNh'
                    }
                  }";

            var info = GetMockedPhotosCategory(url, json).GetOwnerPhotoUploadServer();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.UploadUrl, Is.EqualTo("http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNh"));
		}
        #endregion

        #region GetMessagesUploadServer
        [Test]
        public void GetMessagesUploadServer_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.getMessagesUploadServer";
			const string json =
                @"{
                    'response': {
                      'upload_url': 'http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=de2523dd173af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1',
                      'album_id': -3,
                      'user_id': 234618
                    }
                  }";

            var info = GetMockedPhotosCategory(url, json).GetMessagesUploadServer(123);
			Assert.That(info, Is.Not.Null);

			Assert.That(info.UploadUrl, Is.EqualTo("http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=de2523dd173af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1"));
			Assert.That(info.AlbumId, Is.EqualTo(-3));
			Assert.That(info.UserId, Is.EqualTo(234618));
		}
        #endregion

        #region GetOwnerCoverPhotoUploadServer
        [Test]
        public void GetOwnerCoverPhotoUploadServer_NormalCase() {
            const long group = 1L;
            const string url = "https://api.vk.com/method/photos.getOwnerCoverPhotoUploadServer";
            const string json =
                @"{
                    'response': {
                      'upload_url': 'http://pu.vk.com/c837421/upload.php?_query=eyJhY3QiOiJvd25lcl9jb3ZlciIsIm9pZCI6LTkzNjY5OTI0LCJhcGkiOnRydWUsImFwaV93cmFwIjp7Imhhc2giOiIxMDA4MmRjZWJlZGIzMjZkNDQiLCJwaG90byI6IntyZXN1bHR9In0sIm1pZCI6NzY2NDA4ODIsInNlcnZlciI6ODM3NDIxLCJfb3JpZ2luIjoiaHR0cHM6XC9cL2FwaS52ay5jb20iLCJfc2lnIjoiYzZjNWM4ZGVmYmE5YWQ3YWM1ZTYzYTUxMWJjMjgzZDcifQ&_crop=0,0,1590,400'
                    }
                  }";

            var info = GetMockedPhotosCategory(url, json).GetOwnerCoverPhotoUploadServer(group);
            Assert.That(info, Is.Not.Null);

            Assert.That(info.UploadUrl, Is.EqualTo("http://pu.vk.com/c837421/upload.php?_query=eyJhY3QiOiJvd25lcl9jb3ZlciIsIm9pZCI6LTkzNjY5OTI0LCJhcGkiOnRydWUsImFwaV93cmFwIjp7Imhhc2giOiIxMDA4MmRjZWJlZGIzMjZkNDQiLCJwaG90byI6IntyZXN1bHR9In0sIm1pZCI6NzY2NDA4ODIsInNlcnZlciI6ODM3NDIxLCJfb3JpZ2luIjoiaHR0cHM6XC9cL2FwaS52ay5jb20iLCJfc2lnIjoiYzZjNWM4ZGVmYmE5YWQ3YWM1ZTYzYTUxMWJjMjgzZDcifQ&_crop=0,0,1590,400"));
        }
        #endregion

        #region CreateAlbum

        [Test]
        public void CreateAlbum_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.createAlbum";
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
                      'privacy_view': ['all'],
					  'privacy_comment': ['all'],
                      'size': 0
                    }
                  }";

            var album = GetMockedPhotosCategory(url, json)
                .CreateAlbum(new PhotoCreateAlbumParams
                {
					Title= "hello world",
					Description = "description for album"
                });
			Assert.That(album, Is.Not.Null);
			Assert.That(album.Id, Is.EqualTo(197266686));
			Assert.That(album.ThumbId, Is.EqualTo(-1));
			Assert.That(album.OwnerId, Is.EqualTo(234698));
			Assert.That(album.Title, Is.EqualTo("hello world"));
			Assert.That(album.Description, Is.EqualTo("description for album"));
			Assert.That(album.Created, Is.EqualTo(DateHelper.TimeStampToDateTime(1403185184)));
			Assert.That(album.Updated, Is.EqualTo(DateHelper.TimeStampToDateTime(1403185184)));
			Assert.That(album.PrivacyView[0], Is.EqualTo(Privacy.All));
			Assert.That(album.PrivacyComment[0], Is.EqualTo(Privacy.All));

			Assert.That(album.Size, Is.EqualTo(0));
		}

        #endregion

        #region EditAlbum
        [Test]
        public void EditAlbum_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.editAlbum";
			const string json =
                @"{
                    'response': 1
                  }";

            var result = GetMockedPhotosCategory(url, json).EditAlbum(new PhotoEditAlbumParams
            {
	            AlbumId = 19726,
				Title = "new album title",
				Description = "new description"
			});

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
        }
        #endregion

        #region GetAlbums
        [Test]
        public void GetAlbums_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.getAlbums";
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
            var albums = GetMockedPhotosCategory(url, json).GetAlbums(new PhotoGetAlbumsParams
            {
				OwnerId = 1
			},
            false);
			Assert.That(albums, Is.Not.Null);
			Assert.That(albums.Count, Is.EqualTo(1));

			var album = albums.FirstOrDefault();
			Assert.That(album, Is.Not.Null);
			Assert.That(album.Id, Is.EqualTo(136592355));
			Assert.That(album.ThumbId, Is.EqualTo(321112194));
			Assert.That(album.OwnerId, Is.EqualTo(1));
			Assert.That(album.Title, Is.EqualTo("Здесь будут новые фотографии для прессы-службы"));
			Assert.That(album.Description, Is.EqualTo(string.Empty));
			Assert.That(album.Created, Is.EqualTo(DateHelper.TimeStampToDateTime(1307628778)));
			Assert.That(album.Updated, Is.EqualTo(DateHelper.TimeStampToDateTime(1398625473)));
			Assert.That(album.Size, Is.EqualTo(8));
		}

		[Test]
		public void GetAlbums_PrivacyCase()
		{
			const string url = "https://api.vk.com/method/photos.getAlbums";
			const string json =
				@"{
                    response: {
						count: 1,
						items: [{
							id: 110637109,
							thumb_id: 326631163,
							owner_id: 32190123,
							title: 'Я',
							description: '',
							created: 1307628778,
							updated: 1398625473,
							size: 6,
							thumb_is_last: 1,
							privacy_view: ['list28'],
							privacy_comment: ['list28', '-list1']
						}]
					}
                  }";
			var albums = GetMockedPhotosCategory(url, json).GetAlbums(new PhotoGetAlbumsParams
			{
				AlbumIds = new List<long>
				{
					110637109
				}
			}, false);

			Assert.That(albums, Is.Not.Null);
			Assert.That(albums.Count, Is.EqualTo(1));

			var album = albums.FirstOrDefault();
			Assert.That(album, Is.Not.Null);

			Assert.That(album.Id, Is.EqualTo(110637109));
			Assert.That(album.ThumbId, Is.EqualTo(326631163));
			Assert.That(album.OwnerId, Is.EqualTo(32190123));
			Assert.That(album.Title, Is.EqualTo("Я"));
			Assert.That(album.Description, Is.EqualTo(string.Empty));
			Assert.That(album.Created, Is.EqualTo(new DateTime(2011, 6, 9, 14, 12, 58, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(album.Updated, Is.EqualTo(new DateTime(2014, 4, 27, 19, 4, 33).ToLocalTime()));
			Assert.That(album.Size, Is.EqualTo(6));
			Assert.That(album.ThumbIsLast, Is.True);
			Assert.That(album.PrivacyView[0].ToString(), Is.EqualTo("list28"));
			Assert.That(album.PrivacyComment[0].ToString(), Is.EqualTo("list28"));
			Assert.That(album.PrivacyComment[1].ToString(), Is.EqualTo("-list1"));
		}
		#endregion

		#region GetAlbumsCount
		[Test]
        public void GetAlbumsCount_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.getAlbumsCount";
            const string json =
                @"{
                    'response': 1
                  }";

            var count = GetMockedPhotosCategory(url, json).GetAlbumsCount(1);

			Assert.That(count, Is.Not.Null);
			Assert.That(count, Is.EqualTo(1));
        }
        #endregion

        #region DeleteAlbum
        [Test]
        public void DeleteAlbum_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.deleteAlbum";
			const string json =
                @"{
                    'response': 1
                  }";

            var result = GetMockedPhotosCategory(url, json).DeleteAlbum(197303);
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
        }
        #endregion

        #region GetAll
        [Test]
        public void GetAll_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.getAll";
			const string json =
				@"{
                    'response': {
                      'count': 173,
                      'items': [
                        {
                          'id': 328693256,
                          'album_id': -7,
                          'owner_id': 1,
                          'photo_75': 'http://cs7004.vk.me/c7006/v7006001/26e37/xOF6D9lY3CU.jpg',
                          'photo_130': 'http://cs7004.vk.me/c7006/v7006001/26e38/3atNlPEJpaA.jpg',
                          'photo_604': 'http://cs7004.vk.me/c7006/v7006001/26e39/OfHtSC9qtuA.jpg',
                          'photo_807': 'http://cs7004.vk.me/c7006/v7006001/26e3a/el6ZcXa9WSc.jpg',
                          'width': 609,
                          'height': 574,
                          'text': 'Сегодня должности раздаются чиновниками, которые боятся конкуренции и подбирают себе все менее талантливых и все более беспомощных подчиненных. Государственные посты должны распределяться на основе прозрачных механизмов, в том числе, прямых выборов.',
                          'date': 1398658327
                        },
                        {
                          'id': 328693245,
                          'album_id': -7,
                          'owner_id': 1,
                          'photo_75': 'http://cs7004.vk.me/c7006/v7006001/26e2f/sVIvq64s9N8.jpg',
                          'photo_130': 'http://cs7004.vk.me/c7006/v7006001/26e30/IeqoOkYl7Xw.jpg',
                          'photo_604': 'http://cs7004.vk.me/c7006/v7006001/26e31/ia2se1JpNi0.jpg',
                          'photo_807': 'http://cs7004.vk.me/c7006/v7006001/26e32/bpijpqfjhyw.jpg',
                          'width': 609,
                          'height': 543,
                          'text': 'Текущее обилие противоречащих друг другу законов стимулирует коррупцию и замедляет экономический рост. Страна нуждается в отмене большей части законотворческого балласта, принятого за последние 10 лет.',
                          'date': 1398658302
                        }
                      ]
                    }
                  }";

			var photos = GetMockedPhotosCategory(url, json).GetAll(new PhotoGetAllParams
			{
				OwnerId = 1,
				Offset = 4,
				Count = 2
			});
			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(2));

			var photo = photos.FirstOrDefault();
			Assert.That(photo, Is.Not.Null);

			Assert.That(photo.Id, Is.EqualTo(328693256));
			Assert.That(photo.AlbumId, Is.EqualTo(-7));
			Assert.That(photo.OwnerId, Is.EqualTo(1));
			Assert.That(photo.Photo75, Is.EqualTo(new Uri("http://cs7004.vk.me/c7006/v7006001/26e37/xOF6D9lY3CU.jpg")));
			Assert.That(photo.Photo130, Is.EqualTo(new Uri("http://cs7004.vk.me/c7006/v7006001/26e38/3atNlPEJpaA.jpg")));
			Assert.That(photo.Photo604, Is.EqualTo(new Uri("http://cs7004.vk.me/c7006/v7006001/26e39/OfHtSC9qtuA.jpg")));
			Assert.That(photo.Photo807, Is.EqualTo(new Uri("http://cs7004.vk.me/c7006/v7006001/26e3a/el6ZcXa9WSc.jpg")));
			Assert.That(photo.Width, Is.EqualTo(609));
			Assert.That(photo.Height, Is.EqualTo(574));
			Assert.That(photo.Text, Is.EqualTo("Сегодня должности раздаются чиновниками, которые боятся конкуренции и подбирают себе все менее талантливых и все более беспомощных подчиненных. Государственные посты должны распределяться на основе прозрачных механизмов, в том числе, прямых выборов."));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1398658327)));
		}

		#endregion

		#region Search
		[Test]
        public void Search_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.search";
            const string json =
                @"{
                    'response': {
                      'count': 48888,
                      'items': [
                        {
                          'id': 331520481,
                          'album_id': 182104020,
                          'owner_id': -49512556,
                          'user_id': 100,
                          'photo_75': 'http://cs620223.vk.me/v620223385/bd1f/SajcsJOh7hk.jpg',
                          'photo_130': 'http://cs620223.vk.me/v620223385/bd20/85-Qkc4oNH8.jpg',
                          'photo_604': 'http://cs620223.vk.me/v620223385/bd21/88vFsC-Z_FE.jpg',
                          'photo_807': 'http://cs620223.vk.me/v620223385/bd22/YqRauv0neMY.jpg',
                          'width': 807,
                          'height': 515,
                          'text': '🍓 [club49512556|ЗАХОДИ К НАМ]\nчастное фото секси обнаженные девочки малолетки порно голые сиськи попки эротика няша шлюха грудь секс instagirls instagram лето\n#секс #девушки #девочки #instagram #instagirls #няша #InstaSize #лето #ПОПКИ',
                          'date': 1403455788
                        },
                        {
                          'id': 332606009,
                          'album_id': -7,
                          'owner_id': 178964623,
                          'photo_75': 'http://cs618519.vk.me/v618519623/9595/RvC4OjMXsSM.jpg',
                          'photo_130': 'http://cs618519.vk.me/v618519623/9596/AGp73aAvQo0.jpg',
                          'photo_604': 'http://cs618519.vk.me/v618519623/9597/LRsFBCik5t0.jpg',
                          'photo_807': 'http://cs618519.vk.me/v618519623/9598/Qtge80swvSs.jpg',
                          'photo_1280': 'http://cs618519.vk.me/v618519623/9599/824w0bo3RAQ.jpg',
                          'width': 768,
                          'height': 1024,
                          'text': 'порно',
                          'date': 1403442663
                        },
                        {
                          'id': 331193616,
                          'album_id': 197460133,
                          'owner_id': 32396848,
                          'photo_75': 'http://cs620628.vk.me/v620628848/954d/NB9R43nYW_E.jpg',
                          'photo_130': 'http://cs620628.vk.me/v620628848/954e/0KLMGHdB2RA.jpg',
                          'photo_604': 'http://cs620628.vk.me/v620628848/954f/U7FTHERNKPU.jpg',
                          'photo_807': 'http://cs620628.vk.me/v620628848/9550/eGywWT4JZ20.jpg',
                          'photo_1280': 'http://cs620628.vk.me/v620628848/9551/AS2EFpUEY_4.jpg',
                          'width': 1280,
                          'height': 720,
                          'text': 'порно xD',
                          'date': 1403442409
                        }
                      ]
                    }
                  }";
	        
			var photos = GetMockedPhotosCategory(url, json).Search(new PhotoSearchParams
			{
				Query = "порно",
				Offset = 2,
				Count = 3
			});
			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(3));

			var photo = photos.FirstOrDefault();
			Assert.That(photo, Is.Not.Null);

			Assert.That(photo.Id, Is.EqualTo(331520481));
			Assert.That(photo.AlbumId, Is.EqualTo(182104020));
			Assert.That(photo.OwnerId, Is.EqualTo(-49512556));
			Assert.That(photo.UserId, Is.EqualTo(100));
			Assert.That(photo.Photo75, Is.EqualTo(new Uri("http://cs620223.vk.me/v620223385/bd1f/SajcsJOh7hk.jpg")));
			Assert.That(photo.Photo130, Is.EqualTo(new Uri("http://cs620223.vk.me/v620223385/bd20/85-Qkc4oNH8.jpg")));
			Assert.That(photo.Photo604, Is.EqualTo(new Uri("http://cs620223.vk.me/v620223385/bd21/88vFsC-Z_FE.jpg")));
			Assert.That(photo.Photo807, Is.EqualTo(new Uri("http://cs620223.vk.me/v620223385/bd22/YqRauv0neMY.jpg")));
			Assert.That(photo.Width, Is.EqualTo(807));
			Assert.That(photo.Height, Is.EqualTo(515));
			Assert.That(photo.Text, Is.EqualTo("🍓 [club49512556|ЗАХОДИ К НАМ]\nчастное фото секси обнаженные девочки малолетки порно голые сиськи попки эротика няша шлюха грудь секс instagirls instagram лето\n#секс #девушки #девочки #instagram #instagirls #няша #InstaSize #лето #ПОПКИ"));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1403455788)));  //  2014-06-22 20:49:48.000
		}

        [Test]
        public void Search_Error26_Lat_and_Long_in_output_photo()
        {
			const string url = "https://api.vk.com/method/photos.search";
            const string json =
                @"{
                    'response': {
                      'count': 12,
                      'items': [
                        {
                          'id': 334408466,
                          'album_id': 198144854,
                          'owner_id': 258913887,
                          'photo_75': 'http://cs617419.vk.me/v617419887/11e90/GD__Lv5FTI4.jpg',
                          'photo_130': 'http://cs617419.vk.me/v617419887/11e91/f-4hN1xff9I.jpg',
                          'photo_604': 'http://cs617419.vk.me/v617419887/11e92/KiTWG4Lk8sE.jpg',
                          'photo_807': 'http://cs617419.vk.me/v617419887/11e93/LXbjRssgtso.jpg',
                          'width': 640,
                          'height': 640,
                          'text': '',
                          'date': 1404294037,
                          'lat': 29.999996,
                          'long': 29.999997
                        },
                        {
                          'id': 326991086,
                          'album_id': -6,
                          'owner_id': 249390767,
                          'photo_75': 'http://cs605216.vk.me/v605216767/5336/XeqYTC3wgwo.jpg',
                          'photo_130': 'http://cs605216.vk.me/v605216767/5337/IdbmUgGaoys.jpg',
                          'photo_604': 'http://cs605216.vk.me/v605216767/5338/6wIHGv9_xZ8.jpg',
                          'width': 403,
                          'height': 336,
                          'text': '',
                          'date': 1396601780,
                          'lat': 29.942251,
                          'long': 29.882819,
                          'post_id': 1
                        }
                      ]
                    }
                  }";

			var photos = GetMockedPhotosCategory(url, json).Search(new PhotoSearchParams
			{
				Query = "",
				Latitude = 30,
				Longitude = 30,
				Count = 2
			});
			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(2));

	        var photo = photos.FirstOrDefault();
			Assert.That(photo, Is.Not.Null);

			Assert.That(photo.Latitude, Is.EqualTo(29.999996185302734));
			Assert.That(photo.Longitude, Is.EqualTo(29.999996185302734));

			var photo1 = photos.Skip(1).FirstOrDefault();
			Assert.That(photo1, Is.Not.Null);

			Assert.That(photo1.Latitude, Is.EqualTo(29.942251205444336));
			Assert.That(photo1.Longitude, Is.EqualTo(29.882818222045898));
		}
#endregion

        #region SaveWallPhoto
        [Test]
        public void SaveWallPhoto_NormalCase()
        {
			const string url = "https://api.vk.com/method/photos.saveWallPhoto";
			const string json = @"{
    'response': [
        {
            'id': 3446123,
            'album_id': -12,
            'owner_id': 234695890,
            'photo_75': 'http://cs7004.vk.me/c625725/v625725118/8c39/XZJpyifpfkM.jpg',
            'photo_130': 'http://cs7004.vk.me/c625725/v625725118/8c3a/cYyzeNiQCwg.jpg',
            'photo_604': 'http://cs7004.vk.me/c625725/v625725118/8c3b/b9rHdTFfLuw.jpg',
            'photo_807': 'http://cs7004.vk.me/c625725/v625725118/8c3c/POYM67dCGZg.jpg',
            'photo_1280': 'http://cs7004.vk.me/c625725/v625725118/8c3d/OWWWGO1gkOI.jpg',
            'width': 1256,
            'height': 320,
            'text': '',
            'date': 1415629651
        }
    ]
}";
	        const string response = @"{""server"":631223
				,""photo"":""[]""
				,""hash"":""163abf8b9e4e4513577012d5275cafbb""}";

			var result = GetMockedPhotosCategory(url, json).SaveWallPhoto(response, 1234, 123);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(1));

			var photo = result[0];
			Assert.That(photo, Is.Not.Null);
			Assert.That(photo.Id, Is.EqualTo(3446123));
			Assert.That(photo.AlbumId, Is.EqualTo(-12));
			Assert.That(photo.OwnerId, Is.EqualTo(234695890));
			Assert.That(photo.Photo75, Is.EqualTo(new Uri("http://cs7004.vk.me/c625725/v625725118/8c39/XZJpyifpfkM.jpg")));
			Assert.That(photo.Photo130, Is.EqualTo(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3a/cYyzeNiQCwg.jpg")));
			Assert.That(photo.Photo604, Is.EqualTo(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3b/b9rHdTFfLuw.jpg")));
			Assert.That(photo.Photo807, Is.EqualTo(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3c/POYM67dCGZg.jpg")));
			Assert.That(photo.Photo1280, Is.EqualTo(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3d/OWWWGO1gkOI.jpg")));
			Assert.That(photo.Width, Is.EqualTo(1256));
			Assert.That(photo.Height, Is.EqualTo(320));
			Assert.That(photo.Text, Is.EqualTo(string.Empty));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1415629651)));
		}
        #endregion

        #region SaveOwnerCoverPhoto
        [Test]
        public void SaveOwnerCoverPhoto_NormalCase() {
            const string url = "https://api.vk.com/method/photos.saveOwnerCoverPhoto";
            const string json = @"{
    'response':
    {
        'images': [
        {
            'url': 'https://cs7052.userapi.com/c837421/v837421774/52897/3TEjTwhK2uw.jpg',
            'width': 200,
            'height': 50
        },
        {
            'url': 'https://cs7052.userapi.com/c837421/v837421774/52896/M57KWzVv6zE.jpg',
            'width': 400,
            'height': 101
        },
        {
            'url': 'https://cs7052.userapi.com/c837421/v837421774/52893/yHkTW6fmR68.jpg',
            'width': 795,
            'height': 200
        },
        {
            'url': 'https://cs7052.userapi.com/c837421/v837421774/52895/D6rhfBrxGow.jpg',
            'width': 1080,
            'height': 272
        },
        {
            'url': 'https://cs7052.userapi.com/c837421/v837421774/52894/fEmF9i76g5w.jpg',
            'width': 1590,
            'height': 400
        }
        ]
    }
}";
            const string response = @"{
				""photo"":""[]""
				,""hash"":""163abf8b9e4e4513577012d5275cafbb""
}";

            var result = GetMockedPhotosCategory(url, json).SaveOwnerCoverPhoto(response);
            Assert.That(result, Is.Not.Null);

            var images = result.Images;
            Assert.That(images, Is.Not.Null);
            Assert.That(images.Count, Is.EqualTo(5));

            var image = images.ElementAt(0);
            Assert.That(image, Is.Not.Null);
            Assert.That(image.Url, Is.EqualTo(new Uri("https://cs7052.userapi.com/c837421/v837421774/52897/3TEjTwhK2uw.jpg")));
            Assert.That(image.Width, Is.EqualTo(200));
            Assert.That(image.Height, Is.EqualTo(50));
            image = images.ElementAt(1);
            Assert.That(image, Is.Not.Null);
            Assert.That(image.Url, Is.EqualTo(new Uri("https://cs7052.userapi.com/c837421/v837421774/52896/M57KWzVv6zE.jpg")));
            Assert.That(image.Width, Is.EqualTo(400));
            Assert.That(image.Height, Is.EqualTo(101));
            image = images.ElementAt(2);
            Assert.That(image, Is.Not.Null);
            Assert.That(image.Url, Is.EqualTo(new Uri("https://cs7052.userapi.com/c837421/v837421774/52893/yHkTW6fmR68.jpg")));
            Assert.That(image.Width, Is.EqualTo(795));
            Assert.That(image.Height, Is.EqualTo(200));
            image = images.ElementAt(3);
            Assert.That(image, Is.Not.Null);
            Assert.That(image.Url, Is.EqualTo(new Uri("https://cs7052.userapi.com/c837421/v837421774/52895/D6rhfBrxGow.jpg")));
            Assert.That(image.Width, Is.EqualTo(1080));
            Assert.That(image.Height, Is.EqualTo(272));
            image = images.ElementAt(4);
            Assert.That(image, Is.Not.Null);
            Assert.That(image.Url, Is.EqualTo(new Uri("https://cs7052.userapi.com/c837421/v837421774/52894/fEmF9i76g5w.jpg")));
            Assert.That(image.Width, Is.EqualTo(1590));
            Assert.That(image.Height, Is.EqualTo(400));
        }
        #endregion
    }
}