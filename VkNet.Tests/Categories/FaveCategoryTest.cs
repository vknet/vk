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
	using FluentNUnit;

	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class FaveCategoryTest
	{
		private FaveCategory GetMockedFaveCategory(string url, string json)
		{
			var browser = Mock.Of<IBrowser>(m => m.GetJson(url.Replace('\'', '"')) == json);
			return new FaveCategory(new VkApi(){AccessToken = "token", Browser = browser});
		}

		[Test]
		public void GetUsers_OneItem()
		{
			const string url = "https://api.vk.com/method/fave.getUsers?count=3&offset=1&v=5.40&access_token=token";
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

			users.ShouldNotBeNull();
			users.Count.ShouldEqual(1);
			users[0].Id.ShouldEqual(1);
			users[0].FirstName.ShouldEqual("Павел");
			users[0].LastName.ShouldEqual("Дуров");
		}

		[Test]
		public void GetPhotos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos?count=3&offset=1&v=5.40&access_token=token";
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

			photos.ShouldNotBeNull();
			photos.Count.ShouldEqual(2);

			photos[0].Id.ShouldEqual(263113261);
			photos[0].AlbumId.ShouldEqual(136592355);
			photos[0].OwnerId.ShouldEqual(1);
			photos[0].Photo75.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/s_47267f71.jpg"));
			photos[0].Photo130.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/m_dc54094a.jpg"));
			photos[0].Photo604.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/x_3216ccc1.jpg"));
			photos[0].Photo807.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/y_e10ee835.jpg"));
			photos[0].Photo1280.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/z_a8fd75ba.jpg"));
			photos[0].Photo2560.ShouldEqual(new Uri("http://cs9591.vk.me/u00001/136592355/w_62aef149.jpg"));
			photos[0].Text.ShouldEqual("");
			photos[0].CreateTime.ShouldEqual(new DateTime(2011, 6, 9, 14, 14, 50, DateTimeKind.Utc).ToLocalTime());

			photos[1].Id.ShouldEqual(319770573);
			photos[1].AlbumId.ShouldEqual(-7);
			photos[1].OwnerId.ShouldEqual(-25397178);
			photos[1].UserId.ShouldEqual(100);
			photos[1].Photo75.ShouldEqual(new Uri("http://cs310923.vk.me/v310923070/c28b/VEtf7pX6MXM.jpg"));
			photos[1].Photo130.ShouldEqual(new Uri("http://cs310923.vk.me/v310923070/c28c/cjCqKn_EGxE.jpg"));
			photos[1].Photo604.ShouldEqual(new Uri("http://cs310923.vk.me/v310923070/c28d/IFtj16H-KwI.jpg"));
			photos[1].Width.ShouldEqual(604);
			photos[1].Height.ShouldEqual(530);
			photos[1].Text.ShouldEqual("");
			photos[1].PostId.ShouldEqual(88997);
			photos[1].CreateTime.ShouldEqual(new DateTime(2014, 1, 24, 3, 25, 4, DateTimeKind.Utc).ToLocalTime());
		}

		[Test]
		public void GetPhotos_ExtendedCase()
		{
			const string url = "https://api.vk.com/method/fave.getPhotos?count=3&offset=1&photo_sizes=1&v=5.40&access_token=token";
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

			photos.ShouldNotBeNull();
			photos.Count.ShouldEqual(1);

			photos[0].Id.ShouldEqual(390044361);
			photos[0].AlbumId.ShouldEqual(-7);
			photos[0].OwnerId.ShouldEqual(-66589869);
			photos[0].UserId.ShouldEqual(100);
			Assert.That(photos[0].Sizes[0].Height, Is.EqualTo(67));
			Assert.That(photos[0].Sizes[0].Src, Is.EqualTo(new Url("http://cs629301.vk.me/v629301456/1caaf/XpHNgelMOc0.jpg")));
			Assert.That(photos[0].Sizes[0].Width, Is.EqualTo(75));
			Assert.That(photos[0].Sizes[0].Type, Is.EqualTo(PhotoSizeType.S));
			photos[0].Text.ShouldEqual("");
			// Unix timestamp is seconds past epoch
			var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			photos[0].CreateTime.ShouldEqual(dt.AddSeconds(1447419206).ToLocalTime());
			photos[0].PostId.ShouldEqual(154560);
			photos[0].AccessKey.ShouldEqual("1e2008462f1a012b95");
		}

		[Test]
		public void GetVideos_NormalCase()
		{
			const string url = "https://api.vk.com/method/fave.getVideos?count=3&offset=1&v=5.9&access_token=token";
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

			videos.Count.ShouldEqual(1);

			videos[0].Id.ShouldEqual(164841344);
			videos[0].OwnerId.ShouldEqual(1);
			videos[0].Title.ShouldEqual("This is SPARTA");
			videos[0].Duration.ShouldEqual(16);
			videos[0].Date.ShouldEqual(new DateTime(2013, 4, 20, 21, 57, 55, DateTimeKind.Utc).ToLocalTime());
			videos[0].ViewsCount.ShouldEqual(215502);
			videos[0].CommentsCount.ShouldEqual(2559);
			videos[0].Photo130.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg"));
			videos[0].Photo320.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg"));
		}

		[Test]
		public void GetPosts_NotExtended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts?count=3&offset=1&extended=1&v=5.40&access_token=token";
			const string json =
				@"{
					'response': {
					  'count': 3,
					  'items': [
						{
						  'id': 45611,
						  'from_id': 1,
						  'to_id': 1,
						  'date': 1390260904,
						  'post_type': 'post',
						  'text': 'ВКонтакте взял новую высоту — 60 миллионов человек за сутки.',
						  'attachments': [
							{
							  'type': 'photo',
							  'photo': {
								'id': 320624027,
								'album_id': -7,
								'owner_id': 1,
								'photo_75': 'http://cs7004.vk.me/c540101/v540101001/945b/6JwHSc5wLGg.jpg',
								'photo_130': 'http://cs7004.vk.me/c540101/v540101001/945c/xxlEPKAyYXM.jpg',
								'photo_604': 'http://cs7004.vk.me/c540101/v540101001/945d/jvCKTR8CAHg.jpg',
								'photo_807': 'http://cs7004.vk.me/c540101/v540101001/945e/UUCwCY799wQ.jpg',
								'width': 609,
								'height': 556,
								'text': '',
								'date': 1390260965,
								'access_key': '82b124d82eba43d66d'
							  }
							}
						  ],
						  'post_source': {
							'type': 'vk'
						  },
						  'comments': {
							'count': 0,
							'can_post': 0
						  },
						  'likes': {
							'count': 81167,
							'user_likes': 1,
							'can_like': 0,
							'can_publish': 1
						  },
						  'reposts': {
							'count': 4364,
							'user_reposted': 0
						  }
						},
						{
						  'id': 88997,
						  'from_id': -25397178,
						  'to_id': -25397178,
						  'date': 1390533904,
						  'post_type': 'post',
						  'text': 'Комплекс лучших упражнений на каждую группу мышц \n\nСПИНА \n- Подтягивания 4 подхода 8-12 повторений \n- Становая тяга 3-4 подхода 10-12 повторений \n\n- Тяга (Т-грифа или штанги в наклоне) 3-4 подхода 10-12 повторений \n- Горизонтальная тяга в блочном тренажере 4 подхода 10-12 повторений \n- Шраги со штангой 4 подхода 10-12 повторений \n\nГРУДЬ \n- Жим лёжа (штанги или гантелей) 4 подхода 10-12 повторений \n- Жим на наклонной (штанги или гантелей) 3-4 подхода 10-12 повторений \n- Отжимания на брусьях 4 подхода до отказа \n\nНОГИ \n- Приседания 4 подхода 10-12 повторений \n- Жим ногами 3-4 подхода 8-12 повторений \n- Разгибания ног в тренажере 4 подхода 10-12 повторений \n- Подъём на носки стоя 4 подхода 15 повторений \n- Подъём на носки сидя 3-4 подхода 12-15 повторений \n\nРУКИ \n- Жим лёжа узким хватом 4 подхода 10-12 повторений \n- Отжимания на брусьях 3-4 подхода 8-12 повторений (с доп весом) \n- Подъём штанги на бицепс 4 подхода 10-12 повторений \n- Молот 3-4 подхода 8-12 повторений \n- Армейский жим 3-4 подхода 8-12 повторений \n- Жим сидя 3-4 подхода 8-12 повторений\n- Разведение гантелей в наклоне 3-4 подхода 8-12 повторений \n\nПРЕСС \n- Скручивания 4 подхода 15-20 повторений \n- Косые скручивания 3-4 подхода 12-20 повторений \n- Подъём ног в висе 3-4 подхода 8-15 повторений\n\n#спорт@strog_pocan',
						  'attachments': [
							{
							  'type': 'photo',
							  'photo': {
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
								'post_id': 88997,
								'access_key': 'bab83089cd5ffeb0f8'
							  }
							}
						  ],
						  'post_source': {
							'type': 'api'
						  },
						  'comments': {
							'count': 0,
							'can_post': 0
						  },
						  'likes': {
							'count': 1397,
							'user_likes': 1,
							'can_like': 0,
							'can_publish': 1
						  },
						  'reposts': {
							'count': 565,
							'user_reposted': 0
						  }
						}
					  ]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var posts = cat.GetPosts(3, 1);

			posts.Count.ShouldEqual(2);

			posts[0].Id.ShouldEqual(45611);
			posts[0].FromId.ShouldEqual(1);
			posts[0].Date.ShouldEqual(new DateTime(2014, 1, 21, 3, 35, 4));
			posts[0].PostType.ShouldEqual("post");
			posts[0].Text.ShouldEqual("ВКонтакте взял новую высоту — 60 миллионов человек за сутки.");   
			posts[0].PostSource.Type.ShouldEqual("vk");
			posts[0].Comments.CanPost.ShouldEqual(false);
			posts[0].Comments.Count.ShouldEqual(0);
			posts[0].Likes.Count.ShouldEqual(81167);
			posts[0].Likes.UserLikes.ShouldEqual(true);
			posts[0].Likes.CanLike.ShouldEqual(false);
			posts[0].Likes.CanPublish.ShouldEqual(true);
			posts[0].Reposts.UserReposted.ShouldEqual(false);
			posts[0].Reposts.Count.ShouldEqual(4364);
			posts[0].Attachments.Count.ShouldEqual(1);
			
			var photo = posts[0].Attachments[0].Instance as Photo;
			photo.ShouldNotBeNull();
			photo.Id.ShouldEqual(320624027);
			photo.AlbumId.ShouldEqual(-7);
			photo.OwnerId.ShouldEqual(1);
			photo.Photo75.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945b/6JwHSc5wLGg.jpg"));
			photo.Photo130.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945c/xxlEPKAyYXM.jpg"));
			photo.Photo604.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945d/jvCKTR8CAHg.jpg"));
			photo.Photo807.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945e/UUCwCY799wQ.jpg"));
			photo.Width.ShouldEqual(609);
			photo.Height.ShouldEqual(556);
			photo.Text.ShouldEqual(string.Empty);
			photo.CreateTime.ShouldEqual(new DateTime(2014, 1, 21, 3, 36, 5));
			photo.AccessKey.ShouldEqual("82b124d82eba43d66d");
		}

		[Test]
		public void GetPosts_Extended()
		{
			const string url = "https://api.vk.com/method/fave.getPosts?count=3&offset=1&extended=1&v=5.40&access_token=token";
			const string json =
			@"{
					'response': {
					  'count': 3,
					  'items': [
						{
						  'id': 45611,
						  'from_id': 1,
						  'to_id': 1,
						  'date': 1390260904,
						  'post_type': 'post',
						  'text': 'ВКонтакте взял новую высоту — 60 миллионов человек за сутки.',
						  'attachments': [
							{
							  'type': 'photo',
							  'photo': {
								'id': 320624027,
								'album_id': -7,
								'owner_id': 1,
								'photo_75': 'http://cs7004.vk.me/c540101/v540101001/945b/6JwHSc5wLGg.jpg',
								'photo_130': 'http://cs7004.vk.me/c540101/v540101001/945c/xxlEPKAyYXM.jpg',
								'photo_604': 'http://cs7004.vk.me/c540101/v540101001/945d/jvCKTR8CAHg.jpg',
								'photo_807': 'http://cs7004.vk.me/c540101/v540101001/945e/UUCwCY799wQ.jpg',
								'width': 609,
								'height': 556,
								'text': '',
								'date': 1390260965,
								'access_key': '82b124d82eba43d66d'
							  }
							}
						  ],
						  'post_source': {
							'type': 'vk'
						  },
						  'comments': {
							'count': 0,
							'can_post': 0
						  },
						  'likes': {
							'count': 81168,
							'user_likes': 1,
							'can_like': 0,
							'can_publish': 1
						  },
						  'reposts': {
							'count': 4364,
							'user_reposted': 0
						  }
						},
						{
						  'id': 88997,
						  'from_id': -25397178,
						  'to_id': -25397178,
						  'date': 1390533904,
						  'post_type': 'post',
						  'text': 'Комплекс лучших упражнений на каждую группу мышц \n\nСПИНА \n- Подтягивания 4 подхода 8-12 повторений \n- Становая тяга 3-4 подхода 10-12 повторений \n\n- Тяга (Т-грифа или штанги в наклоне) 3-4 подхода 10-12 повторений \n- Горизонтальная тяга в блочном тренажере 4 подхода 10-12 повторений \n- Шраги со штангой 4 подхода 10-12 повторений \n\nГРУДЬ \n- Жим лёжа (штанги или гантелей) 4 подхода 10-12 повторений \n- Жим на наклонной (штанги или гантелей) 3-4 подхода 10-12 повторений \n- Отжимания на брусьях 4 подхода до отказа \n\nНОГИ \n- Приседания 4 подхода 10-12 повторений \n- Жим ногами 3-4 подхода 8-12 повторений \n- Разгибания ног в тренажере 4 подхода 10-12 повторений \n- Подъём на носки стоя 4 подхода 15 повторений \n- Подъём на носки сидя 3-4 подхода 12-15 повторений \n\nРУКИ \n- Жим лёжа узким хватом 4 подхода 10-12 повторений \n- Отжимания на брусьях 3-4 подхода 8-12 повторений (с доп весом) \n- Подъём штанги на бицепс 4 подхода 10-12 повторений \n- Молот 3-4 подхода 8-12 повторений \n- Армейский жим 3-4 подхода 8-12 повторений \n- Жим сидя 3-4 подхода 8-12 повторений\n- Разведение гантелей в наклоне 3-4 подхода 8-12 повторений \n\nПРЕСС \n- Скручивания 4 подхода 15-20 повторений \n- Косые скручивания 3-4 подхода 12-20 повторений \n- Подъём ног в висе 3-4 подхода 8-15 повторений\n\n#спорт@strog_pocan',
						  'attachments': [
							{
							  'type': 'photo',
							  'photo': {
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
								'post_id': 88997,
								'access_key': 'bab83089cd5ffeb0f8'
							  }
							}
						  ],
						  'post_source': {
							'type': 'api'
						  },
						  'comments': {
							'count': 0,
							'can_post': 0
						  },
						  'likes': {
							'count': 1397,
							'user_likes': 1,
							'can_like': 0,
							'can_publish': 1
						  },
						  'reposts': {
							'count': 565,
							'user_reposted': 0
						  }
						}
					  ],
					  'profiles': [
						{
						  'id': 1,
						  'first_name': 'Павел',
						  'last_name': 'Дуров',
						  'sex': 2,
						  'screen_name': 'durov',
						  'photo_50': 'http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg',
						  'photo_100': 'http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg',
						  'online': 0
						},
						{
						  'id': 234695118,
						  'first_name': 'Ruslan',
						  'last_name': 'Davydov',
						  'sex': 2,
						  'screen_name': 'davydov.ruslan',
						  'photo_50': 'http://vk.com/images/camera_c.gif',
						  'photo_100': 'http://vk.com/images/camera_b.gif',
						  'online': 1
						}
					  ],
					  'groups': [
						{
						  'id': 25397178,
						  'name': 'Мужские мысли',
						  'screen_name': 'strog_pocan',
						  'is_closed': 0,
						  'type': 'page',
						  'is_admin': 0,
						  'is_member': 0,
						  'photo_50': 'http://cs409122.vk.me/v409122070/b992/iQ5ct6z-V3Y.jpg',
						  'photo_100': 'http://cs409122.vk.me/v409122070/b991/9IJpXZTZbuk.jpg',
						  'photo_200': 'http://cs409122.vk.me/v409122070/b98e/0uLRcwvxKQI.jpg'
						}
					  ]
					}
				  }";

			var cat = GetMockedFaveCategory(url, json);

			var posts = cat.GetPostsEx(3, 1);

			posts.Count.ShouldEqual(3);

			posts.WallPosts[0].Id.ShouldEqual(45611);
			posts.WallPosts[0].FromId.ShouldEqual(1);
			posts.WallPosts[0].Date.ShouldEqual(new DateTime(2014, 1, 21, 3, 35, 4));
			posts.WallPosts[0].PostType.ShouldEqual("post");
			posts.WallPosts[0].Text.ShouldEqual("ВКонтакте взял новую высоту — 60 миллионов человек за сутки.");
			posts.WallPosts[0].PostSource.Type.ShouldEqual("vk");
			posts.WallPosts[0].Comments.CanPost.ShouldEqual(false);
			posts.WallPosts[0].Comments.Count.ShouldEqual(0);
			posts.WallPosts[0].Likes.Count.ShouldEqual(81168);
			posts.WallPosts[0].Likes.UserLikes.ShouldEqual(true);
			posts.WallPosts[0].Likes.CanLike.ShouldEqual(false);
			posts.WallPosts[0].Likes.CanPublish.ShouldEqual(true);
			posts.WallPosts[0].Reposts.UserReposted.ShouldEqual(false);
			posts.WallPosts[0].Reposts.Count.ShouldEqual(4364);
			posts.WallPosts[0].Attachments.Count.ShouldEqual(1);

			var photo = posts.WallPosts[0].Attachments[0].Instance as Photo;
			photo.ShouldNotBeNull();
			photo.Id.ShouldEqual(320624027);
			photo.AlbumId.ShouldEqual(-7);
			photo.OwnerId.ShouldEqual(1);
			photo.Photo75.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945b/6JwHSc5wLGg.jpg"));
			photo.Photo130.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945c/xxlEPKAyYXM.jpg"));
			photo.Photo604.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945d/jvCKTR8CAHg.jpg"));
			photo.Photo807.ShouldEqual(new Uri("http://cs7004.vk.me/c540101/v540101001/945e/UUCwCY799wQ.jpg"));
			photo.Width.ShouldEqual(609);
			photo.Height.ShouldEqual(556);
			photo.Text.ShouldEqual(string.Empty);
			photo.CreateTime.ShouldEqual(new DateTime(2014, 1, 21, 3, 36, 5));
			photo.AccessKey.ShouldEqual("82b124d82eba43d66d");

			posts.Profiles[0].Id.ShouldEqual(1);
			posts.Profiles[0].FirstName.ShouldEqual("Павел");
			posts.Profiles[0].LastName.ShouldEqual("Дуров");
			posts.Profiles[0].Sex.ShouldEqual(Sex.Male);
			posts.Profiles[0].screenName.ShouldEqual("durov");
			posts.Profiles[0].PhotoPreviews.Photo50.ShouldEqual("http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg");
			posts.Profiles[0].PhotoPreviews.Photo100.ShouldEqual("http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg");
			posts.Profiles[0].Online.ShouldEqual(false);

			posts.Groups[0].Id.ShouldEqual(25397178);
			posts.Groups[0].Name.ShouldEqual("Мужские мысли");
			posts.Groups[0].ScreenName.ShouldEqual("strog_pocan");
			posts.Groups[0].IsClosed.ShouldEqual(GroupPublicity.Public);
			posts.Groups[0].Type.ShouldEqual(GroupType.Page);
			posts.Groups[0].IsAdmin.ShouldEqual(false);
			posts.Groups[0].IsMember.ShouldEqual(false);
			posts.Groups[0].PhotoPreviews.Photo50.ShouldEqual("http://cs409122.vk.me/v409122070/b992/iQ5ct6z-V3Y.jpg");
			posts.Groups[0].PhotoPreviews.Photo100.ShouldEqual("http://cs409122.vk.me/v409122070/b991/9IJpXZTZbuk.jpg");
			posts.Groups[0].PhotoPreviews.Photo200.ShouldEqual("http://cs409122.vk.me/v409122070/b98e/0uLRcwvxKQI.jpg");
		}
	}
}