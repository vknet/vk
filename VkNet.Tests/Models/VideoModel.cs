using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class VideoModel
	{
		[Test]
		public void ToString_VideoShouldHaveAccessKey()
		{
			var video = new Video
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = video.ToString();

			Assert.AreEqual(result, "video1234_1234_test");
		}
	}
}