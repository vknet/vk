using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudiogGetPopularTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetGetPopularTest()
		{
			Url = "https://api.vk.me/method/audio.getPopular";

			ReadCategoryJsonPath(nameof(Api.Audio.GetPopular));

			var response = Api.Audio.GetPopular(false, null, 0, 1).ToList();
			var audio = response.FirstOrDefault();

			Assert.IsNotEmpty(response);
			Assert.NotNull(audio);
			Assert.That(audio.Id, Is.EqualTo(456240861));
		}
	}
}