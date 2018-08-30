using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetPlaylistsTest : BaseTest
	{
		[Test]
		public void GetPlaylistsTest()
		{
			Url = "https://api.vk.com/method/audio.getPlaylists";

			Json = @"{
					  'response': {
					    'count': 3,
					    'items': [
					      {
					        'id': 4,
					        'owner_id': 178925712,
					        'type': 0,
					        'title': 'qw',
					        'description': '',
					        'genres': [],
					        'count': 1,
					        'is_following': false,
					        'followers': 0,
					        'plays': 0,
					        'create_time': 1533707035,
					        'update_time': 1533707056,
					        'thumbs': [
					          {
					            'photo_34': 'https://sun1-15.userapi.com/c841425/v841425912/8a05f/r3IHi42bs0s.jpg',
					            'photo_68': 'https://sun1-8.userapi.com/c841425/v841425912/8a05d/FKE7Z-aYqNQ.jpg',
					            'photo_135': 'https://sun1-6.userapi.com/c841425/v841425912/8a05b/hXyTouQ2tYQ.jpg',
					            'photo_270': 'https://sun1-9.userapi.com/c841425/v841425912/8a058/EIEJjUtFKfY.jpg',
					            'photo_300': 'https://sun1-16.userapi.com/c841425/v841425912/8a056/9jfeRirgwjw.jpg',
					            'photo_600': 'https://sun1-10.userapi.com/c841425/v841425912/8a053/EX4QuCRB0Ao.jpg',
					            'width': 300,
					            'height': 300
					          }
					        ],
					        'access_key': '40c45974d239fd1322',
					        'display_owner_ids': [
					          178925712
					        ],
					        'artists': []
					      }
					    ]
					  }
					}";

			var result = Api.Audio.GetPlaylists(123456789, 1);
			var playlist = result.FirstOrDefault();

			Assert.That(result.TotalCount, Is.EqualTo(3));
			Assert.IsNotEmpty(result);
			Assert.NotNull(playlist);
		}
	}
}