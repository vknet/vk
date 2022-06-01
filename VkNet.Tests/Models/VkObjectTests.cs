using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class VkObjectTests : BaseTest
	{
		[Test]
		public void VkObjectPage()
		{
			ReadJsonFile("Models", nameof(VkObjectPage));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.Page);
		}

		[Test]
		public void VkObjectApplication()
		{
			ReadJsonFile("Models", nameof(VkObjectApplication));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.Application);
		}

		[Test]
		public void VkObjectGroup()
		{
			ReadJsonFile("Models", nameof(VkObjectGroup));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.Group);
		}

		[Test]
		public void VkObjectUser()
		{
			ReadJsonFile("Models", nameof(VkObjectUser));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.User);
		}

		[Test]
		public void VkObjectPage_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectPage));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("page");

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.Page);
		}

		[Test]
		public void VkObjectApplication_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectApplication));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("application");

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.Application);
		}

		[Test]
		public void VkObjectGroup_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectGroup));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("group");

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.Group);
		}

		[Test]
		public void VkObjectUser_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectUser));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("user");

			result.Id.Should().Be(179331040);
			result.Type.Should().Be(VkObjectType.User);
		}
	}
}