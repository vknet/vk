using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;

namespace VkNet.Tests
{
	[TestFixture]

	public class VkApiTest : BaseTest
	{
		[Test]
		public void AuthorizeByToken()
		{
			Api.Authorize(new ApiAuthParams
			{
				AccessToken = "token",
				UserId = 1
			});

			Assert.That(Api.UserId, Is.EqualTo(1));
		}

		[Test]
		public void AuthorizeAndUpdateTokenAutomatically()
		{
			Api.Authorize(new ApiAuthParams
			{
				ApplicationId = 1,
				Login = "login",
				Password = "pass",
				Settings = Settings.All,
				Phone = "89510000000",
				IsTokenUpdateAutomatically = true
			});

			var waiter = new AutoResetEvent(initialState: false);

			Api.OnTokenUpdatedAutomatically += (_) =>
			{
				waiter.Set();
			};

			var isUpdated = waiter.WaitOne();

			Assert.IsTrue(isUpdated);
		}

		[Test, /*Ignore("Тест врет и не проверяет стабильное воспроизведение, ошибка либо в реализации либо в базовом классе теста")*/]
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
				taskList.Add(Api.CallAsync("friends.getRequests", VkParameters.Empty, true).ContinueWith(_ => Interlocked.Increment(ref calls)));
			}

			await Task.Delay(1000);
			calls.Should().BeLessThanOrEqualTo(callsCount);
		}

		[Test]
		public void CallAndConvertToType()
		{
			Url = "https://api.vk.com/method/friends.getRequests";
			ReadJsonFile(nameof(VkApi), nameof(CallAndConvertToType));

			var result = Api.Call<FriendsGetRequestsResult>("friends.getRequests", VkParameters.Empty);

			result.Should().NotBeNull();
			Assert.That(result.UserId, Is.EqualTo(221634238));
			Assert.That(result.Message, Is.EqualTo("text"));
			Assert.IsNotEmpty(result.Mutual);
		}

		[Test]
		public void DefaultLanguageValue()
		{
			var lang = Api.GetLanguage();
			Assert.IsNull(lang);
		}

		[Test]
		public void DisposeTest()
		{
			Api.Dispose();
		}

		[Test]
		public void EnglishLanguageValue()
		{
			Api.SetLanguage(Language.En);
			var lang = Api.GetLanguage();
			Assert.AreEqual(lang, Language.En);
		}

		[Test]
		public void Invoke_DictionaryParams()
		{
			Url = "https://api.vk.com/method/example.get";
			ReadJsonFile(JsonPaths.EmptyArray);

			var parameters = new Dictionary<string, string>
			{
				{ "count", "23" }
			};

			var json = Api.Invoke("example.get", parameters, true);

			StringAssert.AreEqualIgnoringCase(json, Json);
		}

		[Test]
		public void Invoke_VkParams()
		{
			Url = "https://api.vk.com/method/example.get";
			ReadJsonFile(JsonPaths.EmptyArray);

			var parameters = new VkParameters
			{
				{ "count", 23 }
			};

			var json = Api.Invoke("example.get", parameters, true);

			StringAssert.AreEqualIgnoringCase(json, Json);
		}

		[Test]
		public void Validate()
		{
			var uri = new Uri("https://m.vk.com/activation?act=validate&api_hash=f2fed5f22ebadc301e&hash=c8acf371111c938417");
			Api.Validate(uri.ToString());
		}

		[Test]
		public void VkApi_Constructor_SetDefaultMethodCategories()
		{
			Assert.That(Api.Users, Is.Not.Null);
			Assert.That(Api.Friends, Is.Not.Null);
			Assert.That(Api.Status, Is.Not.Null);
			Assert.That(Api.Messages, Is.Not.Null);
			Assert.That(Api.Groups, Is.Not.Null);
			Assert.That(Api.Audio, Is.Not.Null);
			Assert.That(Api.Wall, Is.Not.Null);
			Assert.That(Api.Database, Is.Not.Null);
			Assert.That(Api.Utils, Is.Not.Null);
			Assert.That(Api.Fave, Is.Not.Null);
			Assert.That(Api.Video, Is.Not.Null);
			Assert.That(Api.Account, Is.Not.Null);
			Assert.That(Api.Photo, Is.Not.Null);
			Assert.That(Api.Docs, Is.Not.Null);
			Assert.That(Api.Likes, Is.Not.Null);
			Assert.That(Api.Pages, Is.Not.Null);
			Assert.That(Api.Gifts, Is.Not.Null);
			Assert.That(Api.Apps, Is.Not.Null);
			Assert.That(Api.NewsFeed, Is.Not.Null);
			Assert.That(Api.Stats, Is.Not.Null);
			Assert.That(Api.Auth, Is.Not.Null);
			Assert.That(Api.Markets, Is.Not.Null);
			Assert.That(Api.Ads, Is.Not.Null);
		}

		[Test]
		public void VkCallShouldBePublic()
		{
			// arrange
			var myType = typeof(VkApi);
			var myArrayMethodInfo = myType.GetMethods();

			// act
			var callMethod = myArrayMethodInfo.FirstOrDefault(x => x.Name.Contains("Call"));

			// Assert
			callMethod.Should().NotBeNull();
			Assert.IsTrue(callMethod.IsPublic);
		}

		[Test]
		public void VersionShouldBeenChanged()
		{
			Api.VkApiVersion.SetVersion(999, 0);

			Assert.AreEqual("999.0", Api.VkApiVersion.Version);
		}

		[Test]
		public void Logout()
		{
			Api.LogOut();
			Assert.IsEmpty(Api.Token);
		}
	}
}