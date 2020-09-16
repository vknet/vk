using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetFloodStatsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetFloodStats()
		{
			Url = "https://api.vk.com/method/ads.getFloodStats";

			ReadCategoryJsonPath(nameof(Api.Ads.GetFloodStats));

			var result = Api.Ads.GetFloodStats(123213);

			Assert.That(result.Left, Is.EqualTo(4998));
		}
	}
}