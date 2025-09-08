using AwesomeAssertions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class VkObjectTests : BaseTest
{
	[Fact(DisplayName = "Vk object page")]
	public void VkObjectPage()
	{
		ReadJsonFile("Models", nameof(VkObjectPage));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.Page);
	}

	[Fact(DisplayName = "Vk object application")]
	public void VkObjectApplication()
	{
		ReadJsonFile("Models", nameof(VkObjectApplication));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.Application);
	}

	[Fact(DisplayName = "Vk object group")]
	public void VkObjectGroup()
	{
		ReadJsonFile("Models", nameof(VkObjectGroup));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.Group);
	}

	[Fact(DisplayName = "Vk object user")]
	public void VkObjectUser()
	{
		ReadJsonFile("Models", nameof(VkObjectUser));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.User);
	}

	[Fact(DisplayName = "Vk object page resolve screen name")]
	public void VkObjectPage_ResolveScreenName()
	{
		ReadJsonFile("Models", nameof(VkObjectPage));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Utils.ResolveScreenName("page");

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.Page);
	}

	[Fact(DisplayName = "Vk object application resolve screen name")]
	public void VkObjectApplication_ResolveScreenName()
	{
		ReadJsonFile("Models", nameof(VkObjectApplication));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Utils.ResolveScreenName("application");

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.Application);
	}

	[Fact(DisplayName = "Vk object group resolve screen name")]
	public void VkObjectGroup_ResolveScreenName()
	{
		ReadJsonFile("Models", nameof(VkObjectGroup));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Utils.ResolveScreenName("group");

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.Group);
	}

	[Fact(DisplayName = "Vk object user resolve screen name")]
	public void VkObjectUser_ResolveScreenName()
	{
		ReadJsonFile("Models", nameof(VkObjectUser));

		Url = "https://api.vk.ru/method/utils.resolveScreenName";
		var result = Api.Utils.ResolveScreenName("user");

		result.Id.Should()
			.Be(179331040);

		result.Type.Should()
			.Be(VkObjectType.User);
	}
}