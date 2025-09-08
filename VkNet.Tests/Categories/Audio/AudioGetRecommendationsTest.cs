using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetRecommendationsTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact(DisplayName = "Get recommendations test")]
	public void GetRecommendationsTest()
	{
		Url = "https://api.vk.ru/method/audio.getRecommendations";

		ReadCategoryJsonPath(nameof(Api.Audio.GetRecommendations));

		var result = Api.Audio.GetRecommendations();
		var audio = result.FirstOrDefault();

		result.Should()
			.NotBeEmpty();

		audio.Should()
			.NotBeNull();
	}
}