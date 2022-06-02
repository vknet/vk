using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioGetTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetTest()
		{
			Url = "https://api.vk.com/method/audio.get";

			ReadCategoryJsonPath(nameof(Api.Audio.Get));

			var result = Api.Audio.Get(new AudioGetParams
			{
				Count = 1
			});

			var audio = result.FirstOrDefault();

			result.Should().NotBeEmpty();
			result.Should().ContainSingle();
			audio.Should().NotBeNull();
		}
	}
}