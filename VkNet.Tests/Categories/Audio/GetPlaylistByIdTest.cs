using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	public class GetPlaylistByIdTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetPlaylistByIdTestTest()
		{
			Url = "https://api.vk.com/method/audio.getPlaylistById";

			ReadCategoryJsonPath(nameof(Api.Audio.GetPlaylistById));

			var result = Api.Audio.GetPlaylistById(-77288583, 84820009);

			result.Should().NotBeNull();
		}
	}
}