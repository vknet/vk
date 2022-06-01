using FluentAssertions;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class FriendsGetRequestsResultModel : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Test]
		public void ShouldHaveField_Message()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_Message));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			result.Message.Should().Be("text");
		}

		[Test]
		public void ShouldHaveField_Mutual()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_Mutual));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			result.Mutual.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldHaveField_UserId()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_UserId));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			result.UserId.Should().Be(221634238L);
		}
	}
}