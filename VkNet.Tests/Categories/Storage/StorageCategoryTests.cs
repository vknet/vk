using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Storage;

public class StorageCategoryTests : CategoryBaseTest
{
	protected override string Folder => "Storage";

	[Fact]
	public void Get()
	{
		Url = "https://api.vk.com/method/storage.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.Storage.Get(new[]
		{
			"qwe"
		});

		result.Should()
			.NotBeNull();

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetKeys()
	{
		Url = "https://api.vk.com/method/storage.getKeys";
		ReadCategoryJsonPath(nameof(GetKeys));

		var result = Api.Storage.GetKeys();

		result.Should()
			.NotBeNull();

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void Set()
	{
		Url = "https://api.vk.com/method/storage.set";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Storage.Set("qwe", "qwe");

		result.Should()
			.BeTrue();
	}
}