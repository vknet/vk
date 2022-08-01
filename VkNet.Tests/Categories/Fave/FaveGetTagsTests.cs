using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Fave;

public class FaveGetTagsTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Fave";

	[Fact]
	public void GetTags()
	{
		Url = "https://api.vk.com/method/fave.getTags";
		ReadCategoryJsonPath(nameof(GetTags));

		var tags = Api.Fave.GetTags();

		var tag = tags.FirstOrDefault();

		tags.Should()
			.NotBeEmpty();

		tag.Should()
			.NotBeNull();
	}
}