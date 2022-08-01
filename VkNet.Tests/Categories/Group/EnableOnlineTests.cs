using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class EnableOnlineTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void EnableOnline()
	{
		Url = "https://api.vk.com/method/groups.enableOnline";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.EnableOnline(3);

		result.Should()
			.BeTrue();
	}
}