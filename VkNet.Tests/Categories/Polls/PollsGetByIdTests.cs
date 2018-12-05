using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Polls
{
	[TestFixture]
	public class PollsGetByIdTests : BaseTest
	{
		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/polls.getById";

			ReadJsonFile("Categories", "Polls", "getById");

			var result = Api.PollsCategory.GetById(new PollsGetByIdParams
			{
				PollId = 123
			});

			Assert.NotNull(result);
		}
	}
}