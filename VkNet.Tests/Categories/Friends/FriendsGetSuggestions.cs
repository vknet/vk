using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories.Friends
{
	[TestFixture]
	public class FriendsGetSuggestions : BaseTest
	{
		[Test]
		public void GetSuggestions_AllParameters()
		{
			Url = "https://api.vk.com/method/friends.getSuggestions";

			Json = @"{
                'response':{
                    'count':182,
                    'items':[
                        {
                            'id':1591605,
                            'first_name':'Михаила',
                            'last_name':'Захаркина',
                            'sex':2
                        }
                    ]
                }
            }";

			var result = Api.Friends.GetSuggestions(filter: FriendsFilter.Mutual
					, count: 1
					, offset: 0
					, fields: UsersFields.Sex
					, nameCase: NameCase.Gen);

			Assert.NotNull(anObject: result);
			Assert.AreEqual(expected: 182, actual: result.TotalCount);
			var user = result.FirstOrDefault();
			Assert.NotNull(anObject: user);
			Assert.AreEqual(expected: Sex.Male, actual: user?.Sex);
		}

		[Test]
		public void GetSuggestions_WithoutParameters()
		{
			Url = "https://api.vk.com/method/friends.getSuggestions";

			Json = @"{
                'response':{
                    'count':3,
                    'items':[
                        {
                            'id':2243095,
                            'first_name':'Alexander',
                            'last_name':'Surikov'
                        },
                        {
                            'id':8611838,
                            'first_name':'Arnold',
                            'last_name':'Gromko'
                        },
                        {
                            'id':50656600,
                            'first_name':'Максим',
                            'last_name':'Щербаков'
                        }
                    ]
                }
            }";

			var result = Api.Friends.GetSuggestions();
			Assert.NotNull(anObject: result);
			Assert.AreEqual(expected: 3, actual: result.TotalCount);
		}
	}
}