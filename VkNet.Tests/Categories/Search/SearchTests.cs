using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Search;

public class SearchTests : CategoryBaseTest
{
	protected override string Folder => "Search";

	[Fact]
	public void GetHints()
	{
		Url = "https://api.vk.com/method/search.getHints";
		ReadCategoryJsonPath(nameof(GetHints));

		var result = Api.Search.GetHints(new());

		result.Should()
			.NotBeNull();
	}
}