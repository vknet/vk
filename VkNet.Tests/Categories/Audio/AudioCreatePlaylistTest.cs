using System.Collections.Generic;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	public class AudioCreatePlaylistTest : BaseTest
	{
		[Test]
		public void CreatePlaylistTest()
		{
			Url = "https://api.vk.com/method/audio.createPlaylist";

			Json = @"{
					  'response': {
					    'id': 11,
					    'owner_id': 123456789,
					    'type': 0,
					    'title': 'test title',
					    'description': 'test description',
					    'genres': [],
					    'count': 0,
					    'is_following': false,
					    'followers': 0,
					    'plays': 0,
					    'create_time': 1533694356,
					    'update_time': 1533694356,
					    'artists': []
					  }
					}";

			var result = Api.Audio.CreatePlaylist(123456789, "test title", "test description", new List<string> { "123456789_123456789" });

			Assert.NotNull(result);
			Assert.That(result.Id == 11);
			Assert.That(result.OwnerId == 123456789);
			Assert.That(result.Title == "test title");
			Assert.That(result.Description == "test description");
		}
	}
}