using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Fave;

public class FaveAddTagTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Fave";

	[Fact(DisplayName = "Add tag")]
	public void AddTag()
	{
		Url = "https://api.vk.ru/method/fave.addTag";

		ReadCategoryJsonPath(nameof(AddTag));

		var tag = Api.Fave.AddTag("Важное", null);

		tag.Should()
			.NotBeNull();
	}
}