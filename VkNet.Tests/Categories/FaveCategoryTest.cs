using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories
{
	using Model.Attachments;

	using System;
	using Moq;
	using NUnit.Framework;
	using VkNet.Categories;
	using VkNet.Utils;


	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class FaveCategoryTest
	{
		private FaveCategory GetMockedFaveCategory(string url, string json)
		{
			var browser = Mock.Of<IBrowser>(m => m.GetJson(url.Replace('\'', '"')) == json);
			return new FaveCategory(new VkApi {AccessToken = "token", Browser = browser});
		}

		[Test]
		public void GetUsers_OneItem()
		{
			const string url = "https://api.vk.com/method/fave.getUsers?count=3&offset=1&v=5.44&access_token=token";
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

			//users.ShouldNotBeNull();
			//users.Count.ShouldEqual(1);
			//users[0].Id.ShouldEqual(1);
			//users[0].FirstName.ShouldEqual("Павел");
			//users[0].LastName.ShouldEqual("Дуров");
		}

		[Test]
		public void GetPhotos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos?count=3&offset=1&v=5.44&access_token=token";
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

			//photos.ShouldNotBeNull();
			//photos.Count.ShouldEqual(2);

			//photos[0].Id.ShouldEqual(263113261);
			//photos[0].AlbumId.ShouldEqual(136592355);
			//photos[0].OwnerId.ShouldEqual(1);
			//photos[0].Photo75.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg"));
			//photos[0].Photo130.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg"));
			//photos[0].Photo604.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg"));
			//photos[0].Photo807.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg"));
			//photos[0].Photo1280.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg"));
			//photos[0].Photo2560.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg"));
			//photos[0].Text.ShouldEqual("");
			//photos[0].CreateTime.ShouldEqual(new DateTime(2011, 6, 9, 14, 14, 50, DateTimeKind.Utc).ToLocalTime());

			//photos[1].Id.ShouldEqual(319770573);
			//photos[1].AlbumId.ShouldEqual(-7);
			//photos[1].OwnerId.ShouldEqual(-25397178);
			//photos[1].UserId.ShouldEqual(100);
			//photos[1].Photo75.ShouldEqual(new Uri("http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg"));
			//photos[1].Photo130.ShouldEqual(new Uri("http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg"));
			//photos[1].Photo604.ShouldEqual(new Uri("http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg"));
			//photos[1].Width.ShouldEqual(604);
			//photos[1].Height.ShouldEqual(530);
			//photos[1].Text.ShouldEqual("");
			//photos[1].PostId.ShouldEqual(88997);
			//photos[1].CreateTime.ShouldEqual(new DateTime(2014, 1, 24, 3, 25, 4, DateTimeKind.Utc).ToLocalTime());
		}

		[Test]
		public void GetPhotos_ExtendedCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos?count=3&offset=1&photo_sizes=1&v=5.44&access_token=token";
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

			//photos.ShouldNotBeNull();
			//photos.Count.ShouldEqual(1);

			//photos[0].Id.ShouldEqual(390044361);
			//photos[0].AlbumId.ShouldEqual(-7);
			//photos[0].OwnerId.ShouldEqual(-66589869);
			//photos[0].UserId.ShouldEqual(100);
			//Assert.That(photos[0].Sizes[0].Height, Is.EqualTo(67));
			//Assert.That(photos[0].Sizes[0].Src, Is.EqualTo(new Url("http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg")));
			//Assert.That(photos[0].Sizes[0].Width, Is.EqualTo(75));
			//Assert.That(photos[0].Sizes[0].Type, Is.EqualTo(PhotoSizeType.S));
			//photos[0].Text.ShouldEqual("");
			//// Unix timestamp is seconds past epoch
			//var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			//photos[0].CreateTime.ShouldEqual(dt.AddSeconds(1447419206).ToLocalTime());
			//photos[0].PostId.ShouldEqual(154560);
			//photos[0].AccessKey.ShouldEqual("1e2008462f1a012b95");
		}

		[Test]
		public void GetVideos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getVideos?count=3&offset=1&extended=1&v=5.44&access_token=token";
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

			//videos.Count.ShouldEqual(1);

			//videos[0].Id.ShouldEqual(164841344);
			//videos[0].OwnerId.ShouldEqual(1);
			//videos[0].Title.ShouldEqual("This is SPARTA");
			//videos[0].Duration.ShouldEqual(16);
			//videos[0].Date.ShouldEqual(new DateTime(2013, 4, 20, 21, 57, 55, DateTimeKind.Utc).ToLocalTime());
			//videos[0].ViewsCount.ShouldEqual(215502);
			//videos[0].CommentsCount.ShouldEqual(2559);
			//videos[0].Photo130.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg"));
			//videos[0].Photo320.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg"));
		}

		[Test]
		public void GetPosts_NotExtended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts?count=3&offset=1&extended=1&v=5.44&access_token=token";
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
							text: 'Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.

							#videos@tproger',
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

			//posts.TotalCount.ShouldEqual(2623u);

			//posts.WallPosts[0].Id.ShouldEqual(1258365);
			//posts.WallPosts[0].FromId.ShouldEqual(-30666517);
			//posts.WallPosts[0].OwnerId.ShouldEqual(-30666517);
			//// 2015-11-16 13:05:33.000
			//var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			//posts.WallPosts[0].Date.ShouldEqual(dt.AddSeconds(1447668333).ToLocalTime());
			//posts.WallPosts[0].PostType.ShouldEqual(PostType.Post);
			//posts.WallPosts[0].Text.ShouldEqual(@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.

			//				#videos@tproger");
			//posts.WallPosts[0].PostSource.Type.ShouldEqual(PostSourceType.Vk);
			//posts.WallPosts[0].Comments.CanPost.ShouldEqual(true);
			//posts.WallPosts[0].Comments.Count.ShouldEqual(9);
			//posts.WallPosts[0].Likes.Count.ShouldEqual(413);
			//posts.WallPosts[0].Likes.UserLikes.ShouldEqual(true);
			//posts.WallPosts[0].Likes.CanLike.ShouldEqual(false);
			//posts.WallPosts[0].Likes.CanPublish.ShouldEqual(true);
			//posts.WallPosts[0].Reposts.UserReposted.ShouldEqual(false);
			//posts.WallPosts[0].Reposts.Count.ShouldEqual(91);
			//posts.WallPosts[0].Attachments.Count.ShouldEqual(1);

			//var video = posts.WallPosts[0].Attachments[0].Instance as Video;
			//video.ShouldNotBeNull();
			//video.Id.ShouldEqual(171514588);
			//video.OwnerId.ShouldEqual(235845316);
			//video.Title.ShouldEqual("Clean Code: Learn to write clean, maintainable and robust code");
			//video.Duration.ShouldEqual(2058);
			//video.ViewsCount.ShouldEqual(1613);
			//video.CommentsCount.ShouldEqual(0);
			//video.Photo130.ShouldEqual(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg"));
			//video.Photo320.ShouldEqual(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg"));
			//video.Photo640.ShouldEqual(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg"));
			//dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			//video.Date.ShouldEqual(dt.AddSeconds(1447535648).ToLocalTime());
			//video.AccessKey.ShouldEqual("733701ff4d7eb85ed7");
		}

		[Test]
		public void GetPosts_Extended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts?count=3&offset=1&extended=1&v=5.44&access_token=token";
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
							text: 'Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.

							#videos@tproger',
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

			//posts.TotalCount.ShouldEqual(2623u);

			//posts.WallPosts[0].Id.ShouldEqual(1258365);
			//posts.WallPosts[0].FromId.ShouldEqual(-30666517);
			//posts.WallPosts[0].OwnerId.ShouldEqual(-30666517);
			//// 2015-11-16 13:05:33.000
			//var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			//posts.WallPosts[0].Date.ShouldEqual(dt.AddSeconds(1447668333).ToLocalTime());
			//posts.WallPosts[0].PostType.ShouldEqual(PostType.Post);
			//posts.WallPosts[0].Text.ShouldEqual(@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально.

			//				#videos@tproger");
			//posts.WallPosts[0].PostSource.Type.ShouldEqual(PostSourceType.Vk);
			//posts.WallPosts[0].Comments.CanPost.ShouldEqual(true);
			//posts.WallPosts[0].Comments.Count.ShouldEqual(9);
			//posts.WallPosts[0].Likes.Count.ShouldEqual(413);
			//posts.WallPosts[0].Likes.UserLikes.ShouldEqual(true);
			//posts.WallPosts[0].Likes.CanLike.ShouldEqual(false);
			//posts.WallPosts[0].Likes.CanPublish.ShouldEqual(true);
			//posts.WallPosts[0].Reposts.UserReposted.ShouldEqual(false);
			//posts.WallPosts[0].Reposts.Count.ShouldEqual(91);
			//posts.WallPosts[0].Attachments.Count.ShouldEqual(1);

			//var video = posts.WallPosts[0].Attachments[0].Instance as Video;
			//video.ShouldNotBeNull();
			//video.Id.ShouldEqual(171514588);
			//video.OwnerId.ShouldEqual(235845316);
			//video.Title.ShouldEqual("Clean Code: Learn to write clean, maintainable and robust code");
			//video.Duration.ShouldEqual(2058);
			//video.ViewsCount.ShouldEqual(1613);
			//video.CommentsCount.ShouldEqual(0);
			//video.Photo130.ShouldEqual(new Uri("https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg"));
			//video.Photo320.ShouldEqual(new Uri("https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg"));
			//video.Photo640.ShouldEqual(new Uri("https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg"));
			//dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			//video.Date.ShouldEqual(dt.AddSeconds(1447535648).ToLocalTime());
			//video.AccessKey.ShouldEqual("733701ff4d7eb85ed7");

			//posts.Profiles[0].Id.ShouldEqual(235845316);
			//posts.Profiles[0].FirstName.ShouldEqual("Лапанильда");
			//posts.Profiles[0].LastName.ShouldEqual("Кошкодавленко");
			//posts.Profiles[0].Sex.ShouldEqual(Sex.Female);
			//posts.Profiles[0].ScreenName.ShouldEqual("deadlymanul");
			//posts.Profiles[0].PhotoPreviews.Photo50.ShouldEqual(new Uri("https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg"));
			//posts.Profiles[0].PhotoPreviews.Photo100.ShouldEqual(new Uri("https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg"));
			//posts.Profiles[0].Online.ShouldEqual(true);

			//posts.Groups[0].Id.ShouldEqual(30666517);
			//posts.Groups[0].Name.ShouldEqual("Типичный программист | tproger");
			//posts.Groups[0].ScreenName.ShouldEqual("tproger");
			//posts.Groups[0].IsClosed.ShouldEqual(GroupPublicity.Public);
			//posts.Groups[0].Type.ShouldEqual(GroupType.Page);
			//posts.Groups[0].IsAdmin.ShouldEqual(false);
			//posts.Groups[0].IsMember.ShouldEqual(true);
			//posts.Groups[0].PhotoPreviews.Photo50.ShouldEqual(new Uri("https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg"));
			//posts.Groups[0].PhotoPreviews.Photo100.ShouldEqual(new Uri("https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg"));
			//posts.Groups[0].PhotoPreviews.Photo200.ShouldEqual(new Uri("https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg"));
		}

		[Test]
		public void GetLinks_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getLinks?count=1&offset=1&v=5.44&access_token=token";
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

			//links.Count.ShouldEqual(1);
			//links[0].Id.ShouldEqual("2_32190123_1");
			//links[0].Url.ShouldEqual("https://vk.com/apiclub");
			//links[0].Name.ShouldEqual("ВКонтакте API");
			//links[0].Description.ShouldEqual("Сообщество");
			//links[0].Photo50.ShouldEqual("https://pp.vk.me/c400/g00001/e_5ba03323.jpg");
			//links[0].Photo100.ShouldEqual("https://pp.vk.me/c400/g00001/e_5ba03323.jpg");
		}
	}
}