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

		public string Json = null;

		public VkParameters Parameters = new VkParameters();

		/// <summary>
		/// Пред установки выполнения каждого теста.
		/// </summary>
		[SetUp]
		public void Init()
		{
			var browser = new Mock<IBrowser>();
			browser.Setup(m => m.GetJson(It.IsAny<string>())).Returns(() =>
			{
				if (string.IsNullOrWhiteSpace(Json))
				{
					throw new ArgumentNullException(nameof(Json), "Json не может быть равен null. Обновите значение поля Json");
				}
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
		}
	}
}