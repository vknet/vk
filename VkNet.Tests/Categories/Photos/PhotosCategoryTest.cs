using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Photos;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class PhotosCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Photos";

	[Fact]
	public void CreateAlbum_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.createAlbum";
		ReadCategoryJsonPath(nameof(CreateAlbum_NormalCase));

		var album = Api.Photo
			.CreateAlbum(new()
			{
				Title = "hello world",
				Description = "description for album"
			});

		album.Should()
			.NotBeNull();

		album.Id.Should()
			.Be(11111);

		album.ThumbId.Should()
			.Be(0);

		album.OwnerId.Should()
			.Be(22222);

		album.Title.Should()
			.Be("test");

		album.Description.Should()
			.Be("");

		album.Created.Should()
			.Be(DateHelper.TimeStampToDateTime(1679008006));

		album.Updated.Should()
			.Be(DateHelper.TimeStampToDateTime(1679008006));

		album.PrivacyView.Category
			.Should()
			.Be(Privacy.All);

		album.PrivacyView.Owners.Allowed
			.Should().BeEmpty();

		album.PrivacyComment.Category
			.Should()
			.Be(Privacy.All);

		album.PrivacyComment.Owners.Allowed
			.Should().BeEmpty();

		album.Size.Should()
			.Be(0);
	}

	[Fact]
	public void DeleteAlbum_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.deleteAlbum";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Photo.DeleteAlbum(197303);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void EditAlbum_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.editAlbum";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Photo
			.EditAlbum(new()
			{
				AlbumId = 19726,
				Title = "new album title",
				Description = "new description"
			});

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void GetAlbums_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.getAlbums";
		ReadCategoryJsonPath(nameof(GetAlbums_NormalCase));

		var albums = Api.Photo
			.GetAlbums(new()
			{
				OwnerId = 1
			});

		albums.Should()
			.NotBeNull();

		albums.Should()
			.ContainSingle();

		var album = albums.FirstOrDefault();

		album.Should()
			.NotBeNull();

		album.Id.Should()
			.Be(136592355);

		album.ThumbId.Should()
			.Be(321112194);

		album.OwnerId.Should()
			.Be(1);

		album.Title.Should()
			.Be("Здесь будут новые фотографии для прессы-службы");

		album.Description.Should()
			.BeEmpty();

		album.Created.Should()
			.Be(DateHelper.TimeStampToDateTime(1307628778));

		album.Updated.Should()
			.Be(DateHelper.TimeStampToDateTime(1398625473));

		album.Size.Should()
			.Be(8);
	}

	[Fact]
	public void GetAlbums_PrivacyCase()
	{
		Url = "https://api.vk.com/method/photos.getAlbums";
		ReadCategoryJsonPath(nameof(GetAlbums_PrivacyCase));

		var albums = Api.Photo
			.GetAlbums(new()
			{
				AlbumIds = new List<long>
				{
					110637109
				}
			});

		albums.Should()
			.NotBeNull();

		albums.Should()
			.ContainSingle();

		var album = albums.FirstOrDefault();

		album.Should()
			.NotBeNull();

		album.Id.Should()
			.Be(1111);

		album.ThumbId.Should()
			.Be(0);

		album.OwnerId.Should()
			.Be(5555);

		album.Title.Should()
			.Be("test");

		album.Description.Should()
			.BeEmpty();

		album.Size.Should()
			.Be(0);

		album.ThumbIsLast.Should()
			.BeTrue();

		album.PrivacyView.Owners.Allowed.FirstOrDefault()
			.Should()
			.Be(121);

		album.PrivacyComment.Owners.Allowed.FirstOrDefault()
			.Should()
			.Be(111);
	}

	[Fact]
	public void GetAlbumsCount_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.getAlbumsCount";
		ReadJsonFile(JsonPaths.True);

		var count = Api.Photo.GetAlbumsCount(1);

		count.Should()
			.Be(1);
	}

	[Fact]
	public void GetAll_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.getAll";
		ReadCategoryJsonPath(nameof(GetAll_NormalCase));

		var photos = Api.Photo
			.GetAll(new()
			{
				OwnerId = 1,
				Offset = 4,
				Count = 2
			});

		photos.Should()
			.NotBeNull();

		photos.Should()
			.HaveCount(2);

		var photo = photos.FirstOrDefault();

		photo.Should()
			.NotBeNull();

		photo.Id.Should()
			.Be(328693256);

		photo.AlbumId.Should()
			.Be(-7);

		photo.OwnerId.Should()
			.Be(1);

		photo.Photo75.Should()
			.Be(new Uri("http://cs7004.vk.me/c7006/v7006001/26e37/xOF6D9lY3CU.jpg"));

		photo.Photo130.Should()
			.Be(new Uri("http://cs7004.vk.me/c7006/v7006001/26e38/3atNlPEJpaA.jpg"));

		photo.Photo604.Should()
			.Be(new Uri("http://cs7004.vk.me/c7006/v7006001/26e39/OfHtSC9qtuA.jpg"));

		photo.Photo807.Should()
			.Be(new Uri("http://cs7004.vk.me/c7006/v7006001/26e3a/el6ZcXa9WSc.jpg"));

		photo.Width.Should()
			.Be(609);

		photo.Height.Should()
			.Be(574);

		photo.Text.Should()
			.Be(
				"Сегодня должности раздаются чиновниками, которые боятся конкуренции и подбирают себе все менее талантливых и все более беспомощных подчиненных. Государственные посты должны распределяться на основе прозрачных механизмов, в том числе, прямых выборов.");

		photo.CreateTime.Should()
			.Be(DateHelper.TimeStampToDateTime(1398658327));
	}

	[Fact]
	public void GetMessagesUploadServer_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.getMessagesUploadServer";
		ReadCategoryJsonPath(nameof(GetMessagesUploadServer_NormalCase));

		var info = Api.Photo.GetMessagesUploadServer(123);

		info.Should()
			.NotBeNull();

		info.UploadUrl.Should()
			.Be(
				"http://cs618026.vk.com/upload.php?act=do_add&mid=234695118&aid=-3&gid=0&hash=de2523dd173af592a5dcea351a0ea9e7&rhash=71534021af2730c5b88c05d9ca7c9ed3&swfupload=1&api=1&mailphoto=1");

		info.AlbumId.Should()
			.Be(-3);

		info.UserId.Should()
			.Be(234618);
	}

	[Fact]
	public void GetOwnerCoverPhotoUploadServer_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.getOwnerCoverPhotoUploadServer";
		ReadCategoryJsonPath(nameof(GetOwnerCoverPhotoUploadServer_NormalCase));

		var info = Api.Photo.GetOwnerCoverPhotoUploadServer(1L);

		info.Should()
			.NotBeNull();

		info.UploadUrl.Should()
			.Be(
				"http://pu.vk.com/c837421/upload.php?_query=eyJhY3QiOiJvd25lcl9jb3ZlciIsIm9pZCI6LTkzNjY5OTI0LCJhcGkiOnRydWUsImFwaV93cmFwIjp7Imhhc2giOiIxMDA4MmRjZWJlZGIzMjZkNDQiLCJwaG90byI6IntyZXN1bHR9In0sIm1pZCI6NzY2NDA4ODIsInNlcnZlciI6ODM3NDIxLCJfb3JpZ2luIjoiaHR0cHM6XC9cL2FwaS52ay5jb20iLCJfc2lnIjoiYzZjNWM4ZGVmYmE5YWQ3YWM1ZTYzYTUxMWJjMjgzZDcifQ&_crop=0,0,1590,400");
	}

	[Fact]
	public void GetProfileUploadServer_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.getOwnerPhotoUploadServer";
		ReadCategoryJsonPath(nameof(GetProfileUploadServer_NormalCase));

		var info = Api.Photo.GetOwnerPhotoUploadServer();

		info.Should()
			.NotBeNull();

		info.UploadUrl.Should()
			.Be("http://cs618026.vk.com/upload.php?_query=eyJhY3QiOiJvd25lcl9waG90byIsInNh");
	}

	[Fact]
	public void SaveOwnerCoverPhoto_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.saveOwnerCoverPhoto";
		ReadCategoryJsonPath(nameof(SaveOwnerCoverPhoto_NormalCase));

		const string response = @"{""photo"":""[]"",""hash"":""163abf8b9e4e4513577012d5275cafbb""}";

		var result = Api.Photo.SaveOwnerCoverPhoto(response);

		result.Should()
			.NotBeNull();

		var images = result.Images;

		images.Should()
			.NotBeNull();

		images.Should()
			.HaveCount(5);

		var image = images.ElementAt(0);

		image.Should()
			.NotBeNull();

		image.Url.Should()
			.Be(new Uri("https://cs7052.userapi.com/c837421/v837421774/52897/3TEjTwhK2uw.jpg"));

		image.Width.Should()
			.Be(200);

		image.Height.Should()
			.Be(50);

		image = images.ElementAt(1);

		image.Should()
			.NotBeNull();

		image.Url.Should()
			.Be(new Uri("https://cs7052.userapi.com/c837421/v837421774/52896/M57KWzVv6zE.jpg"));

		image.Width.Should()
			.Be(400);

		image.Height.Should()
			.Be(101);

		image = images.ElementAt(2);

		image.Should()
			.NotBeNull();

		image.Url.Should()
			.Be(new Uri("https://cs7052.userapi.com/c837421/v837421774/52893/yHkTW6fmR68.jpg"));

		image.Width.Should()
			.Be(795);

		image.Height.Should()
			.Be(200);

		image = images.ElementAt(3);

		image.Should()
			.NotBeNull();

		image.Url.Should()
			.Be(new Uri("https://cs7052.userapi.com/c837421/v837421774/52895/D6rhfBrxGow.jpg"));

		image.Width.Should()
			.Be(1080);

		image.Height.Should()
			.Be(272);

		image = images.ElementAt(4);

		image.Should()
			.NotBeNull();

		image.Url.Should()
			.Be(new Uri("https://cs7052.userapi.com/c837421/v837421774/52894/fEmF9i76g5w.jpg"));

		image.Width.Should()
			.Be(1590);

		image.Height.Should()
			.Be(400);
	}

	[Fact]
	public void SaveWallPhoto_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.saveWallPhoto";
		ReadCategoryJsonPath(nameof(SaveWallPhoto_NormalCase));

		const string response = @"{""server"":631223,""photo"":""[]"",""hash"":""163abf8b9e4e4513577012d5275cafbb""}";

		var result = Api.Photo.SaveWallPhoto(response, 1234, 123);

		result.Should()
			.NotBeNull();

		result.Should()
			.ContainSingle();

		var photo = result[0];

		photo.Should()
			.NotBeNull();

		photo.Id.Should()
			.Be(3446123);

		photo.AlbumId.Should()
			.Be(-12);

		photo.OwnerId.Should()
			.Be(234695890);

		photo.Photo75.Should()
			.Be(new Uri("http://cs7004.vk.me/c625725/v625725118/8c39/XZJpyifpfkM.jpg"));

		photo.Photo130.Should()
			.Be(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3a/cYyzeNiQCwg.jpg"));

		photo.Photo604.Should()
			.Be(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3b/b9rHdTFfLuw.jpg"));

		photo.Photo807.Should()
			.Be(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3c/POYM67dCGZg.jpg"));

		photo.Photo1280.Should()
			.Be(new Uri("http://cs7004.vk.me/c625725/v625725118/8c3d/OWWWGO1gkOI.jpg"));

		photo.Width.Should()
			.Be(1256);

		photo.Height.Should()
			.Be(320);

		photo.Text.Should()
			.BeEmpty();

		photo.CreateTime.Should()
			.Be(DateHelper.TimeStampToDateTime(1415629651));
	}

	[Fact]
	public void Search_Error26_Lat_and_Long_in_output_photo()
	{
		Url = "https://api.vk.com/method/photos.search";
		ReadCategoryJsonPath(nameof(Search_Error26_Lat_and_Long_in_output_photo));

		var photos = Api.Photo
			.Search(new()
			{
				Query = "",
				Latitude = 30,
				Longitude = 30,
				Count = 2
			});

		photos.Should()
			.NotBeNull();

		photos.Should()
			.HaveCount(2);

		var photo = photos.FirstOrDefault();

		photo.Should()
			.NotBeNull();

		photo.Latitude.Should()
			.Be(29.999996);

		photo.Longitude.Should()
			.Be(29.999997);

		var photo1 = photos.Skip(1)
			.FirstOrDefault();

		photo1.Should()
			.NotBeNull();

		photo1.Latitude.Should()
			.Be(29.942251);

		photo1.Longitude.Should()
			.Be(29.882819);
	}

	[Fact]
	public void Search_NormalCase()
	{
		Url = "https://api.vk.com/method/photos.search";
		ReadCategoryJsonPath(nameof(Search_NormalCase));

		var photos = Api.Photo
			.Search(new()
			{
				Query = "порно",
				Offset = 2,
				Count = 3
			});

		photos.Should()
			.NotBeNull();

		photos.Should()
			.HaveCount(3);

		var photo = photos.FirstOrDefault();

		photo.Should()
			.NotBeNull();

		photo.Id.Should()
			.Be(331520481);

		photo.AlbumId.Should()
			.Be(182104020);

		photo.OwnerId.Should()
			.Be(-49512556);

		photo.UserId.Should()
			.Be(100);

		photo.Photo75.Should()
			.Be(new Uri("http://cs620223.vk.me/v620223385/bd1f/SajcsJOh7hk.jpg"));

		photo.Photo130.Should()
			.Be(new Uri("http://cs620223.vk.me/v620223385/bd20/85-Qkc4oNH8.jpg"));

		photo.Photo604.Should()
			.Be(new Uri("http://cs620223.vk.me/v620223385/bd21/88vFsC-Z_FE.jpg"));

		photo.Photo807.Should()
			.Be(new Uri("http://cs620223.vk.me/v620223385/bd22/YqRauv0neMY.jpg"));

		photo.Width.Should()
			.Be(807);

		photo.Height.Should()
			.Be(515);

		photo.Text.Should()
			.Be(
				"🍓 [club49512556|ЗАХОДИ К НАМ]\nчастное фото секси обнаженные девочки малолетки порно голые сиськи попки эротика няша шлюха грудь секс instagirls instagram лето\n#секс #девушки #девочки #instagram #instagirls #няша #InstaSize #лето #ПОПКИ");

		photo.CreateTime.Should()
			.Be(DateHelper.TimeStampToDateTime(1403455788)); //  2014-06-22 20:49:48.000
	}

	[Fact]
	public void GetAlbums_Photo_Sizes()
	{
		Url = "https://api.vk.com/method/photos.getAlbums";
		ReadCategoryJsonPath(nameof(GetAlbums_Photo_Sizes));

		long[] albumsids =
		{
			270417281
		};

		var result = Api.Photo.GetAlbums(new()
		{
			AlbumIds = albumsids,
			OwnerId = 504736359,
			NeedSystem = true,
			NeedCovers = true,
			PhotoSizes = true
		});

		result.Should()
			.NotBeNull();

		result[2]
			.Id.Should()
			.Be(270417281);

		result[2]
			.Sizes.Last()
			.Src.AbsoluteUri.Should()
			.Be("https://sun9-46.userapi.com/c858232/v858232634/16acf0/SNHX0daieLw.jpg");
	}
}