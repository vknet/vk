using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group;

public class EnableOnlineTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Test]
	[DisplayName("Enable online")]
	public void EnableOnline()
	{
		Url = "https://api.vk.ru/method/groups.enableOnline";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.EnableOnline(3);

		result.Should()
			.BeTrue();
	}
}