using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetPopularTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact]
	public void GetGetPopularTest()
	{
		Url = "https://api.vk.com/method/audio.getPopular";

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