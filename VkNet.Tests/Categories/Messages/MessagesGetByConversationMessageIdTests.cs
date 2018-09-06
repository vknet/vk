using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[ExcludeFromCodeCoverage]
	public class MessagesGetByConversationMessageIdTests : BaseTest
	{
		[Test]
		public void GetByConversationMessageId()
		{
			Url = "https://api.vk.com/method/messages.getByConversationMessageId";

			Json = @"{
				response: {
					count: 1,
					items: [
						{
							date: 1465721282,
							from_id: 32190123,
							id: 180314,
							out: 1,
							peer_id: 2000000041,
							text: 'Точно! &#128516;',
							conversation_message_id: 5,
							fwd_messages: [],
							important: false,
							random_id: 0,
							attachments: [],
							is_hidden: false
						}
					],
					profiles: [
						{
							id: 32190123,
							first_name: 'Максим',
							last_name: 'Инютин',
							sex: 2,
							screen_name: 'inyutin_maxim',
							photo_50: 'https://pp.userapGqV91plgs.jpg?ava=1',
							photo_100: 'https://pp.userapmbpXTp7PA.jpg?ava=1',
							online: 1
						}
					]
				}
			}";

			var result = Api.Messages.GetByConversationMessageId(123, new ulong[] { 123 }, new[] { "" });

			Assert.That(1, Is.EqualTo(result.Count));
		}
	}
}