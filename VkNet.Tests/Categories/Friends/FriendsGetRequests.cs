using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Friends
{
	[TestFixture]
	public class FriendsGetRequests : BaseTest
	{
		[Test]
		public void DefaultParams()
		{
			Url = "https://api.vk.com/method/friends.getRequests";

			Json = @"{
                'response': {
                    'count': 1,
                    'items': [435460566]
                }
            }";

			var result = Api.Friends.GetRequests(@params: new FriendsGetRequestsParams());
			Assert.NotNull(anObject: result);
			Assert.AreEqual(expected: 1, actual: result.Count);
		}

		[Test]
		public void Extended()
		{
			Url = "https://api.vk.com/method/friends.getRequests";

			Json = @"{
                'response': {
                    'count': 1,
                    'items': [{
                        'user_id': 435460566
                    }]
                }
            }";

			var result = Api.Friends.GetRequestsExtended(@params: new FriendsGetRequestsParams
			{
					Extended = true
			});

			Assert.NotNull(anObject: result);
			Assert.AreEqual(expected: 1, actual: result.Count);
		}
	}
}