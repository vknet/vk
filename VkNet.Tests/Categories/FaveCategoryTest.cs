using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Policy;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Categories
{
	using NUnit.Framework;
	using VkNet.Categories;


	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class FaveCategoryTest : BaseTest
	{
		private FaveCategory GetMockedFaveCategory(string url, string json)
		{
            Json = json;
            Url = url;
            return new FaveCategory(Api);
		}

		[Test]
		public void GetUsers_OneItem()
		{
			const string url = "https://api.vk.com/method/fave.getUsers?count=3&offset=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
			@"{
					'response': {
					  'count': 2,
					  'items': [
						{
						  'id': 1,
						  'first_name': 'Павел',
						  'last_name': 'Дуров'
						}
					  ]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var users = cat.GetUsers(3, 1);
			Assert.That(users, Is.Not.Null);
			Assert.That(users.Count, Is.EqualTo(1));
			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Id, Is.EqualTo(1));
			Assert.That(user.FirstName, Is.EqualTo("Павел"));
			Assert.That(user.LastName, Is.EqualTo("Дуров"));
		}

		[Test]
		public void GetPhotos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos?count=3&offset=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
			@"{
					'response': {
					  'count': 3,
					  'items': [
						{
						  'id': 263113261,
						  'album_id': 136592355,
						  'owner_id': 1,
						  'photo_75': 'http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg',
						  'photo_130': 'http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg',
						  'photo_604': 'http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg',
						  'photo_807': 'http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg',
						  'photo_1280': 'http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg',
						  'photo_2560': 'http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg',
						  'text': '',
						  'date': 1307628890
						},
						{
						  'id': 319770573,
						  'album_id': -7,
						  'owner_id': -25397178,
						  'user_id': 100,
						  'photo_75': 'http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg',
						  'photo_130': 'http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg',
						  'photo_604': 'http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg',
						  'width': 604,
						  'height': 530,
						  'text': '',
						  'date': 1390533904,
						  'post_id': 88997
						}
					  ]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var photos = cat.GetPhotos(3, 1);
			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(2));
			var photo = photos.FirstOrDefault();

			Assert.That(photo.Id, Is.EqualTo(263113261));
			Assert.That(photo.AlbumId, Is.EqualTo(136592355));
			Assert.That(photo.OwnerId, Is.EqualTo(1));
			Assert.That(photo.Photo75, Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg")));
			Assert.That(photo.Photo130, Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg")));
			Assert.That(photo.Photo604, Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg")));
			Assert.That(photo.Photo807, Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg")));
			Assert.That(photo.Photo1280, Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg")));
			Assert.That(photo.Photo2560, Is.EqualTo(new Uri("http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg")));
			Assert.That(photo.Text, Is.EqualTo(""));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1307628890)));

			var photo2 = photos.Skip(1).FirstOrDefault();
			Assert.That(photo2.Id, Is.EqualTo(319770573));
			Assert.That(photo2.AlbumId, Is.EqualTo(-7));
			Assert.That(photo2.OwnerId, Is.EqualTo(-25397178));
			Assert.That(photo2.UserId, Is.EqualTo(100));
			Assert.That(photo2.Photo75, Is.EqualTo(new Uri("http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg")));
			Assert.That(photo2.Photo130, Is.EqualTo(new Uri("http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg")));
			Assert.That(photo2.Photo604, Is.EqualTo(new Uri("http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg")));
			Assert.That(photo2.Width, Is.EqualTo(604));
			Assert.That(photo2.Height, Is.EqualTo(530));
			Assert.That(photo2.Text, Is.EqualTo(""));
			Assert.That(photo2.PostId, Is.EqualTo(88997));
			Assert.That(photo2.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1390533904)));
		}

		[Test]
		public void GetPhotos_ExtendedCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos?count=3&offset=1&photo_sizes=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
			@"{
				response: {
					count: 1061,
					items: [{
						id: 390044361,
						album_id: -7,
						owner_id: -66589869,
						user_id: 100,
						sizes: [{
							src: 'http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg',
							width: 75,
							height: 67,
							type: 's'
							}, {
							src: 'http://cs629301.v...ab0/khhRkq0uhoo.jpg',
							width: 130,
							height: 116,
							type: 'm'
							}, {
							src: 'http://cs629301.v...ab1/cNehIdjHNXg.jpg',
							width: 604,
							height: 537,
							type: 'x'
							}, {
							src: 'http://cs629301.v...ab2/reFF7eJG23U.jpg',
							width: 130,
							height: 116,
							type: 'o'
							}, {
							src: 'http://cs629301.v...ab3/6YYP7c34Vp4.jpg',
							width: 200,
							height: 178,
							type: 'p'
							}, {
							src: 'http://cs629301.v...ab4/I3fCEQCPuec.jpg',
							width: 320,
							height: 285,
							type: 'q'
							}, {
							src: 'http://cs629301.v...ab5/VtX_ZADIFXg.jpg',
							width: 510,
							height: 453,
							type: 'r'
						}],
						text: '',
						date: 1447419206,
						post_id: 154560,
						access_key: '1e2008462f1a012b95'
					}]
					}
			}";

			var cat = GetMockedFaveCategory(url, json);

			var photos = cat.GetPhotos(3, 1, true);
			Assert.That(photos, Is.Not.Null);
			Assert.That(photos.Count, Is.EqualTo(1));
			var photo = photos.FirstOrDefault();

			Assert.That(photo.Id, Is.EqualTo(390044361));
			Assert.That(photo.AlbumId, Is.EqualTo(-7));
			Assert.That(photo.OwnerId, Is.EqualTo(-66589869));
			Assert.That(photo.UserId, Is.EqualTo(100));
			Assert.That(photos[0].Sizes[0].Height, Is.EqualTo(67));
			Assert.That(photos[0].Sizes[0].Src, Is.EqualTo(new Url("http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg")));
			Assert.That(photos[0].Sizes[0].Width, Is.EqualTo(75));
			Assert.That(photos[0].Sizes[0].Type, Is.EqualTo(PhotoSizeType.S));
			Assert.That(photo.Text, Is.EqualTo(""));
			Assert.That(photo.CreateTime, Is.EqualTo(DateHelper.TimeStampToDateTime(1447419206)));
			Assert.That(photo.PostId, Is.EqualTo(154560));
			Assert.That(photo.AccessKey, Is.EqualTo("1e2008462f1a012b95"));
		}

		[Test]
		public void GetVideos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getVideos?count=3&offset=1&extended=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
			@"{
					'response': {
					  'count': 2,
					  'items': [
						{
						  'id': 164841344,
						  'owner_id': 1,
						  'title': 'This is SPARTA',
						  'duration': 16,
						  'description': '',
						  'date': 1366495075,
						  'views': 215502,
						  'comments': 2559,
						  'photo_130': 'http://cs12761.vk.me/u5705167/video/s_df53315c.jpg',
						  'photo_320': 'http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg'
						}
					  ]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var videos = cat.GetVideos(3, 1);
			Assert.That(videos.Count, Is.EqualTo(1));
			var video = videos.FirstOrDefault();
			Assert.That(video.Id, Is.EqualTo(164841344));
			Assert.That(video.OwnerId, Is.EqualTo(1));
			Assert.That(video.Title, Is.EqualTo("This is SPARTA"));
			Assert.That(video.Duration, Is.EqualTo(16));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1366495075)));
			Assert.That(video.ViewsCount, Is.EqualTo(215502));
			Assert.That(video.CommentsCount, Is.EqualTo(2559));
			Assert.That(video.Photo130, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));
			Assert.That(video.Photo320, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));
		}

		[Test]
		public void GetPosts_NotExtended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts?count=3&offset=1&extended=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
			@"{
					response: {
						count: 2623,
						items: [{
							id: 1258365,
							from_id: -30666517,
							owner_id: -30666517,
							date: 1447668333,
							post_type: 'post',
							text: 'Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.',
							attachments: [{
								type: 'video',
								video: {
									id: 171514588,
									owner_id: 235845316,
									title: 'Clean Code: Learn to write clean, maintainable and robust code',
									duration: 2058,
									description: 'Clean Code: Learn to write clean, maintainable and robust code.

									In this video, I take a poorly-written piece of code and refactor in a step-by-step fashion. I also teach you some productivity tips along the way that helps you write code fast with Visual Studio.

									If you enjoy my teaching style and want to learn more from me, check out my courses on Udemy:

									C# Intermediate: Classes, Interfaces and Object-oriented Programming

									https://www.udemy.com/csharp-intermediate-classes-interfaces-and-oop/?couponCode=',
									date: 1447535648,
									views: 1613,
									comments: 0,
									photo_130: 'https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg',
									photo_320: 'https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg',
									photo_800: 'https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg',
									photo_640: 'https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg',
									access_key: '733701ff4d7eb85ed7'
								}
							}],
							post_source: {
								type: 'vk'
							},
							comments: {
								count: 9,
								can_post: 1
							},
							likes: {
								count: 413,
								user_likes: 1,
								can_like: 0,
								can_publish: 1
							},
							reposts: {
								count: 91,
								user_reposted: 0
							}
						}],
						profiles: [{
							id: 235845316,
							first_name: 'Лапанильда',
							last_name: 'Кошкодавленко',
							sex: 1,
							screen_name: 'deadlymanul',
							photo_50: 'https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg',
							photo_100: 'https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg',
							online: 1
						}],
						groups: [{
							id: 30666517,
							name: 'Типичный программист | tproger',
							screen_name: 'tproger',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 1,
							photo_50: 'https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg',
							photo_100: 'https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg',
							photo_200: 'https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg'
						}]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var posts = cat.GetPostsEx(3, 1);

			Assert.That(posts.TotalCount, Is.EqualTo(2623u));

			var wallPost = posts.WallPosts.FirstOrDefault();

			Assert.That(wallPost.Id, Is.EqualTo(1258365));
			Assert.That(wallPost.FromId, Is.EqualTo(-30666517));
			Assert.That(wallPost.OwnerId, Is.EqualTo(-30666517));
			Assert.That(wallPost.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447668333)));
			Assert.That(wallPost.PostType, Is.EqualTo(PostType.Post));
			Assert.That(wallPost.Text, Is.EqualTo(@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально."));
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

			var video = posts.WallPosts[0].Attachments[0].Instance as Video;
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(171514588));
			Assert.That(video.OwnerId, Is.EqualTo(235845316));
			Assert.That(video.Title, Is.EqualTo("Clean Code: Learn to write clean, maintainable and robust code"));
			Assert.That(video.Duration, Is.EqualTo(2058));
			Assert.That(video.ViewsCount, Is.EqualTo(1613));
			Assert.That(video.CommentsCount, Is.EqualTo(0));
			Assert.That(video.Photo130, Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg")));
			Assert.That(video.Photo320, Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg")));
			Assert.That(video.Photo640, Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg")));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447535648)));
			Assert.That(video.AccessKey, Is.EqualTo("733701ff4d7eb85ed7"));
		}

		[Test]
		public void GetPosts_Extended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts?count=3&offset=1&extended=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
			@"{
					response: {
						count: 2623,
						items: [{
							id: 1258365,
							from_id: -30666517,
							owner_id: -30666517,
							date: 1447668333,
							post_type: 'post',
							text: 'Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.',
							attachments: [{
								type: 'video',
								video: {
									id: 171514588,
									owner_id: 235845316,
									title: 'Clean Code: Learn to write clean, maintainable and robust code',
									duration: 2058,
									description: 'Clean Code: Learn to write clean, maintainable and robust code.

									In this video, I take a poorly-written piece of code and refactor in a step-by-step fashion. I also teach you some productivity tips along the way that helps you write code fast with Visual Studio.

									If you enjoy my teaching style and want to learn more from me, check out my courses on Udemy:

									C# Intermediate: Classes, Interfaces and Object-oriented Programming

									https://www.udemy.com/csharp-intermediate-classes-interfaces-and-oop/?couponCode=',
									date: 1447535648,
									views: 1613,
									comments: 0,
									photo_130: 'https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg',
									photo_320: 'https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg',
									photo_800: 'https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg',
									photo_640: 'https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg',
									access_key: '733701ff4d7eb85ed7'
								}
							}],
							post_source: {
								type: 'vk'
							},
							comments: {
								count: 9,
								can_post: 1
							},
							likes: {
								count: 413,
								user_likes: 1,
								can_like: 0,
								can_publish: 1
							},
							reposts: {
								count: 91,
								user_reposted: 0
							}
						}],
						profiles: [{
							id: 235845316,
							first_name: 'Лапанильда',
							last_name: 'Кошкодавленко',
							sex: 1,
							screen_name: 'deadlymanul',
							photo_50: 'https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg',
							photo_100: 'https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg',
							online: 1
						}],
						groups: [{
							id: 30666517,
							name: 'Типичный программист | tproger',
							screen_name: 'tproger',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 1,
							photo_50: 'https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg',
							photo_100: 'https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg',
							photo_200: 'https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg'
						}]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var posts = cat.GetPostsEx(3, 1);

			Assert.That(posts.TotalCount, Is.EqualTo(2623u));

			var wallPost = posts.WallPosts.FirstOrDefault();
			Assert.That(wallPost, Is.Not.Null);
			Assert.That(wallPost.Id, Is.EqualTo(1258365));
			Assert.That(wallPost.FromId, Is.EqualTo(-30666517));
			Assert.That(wallPost.OwnerId, Is.EqualTo(-30666517));
			Assert.That(wallPost.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447668333)));
			Assert.That(wallPost.PostType, Is.EqualTo(PostType.Post));
			Assert.That(wallPost.Text, Is.EqualTo(@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально."));
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

			var video = posts.WallPosts[0].Attachments[0].Instance as Video;
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(171514588));
			Assert.That(video.OwnerId, Is.EqualTo(235845316));
			Assert.That(video.Title, Is.EqualTo("Clean Code: Learn to write clean, maintainable and robust code"));
			Assert.That(video.Duration, Is.EqualTo(2058));
			Assert.That(video.ViewsCount, Is.EqualTo(1613));
			Assert.That(video.CommentsCount, Is.EqualTo(0));
			Assert.That(video.Photo130, Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg")));
			Assert.That(video.Photo320, Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg")));
			Assert.That(video.Photo640, Is.EqualTo(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg")));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447535648)));
			Assert.That(video.AccessKey, Is.EqualTo("733701ff4d7eb85ed7"));

			var profile = posts.Profiles.FirstOrDefault();
			Assert.That(profile, Is.Not.Null);
			Assert.That(profile.Id, Is.EqualTo(235845316));
			Assert.That(profile.FirstName, Is.EqualTo("Лапанильда"));
			Assert.That(profile.LastName, Is.EqualTo("Кошкодавленко"));
			Assert.That(profile.Sex, Is.EqualTo(Sex.Female));
			Assert.That(profile.ScreenName, Is.EqualTo("deadlymanul"));
			Assert.That(profile.PhotoPreviews.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg")));
			Assert.That(profile.PhotoPreviews.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg")));
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
			Assert.That(group.PhotoPreviews.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg")));
			Assert.That(group.PhotoPreviews.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg")));
			Assert.That(group.PhotoPreviews.Photo200, Is.EqualTo(new Uri("https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg")));
		}

		[Test]
		public void GetLinks_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getLinks?count=1&offset=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json = @"
			{
				response: {
					count: 4,
					items: [{
						id: '2_32190123_1',
						url: 'https://vk.com/apiclub',
						title: 'ВКонтакте API',
						description: 'Сообщество',
						photo_50: 'https://pp.vk.me/c400/g00001/e_5ba03323.jpg',
						photo_100: 'https://pp.vk.me/c400/g00001/e_5ba03323.jpg'
					}]
				}
			}";

			var cat = GetMockedFaveCategory(url, json);

			var links = cat.GetLinks(1, 1);

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

		#region GetMarketItems


		[Test]
		public void GetMarketItems_WithoutParams()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: {
					count: 1,
					items: [{
						id: 94992,
						owner_id: -103292418,
						title: 'Название',
						description: 'Описание',
						price: {
							amount: '12300',
							currency: {
								id: 643,
								name: 'RUB'
							},
							text: '123руб.'
						},
						category: {
							id: 300,
							name: 'Компьютеры',
							section: {
								id: 3,
								name: 'Компьютернаятехника'
							}
						},
						date: 1452002460,
						thumb_photo: 'https://pp.vk.me/c628717/v628717123/3852b/Kli3SztJwDE.jpg',
						availability: 0
					}]
				}
			}";

			var marketItems = Api.Fave.GetMarketItems();
			Assert.NotNull(marketItems);
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetMarketItems_count()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems?count=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: {
					count: 1,
					items: [{
						id: 94992,
						owner_id: -103292418,
						title: 'Название',
						description: 'Описание',
						price: {
							amount: '12300',
							currency: {
								id: 643,
								name: 'RUB'
							},
							text: '123руб.'
						},
						category: {
							id: 300,
							name: 'Компьютеры',
							section: {
								id: 3,
								name: 'Компьютернаятехника'
							}
						},
						date: 1452002460,
						thumb_photo: 'https://pp.vk.me/c628717/v628717123/3852b/Kli3SztJwDE.jpg',
						availability: 0
					}]
				}
			}";

			var marketItems = Api.Fave.GetMarketItems(1);
			Assert.NotNull(marketItems);
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetMarketItems_countAndOffset()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems?count=1&offset=0&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: {
					count: 1,
					items: [{
						id: 94992,
						owner_id: -103292418,
						title: 'Название',
						description: 'Описание',
						price: {
							amount: '12300',
							currency: {
								id: 643,
								name: 'RUB'
							},
							text: '123руб.'
						},
						category: {
							id: 300,
							name: 'Компьютеры',
							section: {
								id: 3,
								name: 'Компьютернаятехника'
							}
						},
						date: 1452002460,
						thumb_photo: 'https://pp.vk.me/c628717/v628717123/3852b/Kli3SztJwDE.jpg',
						availability: 0
					}]
				}
			}";

			var marketItems = Api.Fave.GetMarketItems(1,0);
			Assert.NotNull(marketItems);
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		[Test]
		public void GetMarketItems_AllParams()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems?count=1&offset=0&extended=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: {
					count: 1,
					items: [{
						id: 94992,
						owner_id: -103292418,
						title: 'Название',
						description: 'Описание',
						price: {
							amount: '12300',
							currency: {
								id: 643,
								name: 'RUB'
							},
							text: '123руб.'
						},
						category: {
							id: 300,
							name: 'Компьютеры',
							section: {
								id: 3,
								name: 'Компьютернаятехника'
							}
						},
						date: 1452002460,
						thumb_photo: 'https://pp.vk.me/c628717/v628717123/3852b/Kli3SztJwDE.jpg',
						availability: 0,
						albums_ids: [1],
						photos: [{
							id: 396740679,
							album_id: -53,
							owner_id: -103292418,
							user_id: 32190123,
							photo_75: 'https://pp.vk.me/c628717/v628717123/38520/w70n0UtkOm0.jpg',
							photo_130: 'https://pp.vk.me/c628717/v628717123/38521/mi9r7yOxsUQ.jpg',
							photo_604: 'https://pp.vk.me/c628717/v628717123/38522/o--iWrn5qgI.jpg',
							width: 550,
							height: 412,
							text: '',
							date: 1452002447
						}],
						can_comment: 1,
						can_repost: 1,
						likes: {
							user_likes: 1,
							count: 1
						},
						views_count: 10
					}]
				}
			}";

			var marketItems = Api.Fave.GetMarketItems(1, 0, true);
			Assert.NotNull(marketItems);
			Assert.That(marketItems.TotalCount, Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(marketItems);
		}

		#endregion

	}
}