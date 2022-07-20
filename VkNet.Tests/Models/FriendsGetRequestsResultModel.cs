using FluentAssertions;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Models
{


	public class FriendsGetRequestsResultModel : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Fact]
		public void ShouldHaveField_Message()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_Message));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			result.Message.Should().Be("text");
		}

		[Fact]
		public void ShouldHaveField_Mutual()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_Mutual));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			result.Mutual.Should().NotBeEmpty();
		}

		[Fact]
		public void ShouldHaveField_UserId()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_UserId));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			result.UserId.Should().Be(221634238L);
		}
	}
}