using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class FriendsGetRequestsResultModel : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Test]
		public void ShouldHaveField_Message()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_Message));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			Assert.That(result.Message, Is.EqualTo("text"));
		}

		[Test]
		public void ShouldHaveField_Mutual()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_Mutual));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			Assert.IsNotEmpty(result.Mutual);
		}

		[Test]
		public void ShouldHaveField_UserId()
		{
			ReadCategoryJsonPath(nameof(ShouldHaveField_UserId));

			var response = GetResponse();
			var result = FriendsGetRequestsResult.FromJson(response);

			Assert.That(result.UserId, Is.EqualTo(221634238L));
		}
	}
}