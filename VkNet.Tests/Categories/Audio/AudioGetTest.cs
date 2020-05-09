using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetTest()
		{
			Url = "https://api.vk.me/method/audio.get";

			ReadCategoryJsonPath(nameof(Api.Audio.Get));

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