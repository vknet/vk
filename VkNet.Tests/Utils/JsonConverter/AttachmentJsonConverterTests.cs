using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Utils.JsonConverter
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
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

		[Test]
		public void SerealizationTest()
		{
			Json = @"{
					  'date': 1538561982,
					  'from_id': 1234567890,
					  'id': 28648,
					  'out': 1,
					  'peer_id': 2000000003,
					  'text': '',
					  'conversation_message_id': 1824,
					  'fwd_messages': [],
					  'important': false,
					  'random_id': 1058133329,
					  'attachments': [
					    {
					      'type': 'photo',
					      'photo': {
					        'id': 456239677,
					        'album_id': -3,
					        'owner_id': 1234567890,
					        'sizes': [
					          {
					            'type': 'm',
					            'url': 'https://pp.userap/6f0/eur0G6JEtHA.jpg',
					            'width': 130,
					            'height': 129
					          }
					        ],
					        'text': '',
					        'date': 1538561982,
					        'access_key': '0a96d1dceb18b6fa7b'
					      }
					    }
					  ],
					  'is_hidden': false
					}";

			var response = GetResponse();
			var message = Message.FromJson(response);

			var json = JsonConvert.SerializeObject(message, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore
			});
			var result = JsonConvert.DeserializeObject<Message>(json);

			Assert.NotNull(result);
			Assert.IsNotEmpty(result.Attachments);
		}
	}
}