using System.Linq;
using FluentAssertions;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollDonutTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_DonutSubscriptionCreate()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionCreate));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutNew:
					{
						var a = x.Instance is DonutNew b
							? b
							: null;

						a.Amount.Should()
							.Be(50);

						a.AmountWithoutFee.Should()
							.Be(49.8M);

						a.UserId.Should()
							.Be(1234);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_DonutSubscriptionProlonged()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionProlonged));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutNew:
					{
						var a = x.Instance is DonutNew b
							? b
							: null;

						a.Amount.Should()
							.Be(50);

						a.AmountWithoutFee.Should()
							.Be(49.8M);

						a.UserId.Should()
							.Be(1234);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_DonutSubscriptionCancelled()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionCancelled));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutEnd:
					{
						var a = x.Instance is DonutEnd b
							? b
							: null;

						a.UserId.Should()
							.Be(1234);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_DonutSubscriptionExpired()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionExpired));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutEnd:
					{
						var a = x.Instance is DonutEnd b
							? b
							: null;

						a.UserId.Should()
							.Be(1234);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_DonutSubscriptionPriceChanged()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionPriceChanged));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutChanged:
					{
						var a = x.Instance is DonutChanged b
							? b
							: null;

						a.AmountOld.Should()
							.Be(50);

						a.AmountNew.Should()
							.Be(100);

						a.AmountDiff.Should()
							.Be(50.0f);

						a.AmountDiffWithoutFee.Should()
							.Be(49.8f);

						a.UserId.Should()
							.Be(1234);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_DonutWithdraw()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutWithdraw));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutWithdraw:
					{
						var a = x.Instance is DonutWithdraw b
							? b
							: null;

						a.Amount.Should()
							.Be(50);

						a.AmountWithoutFee.Should()
							.Be(49.8f);

						a.Error.Should()
							.BeFalse();

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_DonutWithdrawError()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutWithdrawError));

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(new GroupId(1234));
						break;

					case DonutWithdraw:
					{
						var a = x.Instance is DonutWithdraw b
							? b
							: null;

						a.Amount.Should()
							.BeNull();

						a.AmountWithoutFee.Should()
							.BeNull();

						a.Error.Should()
							.BeTrue();

						a.Reason.Should()
							.Be("test");

						break;
					}
				}
			});
	}
}