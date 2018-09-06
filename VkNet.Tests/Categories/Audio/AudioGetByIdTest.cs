using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetByIdTest : BaseTest
	{
		[Test]
		public void GetByIdTest()
		{
			Url = "https://api.vk.com/method/audio.getById";

			Json = @"{
					  'response': [
					    {
					      'id': 456239281,
					      'owner_id': 465742902,
					      'artist': 'mtbrd',
					      'title': 'The Inclination',
					      'duration': 148,
					      'date': 1533161066,
					      'url': 'https://cs1-41v4.vkuseraudio.net/p14/cb9f580c4052be.mp3',
					      'album': {
					        'id': 3096557,
					        'owner_id': -2000096557,
					        'title': 'Smoovies',
					        'access_key': '8dadc3f2f41fe0f4bb',
					        'thumb': {
					          'photo_34': 'https://sun1-2.userapi.com/c844320/v844320780/6bc98/tmJjthw48A4.jpg',
					          'photo_68': 'https://sun1-14.userapi.com/c844320/v844320780/6bc96/Sf1wE3NDmXA.jpg',
					          'photo_135': 'https://sun1-10.userapi.com/c844320/v844320780/6bc94/sw92o4JaZ9A.jpg',
					          'photo_270': 'https://sun1-2.userapi.com/c844320/v844320780/6bc91/K5-Yz4e4ouE.jpg',
					          'photo_300': 'https://sun1-5.userapi.com/c844320/v844320780/6bc8f/zMK6IgnDqUY.jpg',
					          'photo_600': 'https://sun1-19.userapi.com/c844320/v844320780/6bc8c/8LIJSGHgZfw.jpg',
					          'width': 300,
					          'height': 300
					        }
					      },
					      'is_licensed': true,
					      'is_hq': true,
					      'track_genre_id': 14,
					      'access_key': '2a268ea8bbc9e58945'
					    }
					  ]
					}";

			var result = Api.Audio.GetById(new List<string> { "465742902_456239281" }).ToList();
			var audio = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.NotNull(audio);
		}
	}
}