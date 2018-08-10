using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[ExcludeFromCodeCoverage]
	public class ExecuteCategoryTest : BaseTest
	{
		[Test]
		public void ExecuteTest()
		{
			Url =
					@"https://api.vk.com/method/execute";

			Json = @"{response: ['Тишко', 'Бледнов', 'Касимова']}";

			const string code =
					@"return API.users.get({""user_ids"": API.audio.search({""q"":""Beatles"", ""count"":3}).items@.owner_id})@.last_name;";

			var result = Api.Execute.Execute(code);
			Assert.That(result.RawJson, Is.EqualTo(Json));
		}

		[Test]
		public void ExecuteTopicsFeedTest()
		{
			Url =
					@"https://api.vk.com/method/execute";

			Json = @"{
	""response"": {
		""count"": 1,
		""items"": [{
			""id"": 74,
			""from_id"": -60774666,
			""date"": 1506698266,
			""text"": ""«Твоятерритория.онлайн»""
		}]
	}
}";

			const string code =
					@"return API.users.get({""user_ids"": API.audio.search({""q"":""Beatles"", ""count"":3}).items@.owner_id})@.last_name;";

			var result = Api.Execute.Execute<TopicsFeed>(code);
			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public void ExecuteGetUniversitiesTest()
		{
			Url = "https://api.vk.com/method/execute";

			Json =
					@"{
                    'response': {
                      count: 93,
                      items: [{
                        'id': 1,
                        'title': 'СПбГУ'
                      }]
					}
                  }";

			const string code =
					@"return API.database.getUniversities({""country_id"": 1, ""city_id"": 2, ""q"": ""СПб"", count: 1}); ";

			var result = Api.Execute.Execute<VkCollection<University>>(code);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.TotalCount, Is.EqualTo(93));
			Assert.That(result, Is.Not.Empty);
		}

		[Test]
		public void ExecuteErrorTest()
		{
			Url =
					@"https://api.vk.com/method/execute";

			Json = @"{
				error: {
					error_code: 12,
					error_msg: ""Unable to compile code: ';' expected, '' found in line 1"",
					request_params: [{
						key: 'oauth',
						value: '1'
					}, {
						key: 'method',
						value: 'execute'
					}, {
						key: 'code',
						value: 'return API.users.get({""user_ids"": API.audio.search({""q"":""Beatles"", ""count"":3}).items@.owner_id})@.last_name'
					}, {
						key: 'v',
						value: '5.50'
					}]
				}
			}";

			const string code =
					@"return API.users.get({""user_ids"": API.audio.search({""q"":""Beatles"", ""count"":3}).items@.owner_id})@.last_name";

			Assert.That(() => Api.Execute.Execute(code), Throws.InstanceOf<VkApiException>());
		}
	}
}