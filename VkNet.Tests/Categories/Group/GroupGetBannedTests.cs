using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Helper;

namespace VkNet.Tests.Categories.Group
{
    public class GroupGetBannedTests : BaseTest
    {
        [Test]
        public void GetBanned_Profile()
        {
            Url = "https://api.vk.com/method/groups.getBanned";
            Json = @"{
				'response': {
					'count': 1,
					'items': [{
						'type': 'profile',
						'profile': {
							'id': 419909516,
							'first_name': 'Vknet',
							'last_name': 'Developer'
						},
						'ban_info': {
							'admin_id': 32190123,
							'date': 1516980336,
							'reason': 0,
							'comment': 'для теста',
							'comment_visible': true,
							'end_date': 1517585141
						}
					}]
				}
			}";

            var banned = Api.Groups.GetBanned(65968111,null, 3);

            Assert.That(banned, Is.Not.Null);
            Assert.That(banned.Count, Is.EqualTo(1));

            var user = banned.FirstOrDefault();
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Type, Is.EqualTo(SearchResultType.Profile));
            Assert.That(user.Profile, Is.Not.Null);
	        Assert.That(user.Group, Is.Null);
            Assert.That(user.BanInfo, Is.Not.Null);
            Assert.That(user.BanInfo.AdminId, Is.EqualTo(32190123));
            Assert.That(user.BanInfo.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1516980336)));
            Assert.That(user.BanInfo.Reason, Is.EqualTo(BanReason.Other));
            Assert.That(user.BanInfo.Comment, Is.EqualTo("для теста"));
            Assert.That(user.BanInfo.EndDate, Is.EqualTo(DateHelper.TimeStampToDateTime(1517585141)));
        }
	    
        [Test]
        public void GetBanned_Group()
        {
            Url = "https://api.vk.com/method/groups.getBanned";
            Json = @"{
				'response': {
					'count': 1,
					'items': [{
						'type': 'group',
						'group': {
							'id': 419909516,
							'name': 'Vknet'
						},
						'ban_info': {
							'admin_id': 32190123,
							'date': 1516980336,
							'reason': 0,
							'comment': 'для теста',
							'comment_visible': true,
							'end_date': 1517585141
						}
					}]
				}
			}";

            var banned = Api.Groups.GetBanned(65968111,null, 3);

            Assert.That(banned, Is.Not.Null);
            Assert.That(banned.Count, Is.EqualTo(1));

            var user = banned.FirstOrDefault();
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Type, Is.EqualTo(SearchResultType.Group));
            Assert.That(user.Profile, Is.Null);
            Assert.That(user.Group, Is.Not.Null);
            Assert.That(user.BanInfo, Is.Not.Null);
            Assert.That(user.BanInfo.AdminId, Is.EqualTo(32190123));
            Assert.That(user.BanInfo.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1516980336)));
            Assert.That(user.BanInfo.Reason, Is.EqualTo(BanReason.Other));
            Assert.That(user.BanInfo.Comment, Is.EqualTo("для теста"));
            Assert.That(user.BanInfo.EndDate, Is.EqualTo(DateHelper.TimeStampToDateTime(1517585141)));
        }
    }
}