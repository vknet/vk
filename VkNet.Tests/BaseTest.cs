using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VkNet.Abstractions.Utils;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests
{
	/// <summary>
	/// Базовый класс для тестирования категорий методов.
	/// </summary>
	public abstract class
			BaseTest //TODO: V3072 http://www.viva64.com/en/w/V3072 The 'BaseTest' class containing IDisposable members does not itself implement IDisposable. Inspect: Api.
	{
		/// <summary>
		/// Экземпляр класса API.
		/// </summary>
		protected VkApi Api;

		/// <summary>
		/// Ответ от сервера.
		/// </summary>
		protected string Json;

		/// <summary>
		/// Параметры запроса.
		/// </summary>
		protected VkParameters Parameters = new VkParameters();

		/// <summary>
		/// Url запроса.
		/// </summary>
		protected string Url;

		/// <summary>
		/// Пред установки выполнения каждого теста.
		/// </summary>
		[SetUp]
		public void Init()
		{
			var browser = new Mock<IBrowser>();

			browser.Setup(expression: m => m.GetJson(url: It.Is<string>(match: s => s == Url),
							parameters: It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
					.Callback(action: Callback)
					.Returns(valueFunction: () =>
					{
						if (string.IsNullOrWhiteSpace(value: Json))
						{
							throw new NullReferenceException(message: @"Json не может быть равен null. Обновите значение поля Json");
						}

						return Json;
					});

			browser.Setup(expression: o => o.Authorize(authParams: It.IsAny<IApiAuthParams>()))
					.Returns(value: VkAuthorization.From(
							uriFragment: "https://vk.com/auth?__q_hash=qwerty&access_token=token&expires_in=1000&user_id=1"));

			browser.Setup(expression: m => m.Validate(validateUrl: It.IsAny<string>(), phoneNumber: It.IsAny<string>()))
					.Returns(value: VkAuthorization.From(
							uriFragment: "https://oauth.vk.com/blank.html#success=1&access_token=token&user_id=1"));

			var restClient = new Mock<IRestClient>();

			restClient.Setup(expression: x =>
							x.PostAsync(uri: It.Is<Uri>(match: s => s == new Uri(uriString: Url)),
									parameters: It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
					.Callback(action: Callback)
					.Returns(valueFunction: () =>
					{
						if (string.IsNullOrWhiteSpace(value: Json))
						{
							throw new NullReferenceException(message: @"Json не может быть равен null. Обновите значение поля Json");
						}

						return Task.FromResult(result: HttpResponse<string>.Success(httpStatusCode: HttpStatusCode.OK,
								value: Json,
								requestUri: Url));
					});

			restClient.Setup(expression: x => x.PostAsync(uri: It.Is<Uri>(match: s => string.IsNullOrWhiteSpace(value: Url)),
							parameters: It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
					.Throws<ArgumentException>();

			Api = new VkApi
			{
					Browser = browser.Object,
					RestClient = restClient.Object
			};

			Api.Authorize(@params: new ApiAuthParams
			{
					ApplicationId = 1,
					Login = "login",
					Password = "pass",
					Settings = Settings.All
			});

			Api.RequestsPerSecond = 100000; // Чтобы тесты быстрее выполнялись
		}

		/// <summary>
		/// После исполнения каждого теста.
		/// </summary>
		[TearDown]
		public void Cleanup()
		{
			Json = null;
			Parameters = new VkParameters();
			Url = null;
		}

		protected VkResponse GetResponse()
		{
			var response = JToken.Parse(json: Json);

			return new VkResponse(token: response) { RawJson = Json };
		}

		private void Callback()
		{
			if (string.IsNullOrWhiteSpace(value: Url))
			{
				throw new NullReferenceException(message: @"Url не может быть равен null. Обновите значение поля Url");
			}

			Url = Url.Replace(oldValue: "\'", newValue: "%27");
		}
	}
}