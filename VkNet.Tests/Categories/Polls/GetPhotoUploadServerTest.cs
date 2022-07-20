using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Polls
{

	public class GetPhotoUploadServerTest : CategoryBaseTest
	{
		protected override string Folder => "Polls";

		[Fact]
		public void GetPhotoUploadServer()
		{
			Url = "https://api.vk.com/method/polls.getPhotoUploadServer";

			ReadCategoryJsonPath(nameof(Api.PollsCategory.GetPhotoUploadServer));

			var result = Api.PollsCategory.GetPhotoUploadServer(450138623);

			result.UploadUrl.Should().NotBeEmpty();
		}
	}
}