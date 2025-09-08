using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetPlaylistsTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact(DisplayName = "Get playlists test")]
	public void GetPlaylistsTest()
	{
		Url = "https://api.vk.ru/method/audio.getPlaylists";

		ReadCategoryJsonPath(nameof(Api.Audio.GetPlaylists));

		var result = Api.Audio.GetPlaylists(123456789, 1);
		var playlist = result.FirstOrDefault();

		result.TotalCount.Should()
			.Be(3);

		result.Should()
			.NotBeEmpty();

		playlist.Should()
			.NotBeNull();
	}
}