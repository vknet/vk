﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Tests
{
	/// <inheritdoc />
	/// <summary>
	/// Базовый класс для тестирования категорий методов.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public abstract class BaseTest : IDisposable
	{
		protected readonly AutoMocker Mocker = new AutoMocker();

		/// <summary>
		/// Экземпляр класса API.
		/// </summary>
		protected VkApi Api;

		protected Encoding Encoding = Encoding.UTF8;

		/// <summary>
		/// Ответ от сервера.
		/// </summary>
		protected string Json;

		/// <summary>
		/// Url запроса.
		/// </summary>
		protected string Url;

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
			Mocker.Use<IApiAuthParams>(new ApiAuthParams
			{
				ApplicationId = 1,
				Login = "login",
				Password = "pass",
				Settings = Settings.All,
				Phone = "89510000000"
			});

			Mocker.Setup<IAuthorizationFlow, Task<AuthorizationResult>>(o => o.AuthorizeAsync())
				.ReturnsAsync(new AuthorizationResult
				{
					AccessToken = "token",
					ExpiresIn = 1000,
					UserId = 1,
					State = "123456"
				});

			Mocker.Setup<INeedValidationHandler, AuthorizationResult>(m => m.Validate(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(new AuthorizationResult
				{
					AccessToken = "token",
					ExpiresIn = 1000,
					UserId = 1,
					State = "123456"
				});

			Mocker.Setup<INeedValidationHandler, AuthorizationResult>(m => m.Validate(It.IsAny<string>()))
				.Returns(new AuthorizationResult
				{
					AccessToken = "token",
					ExpiresIn = 1000,
					UserId = 1,
					State = "123456"
				});

			Mocker.Setup<ICaptchaSolver, string>(m => m.Solve(It.IsAny<string>()))
				.Returns("123456");

			Mocker.Setup<IRestClient, Task<HttpResponse<string>>>(x =>
					x.PostAsync(It.Is<Uri>(s => s == new Uri(Url)),
						It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
				.Callback(Callback)
				.Returns(() =>
				{
					if (string.IsNullOrWhiteSpace(Json))
					{
						throw new NullReferenceException(@"Json не может быть равен null. Обновите значение поля Json");
					}

					return Task.FromResult(HttpResponse<string>.Success(HttpStatusCode.OK, Json, new Uri(Url)));
				});

			Mocker.Setup<IRestClient, Task<HttpResponse<string>>>(x => x.PostAsync(It.Is<Uri>(s => string.IsNullOrWhiteSpace(Url)),
					It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
				.Throws<ArgumentException>();

			Api = Mocker.CreateInstance<VkApi>();
			Api.RestClient = Mocker.Get<IRestClient>();
			Api.NeedValidationHandler = Mocker.Get<INeedValidationHandler>();
			Api.CaptchaSolver = Mocker.Get<ICaptchaSolver>();
			SetupCaptchaHandler();

			Api.Authorize(new ApiAuthParams
			{
				ApplicationId = 1,
				Login = "login",
				Password = "pass",
				Settings = Settings.All,
				Phone = "89510000000"
			});

			Api.RequestsPerSecond = int.MaxValue;
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

		protected virtual void SetupCaptchaHandler()
		{
		}

		protected VkResponse GetResponse()
		{
			var response = JToken.Parse(Json);

			return new VkResponse(response)
			{
				RawJson = Json
			};
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
				AppContext.BaseDirectory,
				"TestData"
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
	}
}