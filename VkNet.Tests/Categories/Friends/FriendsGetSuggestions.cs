using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Friends
{
	[TestFixture]

	public class FriendsGetSuggestions : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Test]
		public void GetSuggestions_AllParameters()
		{
			Url = "https://api.vk.com/method/friends.getSuggestions";

			ReadCategoryJsonPath(nameof(Api.Friends.GetSuggestions));

			var result = Api.Friends.GetSuggestions(FriendsFilter.Mutual, 1, 0, UsersFields.Sex, NameCase.Gen);

			Assert.NotNull(result);
			Assert.AreEqual(182, result.TotalCount);
			var user = result.FirstOrDefault();
			Assert.NotNull(user);
			Assert.AreEqual(Sex.Male, user.Sex);
		}

		[Test]
		public void GetSuggestions_WithoutParameters()
		{
			Url = "https://api.vk.com/method/friends.getSuggestions";

			ReadCategoryJsonPath(nameof(Api.Friends.GetSuggestions));

			var result = Api.Friends.GetSuggestions();
			Assert.NotNull(result);
			Assert.AreEqual(182, result.TotalCount);
		}
	}
}