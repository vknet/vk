using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioGetBroadcastListTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetBroadcastListTest()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList";

			ReadCategoryJsonPath(nameof(Api.Audio.GetBroadcastList));

			var result = Api.Audio.GetBroadcastList().ToList();
			var firstOrDefault = result.FirstOrDefault();

			result.Should().NotBeEmpty();
			firstOrDefault.Should().NotBeNull();
		}
	}
}