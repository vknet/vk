using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class Update : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact]
	public void EnableOnline()
	{
		Url = "https://api.vk.com/method/appWidgets.update";

		ReadJsonFile(JsonPaths.True);

		var result = Api.AppWidgets.Update("string", AppWidgetType.Donation);

		result.Should()
			.BeTrue();
	}
}