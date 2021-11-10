using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class CreateTest : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void Create()
		{
			Url = "https://api.vk.com/method/groups.create";

			ReadCategoryJsonPath(nameof(Create));

			var result = Api.Groups.Create("Test_Group");

			result.Should().NotBeNull();
			Assert.AreEqual(true, result.IsMember);
		}
	}
}