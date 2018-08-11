using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	public class AudioGetRecommendationsTest : BaseTest
	{
		[Test]
		public void GetRecommendationsTest()
		{
			Url = "https://api.vk.com/method/audio.getRecommendations";

			Json =
				@"{
					'response': {
					    'count': 1000,
					    'items': [
					      {
					        'id': 456239580,
					        'owner_id': 182831620,
					        'artist': 'XXXTENTACION',
					        'title': 'Teeth (Interlude)',
					        'duration': 142,
					        'date': 1503772998,
					        'url': 'https://cs1-48v4.vkuseraudio.net/p14/7d64e96c523c8c.mp3?extra=nPDAPfL4yoczWw2BGfjX3NhLxdwPPoPW6gWAZIqvYWXTZM2LPyqNU7WbF6cMf6dmrT6eh1EAdKBTt9aupzjsJtOV8Hp5xqN7JhwLoV9pxqtXWsAFyepaETFGnekgeAng2Q4spFYB-QQ6vYw',
					        'genre_id': 18,
					        'is_licensed': true,
					        'is_hq': true,
					        'track_genre_id': 11,
					        'access_key': '38f83c0e5da522433a'
					      }
					    ]
					  }
					}";

			var result = Api.Audio.GetRecommendations();
			var audio = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.NotNull(audio);
		}
	}
}