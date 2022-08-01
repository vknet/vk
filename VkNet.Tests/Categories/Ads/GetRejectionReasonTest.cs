using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetRejectionReasonTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetRejectionReason()
	{
		Url = "https://api.vk.com/method/ads.getRejectionReason";

		ReadCategoryJsonPath(nameof(Api.Ads.GetRejectionReason));

		var result = Api.Ads.GetRejectionReason(123, 123);

		result.Comment.Should()
			.Be("123");
	}
}