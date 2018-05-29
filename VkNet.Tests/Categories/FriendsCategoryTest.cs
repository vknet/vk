using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class FriendsCategoryTest : BaseTest
	{
		private FriendsCategory GetMockedFriendsCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new FriendsCategory(vk: Api);
		}

		[Test]
		public void Add_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.add";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var status = cat.Add(userId: 242508, text: "hello, user!");

			Assert.That(actual: status, expression: Is.EqualTo(expected: AddFriendStatus.Sended));
		}

		[Test]
		public void Add_WithCaptcha_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.add";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var status = cat.Add(userId: 242508, text: "hello, user!", captchaSid: 1247329, captchaKey: "hug2z");

			Assert.That(actual: status, expression: Is.EqualTo(expected: AddFriendStatus.Sended));
		}

		[Test]
		public void AddList_NameIsEmpty_ThrowException()
		{
			var cat = GetMockedFriendsCategory(url: "", json: "");
			Assert.That(del: () => cat.AddList(name: ""), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void AddList_OnlyName_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.addList";

			const string json =
					@"{
                    'response': {
                      'list_id': 1
                    }
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var id = cat.AddList(name: "тестовая метка");

			Assert.That(actual: id, expression: Is.EqualTo(expected: 1));
		}

		[Test]
		public void AddList_WithUserIds_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.addList";

			const string json =
					@"{
                    'response': {
                      'list_id': 2
                    }
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var id = cat.AddList(name: "тестовая метка"
					, userIds: new long[]
					{
							1
							, 2
					});

			Assert.That(actual: id, expression: Is.EqualTo(expected: 2));
		}

		[Test]
		public void AreFriends_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(vk: new VkApi());

			Assert.That(del: () => cat.AreFriends(userIds: new long[]
					{
							2
							, 3
					})
					, expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void AreFriends_FourTypes_RightFriendStatuses()
		{
			const string url = "https://api.vk.com/method/friends.areFriends";

			const string json =
					@"{
                    'response': [
                      {
                        'user_id': 24181068,
                        'friend_status': 0
                      },
                      {
                        'user_id': 22911407,
                        'friend_status': 3
                      },
                      {
                        'user_id': 155810539,
                        'friend_status': 2
                      },
                      {
                        'user_id': 3505305,
                        'friend_status': 1
                      }
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var dict = friends.AreFriends(userIds: new long[]
			{
					24181068
					, 22911407
					, 155810539
					, 3505305
			});

			Assert.NotNull(anObject: dict);
			Assert.That(actual: dict.Count, expression: Is.EqualTo(expected: 4));
			Assert.That(actual: dict.FirstOrDefault()?.FriendStatus, expression: Is.EqualTo(expected: FriendStatus.NotFriend));
			Assert.That(actual: dict.Skip(count: 1).FirstOrDefault()?.FriendStatus, expression: Is.EqualTo(expected: FriendStatus.Friend));

			Assert.That(actual: dict.Skip(count: 2).FirstOrDefault()?.FriendStatus
					, expression: Is.EqualTo(expected: FriendStatus.InputRequest));

			Assert.That(actual: dict.Skip(count: 3).FirstOrDefault()?.FriendStatus
					, expression: Is.EqualTo(expected: FriendStatus.OutputRequest));
		}

		[Test]
		public void AreFriends_NullInput_ThrowArgumentNullException()
		{
			var cat = GetMockedFriendsCategory(url: "", json: "");
			Assert.That(del: () => cat.AreFriends(userIds: null), expr: Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void Delete_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.delete";

			const string json =
					@"{
                    response: {
                        success: 2,
                        out_request_deleted: 1
                    }
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var status = cat.Delete(userId: 24250);

			Assert.That(actual: status.OutRequestDeleted, expression: Is.True);
		}

		[Test]
		public void DeleteAllRequests_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.deleteAllRequests";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var result = cat.DeleteAllRequests();

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void DeleteList_IdIsNegative_ThrowException()
		{
			var cat = GetMockedFriendsCategory(url: "", json: "");
			Assert.That(del: () => cat.DeleteList(listId: -1), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void DeleteList_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.deleteList";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var result = cat.DeleteList(listId: 2);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Edit_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.edit";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var result = cat.Edit(userId: 242508111, listIds: new long[] { 2 });

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void EditList_EditName_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.editList";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var result = cat.EditList(listId: 2, name: "new тестовая метка");

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void EditList_ListIdIsNegative_ThrowException()
		{
			var cat = GetMockedFriendsCategory(url: "", json: "");
			Assert.That(del: () => cat.EditList(listId: -1), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		[Ignore(reason: "Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(vk: new VkApi());

			Assert.That(del: () => cat.Get(@params: new FriendsGetParams
					{
							UserId = 1
					})
					, expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_FirstNameLastName_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.get";

			const string json =
					@"{
                    'response': {
                      'count': 690,
                      'items': [
                        {
                          'id': 2,
                          'first_name': 'Александра',
                          'last_name': 'Владимирова',
                          'online': 0
                        },
                        {
                          'id': 5,
                          'first_name': 'Илья',
                          'last_name': 'Перекопский',
                          'online': 0
                        },
                        {
                          'id': 6,
                          'first_name': 'Николай',
                          'last_name': 'Дуров',
                          'online': 0
                        }
                      ]
                    }
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var lst = friends.Get(@params: new FriendsGetParams
			{
					Count = 3
					, Fields = ProfileFields.FirstName|ProfileFields.LastName
					, UserId = 1
			});

			Assert.That(actual: lst.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: lst[index: 0].Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: lst[index: 0].FirstName, expression: Is.EqualTo(expected: "Александра"));
			Assert.That(actual: lst[index: 0].LastName, expression: Is.EqualTo(expected: "Владимирова"));
			Assert.That(actual: lst[index: 0].Online, expression: Is.EqualTo(expected: false));

			Assert.That(actual: lst[index: 1].Id, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: lst[index: 1].FirstName, expression: Is.EqualTo(expected: "Илья"));
			Assert.That(actual: lst[index: 1].LastName, expression: Is.EqualTo(expected: "Перекопский"));
			Assert.That(actual: lst[index: 1].Online, expression: Is.EqualTo(expected: false));

			Assert.That(actual: lst[index: 2].Id, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: lst[index: 2].FirstName, expression: Is.EqualTo(expected: "Николай"));
			Assert.That(actual: lst[index: 2].LastName, expression: Is.EqualTo(expected: "Дуров"));
			Assert.That(actual: lst[index: 2].Online, expression: Is.EqualTo(expected: false));
		}

		[Test]
		public void Get_FriendsForDurov_ListOfFriends()
		{
			const string url = "https://api.vk.com/method/friends.get";

			const string json =
					@"{
                    'response': [
                      2,
                      5,
                      6,
                      7,
                      12
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var users = friends.Get(@params: new FriendsGetParams
					{
							ListId = 1
					})
					.ToList();

			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: users[index: 0].Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: users[index: 1].Id, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: users[index: 2].Id, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: users[index: 3].Id, expression: Is.EqualTo(expected: 7));
			Assert.That(actual: users[index: 4].Id, expression: Is.EqualTo(expected: 12));
		}

		[Test]
		public void GetAppUsers_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(vk: new VkApi());
			Assert.That(del: () => cat.GetAppUsers(), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetAppUsers_NoOne_EmptyList()
		{
			const string url = "https://api.vk.com/method/friends.getAppUsers";

			const string json =
					@"{
                    'response': []
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var users = friends.GetAppUsers().ToList();

			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetAppUsers_ThreeUsers_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.getAppUsers";

			const string json =
					@"{
                    'response': [
                      15221,
                      17836,
                      19194
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);
			var ids = friends.GetAppUsers().ToList();

			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: ids[index: 0], expression: Is.EqualTo(expected: 15221));
			Assert.That(actual: ids[index: 1], expression: Is.EqualTo(expected: 17836));
			Assert.That(actual: ids[index: 2], expression: Is.EqualTo(expected: 19194));
		}

		[Test]
		public void GetLists_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.getLists";

			const string json =
					@"{
                    'response': [
                      {
                        'name': 'тестовая метка',
                        'lid': 1
                      },
                      {
                        'name': 'лист 3',
                        'lid': 2
                      }
                    ]
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var list = cat.GetLists();

			Assert.That(actual: list.Count, expression: Is.EqualTo(expected: 2));

			Assert.That(actual: list[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: list[index: 0].Name, expression: Is.EqualTo(expected: "тестовая метка"));

			Assert.That(actual: list[index: 1].Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: list[index: 1].Name, expression: Is.EqualTo(expected: "лист 3"));
		}

		[Test]
		public void GetMutual_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(vk: new VkApi());

			Assert.That(del: () => cat.GetMutual(@params: new FriendsGetMutualParams
					{
							TargetUid = 2
							, SourceUid = 3
					})
					, expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetMutual_NoOne_EmptyList()
		{
			const string url = "https://api.vk.com/method/friends.getMutual";

			const string json =
					@"{
                    'response': []
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var users = friends.GetMutual(@params: new FriendsGetMutualParams
					{
							TargetUid = 2
							, SourceUid = 1
					})
					.ToList();

			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetMutual_ThreeUsers_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.getMutual";

			const string json =
					@"{
                    'response': [
                      3,
                      31,
                      43
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var ids = friends.GetMutual(@params: new FriendsGetMutualParams
					{
							TargetUid = 2
							, SourceUid = 1
					})
					.ToList();

			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: ids[index: 0], expression: Is.EqualTo(expected: 3));
			Assert.That(actual: ids[index: 1], expression: Is.EqualTo(expected: 31));
			Assert.That(actual: ids[index: 2], expression: Is.EqualTo(expected: 43));
		}

		[Test]
		public void GetOnline_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(vk: new VkApi());

			Assert.That(del: () => cat.GetOnline(@params: new FriendsGetOnlineParams
					{
							UserId = 1
					})
					, expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetOnline_Ex()
		{
			const string url = "https://api.vk.com/method/friends.getOnline";

			const string json =
					@"{
					'response': {
						'online': [105013464],
						'online_mobile': [975892, 16010007, 61270720, 102554254, 325170546]
					}
				}";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var users = friends.GetOnline(@params: new FriendsGetOnlineParams
			{
					OnlineMobile = true
			});

			Assert.That(actual: users.Online.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: users.MobileOnline.Count, expression: Is.EqualTo(expected: 5));
		}

		[Test]
		public void GetOnline_FiveUsers_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.getOnline";

			const string json =
					@"{
                    response: [5, 467, 2943, 4424, 13033]
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var users = friends.GetOnline(@params: new FriendsGetOnlineParams
			{
					UserId = 1
			});

			Assert.That(actual: users.Online.Count, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: users.Online[index: 0], expression: Is.EqualTo(expected: 5));
			Assert.That(actual: users.Online[index: 1], expression: Is.EqualTo(expected: 467));
			Assert.That(actual: users.Online[index: 2], expression: Is.EqualTo(expected: 2943));
			Assert.That(actual: users.Online[index: 3], expression: Is.EqualTo(expected: 4424));
			Assert.That(actual: users.Online[index: 4], expression: Is.EqualTo(expected: 13033));
		}

		[Test]
		public void GetOnline_NoOne_EmptyList()
		{
			const string url = "https://api.vk.com/method/friends.getOnline";

			const string json =
					@"{
                    'response': []
                  }";

			var friends = GetMockedFriendsCategory(url: url, json: json);

			var users = friends.GetOnline(@params: new FriendsGetOnlineParams
			{
					UserId = 1
			});

			Assert.That(actual: users.Online.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetRecent_OneItem()
		{
			const string url = "https://api.vk.com/method/friends.getRecent";

			const string json =
					@"{
                    'response': [
                      242508111
                    ]
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var ids = cat.GetRecent(count: 3);

			Assert.That(actual: ids, expression: Is.Not.Null);
			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: ids[index: 0], expression: Is.EqualTo(expected: 242508111));
		}

		[Test]
		public void GetRequest_count_unread()
		{
			const string url = "https://api.vk.com/method/friends.getRequests";

			const string json =
					@"{
					'response': {
						'count': 171,
						'items': [242508111],
						'count_unread': 1
					}
				}";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var ids = cat.GetRequests(@params: new FriendsGetRequestsParams
			{
					Offset = 0
					, Count = 3
					, Extended = false
					, NeedMutual = false
			});

			Assert.That(actual: ids, expression: Is.Not.Null);
			Assert.That(actual: ids.CountUnread, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 171));
			Assert.That(actual: ids.Items, expression: Is.Not.Empty);
		}

		[Test]
		public void GetRequest_EmptyCollection()
		{
			const string url = "https://api.vk.com/method/friends.getRequests";

			const string json =
					@"{
					'response': {
						'count': 171,
						'items': []
					}
				}";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var ids = cat.GetRequestsExtended(@params: new FriendsGetRequestsParams
			{
					Offset = 0
					, Count = 3
					, Extended = true
					, NeedMutual = true
			});

			Assert.That(actual: ids, expression: Is.Not.Null);
			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetRequests_Basic_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.getRequests";

			const string json =
					@"{
                    'response': {
                      items: [242508111]
                    }
                  }";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var ids = cat.GetRequests(@params: new FriendsGetRequestsParams
			{
					Offset = 0
					, Count = 3
			});

			Assert.That(actual: ids, expression: Is.Not.Null);
			Assert.That(actual: ids.Items[index: 0], expression: Is.EqualTo(expected: 242508111));
		}

		[Test]
		public void GetRequests_Extended_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.getRequests";

			const string json = @"{
				'response': {
					'count': 1,
					'items': [{
						'user_id': 242508111
					}]
				}
			}";

			var cat = GetMockedFriendsCategory(url: url, json: json);

			var ids = cat.GetRequestsExtended(@params: new FriendsGetRequestsParams
			{
					Offset = 0
					, Count = 3
					, Extended = true
					, NeedMutual = true
			});

			Assert.That(actual: ids, expression: Is.Not.Null);
			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: ids[index: 0].UserId, expression: Is.EqualTo(expected: 242508111));
		}
	}
}