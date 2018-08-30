using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetLyricsTest : BaseTest
	{
		[Test]
		public void GetLyricsTest()
		{
			Url = "https://api.vk.com/method/audio.getLyrics";

			Json = @"{
				'response': {
					'lyrics_id': 416041990,
					'text': 'test'
						}
					}";

			var result = Api.Audio.GetLyrics(416041990);

			Assert.That(result.Id, Is.EqualTo(416041990));
			Assert.That(result.Text, Is.EqualTo("test"));
		}
	}
}