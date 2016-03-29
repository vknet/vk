using System;
using NUnit.Framework;
using VkNet.Exception;

namespace VkNet.Tests.Categories
{
	public class ExecuteCategoryTest : BaseTest
	{
		[Test]
		public void ExecuteTest()
		{
			Url =
				"https://api.vk.com/method/execute?code=return+API.users.get(%7b%22user_ids%22%3a+API.audio.search(%7b%22q%22%3a%22Beatles%22%2c+%22count%22%3a3%7d).items%40.owner_id%7d)%40.last_name%3b&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{response: ['Тишко', 'Бледнов', 'Касимова']}";
			const string code = @"return API.users.get({""user_ids"": API.audio.search({""q"":""Beatles"", ""count"":3}).items@.owner_id})@.last_name;";
			var result = Api.Execute.Execute(code);
			Assert.That(result.RawJson, Is.EqualTo(Json));
		}

		[Test]
		public void ExecuteErrorTest()
		{
			Url =
				"https://api.vk.com/method/execute?code=return+API.users.get(%7b%22user_ids%22%3a+API.audio.search(%7b%22q%22%3a%22Beatles%22%2c+%22count%22%3a3%7d).items%40.owner_id%7d)%40.last_name&v=" + VkApi.VkApiVersion + "&access_token=token";
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
			const string code = @"return API.users.get({""user_ids"": API.audio.search({""q"":""Beatles"", ""count"":3}).items@.owner_id})@.last_name";
			Assert.That(() => Api.Execute.Execute(code), Throws.InstanceOf<VkApiException>());
		}
	}
}