using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetLyricsTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact(DisplayName = "Get lyrics test")]
	public void GetLyricsTest()
	{
		Url = "https://api.vk.ru/method/audio.getLyrics";

		ReadCategoryJsonPath(nameof(Api.Audio.GetLyrics));

		var result = Api.Audio.GetLyrics(416041990);

		result.Id.Should()
			.Be(416041990);

		result.Text.Should()
			.Be("test");
	}
}