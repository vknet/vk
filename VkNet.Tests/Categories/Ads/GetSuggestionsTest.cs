using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class GetSuggestionsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
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
			result[0].Id.Should().Be(201187289);
		}
	}
}