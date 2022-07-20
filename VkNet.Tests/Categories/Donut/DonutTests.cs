using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Donut
{
	public class DonutTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Donut";

		[Fact]
		public void IsDon()
		{
			Url = "https://api.vk.com/method/donut.isDon";
			ReadJsonFile(JsonPaths.False);
			Api.Donut.IsDon(-173151748).Should().BeFalse();
		}

		[Fact]
		public void GetFriends()
		{
			Url = "https://api.vk.com/method/donut.getFriends";
			ReadJsonFile(JsonPaths.EmptyArray);
			var result = Api.Donut.GetFriends(-173151748, 0, 3, new UsersFields());
			result.Should().NotBeNull();
		}

		[Fact]
		public void GetSubscription()
		{
			Url = "https://api.vk.com/method/donut.getSubscription";
			ReadErrorsJsonFile(104);
			FluentActions.Invoking(() => Api.Donut.GetSubscription(-173151748)).Should().ThrowExactly<VkApiMethodInvokeException>();
		}

		[Fact]
		public void GetSubscriptions()
		{
			Url = "https://api.vk.com/method/donut.getSubscriptions";
			ReadCategoryJsonPath(nameof(GetSubscriptions));
			Api.Donut.GetSubscriptions(new UsersFields(), 1, 1).Should().NotBeNull();
		}
	}
}
