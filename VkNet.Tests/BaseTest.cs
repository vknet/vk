using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
	/// <remarks>
	/// TODO: V3072 http://www.viva64.com/en/w/V3072 The 'BaseTest' class containing
	/// IDisposable members does not itself implement IDisposable. Inspect: Api.
	/// </remarks>
	[ExcludeFromCodeCoverage]
	public abstract class BaseTest
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

			browser.Setup(o => o.Authorize())
				.Returns(new AuthorizationResult
				{
					AccessToken = "token",
					ExpiresIn = 1000,
					UserId = 1,
					State = "123456"
				});

			browser.Setup(m => m.Validate(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(new AuthorizationResult
				{
					AccessToken = "token",
					ExpiresIn = 1000,
					UserId = 1,
					State = "123456"
				});

			var restClient = new Mock<IRestClient>();

			restClient.Setup(x =>
					x.PostAsync(It.Is<Uri>(s => s == new Uri(Url)),
						It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
				.Callback(Callback)
				.Returns(() =>
				{
					if (string.IsNullOrWhiteSpace(Json))
					{
						throw new NullReferenceException(@"Json не может быть равен null. Обновите значение поля Json");
					}

					return Task.FromResult(HttpResponse<string>.Success(HttpStatusCode.OK,
						Json,
						Url));
				});

			restClient.Setup(x => x.PostAsync(It.Is<Uri>(s => string.IsNullOrWhiteSpace(Url)),
					It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
				.Throws<ArgumentException>();

			Api = new VkApi
			{
				Browser = browser.Object,
				RestClient = restClient.Object
			};

			Api.Authorize(new ApiAuthParams
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
			var response = JToken.Parse(Json);

			return new VkResponse(response) { RawJson = Json };
		}

		private void Callback()
		{
			if (string.IsNullOrWhiteSpace(Url))
			{
				throw new NullReferenceException(@"Url не может быть равен null. Обновите значение поля Url");
			}

			Url = Url.Replace("\'", "%27");
		}
	}
}