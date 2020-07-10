using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioSearchTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void SearchTest()
		{
			Url = "https://api.vk.com/method/audio.search";

			ReadCategoryJsonPath(nameof(Api.Audio.Search));

			var result = Api.Audio.Search(new AudioSearchParams
			{
				Query = "test",
				Count = 1
			});

			Assert.IsNotEmpty(result);
		}
	}
}