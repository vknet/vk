using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GetAddressesTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact(DisplayName = "Get addresses")]
	public void GetAddresses()
	{
		Url = "https://api.vk.ru/method/groups.getAddresses";

		ReadCategoryJsonPath(nameof(GetAddresses));

		var result = Api.Groups.GetAddresses(new()
		{
			GroupId = 165669449,
			AddressIds = [58227]
		});

		result.TotalCount.Should()
			.Be(3);
	}
}