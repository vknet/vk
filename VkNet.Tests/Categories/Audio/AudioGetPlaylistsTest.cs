using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioGetPlaylistsTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetPlaylistsTest()
		{
			Url = "https://api.vk.com/method/audio.getPlaylists";

			ReadCategoryJsonPath(nameof(Api.Audio.GetPlaylists));

			var result = Api.Audio.GetPlaylists(123456789, 1);
			var playlist = result.FirstOrDefault();

			result.TotalCount.Should().Be(3);
			result.Should().NotBeEmpty();
			playlist.Should().NotBeNull();
		}
	}
}