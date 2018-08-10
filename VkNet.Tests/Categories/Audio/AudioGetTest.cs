using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Audio
{
	public class AudioGetTest : BaseTest
	{
		[Test]
		public void GetTest()
		{
			Url = "https://api.vk.com/method/audio.get";

			Json =
				@"{
				  'response': {
				    'count': 100,
				    'items': [
				      {
				        'id': 456239289,
				        'owner_id': 123456789,
				        'artist': 'Nothing,Nowhere.',
				        'title': 'Hopes Up feat. Dashboard Confessional',
				        'duration': 253,
				        'date': 1533756259,
				        'url': 'https://cs1-72v4.vkuseraudio.net/p24/4e7a63b5903e4c.mp3?extra=BNVert6gKlLJr2HRgwJWBrf2-C8kF7MLprt7ZNFdMbqZnPG4WOi_y8fz86vuwX32unDoZN7CBdVsFJaQK7PXqJOOqjJ3MNroWROMpCD_hQL-QXSK2lWY6ob4hnthlmSQ8NsUqrdL2gfn8mc',
				        'album': {
				          'id': 1916788,
				          'owner_id': -2000916788,
				          'title': 'Reaper',
				          'access_key': '05504b9eb5c711e87c',
				          'thumb': {
				            'photo_34': 'https://sun1-11.userapi.com/c841135/v841135318/2ba8c/RZwS63TqTLY.jpg',
				            'photo_68': 'https://sun1-12.userapi.com/c841135/v841135318/2ba8a/e--OfCnR0uU.jpg',
				            'photo_135': 'https://sun1-17.userapi.com/c841135/v841135318/2ba88/sLsi_YoR5r0.jpg',
				            'photo_270': 'https://sun1-3.userapi.com/c841135/v841135318/2ba85/j_xH14RP6wE.jpg',
				            'photo_300': 'https://sun1-17.userapi.com/c841135/v841135318/2ba83/IEmRKd82oaY.jpg',
				            'photo_600': 'https://sun1-10.userapi.com/c841135/v841135318/2ba82/ztIVWFpndh4.jpg',
				            'width': 300,
				            'height': 300
				          }
				        },
				        'is_licensed': true,
				        'is_hq': true,
				        'track_genre_id': 11,
				        'access_key': '44551e096b29dada1a'
				      }
				    ]
				  }
				}";

			var result = Api.Audio.Get(new AudioGetParams
			{
				Count = 1
			});

			var audio = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.That(result.Count, Is.EqualTo(1));
			Assert.NotNull(audio);
		}
	}
}