using System;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	public class MarketCategoryTest : BaseTest
	{
		[Test]
		public void ExecuteTest()
		{
			Url =
                "https://api.vk.com/method/market.add?owner_id=-103292418&name=Воздух&description=Описание&category_id=1&price=10.01&deleted=0&main_photo_id=425060558&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
                response: {
                    market_item_id: 250396
                }
            }";
			
			var result = Api.Markets.Add(new MarketProductParams
			{
                OwnerId = -103292418,
                CategoryId = 1,
                Name = "Воздух",
                Price = 10.01m,
                Description = "Описание",
                MainPhotoId = 425060558
            });
			Assert.That(result, Is.EqualTo(250396));
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