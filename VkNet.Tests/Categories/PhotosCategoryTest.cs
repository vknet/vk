using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class PhotosCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Photos";

		[Test]
		public void CreateAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.createAlbum";
			ReadCategoryJsonPath(nameof(CreateAlbum_NormalCase));

			var album = Api.Photo
				.CreateAlbum(new PhotoCreateAlbumParams
				{
					Title = "hello world",
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

		[Test]
		public void DeleteAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.deleteAlbum";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Photo.DeleteAlbum(197303);
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public void EditAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.editAlbum";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Photo
				.EditAlbum(new PhotoEditAlbumParams
				{
					AlbumId = 19726,
					Title = "new album title",
					Description = "new description"
				});

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public void GetAlbums_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.getAlbums";
			ReadCategoryJsonPath(nameof(GetAlbums_NormalCase));

			var albums = Api.Photo
				.GetAlbums(new PhotoGetAlbumsParams
				{
					OwnerId = 1
				});

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
			Url = "https://api.vk.com/method/photos.getAlbums";
			ReadCategoryJsonPath(nameof(GetAlbums_PrivacyCase));

			var albums = Api.Photo
				.GetAlbums(new PhotoGetAlbumsParams
				{
					AlbumIds = new List<long>
					{
						110637109
					}
				});

			Assert.That(albums, Is.Not.Null);
			Assert.That(albums.Count, Is.EqualTo(1));

			var album = albums.FirstOrDefault();
			Assert.That(album, Is.Not.Null);

			Assert.That(album.Id, Is.EqualTo(110637109));
			Assert.That(album.ThumbId, Is.EqualTo(326631163));
			Assert.That(album.OwnerId, Is.EqualTo(32190123));
			Assert.That(album.Title, Is.EqualTo("Я"));
			Assert.That(album.Description, Is.EqualTo(string.Empty));

			Assert.That(album.Created,
				Is.EqualTo(new DateTime(2011,
					6,
					9,
					14,
					12,
					58,
					DateTimeKind.Utc)));

			Assert.That(album.Updated,
				Is.EqualTo(new DateTime(2014,
					4,
					27,
					19,
					4,
					33,
					DateTimeKind.Utc)));

			Assert.That(album.Size, Is.EqualTo(6));
			Assert.That(album.ThumbIsLast, Is.True);
			Assert.That(album.PrivacyView[0].ToString(), Is.EqualTo("list28"));
			Assert.That(album.PrivacyComment[0].ToString(), Is.EqualTo("list28"));
			Assert.That(album.PrivacyComment[1].ToString(), Is.EqualTo("-list1"));
		}

		[Test]
		public void GetAlbumsCount_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.getAlbumsCount";
			ReadJsonFile(JsonPaths.True);

			var count = Api.Photo.GetAlbumsCount(1);

			Assert.That(count, Is.Not.Null);
			Assert.That(count, Is.EqualTo(1));
		}

		[Test]
		public void GetAll_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.getAll";
			ReadCategoryJsonPath(nameof(GetAll_NormalCase));

			var photos = Api.Photo
				.GetAll(new PhotoGetAllParams
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

			Assert.That(photo.Text,
				Is.EqualTo(
					"Сегодня должности раздаются чиновниками, которые боятся конкуренции и подбирают себе все менее талантливых и все более беспомощных подчиненных. Государственные посты должны распределяться на основе прозрачных механизмов, в том числе, прямых выборов."));

			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1398658327)));
		}

		[Test]
		public void GetMessagesUploadServer_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.getMessagesUploadServer";
			ReadCategoryJsonPath(nameof(GetMessagesUploadServer_NormalCase));

			var info = Api.Photo.GetMessagesUploadServer(123);
			Assert.That(info, Is.Not.Null);

			Assert.That(info.UploadUrl,
				Is.EqualTo(
					"http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=de2523dd173af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1"));

			Assert.That(info.AlbumId, Is.EqualTo(-3));
			Assert.That(info.UserId, Is.EqualTo(234618));
		}

		[Test]
		public void GetOwnerCoverPhotoUploadServer_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.getOwnerCoverPhotoUploadServer";
			ReadCategoryJsonPath(nameof(GetOwnerCoverPhotoUploadServer_NormalCase));

			var info = Api.Photo.GetOwnerCoverPhotoUploadServer(1L);

			Assert.That(info, Is.Not.Null);

			Assert.That(info.UploadUrl,
				Is.EqualTo(
					"http://pu.vk.com/c837421/upload.php?_query=eyJhY3QiOiJvd25lcl9jb3ZlciIsIm9pZCI6LTkzNjY5OTI0LCJhcGkiOnRydWUsImFwaV93cmFwIjp7Imhhc2giOiIxMDA4MmRjZWJlZGIzMjZkNDQiLCJwaG90byI6IntyZXN1bHR9In0sIm1pZCI6NzY2NDA4ODIsInNlcnZlciI6ODM3NDIxLCJfb3JpZ2luIjoiaHR0cHM6XC9cL2FwaS52ay5jb20iLCJfc2lnIjoiYzZjNWM4ZGVmYmE5YWQ3YWM1ZTYzYTUxMWJjMjgzZDcifQ&_crop=0,0,1590,400"));
		}

		[Test]
		public void GetProfileUploadServer_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.getOwnerPhotoUploadServer";
			ReadCategoryJsonPath(nameof(GetProfileUploadServer_NormalCase));

			var info = Api.Photo.GetOwnerPhotoUploadServer();

			Assert.That(info, Is.Not.Null);

			Assert.That(info.UploadUrl, Is.EqualTo("http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNh"));
		}

		[Test]
		public void SaveOwnerCoverPhoto_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.saveOwnerCoverPhoto";
			ReadCategoryJsonPath(nameof(SaveOwnerCoverPhoto_NormalCase));

			const string response = @"{""photo"":""[]"",""hash"":""163abf8b9e4e4513577012d5275cafbb""}";

			var result = Api.Photo.SaveOwnerCoverPhoto(response);
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

		[Test]
		public void SaveWallPhoto_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.saveWallPhoto";
			ReadCategoryJsonPath(nameof(SaveWallPhoto_NormalCase));

			const string response = @"{""server"":631223,""photo"":""[]"",""hash"":""163abf8b9e4e4513577012d5275cafbb""}";

			var result = Api.Photo.SaveWallPhoto(response, 1234, 123);
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

		[Test]
		public void Search_Error26_Lat_and_Long_in_output_photo()
		{
			Url = "https://api.vk.com/method/photos.search";
			ReadCategoryJsonPath(nameof(Search_Error26_Lat_and_Long_in_output_photo));

			var photos = Api.Photo
				.Search(new PhotoSearchParams
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

		[Test]
		public void Search_NormalCase()
		{
			Url = "https://api.vk.com/method/photos.search";
			ReadCategoryJsonPath(nameof(Search_NormalCase));

			var photos = Api.Photo
				.Search(new PhotoSearchParams
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

			Assert.That(photo.Text,
				Is.EqualTo(
					"🍓 [club49512556|ЗАХОДИ К НАМ]\nчастное фото секси обнаженные девочки малолетки порно голые сиськи попки эротика няша шлюха грудь секс instagirls instagram лето\n#секс #девушки #девочки #instagram #instagirls #няша #InstaSize #лето #ПОПКИ"));

			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1403455788))); //  2014-06-22 20:49:48.000
		}

		[Test]
		public void GetAlbums_Photo_Sizes()
		{
			Url = "https://api.vk.com/method/photos.getAlbums";
			ReadCategoryJsonPath(nameof(GetAlbums_Photo_Sizes));

			long[] albumsids =
			{
				270417281
			};

			var result = Api.Photo.GetAlbums(new PhotoGetAlbumsParams
			{
				AlbumIds = albumsids,
				OwnerId = 504736359,
				NeedSystem = true,
				NeedCovers = true,
				PhotoSizes = true
			});

			Assert.That(result, Is.Not.Null);
			Assert.AreEqual(albumsids[0], result[2].Id);
			Assert.AreEqual("https://sun9-46.userapi.com/c858232/v858232634/16acf0/SNHX0daieLw.jpg",result[2].Sizes.Last().Src.AbsoluteUri);
		}
	}
}