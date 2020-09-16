using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioGetLyricsTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetLyricsTest()
		{
			Url = "https://api.vk.com/method/audio.getLyrics";

			ReadCategoryJsonPath(nameof(Api.Audio.GetLyrics));

			var result = Api.Audio.GetLyrics(416041990);

			Assert.That(result.Id, Is.EqualTo(416041990));
			Assert.That(result.Text, Is.EqualTo("test"));
		}
	}
}