using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Categories;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class StatsTest : BaseTest
	{
		private StatsCategory GetMockedStatsCategory(string url, string json)
		{
            Json = json;
            Url = url;
            return new StatsCategory(Api);
		}

		[Test]
		public void GetByApp_NormalCase()
		{
			const string url = "https://api.vk.com/method/stats.get?app_id=1&date_from=2015-11-11&v=5.44&access_token=";
			const string json =
				@"{
					response: [{
						day: '2015-11-11',
						views: 57,
						visitors: 42,
						subscribed: 2,
						unsubscribed: 21,
						sex: [{
							visitors: 26,
							value: 'f'
							}, {
							visitors: 16,
							value: 'm'
						}],
						age: [{
							visitors: 1,
							value: '12-18'
							}, {
							visitors: 2,
							value: '18-21'
							}, {
							visitors: 6,
							value: '21-24'
							}, {
							visitors: 4,
							value: '24-27'
							}, {
							visitors: 1,
							value: '27-30'
							}, {
							visitors: 6,
							value: '30-35'
							}, {
							visitors: 2,
							value: '35-45'
							}, {
							visitors: 12,
							value: '45-100'
						}],
						sex_age: [{
							visitors: 1,
							value: 'f;18-21'
							}, {
							visitors: 2,
							value: 'f;21-24'
							}, {
							visitors: 2,
							value: 'f;24-27'
							}, {
							visitors: 1,
							value: 'f;27-30'
							}, {
							visitors: 2,
							value: 'f;30-35'
							}, {
							visitors: 11,
							value: 'f;45-100'
							}, {
							visitors: 1,
							value: 'm;12-18'
							}, {
							visitors: 1,
							value: 'm;18-21'
							}, {
							visitors: 4,
							value: 'm;21-24'
							}, {
							visitors: 2,
							value: 'm;24-27'
							}, {
							visitors: 4,
							value: 'm;30-35'
							}, {
							visitors: 2,
							value: 'm;35-45'
							}, {
							visitors: 1,
							value: 'm;45-100'
						}],
						cities: [{
							visitors: 5,
							value: 2,
							name: 'Санкт-Петербург'
							}, {
							visitors: 4,
							value: 1,
							name: 'Москва'
							}, {
							visitors: 2,
							value: 147,
							name: 'Тюмень'
							}, {
							visitors: 2,
							value: 158,
							name: 'Челябинск'
							}, {
							visitors: 2,
							value: 151,
							name: 'Уфа'
							}, {
							visitors: 1,
							value: 133,
							name: 'Сочи'
							}, {
							visitors: 1,
							value: 273,
							name: 'Toronto'
							}, {
							visitors: 1,
							value: 157,
							name: 'Чебоксары'
							}, {
							visitors: 1,
							value: 3193,
							name: 'Шымкент'
							}, {
							visitors: 1,
							value: 2001,
							name: 'Первоуральск'
							}, {
							visitors: 1,
							value: 104,
							name: 'Омск'
							}, {
							visitors: 1,
							value: 545,
							name: 'Зеленодольск'
							}, {
							visitors: 1,
							value: 60,
							name: 'Казань'
							}, {
							visitors: 1,
							value: 468,
							name: 'Прокопьевск'
							}, {
							visitors: 1,
							value: 314,
							name: 'Киев'
							}, {
							visitors: 1,
							value: 130,
							name: 'Смоленск'
							}, {
							visitors: 1,
							value: 1143859,
							name: 'Тула'
							}, {
							visitors: 1,
							value: 66,
							name: 'Киров'
							}, {
							visitors: 1,
							value: 9196,
							name: 'Октябрьский'
							}, {
							visitors: 1,
							value: 503,
							name: 'Лодейное Поле'
							}, {
							visitors: 1,
							value: 20444,
							name: 'Кашин'
							}, {
							visitors: 1,
							value: 21856,
							name: 'Троицк'
							}, {
							visitors: 1,
							value: 326,
							name: 'Кандалакша'
						}],
						countries: [{
							visitors: 39,
							value: 1,
							code: 'RU',
							name: 'Россия'
							}, {
							visitors: 1,
							value: 9,
							code: 'US',
							name: 'США'
							}, {
							visitors: 1,
							value: 10,
							code: 'CA',
							name: 'Канада'
							}, {
							visitors: 1,
							value: 4,
							code: 'KZ',
							name: 'Казахстан'
						}]
					}]
				  }";
			var mockedStatsCategory = GetMockedStatsCategory(url, json);
			var statsPeriods = mockedStatsCategory.GetByApp(1, new DateTime(2015, 11, 11));

			Assert.That(statsPeriods[0].Day, Is.EqualTo(new DateTime(2015,11,11)));
			Assert.That(statsPeriods[0].Views, Is.EqualTo(57));
			Assert.That(statsPeriods[0].Visitors, Is.EqualTo(42));
			Assert.That(statsPeriods[0].Subscribed, Is.EqualTo(2));
			Assert.That(statsPeriods[0].Unsubscribed, Is.EqualTo(21));
			Assert.That(statsPeriods[0].Sex[0].Visitors, Is.EqualTo(26));
			Assert.That(statsPeriods[0].Sex[0].Value, Is.EqualTo(@"f"));

			Assert.That(statsPeriods[0].Age[0].Visitors, Is.EqualTo(1));
			Assert.That(statsPeriods[0].Age[0].Value, Is.EqualTo(@"12-18"));

			Assert.That(statsPeriods[0].SexAge[0].Visitors, Is.EqualTo(1));
			Assert.That(statsPeriods[0].SexAge[0].Value, Is.EqualTo(@"f;18-21"));
			
			Assert.That(statsPeriods[0].Cities[0].Visitors, Is.EqualTo(5));
			Assert.That(statsPeriods[0].Cities[0].Value, Is.EqualTo(@"2"));
			Assert.That(statsPeriods[0].Cities[0].Name, Is.EqualTo(@"Санкт-Петербург"));

			Assert.That(statsPeriods[0].Countries[0].Visitors, Is.EqualTo(39));
			Assert.That(statsPeriods[0].Countries[0].Value, Is.EqualTo(@"1"));
			Assert.That(statsPeriods[0].Countries[0].Code, Is.EqualTo(@"RU"));
			Assert.That(statsPeriods[0].Countries[0].Name, Is.EqualTo(@"Россия"));
		}

		[Test]
		public void GetByGroup_NormalCase()
		{
			const string url = "https://api.vk.com/method/stats.get?group_id=1&date_from=2015-11-11&v=5.44&access_token=";
			const string json =
				@"{
					response: [{
						day: '2015-11-11',
						views: 810,
						visitors: 647,
						reach: 428,
						reach_subscribers: 106,
						subscribed: 23,
						unsubscribed: 17,
						sex: [{
							visitors: 319,
							value: 'f'
							}, {
							visitors: 299,
							value: 'm'
						}],
						age: [{
							visitors: 222,
							value: '12-18'
							}, {
							visitors: 103,
							value: '18-21'
							}, {
							visitors: 67,
							value: '21-24'
							}, {
							visitors: 54,
							value: '24-27'
							}, {
							visitors: 31,
							value: '27-30'
							}, {
							visitors: 26,
							value: '30-35'
							}, {
							visitors: 11,
							value: '35-45'
							}, {
							visitors: 27,
							value: '45-100'
						}],
						sex_age: [{
							visitors: 137,
							value: 'f;12-18'
							}, {
							visitors: 50,
							value: 'f;18-21'
							}, {
							visitors: 28,
							value: 'f;21-24'
							}, {
							visitors: 19,
							value: 'f;24-27'
							}, {
							visitors: 14,
							value: 'f;27-30'
							}, {
							visitors: 13,
							value: 'f;30-35'
							}, {
							visitors: 6,
							value: 'f;35-45'
							}, {
							visitors: 10,
							value: 'f;45-100'
							}, {
							visitors: 85,
							value: 'm;12-18'
							}, {
							visitors: 53,
							value: 'm;18-21'
							}, {
							visitors: 39,
							value: 'm;21-24'
							}, {
							visitors: 35,
							value: 'm;24-27'
							}, {
							visitors: 17,
							value: 'm;27-30'
							}, {
							visitors: 13,
							value: 'm;30-35'
							}, {
							visitors: 5,
							value: 'm;35-45'
							}, {
							visitors: 17,
							value: 'm;45-100'
						}],
						cities: [{
							visitors: 31,
							value: 1,
							name: 'Москва'
							}, {
							visitors: 20,
							value: 2,
							name: 'Санкт-Петербург'
							}, {
							visitors: 19,
							value: 314,
							name: 'Киев'
							}, {
							visitors: 16,
							value: 183,
							name: 'Алматы'
							}, {
							visitors: 12,
							value: 3193,
							name: 'Шымкент'
							}, {
							visitors: 11,
							value: 282,
							name: 'Минск'
							}, {
							visitors: 7,
							value: 73,
							name: 'Красноярск'
							}, {
							visitors: 7,
							value: 49,
							name: 'Екатеринбург'
							}, {
							visitors: 6,
							value: 280,
							name: 'Харьков'
							}, {
							visitors: 6,
							value: 60,
							name: 'Казань'
							}, {
							visitors: 6,
							value: 110,
							name: 'Пермь'
							}, {
							visitors: 5,
							value: 706,
							name: 'Уральск'
							}, {
							visitors: 4,
							value: 1006,
							name: 'Актау'
							}, {
							visitors: 4,
							value: 37,
							name: 'Владивосток'
							}, {
							visitors: 4,
							value: 292,
							name: 'Одесса'
							}, {
							visitors: 3,
							value: 99,
							name: 'Новосибирск'
							}, {
							visitors: 3,
							value: 730,
							name: 'Тараз'
							}, {
							visitors: 3,
							value: 61,
							name: 'Калининград'
							}, {
							visitors: 3,
							value: 1517642,
							name: 'Кызылорда '
							}, {
							visitors: 3,
							value: 2201,
							name: 'Кировоград'
							}, {
							visitors: 3,
							value: 143,
							name: 'Тольятти'
							}, {
							visitors: 3,
							value: 41,
							name: 'Вологда'
							}, {
							visitors: 3,
							value: 25,
							name: 'Барнаул'
							}, {
							visitors: 3,
							value: 104,
							name: 'Омск'
							}, {
							visitors: 2,
							value: 552,
							name: 'Луганск'
							}, {
							visitors: 2,
							value: 2334,
							name: 'Белая Церковь'
						}],
						countries: [{
							visitors: 366,
							value: 1,
							code: 'RU',
							name: 'Россия'
							}, {
							visitors: 121,
							value: 4,
							code: 'KZ',
							name: 'Казахстан'
							}, {
							visitors: 112,
							value: 2,
							code: 'UA',
							name: 'Украина'
							}, {
							visitors: 28,
							value: 3,
							code: 'BY',
							name: 'Беларусь'
							}, {
							visitors: 3,
							value: 9,
							code: 'US',
							name: 'США'
							}, {
							visitors: 2,
							value: 18,
							code: 'UZ',
							name: 'Узбекистан'
							}, {
							visitors: 2,
							value: 192,
							code: 'TW',
							name: 'Тайвань'
							}, {
							visitors: 2,
							value: 15,
							code: 'MD',
							name: 'Молдова'
							}, {
							visitors: 1,
							value: 160,
							code: 'PL',
							name: 'Польша'
							}, {
							visitors: 1,
							value: 200,
							code: 'TR',
							name: 'Турция'
							}, {
							visitors: 1,
							value: 226,
							code: 'KR',
							name: 'Южная Корея'
							}, {
							visitors: 1,
							value: 65,
							code: 'DE',
							name: 'Германия'
							}, {
							visitors: 1,
							value: 17,
							code: 'TM',
							name: 'Туркменистан'
							}, {
							visitors: 1,
							value: 218,
							code: 'SE',
							name: 'Швеция'
							}, {
							visitors: 1,
							value: 14,
							code: 'EE',
							name: 'Эстония'
							}, {
							visitors: 1,
							value: 152,
							code: 'PK',
							name: 'Пакистан'
							}, {
							visitors: 1,
							value: 88,
							code: 'IT',
							name: 'Италия'
							}, {
							visitors: 1,
							value: 8,
							code: 'IL',
							name: 'Израиль'
						}]
					}]
				  }";
			var mockedStatsCategory = GetMockedStatsCategory(url, json);
			var statsPeriods = mockedStatsCategory.GetByGroup(1, new DateTime(2015, 11, 11));

			Assert.That(statsPeriods[0].Day, Is.EqualTo(new DateTime(2015, 11, 11)));
			Assert.That(statsPeriods[0].Views, Is.EqualTo(810));
			Assert.That(statsPeriods[0].Visitors, Is.EqualTo(647));
			Assert.That(statsPeriods[0].Reach, Is.EqualTo(428));
			Assert.That(statsPeriods[0].ReachSubscribers, Is.EqualTo(106));
			Assert.That(statsPeriods[0].Subscribed, Is.EqualTo(23));
			Assert.That(statsPeriods[0].Unsubscribed, Is.EqualTo(17));
			Assert.That(statsPeriods[0].Sex[0].Visitors, Is.EqualTo(319));
			Assert.That(statsPeriods[0].Sex[0].Value, Is.EqualTo(@"f"));

			Assert.That(statsPeriods[0].Age[0].Visitors, Is.EqualTo(222));
			Assert.That(statsPeriods[0].Age[0].Value, Is.EqualTo(@"12-18"));

			Assert.That(statsPeriods[0].SexAge[0].Visitors, Is.EqualTo(137));
			Assert.That(statsPeriods[0].SexAge[0].Value, Is.EqualTo(@"f;12-18"));

			Assert.That(statsPeriods[0].Cities[0].Visitors, Is.EqualTo(31));
			Assert.That(statsPeriods[0].Cities[0].Value, Is.EqualTo(@"1"));
			Assert.That(statsPeriods[0].Cities[0].Name, Is.EqualTo(@"Москва"));

			Assert.That(statsPeriods[0].Countries[0].Visitors, Is.EqualTo(366));
			Assert.That(statsPeriods[0].Countries[0].Value, Is.EqualTo(@"1"));
			Assert.That(statsPeriods[0].Countries[0].Code, Is.EqualTo(@"RU"));
			Assert.That(statsPeriods[0].Countries[0].Name, Is.EqualTo(@"Россия"));
		}

		[Test]
		public void TrackVisitorTest()
		{
			const string url = "https://api.vk.com/method/stats.trackVisitor?v=5.44&access_token=token";
			const string json =
				@"{
					response: 1
				  }";
			var mockedStatsCategory = GetMockedStatsCategory(url, json);
			var statsPeriods = mockedStatsCategory.TrackVisitor();

			Assert.That(statsPeriods, Is.True);
		}
	}
}