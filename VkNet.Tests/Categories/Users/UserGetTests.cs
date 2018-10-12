using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories.Users
{
	[ExcludeFromCodeCoverage]
	public class UserGetTests : BaseTest
	{
		[Test]
		public void Get_Dimon_SingleUser()
		{
			Url = "https://api.vk.com/method/users.get";

			Json =
					@"{
                    'response': [
                      {
                        'id': 47,
                        'first_name': 'Gabriel',
                        'last_name': 'Shalel',
                        'deactivated': 'banned',
						'sex': 2
                      }
                    ]
                  }";

			var users = Api.Users.Get(new List<long> { 118312730 }, ProfileFields.Sex, NameCase.Nom);

			Assert.That(users, Is.Not.Null);
			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Sex, Is.EqualTo(Sex.Deactivated));
		}
	}
}
