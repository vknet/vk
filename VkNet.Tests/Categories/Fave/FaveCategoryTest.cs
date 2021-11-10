using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Fave
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]

	public class FaveCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Fave";

		[Test]
		public void GetLinks_NormalCase()
		{
			Url = "https://api.vk.com/method/fave.getLinks";
			ReadCategoryJsonPath(nameof(GetLinks_NormalCase));

			var links = Api.Fave.GetLinks(1, 1);

			Assert.That(links.Count, Is.EqualTo(1));
			var link = links.FirstOrDefault();
			Assert.That(link, Is.Not.Null);
			Assert.That(link.Id, Is.EqualTo("2_32190123_1"));
			Assert.That(link.Uri, Is.EqualTo("https://vk.com/apiclub"));
			Assert.That(link.Name, Is.EqualTo("ВКонтакте API"));
			Assert.That(link.Description, Is.EqualTo("Сообщество"));
			Assert.That(link.Photo50, Is.EqualTo("https://pp.vk.me/c400/g00001/e_5ba03323.jpg"));
			Assert.That(link.Photo100, Is.EqualTo("https://pp.vk.me/c400/g00001/e_5ba03323.jpg"));
		}

		[Test]
		public void GetMarketItems_AllParams()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";
			ReadCategoryJsonPath(nameof(GetMarketItems_AllParams));

			var marketItems = Api.Fave.GetMarketItems(1, 0, true);

			marketItems.Should().NotBeNull();
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetMarketItems_count()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";
			ReadCategoryJsonPath(nameof(GetMarketItems_count));

			var marketItems = Api.Fave.GetMarketItems(1);

			marketItems.Should().NotBeNull();
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetMarketItems_countAndOffset()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";
			ReadCategoryJsonPath(nameof(GetMarketItems_countAndOffset));

			var marketItems = Api.Fave.GetMarketItems(1, 0);

			marketItems.Should().NotBeNull();
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetMarketItems_WithoutParams()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";
			ReadCategoryJsonPath(nameof(GetMarketItems_WithoutParams));

			var marketItems = Api.Fave.GetMarketItems();

			marketItems.Should().NotBeNull();
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetPhotos_ExtendedCase()
		{
			Url = "https://api.vk.com/method/fave.getPhotos";
			ReadCategoryJsonPath(nameof(GetPhotos_ExtendedCase));

			var photos = Api.Fave.GetPhotos(3, 1, true);

			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(1));
			var photo = photos.First();

			Assert.That(photo.Id, Is.EqualTo(390044361));
			Assert.That(photo.AlbumId, Is.EqualTo(-7));
			Assert.That(photo.OwnerId, Is.EqualTo(-66589869));
			Assert.That(photo.UserId, Is.EqualTo(100));
			Assert.That(photos[0].Sizes[0].Height, Is.EqualTo(67));

			Assert.That(photos[0].Sizes[0].Url,
				Is.EqualTo(new Uri("http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg")));

			Assert.That(photos[0].Sizes[0].Width, Is.EqualTo(75));
			Assert.That(photos[0].Sizes[0].Type, Is.EqualTo(PhotoSizeType.S));
			Assert.That(photo.Text, Is.EqualTo(""));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1447419206)));
			Assert.That(photo.PostId, Is.EqualTo(154560));
			Assert.That(photo.AccessKey, Is.EqualTo("1e2008462f1a012b95"));
		}

		[Test]
		public void GetPhotos_NormalCase()
		{
			Url = "https://api.vk.com/method/fave.getPhotos";
			ReadCategoryJsonPath(nameof(GetPhotos_NormalCase));

			var photos = Api.Fave.GetPhotos(3, 1);

			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(2));
			var photo = photos.FirstOrDefault();

			Assert.That(photo.Id, Is.EqualTo(263113261));
			Assert.That(photo.AlbumId, Is.EqualTo(136592355));
			Assert.That(photo.OwnerId, Is.EqualTo(1));

			Assert.That(photo.Photo75,
				Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg")));

			Assert.That(photo.Photo130,
				Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg")));

			Assert.That(photo.Photo604,
				Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg")));

			Assert.That(photo.Photo807,
				Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg")));

			Assert.That(photo.Photo1280,
				Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg")));

			Assert.That(photo.Photo2560,
				Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg")));

			Assert.That(photo.Text, Is.EqualTo(""));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1307628890)));

			var photo2 = photos.Skip(1).FirstOrDefault();
			Assert.That(photo2.Id, Is.EqualTo(319770573));
			Assert.That(photo2.AlbumId, Is.EqualTo(-7));
			Assert.That(photo2.OwnerId, Is.EqualTo(-25397178));
			Assert.That(photo2.UserId, Is.EqualTo(100));

			Assert.That(photo2.Photo75,
				Is.EqualTo(new Uri("http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg")));

			Assert.That(photo2.Photo130,
				Is.EqualTo(new Uri("http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg")));

			Assert.That(photo2.Photo604,
				Is.EqualTo(new Uri("http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg")));

			Assert.That(photo2.Width, Is.EqualTo(604));
			Assert.That(photo2.Height, Is.EqualTo(530));
			Assert.That(photo2.Text, Is.EqualTo(""));
			Assert.That(photo2.PostId, Is.EqualTo(88997));
			Assert.That(photo2.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1390533904)));
		}

		[Test]
		public void GetPosts_Extended()
		{
			Url = "https://api.vk.com/method/fave.getPosts";
			ReadCategoryJsonPath(nameof(GetPosts_Extended));

			var posts = Api.Fave.GetPosts(3, 1);

			Assert.That(posts.TotalCount, Is.EqualTo(2623u));

			var wallPost = posts.WallPosts.FirstOrDefault();
			Assert.That(wallPost, Is.Not.Null);
			Assert.That(wallPost.Id, Is.EqualTo(1258365));
			Assert.That(wallPost.FromId, Is.EqualTo(-30666517));
			Assert.That(wallPost.OwnerId, Is.EqualTo(-30666517));
			Assert.That(wallPost.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447668333)));
			Assert.That(wallPost.PostType, Is.EqualTo(PostType.Post));

			Assert.That(wallPost.Text,
				Is.EqualTo(
					@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально."));

			Assert.That(wallPost.PostSource.Type, Is.EqualTo(PostSourceType.Vk));
			Assert.That(wallPost.Comments.CanPost, Is.EqualTo(true));
			Assert.That(wallPost.Comments.Count, Is.EqualTo(9));
			Assert.That(wallPost.Likes.Count, Is.EqualTo(413));
			Assert.That(wallPost.Likes.UserLikes, Is.EqualTo(true));
			Assert.That(wallPost.Likes.CanLike, Is.EqualTo(false));
			Assert.That(wallPost.Likes.CanPublish, Is.EqualTo(true));
			Assert.That(wallPost.Reposts.UserReposted, Is.EqualTo(false));
			Assert.That(wallPost.Reposts.Count, Is.EqualTo(91));
			Assert.That(wallPost.Attachments.Count, Is.EqualTo(1));

			var video = posts.WallPosts[0].Attachments[0].Instance as Model.Attachments.Video;
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(171514588));
			Assert.That(video.OwnerId, Is.EqualTo(235845316));

			Assert.That(video.Title,
				Is.EqualTo("Clean Code: Learn to write clean, maintainable and robust code"));

			Assert.That(video.Duration, Is.EqualTo(2058));
			Assert.That(video.Views, Is.EqualTo(1613));
			Assert.That(video.Comments, Is.EqualTo(0));

			Assert.That(video.Photo130,
				Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg")));

			Assert.That(video.Photo320,
				Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg")));

			Assert.That(video.Photo640,
				Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg")));

			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447535648)));
			Assert.That(video.AccessKey, Is.EqualTo("733701ff4d7eb85ed7"));

			var profile = posts.Profiles.FirstOrDefault();
			Assert.That(profile, Is.Not.Null);
			Assert.That(profile.Id, Is.EqualTo(235845316));
			Assert.That(profile.FirstName, Is.EqualTo("Лапанильда"));
			Assert.That(profile.LastName, Is.EqualTo("Кошкодавленко"));
			Assert.That(profile.Sex, Is.EqualTo(Sex.Female));
			Assert.That(profile.ScreenName, Is.EqualTo("deadlymanul"));

			Assert.That(profile.PhotoPreviews.Photo50,
				Is.EqualTo(new Uri("https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg")));

			Assert.That(profile.PhotoPreviews.Photo100,
				Is.EqualTo(new Uri("https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg")));

			Assert.That(profile.Online, Is.EqualTo(true));

			var group = posts.Groups.FirstOrDefault();
			Assert.That(group, Is.Not.Null);
			Assert.That(group.Id, Is.EqualTo(30666517));
			Assert.That(group.Name, Is.EqualTo("Типичный программист | tproger"));
			Assert.That(group.ScreenName, Is.EqualTo("tproger"));
			Assert.That(group.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group.Type, Is.EqualTo(GroupType.Page));
			Assert.That(group.IsAdmin, Is.EqualTo(false));
			Assert.That(group.IsMember, Is.EqualTo(true));

			Assert.That(group.PhotoPreviews.Photo50,
				Is.EqualTo(new Uri("https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg")));

			Assert.That(group.PhotoPreviews.Photo100,
				Is.EqualTo(new Uri("https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg")));

			Assert.That(group.PhotoPreviews.Photo200,
				Is.EqualTo(new Uri("https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg")));
		}

		[Test]
		public void GetPosts_NotExtended()
		{
			Url = "https://api.vk.com/method/fave.getPosts";
			ReadCategoryJsonPath(nameof(GetPosts_NotExtended));

			var posts = Api.Fave.GetPosts(3, 1);

			Assert.That(posts.TotalCount, Is.EqualTo(2623u));

			var wallPost = posts.WallPosts.FirstOrDefault();

			Assert.That(wallPost.Id, Is.EqualTo(1258365));
			Assert.That(wallPost.FromId, Is.EqualTo(-30666517));
			Assert.That(wallPost.OwnerId, Is.EqualTo(-30666517));
			Assert.That(wallPost.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447668333)));
			Assert.That(wallPost.PostType, Is.EqualTo(PostType.Post));

			Assert.That(wallPost.Text,
				Is.EqualTo(
					@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально."));

			Assert.That(wallPost.PostSource.Type, Is.EqualTo(PostSourceType.Vk));
			Assert.That(wallPost.Comments.CanPost, Is.EqualTo(true));
			Assert.That(wallPost.Comments.Count, Is.EqualTo(9));
			Assert.That(wallPost.Likes.Count, Is.EqualTo(413));
			Assert.That(wallPost.Likes.UserLikes, Is.EqualTo(true));
			Assert.That(wallPost.Likes.CanLike, Is.EqualTo(false));
			Assert.That(wallPost.Likes.CanPublish, Is.EqualTo(true));
			Assert.That(wallPost.Reposts.UserReposted, Is.EqualTo(false));
			Assert.That(wallPost.Reposts.Count, Is.EqualTo(91));
			Assert.That(wallPost.Attachments.Count, Is.EqualTo(1));

			var video = posts.WallPosts[0].Attachments[0].Instance as Model.Attachments.Video;
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(171514588));
			Assert.That(video.OwnerId, Is.EqualTo(235845316));

			Assert.That(video.Title,
				Is.EqualTo("Clean Code: Learn to write clean, maintainable and robust code"));

			Assert.That(video.Duration, Is.EqualTo(2058));
			Assert.That(video.Views, Is.EqualTo(1613));
			Assert.That(video.Comments, Is.EqualTo(0));

			Assert.That(video.Photo130,
				Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg")));

			Assert.That(video.Photo320,
				Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg")));

			Assert.That(video.Photo640,
				Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg")));

			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447535648)));
			Assert.That(video.AccessKey, Is.EqualTo("733701ff4d7eb85ed7"));
		}

		[Test]
		public void GetUsers_OneItem()
		{
			Url = "https://api.vk.com/method/fave.getUsers";
			ReadCategoryJsonPath(nameof(GetUsers_OneItem));

			var users = Api.Fave.GetUsers(3, 1);

			Assert.That(users, Is.Not.Null);
			Assert.That(users.Count, Is.EqualTo(1));
			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Id, Is.EqualTo(1));
			Assert.That(user.FirstName, Is.EqualTo("Павел"));
			Assert.That(user.LastName, Is.EqualTo("Дуров"));
		}

		[Test]
		public void GetVideos_NormalCase()
		{
			Url = "https://api.vk.com/method/fave.getVideos";
			ReadCategoryJsonPath(nameof(GetVideos_NormalCase));

			var videos = Api.Fave.GetVideos(3, 1);

			Assert.That(videos.Count, Is.EqualTo(2));
			var video = videos.Videos.FirstOrDefault();
			Assert.That(video.Id, Is.EqualTo(164841344));
			Assert.That(video.OwnerId, Is.EqualTo(1));
			Assert.That(video.Title, Is.EqualTo("This is SPARTA"));
			Assert.That(video.Duration, Is.EqualTo(16));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1366495075)));
			Assert.That(video.Views, Is.EqualTo(215502));
			Assert.That(video.Comments, Is.EqualTo(2559));

			Assert.That(video.Photo130,
				Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));

			Assert.That(video.Photo320,
				Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));
		}
	}
}