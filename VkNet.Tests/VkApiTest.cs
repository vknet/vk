namespace VkNet.Tests
{
	using System;
	using System.Collections.Generic;
	using Moq;
	using NUnit.Framework;
	using Exception;
	using Enums.Filters;
	using VkNet.Utils;

	[TestFixture]
	public class VkApiTest : BaseTest
	{
		[Test]
		public void GetApiUrl_IntArray()
		{
			var arr = new[] { 1, 65 };

			var parameters = new VkParameters();
			parameters.Add<int>("country_ids", arr);

			const string expected = "https://api.vk.com/method/database.getCountriesById?country_ids=1,65&access_token=token";

			var url = Api.GetApiUrl("database.getCountriesById", parameters);

			Assert.That(url, Is.EqualTo(expected));
		}

		[Test]
		public void VkApi_Constructor_SetDefaultMethodCategories()
		{
			Assert.That(Api.Users, Is.Not.Null);
			Assert.That(Api.Friends, Is.Not.Null);
			Assert.That(Api.Status, Is.Not.Null);
			Assert.That(Api.Messages, Is.Not.Null);
			Assert.That(Api.Groups, Is.Not.Null);
			Assert.That(Api.Audio, Is.Not.Null);
			Assert.That(Api.Wall, Is.Not.Null);
			Assert.That(Api.Database, Is.Not.Null);
			Assert.That(Api.Utils, Is.Not.Null);
			Assert.That(Api.Fave, Is.Not.Null);
			Assert.That(Api.Video, Is.Not.Null);
			Assert.That(Api.Account, Is.Not.Null);
			Assert.That(Api.Photo, Is.Not.Null);
			Assert.That(Api.Docs, Is.Not.Null);
			Assert.That(Api.Likes, Is.Not.Null);
			Assert.That(Api.Pages, Is.Not.Null);
			Assert.That(Api.Gifts, Is.Not.Null);
			Assert.That(Api.Apps, Is.Not.Null);
			Assert.That(Api.NewsFeed, Is.Not.Null);
			Assert.That(Api.Stats, Is.Not.Null);
			Assert.That(Api.Auth, Is.Not.Null);
			Assert.That(Api.Markets, Is.Not.Null);
		}

		[Test]
		public void GetApiUrl_GetProfile_RightUrl()
		{
			Parameters.Add("uid", "66748");

			var output = Api.GetApiUrl("getProfiles", Parameters);

			Assert.That(output, Is.Not.Null.Or.Empty);

			const string expected = "https://api.vk.com/method/getProfiles?uid=66748&access_token=token";

			Assert.That(output, Is.EqualTo(expected));
		}

		[Test]
		public void GetApiUrl_GetProfile_WithFields()
		{
			var fields = ProfileFields.FirstName | ProfileFields.Domain | ProfileFields.Education;

			Parameters.Add("uid", "66748");
			Parameters.Add("fields", fields);

			var output = Api.GetApiUrl("getProfiles", Parameters);

			const string expected = "https://api.vk.com/method/getProfiles?uid=66748&fields=first_name,domain,education&access_token=token";

			Assert.That(output, Is.EqualTo(expected));
		}

		//[Test]
		//[Ignore("")]
		//public void Authorize_BadLoginOrPasswrod_ThrowVkApiAuthorizationException()
		//{
		//   const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&m=4&email=mail";
		//    var browser = new Mock<IBrowser>();
		//    browser.Setup(b => b.Authorize(AppId, Email, Password, Settings.Friends)).Returns(VkAuthorization.From(new Uri(urlWithBadLoginOrPassword)));
		//
		//    Api.Browser = browser.Object;
		//    var ex = This.Action(() => Api.Authorize(AppId, Email, Password, Settings.Friends)).Throws<VkApiAuthorizationException>();
		//    ex.Message.ShouldEqual(VkApi.InvalidAuthorization);
		//}

		[Test]
		public void Call_ThrowsCaptchaNeededException()
		{
			Url = "https://api.vk.com/method/messages.send?v=5.50&access_token=";
			Json =
				@"{
					'error': {
					  'error_code': 14,
					  'error_msg': 'Captcha needed',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'messages.send'
						},
						{
						  'key': 'uid',
						  'value': '242508553'
						},
						{
						  'key': 'message',
						  'value': 'hello10'
						},
						{
						  'key': 'type',
						  'value': '0'
						},
						{
						  'key': 'access_token',
						  'value': '1fe7889c3395722934b1'
						}
					  ],
					  'captcha_sid': '548747100691',
					  'captcha_img': 'http://api.vk.com/captcha.php?sid=548747100284&s=1'
					}
				  }";
			var ex = Assert.Throws<CaptchaNeededException>(() => Api.Call("messages.send", VkParameters.Empty, true));
			Assert.That(ex.Sid, Is.EqualTo(548747100691));
			Assert.That(ex.Img, Is.EqualTo(new Uri("http://api.vk.com/captcha.php?sid=548747100284&s=1")));
			// TODO Перенести в VkErrorsTest
		}

		[Test]
		public void Call_NotMoreThen3CallsPerSecond()
		{
			Json = @"{ ""response"": 2 }";
			Api.RequestsPerSecond = 3; // Переопределение значения в базовом классе
			var invocationCount = 0;
			Mock.Get(Api.Browser)
				.Setup(m => m.GetJson(It.IsAny<string>()))
				.Returns(Json)
				.Callback(() => invocationCount++);

			var start = DateTimeOffset.Now;
			while (true)
			{
				Api.Call("someMethod", VkParameters.Empty, true);

				var total = (int)(DateTimeOffset.Now - start).TotalMilliseconds;
				if (total > 999)
				{
					break;
				}
			}

			// Не больше 4 раз, т.к. 4-ый раз вызывается через 1002 мс после первого вызова, а total выходит через 1040 мс
			// переписать тест, когда придумаю более подходящий метод проверки
			Mock.Get(Api.Browser).Verify(m => m.GetJson(It.IsAny<string>()), Times.AtMost(4));
		}

		[Test]
		public void Invoke_VkParams()
		{
			Url = "https://api.vk.com/method/example.get?count=23&access_token=";
			Json = @"{ 'response' : [] }";
			Parameters = new VkParameters { { "count", 23 } };
			var json = Api.Invoke("example.get", Parameters, true);

			StringAssert.AreEqualIgnoringCase(json, Json);
		}

		[Test]
		public void Invoke_DictionaryParams()
		{
			Url = "https://api.vk.com/method/example.get?count=23&access_token=";
			Json = @"{ 'response' : [] }";
			var parameters = new Dictionary<string, string> { { "count", "23" } };
			var json = Api.Invoke("example.get", parameters, true);

			StringAssert.AreEqualIgnoringCase(json, Json);
		}

		[Test]
		public void AuthorizeByToken()
		{
			Api.Authorize("token", 1);
			Assert.That(Api.UserId, Is.EqualTo(1));
		}

		[Test]
		public void AuthorizeByTokenNegative()
		{
			Api = new VkApi(); // В базовом классе предопределено свойство AccessToken
			Api.Authorize("", 1);
			Assert.That(Api.UserId, Is.Null);
		}
	}
}
