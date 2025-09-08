using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class DisableOnlineTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact(DisplayName = "Disable online")]
	public void DisableOnline()
	{
		Url = "https://api.vk.ru/method/groups.disableOnline";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.DisableOnline(3);

		result.Should()
			.BeTrue();
	}
}