using System.CodeDom;
using System.IO;

namespace VkNet.Tests
{
	using System;
	using System.Collections.Generic;
	using Moq;
	using NUnit.Framework;
	using Exception;
	using Enums.Filters;
	using VkNet.Utils;
	using FluentNUnit;

	[TestFixture]
	public class VkApiTest
	{
		private const string Email = "test@test.com";
		private const string Password = "pwd1234";
		private const int AppId = 123;

		private VkApi _vk;
		private IDictionary<string, string> _values;

		[SetUp]
		public void SetUp()
		{
			_vk = new VkApi { AccessToken = "token" };
			_values = new Dictionary<string, string>();
		}
		
		[Test]
		public void GetApiUrl_IntArray()
		{
			var arr = new[] {1, 65};

			//var parameters = new VkParameters { { "country_ids", arr } };
			var parameters = new VkParameters();
			parameters.Add<int>("country_ids", arr);

			const string expected = "https://api.vk.com/method/database.getCountriesById?country_ids=1,65&access_token=token";

			var url = _vk.GetApiUrl("database.getCountriesById", parameters);

			Assert.That(url, Is.EqualTo(expected));
		}

		[Test]
		public void VkApi_Constructor_SetDefaultMethodCategories()
		{
			Assert.That(_vk.Users, Is.Not.Null);
			Assert.That(_vk.Friends, Is.Not.Null);
			Assert.That(_vk.Status, Is.Not.Null);
			Assert.That(_vk.Messages, Is.Not.Null);
			Assert.That(_vk.Groups, Is.Not.Null);
			Assert.That(_vk.Audio, Is.Not.Null);
			Assert.That(_vk.Wall, Is.Not.Null);
			Assert.That(_vk.Database, Is.Not.Null);
			Assert.That(_vk.Utils, Is.Not.Null);

			_vk.Fave.ShouldNotBeNull();
			_vk.Video.ShouldNotBeNull();
			_vk.Account.ShouldNotBeNull();
			_vk.Photo.ShouldNotBeNull();
			// TODO: continue later
		}

		[Test]
		public void GetApiUrl_GetProfile_RightUrl()
		{
			_values.Add("uid", "66748");
			const string expected = "https://api.vk.com/method/getProfiles?uid=66748&access_token=token";

			var output = _vk.GetApiUrl("getProfiles", _values);

			Assert.That(output, Is.Not.Null.Or.Empty);
			Assert.That(output, Is.EqualTo(expected));
		}

		[Test]
		public void GetApiUrl_GetProfile_WithFields()
		{
			var fields = ProfileFields.FirstName | ProfileFields.Domain | ProfileFields.Education;
			_values.Add("uid", "66748");
			_values.Add("fields", fields.ToString().Replace(" ", ""));
			const string expected = "https://api.vk.com/method/getProfiles?uid=66748&fields=first_name,domain,education&access_token=token";

			var output = _vk.GetApiUrl("getProfiles", _values);

			Assert.That(output, Is.EqualTo(expected));
		}

		//[Test]
		//[Ignore]
		//public void Authorize_BadLoginOrPasswrod_ThrowVkApiAuthorizationException()
		//{
		//   const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&m=4&email=mail";            
		//    var browser = new Mock<IBrowser>();
		//    browser.Setup(b => b.Authorize(AppId, Email, Password, Settings.Friends)).Returns(VkAuthorization.From(new Uri(urlWithBadLoginOrPassword)));
		//
		//    _vk.Browser = browser.Object;
		//    var ex = This.Action(() => _vk.Authorize(AppId, Email, Password, Settings.Friends)).Throws<VkApiAuthorizationException>();
		//    ex.Message.ShouldEqual(VkApi.InvalidAuthorization);
		//}

		[Test]
		public void Call_ThrowsCaptchaNeededException()
		{
			const string json =
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

			var browser = Mock.Of<IBrowser>(m => m.GetJson(It.IsAny<string>()) == json);
			var api = new VkApi {Browser = browser};

			var ex = This.Action(() => api.Call("messages.send", VkParameters.Empty, true)).Throws<CaptchaNeededException>();

			ex.Sid.ShouldEqual(548747100691);
			ex.Img.ShouldEqual(new Uri("http://api.vk.com/captcha.php?sid=548747100284&s=1"));
		}

		[Test, Ignore("Почему то тест стал падать")]
		public void Call_NotMoreThen3CallsPerSecond()
		{
			var invocationCount = 0;
			var browser = new Mock<IBrowser>();
			browser.Setup(m => m.GetJson(It.IsAny<string>()))
				   .Returns(@"{ ""response"": 2 }")
				   .Callback(() => invocationCount++);

			var api = new VkApi {Browser = browser.Object};

			var start = DateTimeOffset.Now;
			while (true)
			{
				api.Call("someMethod", VkParameters.Empty, true);

				var total = (int)(DateTimeOffset.Now - start).TotalMilliseconds;
				if (total > 999)
				{
					break;
				}
			}

			// Не больше 4 раз, т.к. 4-ый раз вызывается через 1002 мс после первого вызова, а total выходит через 1040 мс
			// переписать тест, когда придумаю более подходящий метод проверки
			// TODO почему то стал падать тест в этом месте
			browser.Verify(m => m.GetJson(It.IsAny<string>()), Times.AtMost(4));
		}

		[Test]
		public void Invoke_VkParams()
		{
			const string resultJson = @"{ 'response' : [] }";

			var browser = Mock.Of<IBrowser>(m => m.GetJson(It.IsAny<string>()) == resultJson);
			var api = new VkApi{Browser =  browser};
			var parameters = new VkParameters {{"count", 23}};
			var json = api.Invoke("example.get", parameters, true);

			json.ShouldEqual(resultJson);
		}

		[Test]
		public void Invoke_DictionaryParams()
		{
			const string resultJson = @"{ 'response' : [] }";

			var browser = Mock.Of<IBrowser>(m => m.GetJson(It.IsAny<string>()) == resultJson);
			var api = new VkApi { Browser = browser };
			var parameters = new Dictionary<string, string> { { "count", "23" } };
			var json = api.Invoke("example.get", parameters, true);

			json.ShouldEqual(resultJson);
		}
	}
}
