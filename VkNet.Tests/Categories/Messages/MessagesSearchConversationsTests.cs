using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[ExcludeFromCodeCoverage]
	public class MessagesSearchConversationsTests : BaseTest
	{
		[Test]
		public void SearchConversations()
		{
			Url = "https://api.vk.com/method/messages.searchConversations";

			Json = @"{
				response: {
					count: 20,
					items: [
						{
							peer: {
								id: 373331615,
								type: 'user',
								local_id: 373331615
							},
							in_read: 0,
							out_read: 0,
							last_message_id: 0,
							can_write: {
								allowed: true
							},
							push_settings: {
								no_sound: false,
								disabled_until: 0,
								disabled_forever: true
							}
						}
					],
					profiles: [
						{
							id: 14575122,
							first_name: 'Александр',
							last_name: 'Иванов',
							sex: 2,
							screen_name: 'zerojoker',
							photo_50: 'https://pp.userapjMH9T820c.jpg?ava=1',
							photo_100: 'https://pp.userapekLiX8uK4.jpg?ava=1',
							online: 0
						}
					]
				}
			}";

			var result = Api.Messages.SearchConversations("query", new[] { "fields" });

			Assert.That(20, Is.EqualTo(result.Count));
		}
	}
}