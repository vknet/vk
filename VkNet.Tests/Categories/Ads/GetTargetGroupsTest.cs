using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetTargetGroupsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetTargetGroups()
		{
			Url = "https://api.vk.com/method/ads.getTargetGroups";

			ReadCategoryJsonPath(nameof(Api.Ads.GetTargetGroups));

			var result = Api.Ads.GetTargetGroups(123);
			Assert.That(result[0].Name, Is.EqualTo("Test1"));
		}
	}
}