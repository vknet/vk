using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class StatsTest : CategoryBaseTest
	{
		protected override string Folder => "Stats";

		[Test]
		public void GetByApp_NormalCase()
		{
			Url = "https://api.vk.com/method/stats.get";
			ReadCategoryJsonPath(nameof(GetByApp_NormalCase));

			var statsPeriods = Api.Stats.Get(new StatsGetParams
			{
				AppId = 1,
				TimestampTo = new DateTime(2015,
					11,
					11,
					0,
					0,
					0,
					DateTimeKind.Utc)
			});

			Assert.NotNull(statsPeriods[0]);
			Assert.That(new DateTime(2013, 09, 08), Is.EqualTo(statsPeriods[0].PeriodFrom));
		}

		[Test]
		public void GetByGroup_EmptyActivityCase()
		{
			Url = "https://api.vk.com/method/stats.get";
			ReadCategoryJsonPath(nameof(GetByGroup_EmptyActivityCase));

			var statsPeriods = Api.Stats.Get(new StatsGetParams
			{
				GroupId = 1,
				TimestampFrom = new DateTime(2015,
					11,
					11,
					0,
					0,
					0,
					DateTimeKind.Utc)
			});

			Assert.NotNull(statsPeriods[0]);
			Assert.Null(statsPeriods[0].Activity);

			Assert.That(new DateTime(2013, 09, 08), Is.EqualTo(statsPeriods[0].PeriodFrom));
		}

		[Test]
		public void GetByGroup_NormalCase()
		{
			Url = "https://api.vk.com/method/stats.get";
			ReadCategoryJsonPath(nameof(GetByGroup_NormalCase));

			var statsPeriods = Api.Stats.Get(new StatsGetParams
			{
				GroupId = 1,
				TimestampFrom = new DateTime(2015,
					11,
					11,
					0,
					0,
					0,
					DateTimeKind.Utc)
			});

			Assert.NotNull(statsPeriods[0]);

			Assert.That(new DateTime(2013, 09, 08), Is.EqualTo(statsPeriods[0].PeriodFrom));
		}

		[Test]
		public void TrackVisitorTest()
		{
			Url = "https://api.vk.com/method/stats.trackVisitor";
			ReadJsonFile(JsonPaths.True);

			var statsPeriods = Api.Stats.TrackVisitor();

			Assert.That(statsPeriods, Is.True);
		}
	}
}