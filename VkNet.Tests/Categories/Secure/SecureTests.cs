using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Secure
{

	public class SecureTests : CategoryBaseTest
	{
		protected override string Folder => "Secure";

		[Fact]
		public void AddAppEvent()
		{
			Url = "https://api.vk.com/method/secure.addAppEvent";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Secure.AddAppEvent(1, 2, 1500);

			app.Should().BeTrue();
		}

		[Fact]
		public void CheckToken()
		{
			Url = "https://api.vk.com/method/secure.checkToken";
			ReadCategoryJsonPath(nameof(CheckToken));

			var app = Api.Secure.CheckToken("access_token", "");

			app.Should().NotBeNull();
		}

		[Fact]
		public void GetAppBalance()
		{
			Url = "https://api.vk.com/method/secure.getAppBalance";
			ReadCategoryJsonPath(nameof(GetAppBalance));

			var app = Api.Secure.GetAppBalance();

			app.Should().Be(5000);
		}

		[Fact]
		public void GetSmsHistory()
		{
			Url = "https://api.vk.com/method/secure.getSMSHistory";
			ReadCategoryJsonPath(nameof(GetSmsHistory));

			var app = Api.Secure.GetSmsHistory(123);

			app.Should().NotBeEmpty();
			var item = app.FirstOrDefault();
			item.Should().NotBeNull();
			item.Id.Should().Be(1238497);
		}

		[Fact]
		public void GetTransactionsHistory()
		{
			Url = "https://api.vk.com/method/secure.getTransactionsHistory";
			ReadCategoryJsonPath(nameof(GetTransactionsHistory));

			var app = Api.Secure.GetTransactionsHistory();

			app.Should().NotBeEmpty();
		}

		[Fact]
		public void GetUserLevel()
		{
			Url = "https://api.vk.com/method/secure.getUserLevel";
			ReadCategoryJsonPath(nameof(GetUserLevel));

			var app = Api.Secure.GetUserLevel(new long[]
			{
				123
			});

			app.Should().NotBeEmpty();
		}

		[Fact]
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

			app.Should().NotBeEmpty();
		}

		[Fact]
		public void SendNotification()
		{
			Url = "https://api.vk.com/method/secure.sendNotification";
			ReadCategoryJsonPath(nameof(SendNotification));

			var app = Api.Secure.SendNotification("Notification",
				new ulong[]
				{
					123
				});

			app.Should().NotBeEmpty();
		}

		[Fact]
		public void SendSmsNotification()
		{
			Url = "https://api.vk.com/method/secure.sendSMSNotification";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Secure.SendSmsNotification(123, "SMS Message");

			app.Should().BeTrue();
		}

		[Fact]
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

			app.Should().BeTrue();
		}
	}
}