using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioCreatePlaylistTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void CreatePlaylistTest()
		{
			Url = "https://api.vk.com/method/audio.createPlaylist";

			ReadCategoryJsonPath(nameof(Api.Audio.CreatePlaylist));

			var result = Api.Audio.CreatePlaylist(123456789, "test title", "test description", new List<string> { "123456789_123456789" });

			result.Should().NotBeNull();
			result.Id.Should().Be(11);
			result.OwnerId.Should().Be(123456789);
			result.Title.Should().Be("test title");
			result.Description.Should().Be("test description");
		}
	}
}