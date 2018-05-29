using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Utils.JsonConverter
{
	[TestFixture]
	public class AttachmentJsonConverterTests : BaseTest
	{
		[Test]
		public void CallAndConvertToType()
		{
			Json = @"
            {
                'response': 
                {
                    'id': 3,
                    'from_id': 32190123,
                    'date': 1520709748,
                    'text': '',
                    'attachments': [{
                        'type': 'audio',
                        'audio': {
                        'id': 456239085,
                        'owner_id': 32190123,
                        'artist': 'Невероятные приключения Джо Джо',
                        'title': 'Ost',
                        'duration': 172,
                        'date': 1516564607,
                        'url': 'https://cs1-63v4_Pe_2RecbHMX0M2F0vg',
                        'genre_id': 18,
                        'is_hq': true
                        }
                    }]
                }
            }";

			Url = "https://api.vk.com/method/friends.getRequests";
			CommentBoard result = Api.Call(methodName: "friends.getRequests", parameters: VkParameters.Empty);
			Assert.NotNull(anObject: result);
			Assert.That(actual: result.Id, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: result.FromId, expression: Is.EqualTo(expected: 32190123));
			Assert.IsNotEmpty(collection: result.Attachments);
		}
	}
}