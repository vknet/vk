using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Polls
{

	public class PollsSavePhotoTest : CategoryBaseTest
	{
		protected override string Folder => "Polls";

		[Fact]
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