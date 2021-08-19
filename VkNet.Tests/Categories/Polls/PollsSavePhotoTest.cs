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

			Assert.That(result.Id, Is.EqualTo(457245390));
			Assert.That(result.Color, Is.EqualTo("BE272E"));
			Assert.That(result.Images[0].Height, Is.EqualTo(600));
			Assert.IsNotEmpty(result.Images[0].Url.ToString());
		}
	}
}