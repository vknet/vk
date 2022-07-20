using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio
{
	public class GetPlaylistByIdTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Fact]
		public void GetPlaylistByIdTestTest()
		{
			Url = "https://api.vk.com/method/audio.getPlaylistById";

			ReadCategoryJsonPath(nameof(Api.Audio.GetPlaylistById));

			var result = Api.Audio.GetPlaylistById(-77288583, 84820009);

			result.Should().NotBeNull();
		}
	}
}