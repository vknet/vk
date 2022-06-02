using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class RemoveOfficeUsersTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void RemoveOfficeUsers()
		{
			Url = "https://api.vk.com/method/ads.removeOfficeUsers";

			ReadCategoryJsonPath(nameof(Api.Ads.RemoveOfficeUsers));

			var a = new[]
			{
				"1",
				"2"
			};

			var result = Api.Ads.RemoveOfficeUsers(new RemoveOfficeUsersParams
			{
				AccountId = 1605245430,
				Ids = a
			});

			result.Should().HaveElementAt(0, true);
			result.Should().HaveElementAt(1, true);
		}
	}
}