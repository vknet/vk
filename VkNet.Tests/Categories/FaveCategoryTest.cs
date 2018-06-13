using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Tests.Helper;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage(category: "ReSharper", checkId: "PublicMembersMustHaveComments")]
	public class FaveCategoryTest : BaseTest
	{
		private FaveCategory GetMockedFaveCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new FaveCategory(vk: Api);
		}

		[Test]
		public void GetLinks_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getLinks";

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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var links = cat.GetLinks(count: 1, offset: 1);

			Assert.That(actual: links.Count, expression: Is.EqualTo(expected: 1));
			var link = links.FirstOrDefault();
			Assert.That(actual: link, expression: Is.Not.Null);
			Assert.That(actual: link.Id, expression: Is.EqualTo(expected: "2_32190123_1"));
			Assert.That(actual: link.Uri, expression: Is.EqualTo(expected: "https://vk.com/apiclub"));
			Assert.That(actual: link.Name, expression: Is.EqualTo(expected: "ВКонтакте API"));
			Assert.That(actual: link.Description, expression: Is.EqualTo(expected: "Сообщество"));
			Assert.That(actual: link.Photo50, expression: Is.EqualTo(expected: "https://pp.vk.me/c400/g00001/e_5ba03323.jpg"));
			Assert.That(actual: link.Photo100, expression: Is.EqualTo(expected: "https://pp.vk.me/c400/g00001/e_5ba03323.jpg"));
		}

		[Test]
		public void GetMarketItems_AllParams()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";

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

			var marketItems = Api.Fave.GetMarketItems(count: 1, offset: 0, extended: true);
			Assert.NotNull(anObject: marketItems);
			Assert.That(actual: marketItems.TotalCount, expression: Is.EqualTo(expected: 1));
			CollectionAssert.IsNotEmpty(collection: marketItems);
		}

		[Test]
		public void GetMarketItems_count()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";

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

			var marketItems = Api.Fave.GetMarketItems(count: 1);
			Assert.NotNull(anObject: marketItems);
			Assert.That(actual: marketItems.TotalCount, expression: Is.EqualTo(expected: 1));
			CollectionAssert.IsNotEmpty(collection: marketItems);
		}

		[Test]
		public void GetMarketItems_countAndOffset()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";

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

			var marketItems = Api.Fave.GetMarketItems(count: 1, offset: 0);
			Assert.NotNull(anObject: marketItems);
			Assert.That(actual: marketItems.TotalCount, expression: Is.EqualTo(expected: 1));
			CollectionAssert.IsNotEmpty(collection: marketItems);
		}

		[Test]
		public void GetMarketItems_WithoutParams()
		{
			Url = "https://api.vk.com/method/fave.getMarketItems";

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
			Assert.NotNull(anObject: marketItems);
			Assert.That(actual: marketItems.TotalCount, expression: Is.EqualTo(expected: 1));
			CollectionAssert.IsNotEmpty(collection: marketItems);
		}

		[Test]
		public void GetPhotos_ExtendedCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos";

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
							url: 'http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg',
							width: 75,
							height: 67,
							type: 's'
							}, {
							url: 'http://cs629301.vab0/khhRkq0uhoo.jpg',
							width: 130,
							height: 116,
							type: 'm'
							}, {
							url: 'http://cs629301.vab1/cNehIdjHNXg.jpg',
							width: 604,
							height: 537,
							type: 'x'
							}, {
							url: 'http://cs629301.vab2/reFF7eJG23U.jpg',
							width: 130,
							height: 116,
							type: 'o'
							}, {
							url: 'http://cs629301.vab3/6YYP7c34Vp4.jpg',
							width: 200,
							height: 178,
							type: 'p'
							}, {
							url: 'http://cs629301.vab4/I3fCEQCPuec.jpg',
							width: 320,
							height: 285,
							type: 'q'
							}, {
							url: 'http://cs629301.vab5/VtX_ZADIFXg.jpg',
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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var photos = cat.GetPhotos(count: 3, offset: 1, photoSizes: true);
			Assert.That(actual: photos, expression: Is.Not.Null);
			Assert.That(actual: photos.Count, expression: Is.EqualTo(expected: 1));
			var photo = photos.FirstOrDefault();

			Assert.That(actual: photo.Id, expression: Is.EqualTo(expected: 390044361));
			Assert.That(actual: photo.AlbumId, expression: Is.EqualTo(expected: -7));
			Assert.That(actual: photo.OwnerId, expression: Is.EqualTo(expected: -66589869));
			Assert.That(actual: photo.UserId, expression: Is.EqualTo(expected: 100));
			Assert.That(actual: photos[index: 0].Sizes[index: 0].Height, expression: Is.EqualTo(expected: 67));

			Assert.That(actual: photos[index: 0].Sizes[index: 0].Src,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg")));

			Assert.That(actual: photos[index: 0].Sizes[index: 0].Width, expression: Is.EqualTo(expected: 75));
			Assert.That(actual: photos[index: 0].Sizes[index: 0].Type, expression: Is.EqualTo(expected: PhotoSizeType.S));
			Assert.That(actual: photo.Text, expression: Is.EqualTo(expected: ""));
			Assert.That(actual: photo.CreateTime, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1447419206)));
			Assert.That(actual: photo.PostId, expression: Is.EqualTo(expected: 154560));
			Assert.That(actual: photo.AccessKey, expression: Is.EqualTo(expected: "1e2008462f1a012b95"));
		}

		[Test]
		public void GetPhotos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos";

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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var photos = cat.GetPhotos(count: 3, offset: 1);
			Assert.That(actual: photos, expression: Is.Not.Null);
			Assert.That(actual: photos.Count, expression: Is.EqualTo(expected: 2));
			var photo = photos.FirstOrDefault();

			Assert.That(actual: photo.Id, expression: Is.EqualTo(expected: 263113261));
			Assert.That(actual: photo.AlbumId, expression: Is.EqualTo(expected: 136592355));
			Assert.That(actual: photo.OwnerId, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: photo.Photo75,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg")));

			Assert.That(actual: photo.Photo130,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg")));

			Assert.That(actual: photo.Photo604,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg")));

			Assert.That(actual: photo.Photo807,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg")));

			Assert.That(actual: photo.Photo1280,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg")));

			Assert.That(actual: photo.Photo2560,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg")));

			Assert.That(actual: photo.Text, expression: Is.EqualTo(expected: ""));
			Assert.That(actual: photo.CreateTime, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1307628890)));

			var photo2 = photos.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: photo2.Id, expression: Is.EqualTo(expected: 319770573));
			Assert.That(actual: photo2.AlbumId, expression: Is.EqualTo(expected: -7));
			Assert.That(actual: photo2.OwnerId, expression: Is.EqualTo(expected: -25397178));
			Assert.That(actual: photo2.UserId, expression: Is.EqualTo(expected: 100));

			Assert.That(actual: photo2.Photo75,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg")));

			Assert.That(actual: photo2.Photo130,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg")));

			Assert.That(actual: photo2.Photo604,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg")));

			Assert.That(actual: photo2.Width, expression: Is.EqualTo(expected: 604));
			Assert.That(actual: photo2.Height, expression: Is.EqualTo(expected: 530));
			Assert.That(actual: photo2.Text, expression: Is.EqualTo(expected: ""));
			Assert.That(actual: photo2.PostId, expression: Is.EqualTo(expected: 88997));
			Assert.That(actual: photo2.CreateTime, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1390533904)));
		}

		[Test]
		public void GetPosts_Extended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts";

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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var posts = cat.GetPosts(count: 3, offset: 1);

			Assert.That(actual: posts.TotalCount, expression: Is.EqualTo(expected: 2623u));

			var wallPost = posts.WallPosts.FirstOrDefault();
			Assert.That(actual: wallPost, expression: Is.Not.Null);
			Assert.That(actual: wallPost.Id, expression: Is.EqualTo(expected: 1258365));
			Assert.That(actual: wallPost.FromId, expression: Is.EqualTo(expected: -30666517));
			Assert.That(actual: wallPost.OwnerId, expression: Is.EqualTo(expected: -30666517));
			Assert.That(actual: wallPost.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1447668333)));
			Assert.That(actual: wallPost.PostType, expression: Is.EqualTo(expected: PostType.Post));

			Assert.That(actual: wallPost.Text,
				expression: Is.EqualTo(expected:
					@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально."));

			Assert.That(actual: wallPost.PostSource.Type, expression: Is.EqualTo(expected: PostSourceType.Vk));
			Assert.That(actual: wallPost.Comments.CanPost, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wallPost.Comments.Count, expression: Is.EqualTo(expected: 9));
			Assert.That(actual: wallPost.Likes.Count, expression: Is.EqualTo(expected: 413));
			Assert.That(actual: wallPost.Likes.UserLikes, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wallPost.Likes.CanLike, expression: Is.EqualTo(expected: false));
			Assert.That(actual: wallPost.Likes.CanPublish, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wallPost.Reposts.UserReposted, expression: Is.EqualTo(expected: false));
			Assert.That(actual: wallPost.Reposts.Count, expression: Is.EqualTo(expected: 91));
			Assert.That(actual: wallPost.Attachments.Count, expression: Is.EqualTo(expected: 1));

			var video = posts.WallPosts[index: 0].Attachments[index: 0].Instance as Video;
			Assert.That(actual: video, expression: Is.Not.Null);
			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 171514588));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: 235845316));

			Assert.That(actual: video.Title,
				expression: Is.EqualTo(expected: "Clean Code: Learn to write clean, maintainable and robust code"));

			Assert.That(actual: video.Duration, expression: Is.EqualTo(expected: 2058));
			Assert.That(actual: video.Views, expression: Is.EqualTo(expected: 1613));
			Assert.That(actual: video.Comments, expression: Is.EqualTo(expected: 0));

			Assert.That(actual: video.Photo130,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg")));

			Assert.That(actual: video.Photo320,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg")));

			Assert.That(actual: video.Photo640,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg")));

			Assert.That(actual: video.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1447535648)));
			Assert.That(actual: video.AccessKey, expression: Is.EqualTo(expected: "733701ff4d7eb85ed7"));

			var profile = posts.Profiles.FirstOrDefault();
			Assert.That(actual: profile, expression: Is.Not.Null);
			Assert.That(actual: profile.Id, expression: Is.EqualTo(expected: 235845316));
			Assert.That(actual: profile.FirstName, expression: Is.EqualTo(expected: "Лапанильда"));
			Assert.That(actual: profile.LastName, expression: Is.EqualTo(expected: "Кошкодавленко"));
			Assert.That(actual: profile.Sex, expression: Is.EqualTo(expected: Sex.Female));
			Assert.That(actual: profile.ScreenName, expression: Is.EqualTo(expected: "deadlymanul"));

			Assert.That(actual: profile.PhotoPreviews.Photo50,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c621918/v621918316/3e98c/-t0a2WEOZDU.jpg")));

			Assert.That(actual: profile.PhotoPreviews.Photo100,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c621918/v621918316/3e98b/tqlsDgLIgzE.jpg")));

			Assert.That(actual: profile.Online, expression: Is.EqualTo(expected: true));

			var group = posts.Groups.FirstOrDefault();
			Assert.That(actual: group, expression: Is.Not.Null);
			Assert.That(actual: group.Id, expression: Is.EqualTo(expected: 30666517));
			Assert.That(actual: group.Name, expression: Is.EqualTo(expected: "Типичный программист | tproger"));
			Assert.That(actual: group.ScreenName, expression: Is.EqualTo(expected: "tproger"));
			Assert.That(actual: group.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group.Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: group.IsAdmin, expression: Is.EqualTo(expected: false));
			Assert.That(actual: group.IsMember, expression: Is.EqualTo(expected: true));

			Assert.That(actual: group.PhotoPreviews.Photo50,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c625628/v625628973/43c4a/MUFXdlLGg-I.jpg")));

			Assert.That(actual: group.PhotoPreviews.Photo100,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c625628/v625628973/43c49/qO1HJcRXnaQ.jpg")));

			Assert.That(actual: group.PhotoPreviews.Photo200,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c625628/v625628973/43c48/0ioH05XEjCc.jpg")));
		}

		[Test]
		public void GetPosts_NotExtended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts";

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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var posts = cat.GetPosts(count: 3, offset: 1);

			Assert.That(actual: posts.TotalCount, expression: Is.EqualTo(expected: 2623u));

			var wallPost = posts.WallPosts.FirstOrDefault();

			Assert.That(actual: wallPost.Id, expression: Is.EqualTo(expected: 1258365));
			Assert.That(actual: wallPost.FromId, expression: Is.EqualTo(expected: -30666517));
			Assert.That(actual: wallPost.OwnerId, expression: Is.EqualTo(expected: -30666517));
			Assert.That(actual: wallPost.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1447668333)));
			Assert.That(actual: wallPost.PostType, expression: Is.EqualTo(expected: PostType.Post));

			Assert.That(actual: wallPost.Text,
				expression: Is.EqualTo(expected:
					@"Видео с наглядными инструкциями, как правильно отрефакторить плохо написанный код, сделав его намного более читаемым, чем было изначально."));

			Assert.That(actual: wallPost.PostSource.Type, expression: Is.EqualTo(expected: PostSourceType.Vk));
			Assert.That(actual: wallPost.Comments.CanPost, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wallPost.Comments.Count, expression: Is.EqualTo(expected: 9));
			Assert.That(actual: wallPost.Likes.Count, expression: Is.EqualTo(expected: 413));
			Assert.That(actual: wallPost.Likes.UserLikes, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wallPost.Likes.CanLike, expression: Is.EqualTo(expected: false));
			Assert.That(actual: wallPost.Likes.CanPublish, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wallPost.Reposts.UserReposted, expression: Is.EqualTo(expected: false));
			Assert.That(actual: wallPost.Reposts.Count, expression: Is.EqualTo(expected: 91));
			Assert.That(actual: wallPost.Attachments.Count, expression: Is.EqualTo(expected: 1));

			var video = posts.WallPosts[index: 0].Attachments[index: 0].Instance as Video;
			Assert.That(actual: video, expression: Is.Not.Null);
			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 171514588));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: 235845316));

			Assert.That(actual: video.Title,
				expression: Is.EqualTo(expected: "Clean Code: Learn to write clean, maintainable and robust code"));

			Assert.That(actual: video.Duration, expression: Is.EqualTo(expected: 2058));
			Assert.That(actual: video.Views, expression: Is.EqualTo(expected: 1613));
			Assert.That(actual: video.Comments, expression: Is.EqualTo(expected: 0));

			Assert.That(actual: video.Photo130,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c627830/u235845316/video/s_856d4cf3.jpg")));

			Assert.That(actual: video.Photo320,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c627830/u235845316/video/l_e2fc316e.jpg")));

			Assert.That(actual: video.Photo640,
				expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c627830/u235845316/video/y_dca48fdd.jpg")));

			Assert.That(actual: video.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1447535648)));
			Assert.That(actual: video.AccessKey, expression: Is.EqualTo(expected: "733701ff4d7eb85ed7"));
		}

		[Test]
		public void GetUsers_OneItem()
		{
			const string url = "https://api.vk.com/method/fave.getUsers";

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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var users = cat.GetUsers(count: 3, offset: 1);
			Assert.That(actual: users, expression: Is.Not.Null);
			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 1));
			var user = users.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Павел"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Дуров"));
		}

		[Test]
		public void GetVideos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getVideos";

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

			var cat = GetMockedFaveCategory(url: url, json: json);

			var videos = cat.GetVideos(count: 3, offset: 1);
			Assert.That(actual: videos.Count, expression: Is.EqualTo(expected: 2));
			var video = videos.Videos.FirstOrDefault();
			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 164841344));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video.Title, expression: Is.EqualTo(expected: "This is SPARTA"));
			Assert.That(actual: video.Duration, expression: Is.EqualTo(expected: 16));
			Assert.That(actual: video.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1366495075)));
			Assert.That(actual: video.Views, expression: Is.EqualTo(expected: 215502));
			Assert.That(actual: video.Comments, expression: Is.EqualTo(expected: 2559));

			Assert.That(actual: video.Photo130,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));

			Assert.That(actual: video.Photo320,
				expression: Is.EqualTo(expected: new Uri(uriString: "http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));
		}
	}
}