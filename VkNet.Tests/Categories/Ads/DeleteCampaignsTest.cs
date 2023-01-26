using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class DeleteCampaignsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void DeleteCampaigns()
	{
		Url = "https://api.vk.com/method/ads.deleteCampaigns";

		ReadCategoryJsonPath(nameof(Api.Ads.DeleteCampaigns));

		var a = new[]
		{
			"1",
			"2"
		};

		var result = Api.Ads.DeleteCampaigns(new()
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