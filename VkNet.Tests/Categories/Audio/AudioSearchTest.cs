using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio;

public class AudioSearchTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Test]
	[DisplayName("Search test")]
	public void SearchTest()
	{
		Url = "https://api.vk.ru/method/audio.search";

		ReadCategoryJsonPath(nameof(Api.Audio.Search));

		var result = Api.Audio.Search(new()
		{
			Query = "test",
			Count = 1
		});

		result.Should()
			.NotBeEmpty();
	}
}