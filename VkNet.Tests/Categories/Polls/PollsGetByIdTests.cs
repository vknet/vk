using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Polls;

public class PollsGetByIdTests : CategoryBaseTest
{
	protected override string Folder => "Polls";

	[Test]
	[DisplayName("Get by id")]
	public void GetById()
	{
		Url = "https://api.vk.ru/method/polls.getById";

		ReadCategoryJsonPath("GetById");

		var result = Api.PollsCategory.GetById(new()
		{
			PollId = 123
		});

		result.Should()
			.NotBeNull();
	}
}