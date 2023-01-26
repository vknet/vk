using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class DeleteAdsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void DeleteAds()
	{
		Url = "https://api.vk.com/method/ads.deleteAds";

		ReadCategoryJsonPath(nameof(Api.Ads.DeleteAds));

		var a = new[]
		{
			"1",
			"2"
		};

		var result = Api.Ads.DeleteAds(new()
		{
			AccountId = 1605245430,
			Ids = a
		});

		result.Should()
			.HaveElementAt(0, true);

		result.Should()
			.HaveElementAt(1, true);
	}
}