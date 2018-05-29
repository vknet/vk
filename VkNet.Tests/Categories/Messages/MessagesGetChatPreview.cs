using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetChatPreview : BaseTest
	{
		[Test]
		public void DefaultParams()
		{
			Url = "https://api.vk.com/method/messages.getChatPreview";

			Json = @"
                {
                    'response': {
                        'preview': {
                            admin_id: 123,
                            members: [1,2,3],
                            title: 'qwe',
                            photo:{
                                photo_50: 'http:\\vk.com',
                                photo_100: 'http:\\vk.com',
                                photo_200: 'http:\\vk.com'
                            },
                            local_id: 43
                        },
                        'profiles': [{
                            'uid': 165614770,
                            'first_name': 'Маша',
                            'last_name': 'Иванова',
                            'university': '0',
                            'university_name': '',
                            'faculty': '0',
                            'faculty_name': '',
                            'graduation': '0'
                        }],
                        'groups': [{
                            'id': 26442631,
                            'name': 'Music Quotes. First Public.',
                            'screen_name': 'music_quotes_public',
                            'is_closed': 0,
                            'is_admin': 0,
                            'is_member': 0,
                            'photo_50': 'http://cs303205.userapi.com/g26442631/e_bcb8704f.jpg',
                            'photo_100': 'http://cs303205.userapi.com/g26442631/d_a3627c6f.jpg',
                            'photo_200': 'http://cs303205.userapi.com/g26442631/a_32dd770f.jpg'
                          }],
                        'emails': [{
                            id: 123,
                            address: 'qwe@qwe.ru'
                        }],                        
                    }
                }
            ";

			var result = Api.Messages.GetChatPreview(link: "http://vk.com", fields: ProfileFields.About);
			Assert.NotNull(anObject: result);
			Assert.That(actual: result.Emails, expression: Is.Not.Empty);
			Assert.That(actual: result.Groups, expression: Is.Not.Empty);
			Assert.That(actual: result.Profiles, expression: Is.Not.Empty);
			Assert.That(actual: result.Preview, expression: Is.Not.Null);
			Assert.That(actual: result.Preview.LocalId, expression: Is.EqualTo(expected: 43));
			Assert.That(actual: result.Preview.Title, expression: Is.EqualTo(expected: "qwe"));
			Assert.That(actual: result.Preview.AdminId, expression: Is.EqualTo(expected: 123));
			Assert.That(actual: result.Preview.Members, expression: Is.Not.Empty);
		}
	}
}