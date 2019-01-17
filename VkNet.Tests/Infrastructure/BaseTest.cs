using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Text;
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
	/// <inheritdoc />
	/// <summary>
	/// Базовый класс для тестирования категорий методов.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public abstract class BaseTest : IDisposable
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
		/// Url запроса.
		/// </summary>
		protected string Url;

		protected Encoding Encoding = Encoding.UTF8;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

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

			browser.Setup(m => m.Validate(It.IsAny<string>()))
				.Returns(new AuthorizationResult
				{
					AccessToken = "token",
					ExpiresIn = 1000,
					UserId = 1,
					State = "123456"
				});

			var restClient = new Mock<IRestClient>();

			SetupIRestClient(restClient);

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
				Settings = Settings.All,
				Phone = "89510000000"
			});

			Api.RequestsPerSecond = 999999999; // Чтобы тесты быстрее выполнялись
		}

		/// <summary>
		/// После исполнения каждого теста.
		/// </summary>
		[TearDown]
		public void Cleanup()
		{
			Json = null;
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

		protected void ReadJsonFile(params string[] jsonRelativePaths)
		{
			Json = ReadJson(jsonRelativePaths);
		}

		protected void ReadErrorsJsonFile(uint errorCode)
		{
			ReadJsonFile("Errors", errorCode.ToString());
		}

		protected string ReadJson(params string[] jsonRelativePaths)
		{
			var folders = new List<string>
			{
				AppContext.BaseDirectory, "TestData"
			};

			folders.AddRange(jsonRelativePaths);

			var path = Path.Combine(folders.ToArray()) + ".json";

			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path);
			}

			return File.ReadAllText(path, Encoding);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				Api?.Dispose();
			}
		}

		protected void SetupIRestClient(Mock<IRestClient> restClient)
		{
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

					return Task.FromResult(HttpResponse<string>.Success(HttpStatusCode.OK, Json, Url));
				});

			restClient.Setup(x => x.PostAsync(It.Is<Uri>(s => string.IsNullOrWhiteSpace(Url)),
					It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
				.Throws<ArgumentException>();
		}
	}
}