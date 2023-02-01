using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class SetLongPollSettingsTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void SetLongPollSettings()
	{
		Url = "https://api.vk.com/method/groups.setLongPollSettings";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.SetLongPollSettings(new());

		result.Should()
			.BeTrue();
	}
}