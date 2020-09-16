using System.Diagnostics.CodeAnalysis;
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

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.Page));
		}

		[Test]
		public void VkObjectApplication()
		{
			ReadJsonFile("Models", nameof(VkObjectApplication));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.Application));
		}

		[Test]
		public void VkObjectGroup()
		{
			ReadJsonFile("Models", nameof(VkObjectGroup));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.Group));
		}

		[Test]
		public void VkObjectUser()
		{
			ReadJsonFile("Models", nameof(VkObjectUser));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Call<VkObject>("utils.resolveScreenName", VkParameters.Empty);

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.User));
		}

		[Test]
		public void VkObjectPage_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectPage));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("page");

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.Page));
		}

		[Test]
		public void VkObjectApplication_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectApplication));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("application");

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.Application));
		}

		[Test]
		public void VkObjectGroup_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectGroup));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("group");

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.Group));
		}

		[Test]
		public void VkObjectUser_ResolveScreenName()
		{
			ReadJsonFile("Models", nameof(VkObjectUser));

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName("user");

			Assert.That(result.Id, Is.EqualTo(179331040));
			Assert.That(result.Type, Is.EqualTo(VkObjectType.User));
		}
	}
}