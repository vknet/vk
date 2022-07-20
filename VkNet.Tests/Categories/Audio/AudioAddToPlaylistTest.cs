using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio
{


	public class AudioAddToPlaylistTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Fact]
		public void AddToPlaylistTest()
		{
			Url = "https://api.vk.com/method/audio.addToPlaylist";

			ReadCategoryJsonPath(nameof(Api.Audio.AddToPlaylist));

			var result = Api.Audio.AddToPlaylist(123456789,
					1,
					new List<string>
					{
						"456239288",
						"456239289"
					})
				.ToList();

			result.Should().NotBeEmpty();
			result.Should().HaveCount(2);
		}
	}
}