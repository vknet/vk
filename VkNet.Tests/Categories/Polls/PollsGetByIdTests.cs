using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Polls
{
	[TestFixture]
	public class PollsGetByIdTests : CategoryBaseTest
	{
		protected override string Folder => "Polls";

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/polls.getById";

			ReadCategoryJsonPath("GetById");

			var result = Api.PollsCategory.GetById(new PollsGetByIdParams
			{
				PollId = 123
			});

			result.Should().NotBeNull();
		}
	}
}