using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetTargetGroupsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetTargetGroups()
	{
		Url = "https://api.vk.com/method/ads.getTargetGroups";

		ReadCategoryJsonPath(nameof(Api.Ads.GetTargetGroups));

		var result = Api.Ads.GetTargetGroups(123);

		result[0]
			.Name.Should()
			.Be("Test1");
	}
}