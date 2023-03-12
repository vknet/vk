using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Polls;

public class GetBackgroundsTest : CategoryBaseTest
{
	protected override string Folder => "Polls";

	[Fact]
	public void GetBackgrounds()
	{
		Url = "https://api.vk.com/method/polls.getBackgrounds";

		ReadCategoryJsonPath(nameof(Api.PollsCategory.GetBackgrounds));

		var result = Api.PollsCategory.GetBackgrounds();

		result[0]
			.Type.Should().Be(PollBackgroundType.Gradient);

		result[0]
			.Angle.Should()
			.Be("225");

		result[0]
			.Points[0]
			.Color.Should()
			.Be("f24973");

		result[0]
			.Points[0]
			.Position.Should()
			.Be(0);

		result[1]
			.Type.Should().Be(PollBackgroundType.Gradient);

		result[1]
			.Angle.Should()
			.Be("180");

		result[1]
			.Points[1]
			.Color.Should()
			.Be("2f733f");

		result[1]
			.Points[1]
			.Position.Should()
			.Be(1);
	}
}