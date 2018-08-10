using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[ExcludeFromCodeCoverage]
	public class MessagesGetConversationMembersTests : BaseTest
	{
		[Test]
		public void GetConversationMembers()
		{
			Url = "https://api.vk.com/method/messages.getConversationMembers";

			Json = @"{
				response: {
					items: [
						{
							member_id: 32190123
						},
						{
							member_id: 1
						}
					],
					count: 2,
					profiles: [
						{
							id: 1,
							first_name: 'Павел',
							last_name: 'Дуров',
							sex: 2,
							screen_name: 'durov',
							photo_50: 'https://pp.userapxZpRF-z_M.jpg?ava=1',
							photo_100: 'https://pp.userapCm4JfplhQ.jpg?ava=1',
							online: 0
						},
						{
							id: 32190123,
							first_name: 'Максим',
							last_name: 'Инютин',
							sex: 2,
							screen_name: 'inyutin_maxim',
							photo_50: 'https://pp.userapGqV91plgs.jpg?ava=1',
							photo_100: 'https://pp.userapmbpXTp7PA.jpg?ava=1',
							online: 0
						}
					]
				}
			}";

			var result = Api.Messages.GetConversationMembers(123, new[] { "" });

			Assert.That(2, Is.EqualTo(result.Count));
		}
	}
}