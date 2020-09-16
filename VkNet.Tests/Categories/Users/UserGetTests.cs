using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Users
{

	public class UserGetTests : CategoryBaseTest
	{
		protected override string Folder => "Users";

		[Test]
		public void Get_Olesya_SingleUser()
		{
			Url = "https://api.vk.com/method/users.get";
			ReadCategoryJsonPath(nameof(Get_Olesya_SingleUser));

			var users = Api.Users.Get(new List<long> { 118312730 }, ProfileFields.Sex, NameCase.Nom);

			Assert.That(users, Is.Not.Null);
			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Sex, Is.EqualTo(Sex.Deactivated));
		}
	}
}