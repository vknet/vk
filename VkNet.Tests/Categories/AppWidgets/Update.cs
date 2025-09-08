using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class Update : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact(DisplayName = "Enable online")]
	public void EnableOnline()
	{
		Url = "https://api.vk.ru/method/appWidgets.update";

		ReadJsonFile(JsonPaths.True);

		var result = Api.AppWidgets.Update("string", AppWidgetType.Donation);

		result.Should()
			.BeTrue();
	}
}