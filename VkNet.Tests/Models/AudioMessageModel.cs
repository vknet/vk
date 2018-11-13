using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioMessageModel
	{
		[Test]
		public void ToString_AudioMessageShouldHaveAccessKey()
		{
			var audioMessage = new AudioMessage
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = audioMessage.ToString();

			Assert.AreEqual(result, "audio_message1234_1234_test");
		}
	}
}