using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudiogGetPopularTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetGetPopularTest()
		{
			Url = "https://api.vk.com/method/audio.getPopular";

			ReadCategoryJsonPath(nameof(Api.Audio.GetPopular));

			var response = Api.Audio.GetPopular(false, null, 0, 1).ToList();
			var audio = response.FirstOrDefault();

			Assert.IsNotEmpty(response);
			audio.Should().NotBeNull();
			Assert.That(audio.Id, Is.EqualTo(456240861));
		}
	}
}