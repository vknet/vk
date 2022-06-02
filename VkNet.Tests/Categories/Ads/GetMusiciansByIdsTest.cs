using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{

	public class GetMusiciansByIdsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void GetMusiciansByIds()
		{
			Url = "https://api.vk.com/method/ads.getMusiciansByIds";

			ReadCategoryJsonPath(nameof(Api.Ads.GetMusiciansByIds));

			var result = Api.Ads.GetMusiciansByIds("1, 2, 3");
			result[0].Name.Should().Be("UGLYBOY");
			result[1].Name.Should().Be("Rudesarcasmov");
			result[2].Name.Should().Be("Santiz");
			result[1].Id.Should().Be(2);
		}
	}
}