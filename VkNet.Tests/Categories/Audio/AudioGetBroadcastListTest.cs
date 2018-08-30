using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetBroadcastListTest : BaseTest
	{
		[Test]
		public void GetBroadcastListTest()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList";

			Json = @"{
					  'response': [
					    {
					      'id': 123456789,
					      'name': 'Test',
					      'screen_name': 'test',
					      'is_closed': 0,
					      'type': 'page',
					      'is_admin': 1,
					      'admin_level': 3,
					      'is_member': 1,
					      'photo_50': 'https://vk.com/images/community_50.png?ava=1',
					      'photo_100': 'https://vk.com/images/community_100.png?ava=1',
					      'photo_200': 'https://vk.com/images/community_200.png?ava=1',
					      'status_audio': {
					        'id': 456239281,
					        'owner_id': 123456789,
					        'artist': 'mtbrd',
					        'title': 'The Inclination',
					        'duration': 148,
					        'date': 1533161066,
					        'url': 'https://cs1-41v4.vkuseraudio.net/p14/19d125df879d9a.mp3?extra=sYuaB4IKRa_F00nGKBcYHSqRVqfa618dHihpHS3FtGLw5yJLGxFXH1ilQ5b9LYhdXotFzWfS_578cadBvHWHNap8O-CKa_6rBghVnvAdjStwEPagOiYDUK9s8xUuZofBE4-ws06eFN4RKbI',
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
					    }
					  ]
					}";

			var result = Api.Audio.GetBroadcastList().ToList();
			var Object = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.NotNull(Object);
		}
	}
}