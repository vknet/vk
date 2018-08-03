using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class AppsTest : BaseTest
	{
		[Test]
		public void DeleteAppRequests_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.deleteAppRequests";

			Json =
					@"{
					'response': 1
				  }";

			var app = Api.Apps.DeleteAppRequests();
			Assert.That(app, Is.True);
		}

		[Test]
		public void Get_NormalCase()
		{
			Url =
					"https://api.vk.com/method/apps.get";

			Json =
					@"{
					'response': {
						'count': 1,
						'items': [{
							'id': 4268118,
							'title': 'raventestapp',
							'icon_256': 'http://vk.com/images/dquestion_l.png',
							'icon_128': 'http://cs624017.vk.me/v624017123/47c4e/9Wx9pRA33yk.jpg',
							'icon_200': 'http://cs624017.vk.me/v624017123/47c4e/9Wx9pRA33yk.jpg',
							'icon_100': 'http://cs624017.vk.me/v624017123/47c4e/9Wx9pRA33yk.jpg',
							'icon_75': 'http://cs624017.vk.me/v624017123/47c4c/HaqH9hwhWQs.jpg',
							'icon_50': 'http://cs624017.vk.me/v624017123/47c4c/HaqH9hwhWQs.jpg',
							'icon_25': 'http://cs624017.vk.me/v624017123/47c4c/HaqH9hwhWQs.jpg',
							'banner_186': 'http://vk.com/images/dquestion_x.gif',
							'banner_896': 'http://vk.com/images/dquestion_t.png',
							'type': 'standalone',
							'author_url': 'http://vk.com/club103292418',
							'author_group': 103292418,
							'members_count': 3,
							'install_url': 'http://m.vk.com/app4268118?api_view=7658df7dd4b391d7746beb3f1d6791',
							'leaderboard_type': 1,
							'installed': true
						}]
					}
				  }";

			var app = Api.Apps.Get(new AppGetParams
			{
					AppIds = new ulong[] { 4268118 }
					, Platform = AppPlatforms.Web
			});

			Assert.That(app.TotalCount, Is.AtLeast(0));
			Assert.That(app.Apps.First().Title, Is.EqualTo("raventestapp"));
		}

		[Test]
		public void GetCatalog_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.getCatalog";

			Json =
					@"{
					'response': {
						'count': 8710,
						'items': [{
						'id': 5073227,
						'title': 'Подземелья!',
						'icon_256': 'http://cs629108.vd14/4_LCPn3f9xM.jpg',
						'icon_128': 'http://cs629108.vd13/Nyh0cl33tdo.jpg',
						'icon_200': 'http://cs629108.vd12/tDT8i2jKJxA.jpg',
						'icon_100': 'http://cs629108.vd12/tDT8i2jKJxA.jpg',
						'icon_75': 'http://cs629108.vd10/gEeNbWxy4VE.jpg',
						'icon_50': 'http://cs629108.vd10/gEeNbWxy4VE.jpg',
						'icon_25': 'http://cs629108.vd10/gEeNbWxy4VE.jpg',
						'banner_186': 'http://vk.com/images/dquestion_x.gif',
						'banner_896': 'http://cs629108.va7d/YTXfqXAxDH0.jpg',
						'description': 'Клановые битвы,
						десятки эпичных героев,
						коварные враги и полчища монстров,
						ПвП турниры и состязания каждый день!

						Все это и многое другое ждет вас в ""Подземельях""!',
						'screen_name': 'dungeons.game',
						'icon_16': 'http://cs629108.v129783/ff35539x.gif',
						'type': 'game',
						'section': 'Ролевые',
						'author_url': 'http://vk.com/club92779882',
						'author_group': 92779882,
						'members_count': 100046,
						'published_date': 1442855905,
						'is_new': 1,
						'install_url': 'http://m.vk.com/a...&source=catalog',
						'leaderboard_type': 0,
						'installed': 0
						}, {
						'id': 4864760,
						'title': 'Властелины стихий',
						'icon_256': 'http://cs629413.vc8c/YJjX-K80uoE.jpg',
						'icon_128': 'http://cs629413.vc8b/bPip_0Gqzbc.jpg',
						'icon_200': 'http://cs627122.v6bd/m3kRG2CyFhw.jpg',
						'icon_100': 'http://cs627122.v6bd/m3kRG2CyFhw.jpg',
						'icon_75': 'http://cs627122.v6bb/CixTWm1yU6Y.jpg',
						'icon_50': 'http://cs627122.v6bb/CixTWm1yU6Y.jpg',
						'icon_25': 'http://cs627122.v6bb/CixTWm1yU6Y.jpg',
						'banner_186': 'http://vk.com/images/dquestion_x.gif',
						'banner_896': 'http://cs629111.vc25/Sj8ZufFvyHI.jpg',
						'description': 'Срочно разыскиваются герои для борьбы со злом!

						Властелины стихий - это MMORPG с динамичными сражениями в реальном времени!

						Скорость, зрелищность, PvP-зоны, крутая графика – все это сочетают в себе ""Властелины стихий"". Готовься воевать за локации и мобов, управлять силами природы и стать частью удивительной истории.',
						'screen_name': 'app4864760',
						'icon_16': 'http://cs621624.v832474/43d3ed9x.gif',
						'type': 'game',
						'section': 'Ролевые',
						'author_url': 'http://vk.com/club100516174',
						'author_group': 100516174,
						'members_count': 73829,
						'published_date': 1440701743,
						'install_url': 'http://m.vk.com/a...&source=catalog',
						'leaderboard_type': 0,
						'installed': 0
						}]
						}
				  }";

			var app = Api.Apps.GetCatalog(new AppGetCatalogParams());
			Assert.That(app.TotalCount, Is.AtLeast(0));
			Assert.That(app.FirstOrDefault()?.Title, Is.EqualTo("Подземелья!"));
		}

		[Test]
		public void GetFriendsList_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.getFriendsList";

			Json =
					@"{
					'response': {
						'count': 130,
						'items': [310881357, 221634238, 72815776, 138230483, 228907945, 63838918, 229634083, 325170546, 131518798, 239679269, 114253497, 224688907, 319045109, 197866462, 204823258, 283140346, 74653727, 159042291, 241237764, 50894115]
					}
				  }";

			var app = Api.Apps.GetFriendsList(AppRequestType.Invite);
			Assert.That(app.TotalCount, Is.GreaterThan(0));
			Assert.That(app, Is.Not.Null);
		}

		[Test]
		public void GetFriendsListEx_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.getFriendsList";

			Json =
					@"{
					'response': {
						'count': 130,
						'items': [{
							'id': 221634238,
							'first_name': 'Александр',
							'last_name': 'Инютин'
						}, {
							'id': 72815776,
							'first_name': 'Антон',
							'last_name': 'Минаев'
						}, {
							'id': 138230483,
							'first_name': 'Юлия',
							'last_name': 'Войтенко'
						}, {
							'id': 228907945,
							'first_name': 'Владимир',
							'last_name': 'Карчков'
						}, {
							id: 63838918,
							first_name: 'Анастасия',
							last_name: 'Кирилина'
						}]
					}
				  }";

			var app = Api.Apps.GetFriendsList(AppRequestType.Invite, true, 5, 1, UsersFields.Online);
			Assert.That(app.TotalCount, Is.GreaterThan(0));
			Assert.That(app, Is.Not.Null);
		}

		[Test]
		public void GetLeaderboard_Extended()
		{
			Url = "https://api.vk.com/method/apps.getLeaderboard";

			Json =
					@"{
					'response': {
						'count': 130,
						'items': [{
							'score': 221634238,
							'points': 256,
							'user_id': 123
						}],
						'profiles': [{
							'id': 72815776,
							'first_name': 'Антон',
							'last_name': 'Минаев'
						}]
					}
				  }";

			var app = Api.Apps.GetLeaderboard(AppRatingType.Points, null, true);
			Assert.IsNotNull(app);
			Assert.That(app.Count, Is.EqualTo(130));
			Assert.That(app.Items, Is.Not.Empty);
			Assert.That(app.Items[0].Score, Is.EqualTo(221634238));
			Assert.That(app.Items[0].Points, Is.EqualTo(256));
			Assert.That(app.Items[0].UserId, Is.EqualTo(123));
			Assert.That(app.Profiles, Is.Not.Empty);
		}

		[Test]
		public void GetLeaderboard_Level()
		{
			Url = "https://api.vk.com/method/apps.getLeaderboard";

			Json =
					@"{
					'response': {
						'count': 130,
						'items': [{
							'score': 221634238,
							'level': 13,
							'user_id': 123
						}]
					}
				  }";

			var app = Api.Apps.GetLeaderboard(AppRatingType.Level);
			Assert.IsNotNull(app);
			Assert.That(app.Count, Is.EqualTo(130));
			Assert.That(app.Items, Is.Not.Empty);
			Assert.That(app.Items[0].Score, Is.EqualTo(221634238));
			Assert.That(app.Items[0].Level, Is.EqualTo(13));
			Assert.That(app.Items[0].UserId, Is.EqualTo(123));
		}

		[Test]
		public void GetLeaderboard_Points()
		{
			Url = "https://api.vk.com/method/apps.getLeaderboard";

			Json =
					@"{
					'response': {
						'count': 130,
						'items': [{
							'score': 221634238,
							'points': 256,
							'user_id': 123
						}]
					}
				  }";

			var app = Api.Apps.GetLeaderboard(AppRatingType.Points);
			Assert.IsNotNull(app);
			Assert.That(app.Count, Is.EqualTo(130));
			Assert.That(app.Items, Is.Not.Empty);
			Assert.That(app.Items[0].Score, Is.EqualTo(221634238));
			Assert.That(app.Items[0].Points, Is.EqualTo(256));
			Assert.That(app.Items[0].UserId, Is.EqualTo(123));
		}
	}
}