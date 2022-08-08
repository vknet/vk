using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GetRequestsTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void GetRequests_With_Fields()
	{
		Url = "https://api.vk.com/method/groups.getRequests";

		ReadCategoryJsonPath(nameof(GetRequests_With_Fields));

		var result = Api.Groups.GetRequests(1, null, null, UsersFields.LastSeen);

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveCount(3);

		result.Should()
			.AllSatisfy(user => user.Should()
				.NotBeNull());
	}

	[Fact]
	public void GetRequests_Without_Fields()
	{
		Url = "https://api.vk.com/method/groups.getRequests";

		ReadCategoryJsonPath(nameof(GetRequests_Without_Fields));

		var result = Api.Groups.GetRequests(1);

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveCount(3);

		result.Should()
			.AllSatisfy(user => user.Should()
				.NotBeNull());
	}
}