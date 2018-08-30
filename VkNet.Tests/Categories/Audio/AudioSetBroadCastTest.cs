using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioSetBroadCastTest : BaseTest
	{
		[Test]
		public void SetBroadCastTest()
		{
			Url = "https://api.vk.com/method/audio.setBroadcast";

			Json = @"{'response':[-123456789,123456789]}";

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