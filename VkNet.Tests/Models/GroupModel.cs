using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GroupModel : BaseTest
	{
		[Test]
		public void ShouldHaveField_Trending()
		{
			var group = new Group();
			Assert.That(group, Has.Property("Trending"));
		}

		[Test]
		public void Trending_ShouldBeFalse()
		{
			ReadJsonFile("Models", nameof(Trending_ShouldBeFalse));

			var response = GetResponse();
			var group = Group.FromJson(response);

			Assert.That(group.Trending, Is.False);
		}

		[Test]
		public void Trending_ShouldBeFalse2()
		{
			ReadJsonFile("Models", nameof(Trending_ShouldBeFalse2));

			var response = GetResponse();
			var group = Group.FromJson(response);
			Assert.That(group.Trending, Is.False);
		}

		[Test]
		public void Trending_ShouldBeTrue()
		{
			ReadJsonFile("Models", nameof(Trending_ShouldBeTrue));

			var response = GetResponse();
			var group = Group.FromJson(response);
			Assert.That(group.Trending, Is.True);
		}
	}
}