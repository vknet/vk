using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetRecommendationsTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetRecommendationsTest()
		{
			Url = "https://api.vk.me/method/audio.getRecommendations";

			ReadCategoryJsonPath(nameof(Api.Audio.GetRecommendations));

			var result = Api.Audio.GetRecommendations();
			var audio = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.NotNull(audio);
		}
	}
}