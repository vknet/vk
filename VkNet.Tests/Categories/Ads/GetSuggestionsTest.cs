using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetSuggestionsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetSuggestions()
		{
			Url = "https://api.vk.com/method/ads.getSuggestions";

			ReadCategoryJsonPath(nameof(Api.Ads.GetSuggestions));

			var result = Api.Ads.GetSuggestions(new GetSuggestionsParams
			{
				Section = "schools",
				Country = 1,
				Cities = "1",
				Q = "1"
			});
			Assert.That(result[0].Id, Is.EqualTo(201187289));
		}
	}
}