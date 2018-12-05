using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetBroadcastListTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetBroadcastListTest()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList";

			ReadCategoryJsonPath(nameof(Api.Audio.GetBroadcastList));

			var result = Api.Audio.GetBroadcastList().ToList();
			var Object = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.NotNull(Object);
		}
	}
}