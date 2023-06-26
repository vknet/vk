using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests;

public class VkApiTest : BaseTest
{
	[Fact]
	public void AuthorizeByToken()
	{
		Api.Authorize(new()
		{
			AccessToken = "token",
			UserId = 1
		});

		Api.UserId.Should()
			.Be(1);
	}

	[Fact]
	public void AuthorizeAndUpdateTokenAutomatically()
	{
		Api.Authorize(new()
		{
			ApplicationId = 1,
			Login = "login",
			Password = "pass",
			Settings = Settings.All,
			Phone = "89510000000",
			IsTokenUpdateAutomatically = true
		});

		var waiter = new AutoResetEvent(initialState: false);

		Api.OnTokenUpdatedAutomatically += _ =>
		{
			waiter.Set();
		};

		var isUpdated = waiter.WaitOne();

		isUpdated.Should()
			.BeTrue();
	}

	[Fact(Skip = "Не работает")]
	public async Task Call_NotMoreThen3CallsPerSecond()
	{
		Url = "https://api.vk.com/method/friends.getRequests";
		ReadJsonFile(nameof(VkApi), nameof(Call_NotMoreThen3CallsPerSecond));
		const int callsCount = 3;
		Api.RequestsPerSecond = callsCount;

		var taskList = new List<Task>();
		var calls = 0;

		for (var i = 0; i < callsCount + 1; i++)
		{
			taskList.Add(Api.CallAsync("friends.getRequests", VkParameters.Empty, true)
				.ContinueWith(_ => Interlocked.Increment(ref calls)));
		}

		await Task.Delay(1000);

		calls.Should()
			.BeLessThanOrEqualTo(callsCount);
	}

	[Fact]
	public void CallAndConvertToType()
	{
		Url = "https://api.vk.com/method/friends.getRequests";
		ReadJsonFile(nameof(VkApi), nameof(CallAndConvertToType));

		var result = Api.Call<FriendsGetRequestsResult>("friends.getRequests", VkParameters.Empty);

		result.Should()
			.NotBeNull();

		result.UserId.Should()
			.Be(221634238);

		result.Message.Should()
			.Be("text");

		result.Mutual.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void DefaultLanguageValue()
	{
		var lang = Api.GetLanguage();

		lang.Should()
			.BeNull();
	}

	[Fact]
	public void DisposeTest() => Api.Dispose();

	[Fact]
	public void EnglishLanguageValue()
	{
		Api.SetLanguage(Language.En);
		var lang = Api.GetLanguage();

		lang.Should()
			.Be(Language.En);
	}

	[Fact]
	public void Invoke_DictionaryParams()
	{
		Url = "https://api.vk.com/method/example.get";
		ReadJsonFile(JsonPaths.EmptyArray);

		var parameters = new Dictionary<string, string>
		{
			{
				"count", "23"
			}
		};

		var json = Api.Invoke("example.get", parameters, true);

		Json.Should()
			.BeEquivalentTo(json);
	}

	[Fact]
	public void Invoke_VkParams()
	{
		Url = "https://api.vk.com/method/example.get";
		ReadJsonFile(JsonPaths.EmptyArray);

		var parameters = new VkParameters
		{
			{
				"count", 23
			}
		};

		var json = Api.Invoke("example.get", parameters, true);

		Json.Should()
			.BeEquivalentTo(json);
	}

	[Fact]
	public void Validate()
	{
		var uri = new Uri("https://m.vk.com/activation?act=validate&api_hash=f2fed5f22ebadc301e&hash=c8acf371111c938417");
		Api.Validate(uri.ToString());
	}

	[Fact]
	public void VkApi_Constructor_SetDefaultMethodCategories()
	{
		Api.Users.Should()
			.NotBeNull();

		Api.Friends.Should()
			.NotBeNull();

		Api.Status.Should()
			.NotBeNull();

		Api.Messages.Should()
			.NotBeNull();

		Api.Groups.Should()
			.NotBeNull();

		Api.Audio.Should()
			.NotBeNull();

		Api.Wall.Should()
			.NotBeNull();

		Api.Database.Should()
			.NotBeNull();

		Api.Utils.Should()
			.NotBeNull();

		Api.Fave.Should()
			.NotBeNull();

		Api.Video.Should()
			.NotBeNull();

		Api.Account.Should()
			.NotBeNull();

		Api.Photo.Should()
			.NotBeNull();

		Api.Docs.Should()
			.NotBeNull();

		Api.Likes.Should()
			.NotBeNull();

		Api.Pages.Should()
			.NotBeNull();

		Api.Gifts.Should()
			.NotBeNull();

		Api.Apps.Should()
			.NotBeNull();

		Api.NewsFeed.Should()
			.NotBeNull();

		Api.Stats.Should()
			.NotBeNull();

		Api.Auth.Should()
			.NotBeNull();

		Api.Markets.Should()
			.NotBeNull();

		Api.Ads.Should()
			.NotBeNull();
	}

	[Fact]
	public void VkCallShouldBePublic()
	{
		// arrange
		var myType = typeof(VkApi);
		var myArrayMethodInfo = myType.GetMethods();

		// act
		var callMethod = myArrayMethodInfo.FirstOrDefault(x => x.Name.Contains("Call"));

		// Assert
		callMethod.Should()
			.NotBeNull();

		callMethod.IsPublic.Should()
			.BeTrue();
	}

	[Fact]
	public void VersionShouldBeenChanged()
	{
		Api.VkApiVersion.SetVersion(999, 0);

		Api.VkApiVersion.Version.Should()
			.Be("999.0");
	}

	[Fact]
	public void Logout()
	{
		Api.LogOut();

		Api.Token.Should()
			.BeEmpty();
	}
}