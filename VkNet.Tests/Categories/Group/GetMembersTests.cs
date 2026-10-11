using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GetMembersTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Groups";

	[Fact(DisplayName = "Get members")]
	public void GetMembers()
	{
		Url = "https://api.vk.ru/method/groups.getMembers";

		ReadCategoryJsonPath(nameof(GetMembers));

		var result = Api.Groups.GetMembers(new()
		{
			Filter = GroupsMemberFilters.Managers,
			GroupId = "187905748"
		});

		result.Should()
			.NotBeNull();
		result.Should()
			.ContainSingle()
			.Which.Role.Should()
			.Be(ManagerRole.Creator);
	}

	[Fact(DisplayName = "Get donut members returns user ids")]
	public void GetMembers_Donut_ReturnsUserIds()
	{
		Url = "https://api.vk.ru/method/groups.getMembers";

		ReadCategoryJsonPath(nameof(GetMembers_Donut_ReturnsUserIds));

		var result = Api.Groups.GetMembers(new()
		{
			Filter = GroupsMemberFilters.Donut,
			GroupId = "187905748"
		});

		result.TotalCount.Should()
			.Be(1);
		result.Should()
			.ContainSingle()
			.Which.Id.Should()
			.Be(235052667);
	}
}
