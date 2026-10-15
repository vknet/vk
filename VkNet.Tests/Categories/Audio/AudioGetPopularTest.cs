using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetPopularTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Test]
	[DisplayName("Get get popular test")]
	public void GetGetPopularTest()
	{
		Url = "https://api.vk.ru/method/audio.getPopular";

		ReadCategoryJsonPath(nameof(Api.Audio.GetPopular));

		var response = Api.Audio.GetPopular(false, null, 0, 1)
			.ToList();

		var audio = response.FirstOrDefault();

		response.Should()
			.NotBeEmpty();

		audio.Should()
			.NotBeNull();

		audio.Id.Should()
			.Be(456240861);
	}
}