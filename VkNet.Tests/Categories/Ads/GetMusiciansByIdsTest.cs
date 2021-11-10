using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	public class GetMusiciansByIdsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetMusiciansByIds()
		{
			Url = "https://api.vk.com/method/ads.getMusiciansByIds";

			ReadCategoryJsonPath(nameof(Api.Ads.GetMusiciansByIds));

			var result = Api.Ads.GetMusiciansByIds("1, 2, 3");
			Assert.That(result[0].Name, Is.EqualTo("UGLYBOY"));
			Assert.That(result[1].Name, Is.EqualTo("Rudesarcasmov"));
			Assert.That(result[2].Name, Is.EqualTo("Santiz"));
			Assert.That(result[1].Id, Is.EqualTo(2));
		}
	}
}