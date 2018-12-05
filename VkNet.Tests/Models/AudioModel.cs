using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioModel
	{
		[Test]
		public void ToString_AudioShouldHaveAccessKey()
		{
			var audio = new Audio
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = audio.ToString();

			Assert.AreEqual(result, "audio1234_1234_test");
		}
	}
}