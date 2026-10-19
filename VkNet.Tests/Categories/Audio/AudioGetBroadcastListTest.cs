using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetBroadcastListTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Test]
	[DisplayName("Get broadcast list test")]
	public void GetBroadcastListTest()
	{
		Url = "https://api.vk.ru/method/audio.getBroadcastList";

		ReadCategoryJsonPath(nameof(Api.Audio.GetBroadcastList));

		var result = Api.Audio.GetBroadcastList()
			.ToList();

		var firstOrDefault = result.FirstOrDefault();

		result.Should()
			.NotBeEmpty();

		firstOrDefault.Should()
			.NotBeNull();
	}
}