using NUnit.Framework;
using VkNet.Model;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class FriendsGetRequestsResultModel : BaseTest
	{
		[Test]
		public void ShouldHaveField_Message()
		{
			Json = "{'user_id':221634238, 'message':'text'}";
			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response: response);
			Assert.That(actual: result.Message, expression: Is.EqualTo(expected: "text"));
		}

		[Test]
		public void ShouldHaveField_Mutual()
		{
			Json = @"
            {
                'user_id':221634238,
                'mutual': {
                    'count': 3,
                    'users': [227457746, 228907945, 229634083]
                }
            }";

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response: response);
			Assert.IsNotEmpty(collection: result.Mutual);
		}

		[Test]
		public void ShouldHaveField_UserId()
		{
			Json = "{'user_id':221634238}";
			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response: response);
			Assert.That(actual: result.UserId, expression: Is.EqualTo(expected: 221634238L));
		}
	}
}