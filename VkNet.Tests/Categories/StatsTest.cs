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
			const string url = "https://api.vk.com/method/stats.get";

			const string json =
				@"{
					response: [{
						period_from: '2013-09-08',
						period_to: '2013-09-08',
						visitors: {
							views: 3688,
							visitors: 2768,
							mobile_views: 130,
							sex: [
								{
									count: 339,
									value: 'f'
								},
								{
									count: 857,
									value: 'm'
								}
							],
							age: [
								{
									count: 326,
									value: '12-18'
								}
							],
							sex_age: [
								{
									count: 112,
									value: 'f;12-18'
								}
							],
							countries: [
								{
									count: 2372,
									value: 1,
									code: 'RU',
									name: 'Россия'
								}
							],
							cities: [
								{
									count: 303,
									value: 1,
									name: 'Москва'
								}
							]
						},
						reach: {
							reach: 458,
							reach_subscribers: 119,
							mobile_reach: 68,
							sex: [
								{
									count: 162,
									value: 'f'
								}
							],
							age: [
								{
									count: 130,
									value: '12-18'
								}
							],
							sex_age: [
								{
									count: 53,
									value: 'f;12-18'
								}
							],
							countries: [
								{
									count: 344,
									value: 1,
									code: 'RU',
									name: 'Россия'
								}
							],
							cities: [
								{
									count: 72,
									value: 1,
									name: 'Москва'
								}
							]
						},
						activity: {
							likes: 8,
							subscribed: 457,
							unsubscribed: 193
						}
					}]
				  }";

			var mockedStatsCategory = GetMockedStatsCategory(url, json);

			var statsPeriods = mockedStatsCategory.GetByApp(1,
				new DateTime(2015, 11, 11, 0, 0, 0, DateTimeKind.Utc));

			Assert.NotNull(statsPeriods[0]);
			Assert.That(new DateTime(2013, 09, 08), Is.EqualTo(statsPeriods[0].PeriodFrom));
		}

		[Test]
		public void GetByGroup_NormalCase()
		{
			const string url = "https://api.vk.com/method/stats.get";

			const string json =
				@"{
					response: [{
						period_from: '2013-09-08',
						period_to: '2013-09-08',
						visitors: {
							views: 3688,
							visitors: 2768,
							mobile_views: 130,
							sex: [
								{
									count: 339,
									value: 'f'
								},
								{
									count: 857,
									value: 'm'
								}
							],
							age: [
								{
									count: 326,
									value: '12-18'
								}
							],
							sex_age: [
								{
									count: 112,
									value: 'f;12-18'
								}
							],
							countries: [
								{
									count: 2372,
									value: 1,
									code: 'RU',
									name: 'Россия'
								}
							],
							cities: [
								{
									count: 303,
									value: 1,
									name: 'Москва'
								}
							]
						},
						reach: {
							reach: 458,
							reach_subscribers: 119,
							mobile_reach: 68,
							sex: [
								{
									count: 162,
									value: 'f'
								}
							],
							age: [
								{
									count: 130,
									value: '12-18'
								}
							],
							sex_age: [
								{
									count: 53,
									value: 'f;12-18'
								}
							],
							countries: [
								{
									count: 344,
									value: 1,
									code: 'RU',
									name: 'Россия'
								}
							],
							cities: [
								{
									count: 72,
									value: 1,
									name: 'Москва'
								}
							]
						},
						activity: {
							likes: 8,
							subscribed: 457,
							unsubscribed: 193
						}
					}]
				  }";

			var mockedStatsCategory = GetMockedStatsCategory(url, json);

			var statsPeriods = mockedStatsCategory.GetByGroup(1,
				new DateTime(2015, 11, 11, 0, 0, 0, DateTimeKind.Utc));

			Assert.NotNull(statsPeriods[0]);

			Assert.That(new DateTime(2013, 09, 08), Is.EqualTo(statsPeriods[0].PeriodFrom));
		}

		[Test]
		public void TrackVisitorTest()
		{
			const string url = "https://api.vk.com/method/stats.trackVisitor";

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