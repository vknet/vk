using System;
using System.Collections.Generic;
using System.Net;
using Moq;
using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Tests
{
    /// <summary>
    /// Базовый класс для тестирования категорий методов.
    /// </summary>
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
        /// Url запроса.
        /// </summary>
        protected string Url;

        /// <summary>
        /// Параметры запроса.
        /// </summary>
        protected VkParameters Parameters = new VkParameters();

        /// <summary>
        /// Пред установки выполнения каждого теста.
        /// </summary>
        [SetUp]
        public void Init()
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(It.Is<string>(s => s == Url), It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Callback(Callback)
                .Returns(() =>
                {
                    if (string.IsNullOrWhiteSpace(Json))
                    {
                        throw new ArgumentNullException(nameof(Json), @"Json не может быть равен null. Обновите значение поля Json");
                    }
                    return Json;
                });

            browser.Setup(o => o.Authorize(
                It.IsAny<ulong>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Settings>(),
                It.IsAny<Func<string>>(),
                It.IsAny<long?>(),
                It.IsAny<string>(),
                It.IsAny<IWebProxy>()
                )
			)
			.Returns(VkAuthorization.From(new Uri("https://vk.com/auth?__q_hash=qwerty&access_token=token&expires_in=1000&user_id=1")));
            Api = new VkApi
            {
                Browser = browser.Object
            };
            Api.Authorize(new ApiAuthParams
            {
	            ApplicationId = 1,
				Login = "login",
				Password = "pass",
				Settings = Settings.All
            });
	        Api.RequestsPerSecond = 10000; // Чтобы тесты быстрее выполнялись
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

        private void Callback()
        {
            if (string.IsNullOrWhiteSpace(Url))
            {
                throw new ArgumentNullException(nameof(Json), @"Url не может быть равен null. Обновите значение поля Url");
            }
            Url = Url.Replace("\'", "%27");
        }
    }
}