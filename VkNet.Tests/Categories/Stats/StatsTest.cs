using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Stats
{

	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class StatsTest : CategoryBaseTest
	{
		protected override string Folder => "Stats";

		[Fact]
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

			statsPeriods[0].Should().NotBeNull();
			statsPeriods[0].PeriodFrom.Should().Be(new DateTime(2013, 09, 08));
		}

		[Fact]
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

			statsPeriods[0].Should().NotBeNull();
			statsPeriods[0].Activity.Should().BeNull();

			statsPeriods[0].PeriodFrom.Should().Be(new DateTime(2013, 09, 08));
		}

		[Fact]
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

			statsPeriods[0].Should().NotBeNull();

			statsPeriods[0].PeriodFrom.Should().Be(new DateTime(2013, 09, 08));
		}

		[Fact]
		public void TrackVisitorTest()
		{
			Url = "https://api.vk.com/method/stats.trackVisitor";
			ReadJsonFile(JsonPaths.True);

			var statsPeriods = Api.Stats.TrackVisitor();

			statsPeriods.Should().BeTrue();
		}
	}
}