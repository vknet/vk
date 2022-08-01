using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Polls;

public class PollsGetByIdTests : CategoryBaseTest
{
	protected override string Folder => "Polls";

	[Fact]
	public void GetById()
	{
		Url = "https://api.vk.com/method/polls.getById";

		ReadCategoryJsonPath("GetById");

		var result = Api.PollsCategory.GetById(new()
		{
			PollId = 123
		});

		result.Should()
			.NotBeNull();
	}
}