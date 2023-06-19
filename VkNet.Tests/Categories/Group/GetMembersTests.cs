using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GetMembersTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Groups";

	[Fact]
	public void GetMembers()
	{
		Url = "https://api.vk.com/method/groups.getMembers";

		ReadCategoryJsonPath(nameof(GetMembers));

		var result = Api.Groups.GetMembers(new()
		{
			Filter = GroupsMemberFilters.Managers,
			GroupId = "187905748"
		});

		result.Should()
			.NotBeNull();
	}
}