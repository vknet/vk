using System.Linq;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Fave;

public class FaveGetPagesTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Fave";

	[Fact]
	public void GetPages()
	{
		Url = "https://api.vk.com/method/fave.getPages";
		ReadCategoryJsonPath(nameof(GetPages));

		var pages = Api.Fave.GetPages(FavePageType.Users);
		var page = pages.FirstOrDefault();

		pages.Should()
			.NotBeEmpty();

		page.Should()
			.NotBeNull();
	}
}