using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests
{
	[TestFixture]
	public class VkApiTest : BaseTest
	{
		[Test]
		public void AuthorizeByToken()
		{
			Api.Authorize(@params: new ApiAuthParams
			{
					AccessToken = "token"
					, UserId = 1
			});

			Assert.That(actual: Api.UserId, expression: Is.EqualTo(expected: 1));
		}

		[Test]
		public void Call_NotMoreThen3CallsPerSecond()
		{
			Json = @"{ ""response"": 2 }";
			Api.RequestsPerSecond = 3; // Переопределение значения в базовом классе

			Mock.Get(mocked: Api.RestClient)
					.Setup(expression: m =>
							m.PostAsync(uri: It.IsAny<Uri>(), parameters: It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
					.Returns(value: Task.FromResult(result: HttpResponse<string>.Success(httpStatusCode: HttpStatusCode.OK
							, value: Json
							, requestUri: Url)));

			var start = DateTimeOffset.Now;

			while (true)
			{
				Api.Call(methodName: "someMethod", parameters: VkParameters.Empty, skipAuthorization: true);

				var total = (int) (DateTimeOffset.Now - start).TotalMilliseconds;

				if (total > 999)
				{
					break;
				}
			}

			// Не больше 4 раз, т.к. 4-ый раз вызывается через 1002 мс после первого вызова, а total выходит через 1040 мс
			// переписать тест, когда придумаю более подходящий метод проверки
			Mock.Get(mocked: Api.RestClient)
					.Verify(expression: m =>
									m.PostAsync(uri: It.IsAny<Uri>(), parameters: It.IsAny<IEnumerable<KeyValuePair<string, string>>>())
							, times: Times.AtMost(callCount: 4));
		}

		[Test]
		public void CallAndConvertToType()
		{
			Json = @"
            {
				'response': {
					'user_id':221634238,
					'mutual': {
						'count': 3,
						'users': [227457746, 228907945, 229634083]
					},
					'message':'text'
				}
			}";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<FriendsGetRequestsResult>(methodName: "friends.getRequests", parameters: VkParameters.Empty);
			Assert.NotNull(anObject: result);
			Assert.That(actual: result.UserId, expression: Is.EqualTo(expected: 221634238));
			Assert.That(actual: result.Message, expression: Is.EqualTo(expected: "text"));
			Assert.IsNotEmpty(collection: result.Mutual);
		}

		[Test]
		public void DefaultLanguageValue()
		{
			var lang = Api.GetLanguage();
			Assert.IsNull(anObject: lang);
		}

		[Test]
		public void Dispose()
		{
			Api.Dispose();
		}

		[Test]
		public void EnglishLanguageValue()
		{
			Api.SetLanguage(language: Language.En);
			var lang = Api.GetLanguage();
			Assert.AreEqual(expected: lang, actual: Language.En);
		}

		[Test]
		public void Invoke_DictionaryParams()
		{
			Url = "https://api.vk.com/method/example.get";
			Json = @"{ 'response' : [] }";
			var parameters = new Dictionary<string, string> { { "count", "23" } };
			var json = Api.Invoke(methodName: "example.get", parameters: parameters, skipAuthorization: true);

			StringAssert.AreEqualIgnoringCase(expected: json, actual: Json);
		}

		[Test]
		public void Invoke_VkParams()
		{
			Url = "https://api.vk.com/method/example.get";
			Json = @"{ 'response' : [] }";
			var parameters = new VkParameters { { "count", 23 } };
			var json = Api.Invoke(methodName: "example.get", parameters: parameters, skipAuthorization: true);

			StringAssert.AreEqualIgnoringCase(expected: json, actual: Json);
		}

		[Test]
		public void Validate()
		{
			var uri = new Uri(uriString: "https://m.vk.com/activation?act=validate&api_hash=f2fed5f22ebadc301e&hash=c8acf371111c938417");
			Api.Validate(validateUrl: uri.ToString(), phoneNumber: "+7894561230");
		}

		[Test]
		public void VkApi_Constructor_SetDefaultMethodCategories()
		{
			Assert.That(actual: Api.Users, expression: Is.Not.Null);
			Assert.That(actual: Api.Friends, expression: Is.Not.Null);
			Assert.That(actual: Api.Status, expression: Is.Not.Null);
			Assert.That(actual: Api.Messages, expression: Is.Not.Null);
			Assert.That(actual: Api.Groups, expression: Is.Not.Null);
			Assert.That(actual: Api.Audio, expression: Is.Not.Null);
			Assert.That(actual: Api.Wall, expression: Is.Not.Null);
			Assert.That(actual: Api.Database, expression: Is.Not.Null);
			Assert.That(actual: Api.Utils, expression: Is.Not.Null);
			Assert.That(actual: Api.Fave, expression: Is.Not.Null);
			Assert.That(actual: Api.Video, expression: Is.Not.Null);
			Assert.That(actual: Api.Account, expression: Is.Not.Null);
			Assert.That(actual: Api.Photo, expression: Is.Not.Null);
			Assert.That(actual: Api.Docs, expression: Is.Not.Null);
			Assert.That(actual: Api.Likes, expression: Is.Not.Null);
			Assert.That(actual: Api.Pages, expression: Is.Not.Null);
			Assert.That(actual: Api.Gifts, expression: Is.Not.Null);
			Assert.That(actual: Api.Apps, expression: Is.Not.Null);
			Assert.That(actual: Api.NewsFeed, expression: Is.Not.Null);
			Assert.That(actual: Api.Stats, expression: Is.Not.Null);
			Assert.That(actual: Api.Auth, expression: Is.Not.Null);
			Assert.That(actual: Api.Markets, expression: Is.Not.Null);
			Assert.That(actual: Api.Ads, expression: Is.Not.Null);
		}

		[Test]
		public void VkCallShouldBePublic()
		{
			// arrange
			var myType = typeof(VkApi);
			var myArrayMethodInfo = myType.GetMethods();

			// act
			var callMethod = myArrayMethodInfo.FirstOrDefault(predicate: x => x.Name.Contains(value: "Call"));

			// Assert
			Assert.IsNotNull(anObject: callMethod);
			Assert.IsTrue(condition: callMethod.IsPublic);
		}
	}
}