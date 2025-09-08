using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Search;

public class SearchTests : CategoryBaseTest
{
	protected override string Folder => "Search";

	[Fact(DisplayName = "Get hints")]
	public void GetHints()
	{
		Url = "https://api.vk.ru/method/search.getHints";
		ReadCategoryJsonPath(nameof(GetHints));

		var result = Api.Search.GetHints(new());

		result.Should()
			.NotBeNull();
	}
}