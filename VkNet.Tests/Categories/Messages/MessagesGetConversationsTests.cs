using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{
	[ExcludeFromCodeCoverage]
	public class MessagesGetConversationsTests: BaseTest
	{
		[Test]
		public void GetConversations()
		{
			Url = "https://api.vk.com/method/messages.getConversations";

			Json = @"{
				response: {
					count: 1,
					items: [
						{
							conversation: {
								peer: {
									id: 100,
									type: 'user',
									local_id: 100
								},
								in_read: 220697,
								out_read: 220697,
								last_message_id: 220697,
								can_write: {
									allowed: true
								},
								push_settings: {
									no_sound: false,
									disabled_until: 0,
									disabled_forever: true
								}
							},
							last_message: {
								date: 1530088859,
								from_id: 100,
								id: 220697,
								out: 0,
								peer_id: 100,
								text: 'Код подтверждения входа',
								conversation_message_id: 276,
								fwd_messages: [],
								important: false,
								random_id: 0,
								attachments: [],
								is_hidden: false
							}
						}
					]
				}
			}";

			var result = Api.Messages.GetConversations(new GetConversationsParams());

			Assert.That(1, Is.EqualTo(result.Count));
		}
		[Test]
		public void GetConversations_Attachment_wall()
		{
			Url = "https://api.vk.com/method/messages.getConversations";

			Json = @"{
			  'response': {
				'count': 253,
				'items': [
				  {
					'last_message': {
					  'date': 1531204030,
					  'from_id': 442461954,
					  'id': 221368,
					  'out': 0,
					  'peer_id': 2000000041,
					  'text': '',
					  'conversation_message_id': 6801,
					  'fwd_messages': [],
					  'important': false,
					  'random_id': 0,
					  'attachments': [
						{
						  'type': 'wall',
						  'wall': {
							'id': 24760037,
							'from_id': -45745333,
							'to_id': -45745333,
							'date': 1531175400,
							'post_type': 'post',
							'text': '',
							'marked_as_ads': 0,
							'attachments': [
							  {
								'type': 'photo',
								'photo': {
								  'id': 457743483,
								  'album_id': -7,
								  'owner_id': -45745333,
								  'user_id': 100,
								  'sizes': [
								  ],
								  'text': '',
								  'date': 1531145872,
								  'post_id': 24760037,
								  'access_key': ''
								}
							  }
							],
							'post_source': {
							  'type': 'vk'
							},
							'comments': {
							  'count': 300,
							  'groups_can_post': true,
							  'can_post': 1
							},
							'likes': {
							  'count': 11733,
							  'user_likes': 0,
							  'can_like': 1,
							  'can_publish': 1
							},
							'reposts': {
							  'count': 147,
							  'user_reposted': 0
							},
							'views': {
							  'count': 216587
							},
							'access_key': ''
						  }
						}
					  ],
					  'is_hidden': false
					}
				  }
				]
			  }
			}
			";

			var result = Api.Messages.GetConversations(new GetConversationsParams());

			Assert.That(253, Is.EqualTo(result.Count));
		}
	}
}