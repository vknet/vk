using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class CreateTargetGroupTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void CreateTargetGroup()
	{
		Url = "https://api.vk.com/method/ads.createTargetGroup";

		ReadCategoryJsonPath(nameof(Api.Ads.CreateTargetGroup));

		var result = Api.Ads.CreateTargetGroup(new()
		{
			AccountId = 1605245430,
			Name = "123123",
			Lifetime = 720
		});

		result.Id.Should()
			.Be(1488);
	}
}