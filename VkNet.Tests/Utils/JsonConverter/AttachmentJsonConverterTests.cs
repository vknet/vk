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
			CommentBoard result = Api.Call("friends.getRequests", VkParameters.Empty);
			Assert.NotNull(result);
			Assert.That(result.Id, Is.EqualTo(3));
			Assert.That(result.FromId, Is.EqualTo(32190123));
			Assert.IsNotEmpty(result.Attachments);
		}
	}
}