using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact(DisplayName = "Get test")]
	public void GetTest()
	{
		Url = "https://api.vk.ru/method/audio.get";

		ReadCategoryJsonPath(nameof(Api.Audio.Get));

		var result = Api.Audio.Get(new()
		{
			Count = 1
		});

		var audio = result.FirstOrDefault();

		result.Should()
			.NotBeEmpty();

		result.Should()
			.ContainSingle();

		audio.Should()
			.NotBeNull();
	}
}