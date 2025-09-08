using AwesomeAssertions;
using VkNet.Enums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetCategoriesTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetCategories()
	{
		Url = "https://api.vk.ru/method/ads.getCategories";

		ReadCategoryJsonPath(nameof(Api.Ads.GetCategories));

		var result = Api.Ads.GetCategories(Language.Ru);

		result.V1[0]
			.Name.Should()
			.Be("Авто/мото");
	}
}