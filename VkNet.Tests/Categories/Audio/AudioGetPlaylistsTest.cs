using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetPlaylistsTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetPlaylistsTest()
		{
			Url = "https://api.vk.me/method/audio.getPlaylists";

			ReadCategoryJsonPath(nameof(Api.Audio.GetPlaylists));

			var result = Api.Audio.GetPlaylists(123456789, 1);
			var playlist = result.FirstOrDefault();

			Assert.That(result.TotalCount, Is.EqualTo(3));
			Assert.IsNotEmpty(result);
			Assert.NotNull(playlist);
		}
	}
}