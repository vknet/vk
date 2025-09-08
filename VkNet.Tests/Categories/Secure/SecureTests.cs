using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Secure;

public class SecureTests : CategoryBaseTest
{
	protected override string Folder => "Secure";

	[Fact(DisplayName = "Add app event")]
	public void AddAppEvent()
	{
		Url = "https://api.vk.ru/method/secure.addAppEvent";
		ReadJsonFile(JsonPaths.True);

		var app = Api.Secure.AddAppEvent(1, 2, 1500);

		app.Should()
			.BeTrue();
	}

	[Fact(DisplayName = "Check token")]
	public void CheckToken()
	{
		Url = "https://api.vk.ru/method/secure.checkToken";
		ReadCategoryJsonPath(nameof(CheckToken));

		var app = Api.Secure.CheckToken("access_token", "");

		app.Should()
			.NotBeNull();
	}

	[Fact(DisplayName = "Get app balance")]
	public void GetAppBalance()
	{
		Url = "https://api.vk.ru/method/secure.getAppBalance";
		ReadCategoryJsonPath(nameof(GetAppBalance));

		var app = Api.Secure.GetAppBalance();

		app.Should()
			.Be(5000);
	}

	[Fact(DisplayName = "Get sms history")]
	public void GetSmsHistory()
	{
		Url = "https://api.vk.ru/method/secure.getSMSHistory";
		ReadCategoryJsonPath(nameof(GetSmsHistory));

		var app = Api.Secure.GetSmsHistory(123);

		app.Should()
			.NotBeEmpty();

		var item = app.FirstOrDefault();

		item.Should()
			.NotBeNull();

		item.Id.Should()
			.Be(1238497);
	}

	[Fact(DisplayName = "Get transactions history")]
	public void GetTransactionsHistory()
	{
		Url = "https://api.vk.ru/method/secure.getTransactionsHistory";
		ReadCategoryJsonPath(nameof(GetTransactionsHistory));

		var app = Api.Secure.GetTransactionsHistory();

		app.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Get user level")]
	public void GetUserLevel()
	{
		Url = "https://api.vk.ru/method/secure.getUserLevel";
		ReadCategoryJsonPath(nameof(GetUserLevel));

		var app = Api.Secure.GetUserLevel([123]);

		app.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Give event sticker")]
	public void GiveEventSticker()
	{
		Url = "https://api.vk.ru/method/secure.giveEventSticker";
		ReadCategoryJsonPath(nameof(GiveEventSticker));

		var app = Api.Secure.GiveEventSticker([
				1,
				2,
				3
			],
			1);

		app.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Send notification")]
	public void SendNotification()
	{
		Url = "https://api.vk.ru/method/secure.sendNotification";
		ReadCategoryJsonPath(nameof(SendNotification));

		var app = Api.Secure.SendNotification("Notification",
			[123]);

		app.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Send sms notification")]
	public void SendSmsNotification()
	{
		Url = "https://api.vk.ru/method/secure.sendSMSNotification";
		ReadJsonFile(JsonPaths.True);

		var app = Api.Secure.SendSmsNotification(123, "SMS Message");

		app.Should()
			.BeTrue();
	}

	[Fact(DisplayName = "Set counter")]
	public void SetCounter()
	{
		Url = "https://api.vk.ru/method/secure.setCounter";
		ReadJsonFile(JsonPaths.True);

		var app = Api.Secure.SetCounter([
				"66748:6:1",
				"6492:2"
			],
			123,
			2,
			true);

		app.Should()
			.BeTrue();
	}
}