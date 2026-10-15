using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.PrettyCards;

public class EditTest : CategoryBaseTest
{
	protected override string Folder => "PrettyCards";

	[Test]
	[DisplayName("Edit")]
	public void Edit()
	{
		Url = "https://api.vk.ru/method/prettyCards.edit";

		ReadCategoryJsonPath(nameof(Api.PrettyCards.Edit));

		var result = Api.PrettyCards.Edit(new()
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