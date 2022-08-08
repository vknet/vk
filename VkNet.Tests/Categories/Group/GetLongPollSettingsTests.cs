using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GetLongPollSettingsTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void GetLongPollSettings()
	{
		Url = "https://api.vk.com/method/groups.getLongPollSettings";

		ReadCategoryJsonPath(nameof(GetLongPollSettings));

		var result = Api.Groups.GetLongPollSettings(123456);

		result.ApiVersion.Should()
			.Be("5.50");

		result.IsEnabled.Should()
			.BeTrue();

		result.Events.Should()
			.NotBeNull();
	}
}