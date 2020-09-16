using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Friends
{
	[TestFixture]

	public class FriendsGetRequests : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Test]
		public void DefaultParams()
		{
			Url = "https://api.vk.com/method/friends.getRequests";

			ReadCategoryJsonPath(nameof(Api.Friends.GetRequests));

			var result = Api.Friends.GetRequests(new FriendsGetRequestsParams());
			Assert.NotNull(result);
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void Extended()
		{
			Url = "https://api.vk.com/method/friends.getRequests";

			ReadCategoryJsonPath(nameof(Api.Friends.GetRequestsExtended));

			var result = Api.Friends.GetRequestsExtended(new FriendsGetRequestsParams
			{
				Extended = true
			});

			Assert.NotNull(result);
			Assert.AreEqual(1, result.Count);
		}
	}
}