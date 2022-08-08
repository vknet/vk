using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class DisableOnlineTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void DisableOnline()
	{
		Url = "https://api.vk.com/method/groups.disableOnline";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.DisableOnline(3);

		result.Should()
			.BeTrue();
	}
}