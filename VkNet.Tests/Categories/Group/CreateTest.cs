using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group
{


	public class CreateTest : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Fact]
		public void Create()
		{
			Url = "https://api.vk.com/method/groups.create";

			ReadCategoryJsonPath(nameof(Create));

			var result = Api.Groups.Create("Test_Group");

			result.Should().NotBeNull();
			result.IsMember.Should().BeTrue();
		}
	}
}