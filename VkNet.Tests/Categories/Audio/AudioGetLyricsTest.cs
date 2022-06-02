using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio
{


	public class AudioGetLyricsTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Fact]
		public void GetLyricsTest()
		{
			Url = "https://api.vk.com/method/audio.getLyrics";

			ReadCategoryJsonPath(nameof(Api.Audio.GetLyrics));

			var result = Api.Audio.GetLyrics(416041990);

			result.Id.Should().Be(416041990);
			result.Text.Should().Be("test");
		}
	}
}