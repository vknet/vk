using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Fave;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class FaveCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Fave";

	[Fact]
	public void GetLinks_NormalCase()
	{
		Url = "https://api.vk.com/method/fave.getLinks";
		ReadCategoryJsonPath(nameof(GetLinks_NormalCase));

		var links = Api.Fave.GetLinks(1, 1);

		links.Should()
			.ContainSingle();

		var link = links.FirstOrDefault();

		link.Should()
			.NotBeNull();

		link.Id.Should()
			.Be("2_32190123_1");

		link.Uri.Should()
			.Be("https://vk.com/apiclub");

		link.Name.Should()
			.Be("ВКонтакте API");

		link.Description.Should()
			.Be("Сообщество");

		link.Photo50.Should()
			.Be("https://pp.vk.me/c400/g00001/e_5ba03323.jpg");

		link.Photo100.Should()
			.Be("https://pp.vk.me/c400/g00001/e_5ba03323.jpg");
	}

	[Fact]
	public void GetMarketItems_AllParams()
	{
		Url = "https://api.vk.com/method/fave.getMarketItems";
		ReadCategoryJsonPath(nameof(GetMarketItems_AllParams));

		var marketItems = Api.Fave.GetMarketItems(1, 0, true);

		marketItems.Should()
			.NotBeNull();

		marketItems.TotalCount.Should()
			.Be(1);

		marketItems.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetMarketItems_count()
	{
		Url = "https://api.vk.com/method/fave.getMarketItems";
		ReadCategoryJsonPath(nameof(GetMarketItems_count));

		var marketItems = Api.Fave.GetMarketItems(1);

		marketItems.Should()
			.NotBeNull();

		marketItems.TotalCount.Should()
			.Be(1);

		marketItems.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetMarketItems_countAndOffset()
	{
		Url = "https://api.vk.com/method/fave.getMarketItems";
		ReadCategoryJsonPath(nameof(GetMarketItems_countAndOffset));

		var marketItems = Api.Fave.GetMarketItems(1, 0);

		marketItems.Should()
			.NotBeNull();

		marketItems.TotalCount.Should()
			.Be(1);

		marketItems.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetMarketItems_WithoutParams()
	{
		Url = "https://api.vk.com/method/fave.getMarketItems";
		ReadCategoryJsonPath(nameof(GetMarketItems_WithoutParams));

		var marketItems = Api.Fave.GetMarketItems();

		marketItems.Should()
			.NotBeNull();

		marketItems.TotalCount.Should()
			.Be(1);

		marketItems.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetPhotos_ExtendedCase()
	{
		Url = "https://api.vk.com/method/fave.getPhotos";
		ReadCategoryJsonPath(nameof(GetPhotos_ExtendedCase));

		var photos = Api.Fave.GetPhotos(3, 1, true);

		photos.Should()
			.NotBeNull();

		photos.Should()
			.ContainSingle();

		var photo = photos.First();

		photo.Id.Should()
			.Be(390044361);

		photo.AlbumId.Should()
			.Be(-7);

		photo.OwnerId.Should()
			.Be(-66589869);

		photo.UserId.Should()
			.Be(100);

		photos[0]
			.Sizes[0]
			.Height.Should()
			.Be(67);

		photos[0]
			.Sizes[0]
			.Url.Should()
			.Be(new Uri("http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg"));

		photos[0]
			.Sizes[0]
			.Width.Should()
			.Be(75);

		photos[0]
			.Sizes[0]
			.Type.Should()
			.Be(PhotoSizeType.S);

		photo.Text.Should()
			.BeEmpty();

		photo.CreateTime.Should()
			.Be(DateHelper.TimeStampToDateTime(1447419206));

		photo.PostId.Should()
			.Be(154560);

		photo.AccessKey.Should()
			.Be("1e2008462f1a012b95");
	}

	[Fact]
	public void GetPhotos_NormalCase()
	{
		Url = "https://api.vk.com/method/fave.getPhotos";
		ReadCategoryJsonPath(nameof(GetPhotos_NormalCase));

		var photos = Api.Fave.GetPhotos(3, 1);

		photos.Should()
			.NotBeNull();

		photos.Should()
			.HaveCount(2);

		var photo = photos.FirstOrDefault();

		photo.Id.Should()
			.Be(263113261);

		photo.AlbumId.Should()
			.Be(136592355);

		photo.OwnerId.Should()
			.Be(1);

		photo.Photo75.Should()
			.Be(new Uri("http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg"));

		photo.Photo130.Should()
			.Be(new Uri("http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg"));

		photo.Photo604.Should()
			.Be(new Uri("http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg"));

		photo.Photo807.Should()
			.Be(new Uri("http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg"));

		photo.Photo1280.Should()
			.Be(new Uri("http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg"));

		photo.Photo2560.Should()
			.Be(new Uri("http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg"));

		photo.Text.Should()
			.BeEmpty();

		photo.CreateTime.Should()
			.Be(DateHelper.TimeStampToDateTime(1307628890));

		var photo2 = photos.Skip(1)
			.FirstOrDefault();

		photo2.Id.Should()
			.Be(319770573);

		photo2.AlbumId.Should()
			.Be(-7);

		photo2.OwnerId.Should()
			.Be(-25397178);

		photo2.UserId.Should()
			.Be(100);

		photo2.Photo75.Should()
			.Be(new Uri("http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg"));

		photo2.Photo130.Should()
			.Be(new Uri("http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg"));

		photo2.Photo604.Should()
			.Be(new Uri("http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg"));

		photo2.Width.Should()
			.Be(604);

		photo2.Height.Should()
			.Be(530);

		photo2.Text.Should()
			.BeEmpty();

		photo2.PostId.Should()
			.Be(88997);

		photo2.CreateTime.Should()
			.Be(DateHelper.TimeStampToDateTime(1390533904));
	}

	[Fact]
	public void GetPosts_Extended()
	{
		Url = "https://api.vk.com/method/fave.getPosts";
		ReadCategoryJsonPath(nameof(GetPosts_Extended));

		var posts = Api.Fave.GetPosts(3, 1);

		posts.TotalCount.Should()
			.Be(2623u);

		var wallPost = posts.WallPosts.FirstOrDefault();

		wallPost.Should()
			.NotBeNull();

		wallPost.Id.Should()
			.Be(1258365);

		wallPost.FromId.Should()
			.Be(-30666517);

		wallPost.OwnerId.Should()
			.Be(-30666517);

		wallPost.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1447668333));

		wallPost.PostType.Should()
			.Be(PostType.Post);

		wallPost.Text.Should()
			.Be(
				@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.");

		wallPost.PostSource.Type.Should()
			.Be(PostSourceType.Vk);

		wallPost.Comments.CanPost.Should()
			.BeTrue();

		wallPost.Comments.Count.Should()
			.Be(9);

		wallPost.Likes.Count.Should()
			.Be(413);

		wallPost.Likes.UserLikes.Should()
			.BeTrue();

		wallPost.Likes.CanLike.Should()
			.BeFalse();

		wallPost.Likes.CanPublish.Should()
			.BeTrue();

		wallPost.Reposts.UserReposted.Should()
			.BeFalse();

		wallPost.Reposts.Count.Should()
			.Be(91);

		wallPost.Attachments.Count.Should()
			.Be(1);

		var video = posts.WallPosts[0]
			.Attachments[0]
			.Instance as Model.Video;

		video.Should()
			.NotBeNull();

		video.Id.Should()
			.Be(171514588);

		video.OwnerId.Should()
			.Be(235845316);

		video.Title.Should()
			.Be("Clean Code: Learn to write clean, maintainable and robust code");

		video.Duration.Should()
			.Be(2058);

		video.Views.Should()
			.Be(1613);

		video.Comments.Should()
			.Be(0);

		video.Photo130.Should()
			.Be(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg"));

		video.Photo320.Should()
			.Be(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg"));

		video.Photo640.Should()
			.Be(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg"));

		video.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1447535648));

		video.AccessKey.Should()
			.Be("733701ff4d7eb85ed7");

		var profile = posts.Profiles.FirstOrDefault();

		profile.Should()
			.NotBeNull();

		profile.Id.Should()
			.Be(235845316);

		profile.FirstName.Should()
			.Be("Лапанильда");

		profile.LastName.Should()
			.Be("Кошкодавленко");

		profile.Sex.Should()
			.Be(Sex.Female);

		profile.ScreenName.Should()
			.Be("deadlymanul");

		profile.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg"));

		profile.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg"));

		profile.Online.Should()
			.BeTrue();

		var group = posts.Groups.FirstOrDefault();

		group.Should()
			.NotBeNull();

		group.Id.Should()
			.Be(30666517);

		group.Name.Should()
			.Be("Типичный программист | tproger");

		group.ScreenName.Should()
			.Be("tproger");

		group.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group.Type.Should()
			.Be(GroupType.Page);

		group.IsAdmin.Should()
			.BeFalse();

		group.IsMember.Should()
			.BeTrue();

		group.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg"));

		group.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg"));

		group.Photo200.Should()
			.Be(new Uri("https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg"));
	}

	[Fact]
	public void GetPosts_NotExtended()
	{
		Url = "https://api.vk.com/method/fave.getPosts";
		ReadCategoryJsonPath(nameof(GetPosts_NotExtended));

		var posts = Api.Fave.GetPosts(3, 1);

		posts.TotalCount.Should()
			.Be(2623u);

		var wallPost = posts.WallPosts.FirstOrDefault();

		wallPost.Id.Should()
			.Be(1258365);

		wallPost.FromId.Should()
			.Be(-30666517);

		wallPost.OwnerId.Should()
			.Be(-30666517);

		wallPost.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1447668333));

		wallPost.PostType.Should()
			.Be(PostType.Post);

		wallPost.Text.Should()
			.Be(
				@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.");

		wallPost.PostSource.Type.Should()
			.Be(PostSourceType.Vk);

		wallPost.Comments.CanPost.Should()
			.BeTrue();

		wallPost.Comments.Count.Should()
			.Be(9);

		wallPost.Likes.Count.Should()
			.Be(413);

		wallPost.Likes.UserLikes.Should()
			.BeTrue();

		wallPost.Likes.CanLike.Should()
			.BeFalse();

		wallPost.Likes.CanPublish.Should()
			.BeTrue();

		wallPost.Reposts.UserReposted.Should()
			.BeFalse();

		wallPost.Reposts.Count.Should()
			.Be(91);

		wallPost.Attachments.Count.Should()
			.Be(1);

		var video = posts.WallPosts[0]
			.Attachments[0]
			.Instance as Model.Video;

		video.Should()
			.NotBeNull();

		video.Id.Should()
			.Be(171514588);

		video.OwnerId.Should()
			.Be(235845316);

		video.Title.Should()
			.Be("Clean Code: Learn to write clean, maintainable and robust code");

		video.Duration.Should()
			.Be(2058);

		video.Views.Should()
			.Be(1613);

		video.Comments.Should()
			.Be(0);

		video.Photo130.Should()
			.Be(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg"));

		video.Photo320.Should()
			.Be(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg"));

		video.Photo640.Should()
			.Be(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg"));

		video.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1447535648));

		video.AccessKey.Should()
			.Be("733701ff4d7eb85ed7");
	}

	[Fact]
	public void GetUsers_OneItem()
	{
		Url = "https://api.vk.com/method/fave.getUsers";
		ReadCategoryJsonPath(nameof(GetUsers_OneItem));

		var users = Api.Fave.GetUsers(3, 1);

		users.Should()
			.NotBeNull();

		users.Should()
			.ContainSingle();

		var user = users.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(1);

		user.FirstName.Should()
			.Be("Павел");

		user.LastName.Should()
			.Be("Дуров");
	}

	[Fact]
	public void GetVideos_NormalCase()
	{
		Url = "https://api.vk.com/method/fave.getVideos";
		ReadCategoryJsonPath(nameof(GetVideos_NormalCase));

		var videos = Api.Fave.GetVideos(3, 1);

		videos.Count.Should()
			.Be(2);

		var video = videos.Videos.FirstOrDefault();

		video.Id.Should()
			.Be(164841344);

		video.OwnerId.Should()
			.Be(1);

		video.Title.Should()
			.Be("This is SPARTA");

		video.Duration.Should()
			.Be(16);

		video.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1366495075));

		video.Views.Should()
			.Be(215502);

		video.Comments.Should()
			.Be(2559);

		video.Photo130.Should()
			.Be(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg"));

		video.Photo320.Should()
			.Be(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg"));
	}
}