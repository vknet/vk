using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioSetBroadCastTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void SetBroadCastTest()
		{
			Url = "https://api.vk.me/method/audio.setBroadcast";

			ReadCategoryJsonPath(nameof(Api.Audio.SetBroadcast));

			var result = Api.Audio.SetBroadcast("123456789_123456789",
					new List<long>
					{
						123456789,
						123456789
					})
				.ToList();

			Assert.IsNotEmpty(result);
			Assert.That(result.Count, Is.EqualTo(2));
		}
	}
}