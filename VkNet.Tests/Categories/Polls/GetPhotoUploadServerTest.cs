using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Polls
{
	[TestFixture]
	public class GetPhotoUploadServerTest : CategoryBaseTest
	{
		protected override string Folder => "Polls";

		[Test]
		public void GetPhotoUploadServer()
		{
			Url = "https://api.vk.com/method/polls.getPhotoUploadServer";

			ReadCategoryJsonPath(nameof(Api.PollsCategory.GetPhotoUploadServer));

			var result = Api.PollsCategory.GetPhotoUploadServer(450138623);

			Assert.IsNotEmpty(result.UploadUrl);
		}
	}
}