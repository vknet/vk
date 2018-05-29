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

			var banned = Api.Groups.GetBanned(groupId: 65968111, offset: null, count: 3);

			Assert.That(actual: banned, expression: Is.Not.Null);
			Assert.That(actual: banned.Count, expression: Is.EqualTo(expected: 1));

			var user = banned.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Type, expression: Is.EqualTo(expected: SearchResultType.Profile));
			Assert.That(actual: user.Profile, expression: Is.Not.Null);
			Assert.That(actual: user.Group, expression: Is.Null);
			Assert.That(actual: user.BanInfo, expression: Is.Not.Null);
			Assert.That(actual: user.BanInfo.AdminId, expression: Is.EqualTo(expected: 32190123));
			Assert.That(actual: user.BanInfo.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1516980336)));
			Assert.That(actual: user.BanInfo.Reason, expression: Is.EqualTo(expected: BanReason.Other));
			Assert.That(actual: user.BanInfo.Comment, expression: Is.EqualTo(expected: "для теста"));

			Assert.That(actual: user.BanInfo.EndDate
					, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1517585141)));
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

			var banned = Api.Groups.GetBanned(groupId: 65968111, offset: null, count: 3);

			Assert.That(actual: banned, expression: Is.Not.Null);
			Assert.That(actual: banned.Count, expression: Is.EqualTo(expected: 1));

			var user = banned.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Type, expression: Is.EqualTo(expected: SearchResultType.Group));
			Assert.That(actual: user.Profile, expression: Is.Null);
			Assert.That(actual: user.Group, expression: Is.Not.Null);
			Assert.That(actual: user.BanInfo, expression: Is.Not.Null);
			Assert.That(actual: user.BanInfo.AdminId, expression: Is.EqualTo(expected: 32190123));
			Assert.That(actual: user.BanInfo.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1516980336)));
			Assert.That(actual: user.BanInfo.Reason, expression: Is.EqualTo(expected: BanReason.Other));
			Assert.That(actual: user.BanInfo.Comment, expression: Is.EqualTo(expected: "для теста"));

			Assert.That(actual: user.BanInfo.EndDate
					, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1517585141)));
		}
	}
}