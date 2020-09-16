using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Storage
{
	[TestFixture]

	public class StorageCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Storage";

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/storage.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.Storage.Get(new[] { "qwe" });

			Assert.NotNull(result);
			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetKeys()
		{
			Url = "https://api.vk.com/method/storage.getKeys";
			ReadCategoryJsonPath(nameof(GetKeys));

			var result = Api.Storage.GetKeys();

			Assert.NotNull(result);
			Assert.IsNotEmpty(result);
		}

		[Test]
		public void Set()
		{
			Url = "https://api.vk.com/method/storage.set";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Storage.Set("qwe", "qwe");

			Assert.True(result);
		}
	}
}