using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioAddToPlaylistTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void AddToPlaylistTest()
		{
			Url = "https://api.vk.com/method/audio.addToPlaylist";

			ReadCategoryJsonPath(nameof(Api.Audio.AddToPlaylist));

			var result = Api.Audio.AddToPlaylist(123456789,
					1,
					new List<string>
					{
						"456239288",
						"456239289"
					})
				.ToList();

			Assert.IsNotEmpty(result);
			Assert.That(result.Count, Is.EqualTo(2));
		}
	}
}