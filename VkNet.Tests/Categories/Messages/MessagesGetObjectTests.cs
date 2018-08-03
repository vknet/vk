using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetObjectTests : BaseTest
	{
		[Test]
		public void Unread()
		{
			Json = @"{
                    'response': {
                      'count': 3,
                      'skipped': 1,
                      'unread': 1,
                      'items': [
                        {
                          'id': 3000,
                          'body': 'Привет всем',
                          'user_id': 17369555,
                          'from_id': 17369555,
                          'date': 1521666953,
                          'read_state': 1,
                          'out': 1,
                          'random_id': 241581756,
                          'chat_id': 33
                        },
                        {
                          'id': 2999,
                          'body': '',
                          'user_id': 17369555,
                          'from_id': 17369555,
                          'date': 1521666931,
                          'read_state': 1,
                          'out': 1,
                          'random_id': 0,
                          'action': 'chat_create',
                          'action_text': 'Зажигаем',
                          'chat_id': 33
                        }
                      ],
                      'in_read': 3000,
                      'out_read': 3001
                    }
                  }";

			Url = "https://api.vk.com/method/messages.getHistory";
			var res = Api.Messages.GetHistory(new MessagesGetHistoryParams());

			Assert.AreEqual(1, res.Unread);
		}
	}
}