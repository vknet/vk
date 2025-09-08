using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetRejectionReasonTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact(DisplayName = "Get rejection reason")]
	public void GetRejectionReason()
	{
		Url = "https://api.vk.ru/method/ads.getRejectionReason";

		ReadCategoryJsonPath(nameof(Api.Ads.GetRejectionReason));

		var result = Api.Ads.GetRejectionReason(123, 123);

		result.Comment.Should()
			.Be("123");
	}
}