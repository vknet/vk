using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Secure
{
	[TestFixture]
	public class SecureTests : CategoryBaseTest
	{
		protected override string Folder => "Secure";

		[Test]
		public void AddAppEvent()
		{
			Url = "https://api.vk.com/method/secure.addAppEvent";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Secure.AddAppEvent(1, 2, 1500);

			Assert.IsTrue(app);
		}

		[Test]
		public void CheckToken()
		{
			Url = "https://api.vk.com/method/secure.checkToken";
			ReadCategoryJsonPath(nameof(CheckToken));

			var app = Api.Secure.CheckToken("access_token", "");

			Assert.IsNotNull(app);
		}

		[Test]
		public void GetAppBalance()
		{
			Url = "https://api.vk.com/method/secure.getAppBalance";
			ReadCategoryJsonPath(nameof(GetAppBalance));

			var app = Api.Secure.GetAppBalance();

			Assert.AreEqual(5000, app);
		}

		[Test]
		public void GetSmsHistory()
		{
			Url = "https://api.vk.com/method/secure.getSMSHistory";
			ReadCategoryJsonPath(nameof(GetSmsHistory));

			var app = Api.Secure.GetSmsHistory(123);

			Assert.IsNotEmpty(app);
			var item = app.FirstOrDefault();
			Assert.NotNull(item);
			Assert.AreEqual(1238497, item.Id);
		}

		[Test]
		public void GetTransactionsHistory()
		{
			Url = "https://api.vk.com/method/secure.getTransactionsHistory";
			ReadCategoryJsonPath(nameof(GetTransactionsHistory));

			var app = Api.Secure.GetTransactionsHistory();

			Assert.IsNotEmpty(app);
		}

		[Test]
		public void GetUserLevel()
		{
			Url = "https://api.vk.com/method/secure.getUserLevel";
			ReadCategoryJsonPath(nameof(GetUserLevel));

			var app = Api.Secure.GetUserLevel(new long[]
			{
				123
			});

			Assert.IsNotEmpty(app);
		}

		[Test]
		public void GiveEventSticker()
		{
			Url = "https://api.vk.com/method/secure.giveEventSticker";
			ReadCategoryJsonPath(nameof(GiveEventSticker));

			var app = Api.Secure.GiveEventSticker(new ulong[]
				{
					1,
					2,
					3
				},
				1);

			Assert.IsNotEmpty(app);
		}

		[Test]
		public void SendNotification()
		{
			Url = "https://api.vk.com/method/secure.sendNotification";
			ReadCategoryJsonPath(nameof(SendNotification));

			var app = Api.Secure.SendNotification("Notification",
				new ulong[]
				{
					123
				});

			Assert.IsNotEmpty(app);
		}

		[Test]
		public void SendSmsNotification()
		{
			Url = "https://api.vk.com/method/secure.sendSMSNotification";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Secure.SendSmsNotification(123, "SMS Message");

			Assert.That(app, Is.True);
		}

		[Test]
		public void SetCounter()
		{
			Url = "https://api.vk.com/method/secure.setCounter";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Secure.SetCounter(new[]
				{
					"66748:6:1",
					"6492:2"
				},
				123,
				2,
				true);

			Assert.That(app, Is.True);
		}
	}
}