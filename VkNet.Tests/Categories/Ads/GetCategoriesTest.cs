using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetCategoriesTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetCategories()
		{
			Url = "https://api.vk.com/method/ads.getCategories";

			ReadCategoryJsonPath(nameof(Api.Ads.GetCategories));

			var result = Api.Ads.GetCategories(Language.Ru);

			Assert.That(result.V1[0].Name, Is.EqualTo("Авто/мото"));
		}
	}
}