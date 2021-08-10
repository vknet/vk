using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Donut
{
	class DonutTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Donut";

		[Test]
		public void IsDon()
		{
			Url = "https://api.vk.com/method/donut.isDon";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Donut.IsDon(-173151748), Is.False);
		}

		[Test]
		public void GetFriends()
		{
			Url = "https://api.vk.com/method/donut.getFriends";
			ReadJsonFile(JsonPaths.EmptyArray);
			var result = Api.Donut.GetFriends(-173151748, 0, 3, new UsersFields());
			Assert.NotNull(result);
		}

		[Test]
		public void GetSubscription()
		{
			Url = "https://api.vk.com/method/donut.getSubscription";
			ReadErrorsJsonFile(104);
			Assert.That(() => Api.Donut.GetSubscription(-173151748), Throws.InstanceOf<VkApiMethodInvokeException>());
		}

		[Test]
		public void GetSubscriptions()
		{
			Url = "https://api.vk.com/method/donut.getSubscriptions";
			ReadCategoryJsonPath(nameof(GetSubscriptions));
			Assert.NotNull(Api.Donut.GetSubscriptions(new UsersFields(), 1, 1));
		}
	}
}
