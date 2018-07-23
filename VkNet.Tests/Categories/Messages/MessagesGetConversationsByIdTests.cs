using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetConversationsByIdTests : BaseTest
	{
		[Test]
		public void GetConversationsById()
		{
			Url = "https://api.vk.com/method/messages.getConversationsById";

			Json = @"{
				response: {
					count: 1,
					items: [
						{
							peer: {
								id: 2000000041,
								type: 'chat',
								local_id: 41
							},
							in_read: 220698,
							out_read: 220698,
							last_message_id: 220698,
							can_write: {
								allowed: true
							},
							chat_settings: {
								title: 'Сын собаки',
								members_count: 5,
								state: 'in',
								photo: {
									photo_50: 'https://pp.userapVs-RCRoqI.jpg?ava=1',
									photo_100: 'https://pp.userapNFShYGPmE.jpg?ava=1',
									photo_200: 'https://pp.userap9XLqmVm88.jpg?ava=1'
								},
								active_ids: [
									228907945,
									442461954,
									229634083,
									72815776
								]
							}
						}
					],
					profiles: [
						{
							id: 72815776,
							first_name: 'Антон',
							last_name: 'Минаев'
						},
						{
							id: 228907945,
							first_name: 'Владимир',
							last_name: 'Карчков'
						},
						{
							id: 229634083,
							first_name: 'Александр',
							last_name: 'Полковников'
						},
						{
							id: 442461954,
							first_name: 'Александр',
							last_name: 'Инютин'
						}
					]
				}
			}";

			var result = Api.Messages.GetConversationsById(new long[] { 123 }, null);

			Assert.That(1, Is.EqualTo(result.Count));
		}
	}
}