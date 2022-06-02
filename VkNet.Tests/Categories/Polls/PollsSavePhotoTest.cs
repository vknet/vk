using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Polls
{
	[TestFixture]
	public class PollsSavePhotoTest : CategoryBaseTest
	{
		protected override string Folder => "Polls";

		[Test]
		public void PollsSavePhoto()
		{
			Url = "https://api.vk.com/method/polls.savePhoto";

			ReadCategoryJsonPath(nameof(Api.PollsCategory.SavePhoto));

			var result = Api.PollsCategory.SavePhoto(new SavePhotoParams
			{
				Photo = "242344",
				Hash = "fe8f7aaa03ff650cc2"
			});

			result.Id.Should().Be(457245390);
			result.Color.Should().Be("BE272E");
			result.Images[0].Height.Should().Be(600);
			result.Images[0].Url.ToString().Should().NotBeEmpty();
		}
	}
}