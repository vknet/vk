using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class CreateLookALikeRequestTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void CreateLookalikeRequest()
	{
		Url = "https://api.vk.com/method/ads.createLookalikeRequest";

		ReadCategoryJsonPath(nameof(Api.Ads.CreateLookalikeRequest));

		var officeUsers = Api.Ads.CreateLookalikeRequest(new()
		{
			AccountId = 1605245430,
			SourceType = SourceType.RetargetingGroup,
			RetargetingGroupId = 1
		});

		officeUsers.RequestId.Should()
			.Be(3667);
	}
}