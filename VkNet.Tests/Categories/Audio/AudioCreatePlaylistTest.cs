using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioCreatePlaylistTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void CreatePlaylistTest()
		{
			Url = "https://api.vk.com/method/audio.createPlaylist";

			ReadCategoryJsonPath(nameof(Api.Audio.CreatePlaylist));

			var result = Api.Audio.CreatePlaylist(123456789, "test title", "test description", new List<string> { "123456789_123456789" });

			Assert.NotNull(result);
			Assert.That(result.Id, Is.EqualTo(11));
			Assert.That(result.OwnerId, Is.EqualTo(123456789));
			Assert.That(result.Title, Is.EqualTo("test title"));
			Assert.That(result.Description, Is.EqualTo("test description"));
		}
	}
}