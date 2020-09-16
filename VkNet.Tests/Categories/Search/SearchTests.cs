using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Search
{
	[TestFixture]

	public class SearchTests : CategoryBaseTest
	{
		protected override string Folder => "Search";

		[Test]
		public void GetHints()
		{
			Url = "https://api.vk.com/method/search.getHints";
			ReadCategoryJsonPath(nameof(GetHints));

			var result = Api.Search.GetHints(new SearchGetHintsParams());

			Assert.NotNull(result);
		}
	}
}