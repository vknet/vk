using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioAddToPlaylistTest : BaseTest
	{
		[Test]
		public void AddToPlaylistTest()
		{
			Url = "https://api.vk.com/method/audio.addToPlaylist";

			Json = @"{
					  'response': [
					    {
					      'audio_id': 456239288
					    },
					    {
					      'audio_id': 456239289
					    }
					  ]
					}";

			var result = Api.Audio.AddToPlaylist(123456789,
					1,
					new List<long>
					{
						456239288,
						456239289
					})
				.ToList();

			Assert.IsNotEmpty(result);
			Assert.That(result.Count, Is.EqualTo(2));
		}
	}
}