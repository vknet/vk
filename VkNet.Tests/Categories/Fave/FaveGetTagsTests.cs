using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Fave;

public class FaveGetTagsTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Fave";

	[Fact(DisplayName = "Get tags")]
	public void GetTags()
	{
		Url = "https://api.vk.ru/method/fave.getTags";
		ReadCategoryJsonPath(nameof(GetTags));

		var tags = Api.Fave.GetTags();

		var tag = tags.FirstOrDefault();

		tags.Should()
			.NotBeEmpty();

		tag.Should()
			.NotBeNull();
	}
}