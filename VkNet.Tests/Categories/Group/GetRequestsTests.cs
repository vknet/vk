using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	public class GetRequestsTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void GetRequests_With_Fields()
		{
			Url = "https://api.vk.com/method/groups.getRequests";

			ReadCategoryJsonPath(nameof(GetRequests_With_Fields));

			var result = Api.Groups.GetRequests(1, null, null, UsersFields.LastSeen);

			Assert.NotNull(result);
			Assert.AreEqual(3, result.Count);
			foreach (var user in result)
				Assert.NotNull(user);
		}

		[Test]
		public void GetRequests_Without_Fields()
		{
			Url = "https://api.vk.com/method/groups.getRequests";

			ReadCategoryJsonPath(nameof(GetRequests_Without_Fields));

			var result = Api.Groups.GetRequests(1);

			Assert.NotNull(result);
			Assert.AreEqual(3, result.Count);
			foreach (var user in result)
				Assert.NotNull(user);
		}
	}
}