using System;
using Moq;
using NUnit.Framework;
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
		public VkApi Api;

		/// <summary>
		/// Ответ от сервера.
		/// </summary>
		public string Json = null;

		/// <summary>
		/// Url запроса.
		/// </summary>
		public string Url = null;

		/// <summary>
		/// Параметры запроса.
		/// </summary>
		public VkParameters Parameters = new VkParameters();

		/// <summary>
		/// Пред установки выполнения каждого теста.
		/// </summary>
		[SetUp]
		public void Init()
		{
			var browser = new Mock<IBrowser>();
			browser.Setup(m => m.GetJson(It.Is<string>(s => s == Url)))
				.Callback(() =>
				{
					if (string.IsNullOrWhiteSpace(Url))
					{
						throw new ArgumentNullException(nameof(Json), "Url не может быть равен null. Обновите значение поля Url");
					}
				})
				.Returns(() =>
				{
					if (string.IsNullOrWhiteSpace(Json))
					{
						throw new ArgumentNullException(nameof(Json), "Json не может быть равен null. Обновите значение поля Json");
					}
					browser.VerifyAll();
					return Json;
				});
			Api = new VkApi
			{
				AccessToken = "token",
				Browser = browser.Object
			};
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
	}
}