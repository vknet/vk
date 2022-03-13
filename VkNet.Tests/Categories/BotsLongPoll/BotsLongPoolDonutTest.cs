using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollDonutTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionCreate()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionCreate));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionNew;

			Assert.AreEqual(50, donutNew.Amount);
			Assert.AreEqual(49.8f, donutNew.AmountWithoutFee);
			Assert.AreEqual(1234, donutNew.UserId);
			Assert.AreEqual(1234, update.GroupId);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionProlonged()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionProlonged));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionNew;

			Assert.AreEqual(50, donutNew.Amount);
			Assert.AreEqual(49.8f, donutNew.AmountWithoutFee);
			Assert.AreEqual(1234, donutNew.UserId);
			Assert.AreEqual(1234, update.GroupId);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionCancelled()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionCancelled));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionEnd;

			Assert.AreEqual(1234, donutNew.UserId);
			Assert.AreEqual(1234, update.GroupId);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionExpired()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionExpired));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionEnd;

			Assert.AreEqual(1234, donutNew.UserId);
			Assert.AreEqual(1234, update.GroupId);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionPriceChanged()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionPriceChanged));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionPriceChanged;

			Assert.AreEqual(50, donutNew.AmountOld);
			Assert.AreEqual(100, donutNew.AmountNew);
			Assert.AreEqual(50.0f, donutNew.AmountDiff);
			Assert.AreEqual(49.8f, donutNew.AmountDiffWithoutFee);
			Assert.AreEqual(1234, donutNew.UserId);
			Assert.AreEqual(1234, update.GroupId);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutWithdraw()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutWithdraw));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutMoneyWithdraw;

			Assert.AreEqual(50, donutNew.Amount);
			Assert.AreEqual(49.8f, donutNew.AmountWithoutFee);
			Assert.AreEqual(false, donutNew.Error);
			Assert.AreEqual(1234, update.GroupId);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutWithdrawError()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutWithdrawError));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutMoneyWithdraw;

			Assert.AreEqual(null, donutNew.Amount);
			Assert.AreEqual(null, donutNew.AmountWithoutFee);
			Assert.AreEqual(true, donutNew.Error);
			Assert.AreEqual("test", donutNew.Reason);
			Assert.AreEqual(1234, update.GroupId);
		}
	}
}