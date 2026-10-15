using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group;

public class CreateTest : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Test]
	[DisplayName("Create")]
	public void Create()
	{
		Url = "https://api.vk.ru/method/groups.create";

		ReadCategoryJsonPath(nameof(Create));

		var result = Api.Groups.Create("Test_Group");

		result.Should()
			.NotBeNull();

		result.IsMember.Should()
			.BeTrue();
	}
}