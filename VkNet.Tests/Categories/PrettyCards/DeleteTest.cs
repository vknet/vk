using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.PrettyCards;

public class DeleteTest : CategoryBaseTest
{
	protected override string Folder => "PrettyCards";

	[Fact]
	public void Delete()
	{
		Url = "https://api.vk.com/method/prettyCards.delete";

		ReadCategoryJsonPath(nameof(Api.PrettyCards.Delete));

		var result = Api.PrettyCards.Delete(new()
		{
			OwnerId = -126102803,
			CardId = "1488"
		});

		result.Should()
			.NotBeNull();

		result.CardId.Should()
			.Be("1488");

		result.OwnerId.Should()
			.Be(-126102803);
	}
}