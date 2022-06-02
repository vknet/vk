using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioSetBroadCastTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void SetBroadCastTest()
		{
			Url = "https://api.vk.com/method/audio.setBroadcast";

			ReadCategoryJsonPath(nameof(Api.Audio.SetBroadcast));

			var result = Api.Audio.SetBroadcast("123456789_123456789",
					new List<long>
					{
						123456789,
						123456789
					})
				.ToList();

			result.Should().NotBeEmpty();
			result.Should().HaveCount(2);
		}
	}
}