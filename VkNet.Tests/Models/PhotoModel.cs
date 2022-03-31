using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class PhotoModel
	{
		[Test]
		public void ToString_PhotoShouldHaveAccessKey()
		{
			var photo = new Photo
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = photo.ToString();

			result.Should().Be("photo1234_1234_test");
		}
	}
}