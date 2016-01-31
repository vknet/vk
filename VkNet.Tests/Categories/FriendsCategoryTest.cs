﻿namespace VkNet.Tests.Categories
{
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using Moq;
	using NUnit.Framework;
	using FluentNUnit;

	using VkNet.Categories;
	using VkNet.Utils;

	using Enums.Filters;
	using Enums;
	using Exception;
	using Model;

	[TestFixture]
	public class FriendsCategoryTest
	{
		[SetUp]
		public void SetUp()
		{

		}

		public FriendsCategory GetMockedFriendsCategory(string url, string json)
		{
			var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
			return new FriendsCategory(new VkApi { AccessToken = "token", Browser = browser });
		}

		[Test]
		public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var friendsCategory = new FriendsCategory(new VkApi());
			This.Action(() => friendsCategory.Get(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Get_FriendsForDurov_ListOfFriends()
		{
			const string url = "https://api.vk.com/method/friends.get?user_id=1&v=5.44&access_token=token";
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

			var friends = GetMockedFriendsCategory(url, json);
			var users = friends.Get(1).ToList();

			Assert.That(users.Count, Is.EqualTo(5));
			Assert.That(users[0].Id, Is.EqualTo(2));
			Assert.That(users[1].Id, Is.EqualTo(5));
			Assert.That(users[2].Id, Is.EqualTo(6));
			Assert.That(users[3].Id, Is.EqualTo(7));
			Assert.That(users[4].Id, Is.EqualTo(12));
		}

		[Test]
		public void Get_FirstNameLastName_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.get?user_id=1&count=3&fields=first_name,last_name&v=5.44&access_token=token";
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

			var friends = GetMockedFriendsCategory(url, json);
			var lst = friends.Get(1, ProfileFields.FirstName | ProfileFields.LastName, 3);

			Assert.That(lst.Count, Is.EqualTo(3));
			Assert.That(lst[0].Id, Is.EqualTo(2));
			Assert.That(lst[0].FirstName, Is.EqualTo("Александра"));
			Assert.That(lst[0].LastName, Is.EqualTo("Владимирова"));
			Assert.That(lst[0].Online, Is.EqualTo(false));

			Assert.That(lst[1].Id, Is.EqualTo(5));
			Assert.That(lst[1].FirstName, Is.EqualTo("Илья"));
			Assert.That(lst[1].LastName, Is.EqualTo("Перекопский"));
			Assert.That(lst[1].Online, Is.EqualTo(false));

			Assert.That(lst[2].Id, Is.EqualTo(6));
			Assert.That(lst[2].FirstName, Is.EqualTo("Николай"));
			Assert.That(lst[2].LastName, Is.EqualTo("Дуров"));
			Assert.That(lst[2].Online, Is.EqualTo(false));
		}

		[Test]
		public void GetAppUsers_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var friendsCategory = new FriendsCategory(new VkApi());
			This.Action(() => friendsCategory.GetAppUsers()).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetAppUsers_NoOne_EmptyList()
		{
			const string url = "https://api.vk.com/method/friends.getAppUsers?v=5.44&access_token=token";
			const string json =
				@"{
                    'response': []
                  }";

			var friends = GetMockedFriendsCategory(url, json);

			var users = friends.GetAppUsers().ToList();

			Assert.That(users.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetAppUsers_ThreeUsers_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.getAppUsers?v=5.44&access_token=token";
			const string json =
				@"{
                    'response': [
                      15221,
                      17836,
                      19194
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url, json);
			var ids = friends.GetAppUsers().ToList();

			Assert.That(ids.Count, Is.EqualTo(3));
			Assert.That(ids[0], Is.EqualTo(15221));
			Assert.That(ids[1], Is.EqualTo(17836));
			Assert.That(ids[2], Is.EqualTo(19194));
		}

		[Test]
		public void GetOnline_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var friendsCategory = new FriendsCategory(new VkApi());
			This.Action(() => friendsCategory.GetOnline(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetOnline_NoOne_EmptyList()
		{
			const string url = "https://api.vk.com/method/friends.getOnline?user_id=1&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': []
                  }";

			var friends = GetMockedFriendsCategory(url, json);
			var users = friends.GetOnline(1).ToList();

			Assert.That(users.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetOnline_FiveUsers_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.getOnline?user_id=1&v=5.44&access_token=token";
			const string json =
				@"{
                    response: [5, 467, 2943, 4424, 13033]
                  }";

			var friends = GetMockedFriendsCategory(url, json);
			var ids = friends.GetOnline(1).ToList();

			Assert.That(ids.Count, Is.EqualTo(5));
			Assert.That(ids[0], Is.EqualTo(5));
			Assert.That(ids[1], Is.EqualTo(467));
			Assert.That(ids[2], Is.EqualTo(2943));
			Assert.That(ids[3], Is.EqualTo(4424));
			Assert.That(ids[4], Is.EqualTo(13033));
		}

		[Test]
		public void GetMutual_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var friendsCategory = new FriendsCategory(new VkApi());
			This.Action(() => friendsCategory.GetMutual(2, 3)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetMutual_ThreeUsers_ListOfObjects()
		{
			const string url = "https://api.vk.com/method/friends.getMutual?source_uid=1&target_uid=2&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': [
                      3,
                      31,
                      43
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url, json);
			var ids = friends.GetMutual(2, 1).ToList();

			Assert.That(ids.Count, Is.EqualTo(3));
			Assert.That(ids[0], Is.EqualTo(3));
			Assert.That(ids[1], Is.EqualTo(31));
			Assert.That(ids[2], Is.EqualTo(43));
		}

		[Test]
		public void GetMutual_NoOne_EmptyList()
		{
			const string url = "https://api.vk.com/method/friends.getMutual?source_uid=1&target_uid=2&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': []
                  }";

			var friends = GetMockedFriendsCategory(url, json);

			var users = friends.GetMutual(2, 1).ToList();

			Assert.That(users.Count, Is.EqualTo(0));
		}

		[Test]
		public void AreFriends_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var friendsCategory = new FriendsCategory(new VkApi());
			This.Action(() => friendsCategory.AreFriends(new long[] { 2, 3 })).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void AreFriends_NullInput_ThrowArgumentNullException()
		{
			var friendsCategory = new FriendsCategory(new VkApi { AccessToken = "token" });
			This.Action(() => friendsCategory.AreFriends(null)).Throws<ArgumentNullException>();
		}

		[Test]
		public void AreFriends_FourTypes_RightFriendStatuses()
		{
			const string url = "https://api.vk.com/method/friends.areFriends?user_ids=24181068,22911407,155810539,3505305&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': [
                      {
                        'uid': 24181068,
                        'friend_status': 0
                      },
                      {
                        'uid': 22911407,
                        'friend_status': 3
                      },
                      {
                        'uid': 155810539,
                        'friend_status': 2
                      },
                      {
                        'uid': 3505305,
                        'friend_status': 1
                      }
                    ]
                  }";

			var friends = GetMockedFriendsCategory(url, json);
			var dict = friends.AreFriends(new long[] { 24181068, 22911407, 155810539, 3505305 });

			Assert.That(dict.Count, Is.EqualTo(4));
			Assert.That(dict[24181068], Is.EqualTo(FriendStatus.NotFriend));
			Assert.That(dict[22911407], Is.EqualTo(FriendStatus.Friend));
			Assert.That(dict[155810539], Is.EqualTo(FriendStatus.InputRequest));
			Assert.That(dict[3505305], Is.EqualTo(FriendStatus.OutputRequest));
		}

		[Test]
		public void AddList_OnlyName_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.addList?name=тестовая метка&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': {
                      'list_id': 1
                    }
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var id = cat.AddList("тестовая метка");

			Assert.That(id, Is.EqualTo(1));
		}

		[Test]
		public void AddList_WithUserIds_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.addList?name=тестовая метка&user_ids=1,2&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': {
                      'list_id': 2
                    }
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var id = cat.AddList("тестовая метка", new long[] { 1, 2 });

			Assert.That(id, Is.EqualTo(2));
		}

		[Test]
		public void AddList_NameIsEmpty_ThrowException()
		{
			var cat = GetMockedFriendsCategory("", "");
			This.Action(() => cat.AddList("")).Throws<ArgumentNullException>();
		}

		[Test]
		public void DeleteList_IdIsNegative_ThrowException()
		{
			var cat = GetMockedFriendsCategory("", "");
			This.Action(() => cat.DeleteList(-1)).Throws<ArgumentException>();
		}

		[Test]
		public void DeleteList_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.deleteList?list_id=2&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var result = cat.DeleteList(2);

			Assert.That(result, Is.True);
		}

		[Test]
		public void GetLists_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.getLists?v=5.44&access_token=token";
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

			var cat = GetMockedFriendsCategory(url, json);

			var list = cat.GetLists();

			Assert.That(list.Count, Is.EqualTo(2));

			Assert.That(list[0].Id, Is.EqualTo(1));
			Assert.That(list[0].Name, Is.EqualTo("тестовая метка"));

			Assert.That(list[1].Id, Is.EqualTo(2));
			Assert.That(list[1].Name, Is.EqualTo("лист 3"));
		}

		[Test]
		public void EditList_EditName_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.editList?name=new тестовая метка&list_id=2&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var result = cat.EditList(2, "new тестовая метка");

			Assert.That(result, Is.True);
		}

		[Test]
		public void EditList_ListIdIsNegative_ThrowException()
		{
			var cat = GetMockedFriendsCategory("", "");
			This.Action(() => cat.EditList(-1)).Throws<ArgumentException>();
		}

		[Test]
		public void DeleteAllRequests_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.deleteAllRequests?v=5.44&access_token=token";
			const string json =
				@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var result = cat.DeleteAllRequests();

			Assert.That(result, Is.True);
		}

		[Test]
		public void Add_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.add?user_id=242508&text=hello, user!&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var status = cat.Add(242508, "hello, user!", null, null, null);

			Assert.That(status, Is.EqualTo(AddFriendStatus.Sended));
		}

		[Test]
		public void Add_WithCaptcha_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.add?user_id=242508&text=hello, user!&captcha_sid=1247329&captcha_key=hug2z&access_token=token";
			const string json =
				@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var status = cat.Add(242508, "hello, user!", captchaSid: 1247329, captchaKey: "hug2z");

			Assert.That(status, Is.EqualTo(AddFriendStatus.Sended));
		}

		[Test]
		public void Delete_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.delete?user_id=24250&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': 2
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var status = cat.Delete(24250);

			Assert.That(status, Is.EqualTo(DeleteFriendStatus.RequestRejected));
		}

		[Test]
		public void GetRequests_Extended_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.getRequests?offset=0&count=3&extended=1&need_mutual=1&v=5.44&access_token=token";
			const string json = @"{
				'response': {
					items: [{
						user_id: 242508111
					}]
				}
			}";

			var cat = GetMockedFriendsCategory(url, json);

			var ids = cat.GetRequests(offset: 0, count: 3, extended: true, needMutual: true);

			ids.Count.ShouldEqual(1);
			ids[0].ShouldEqual(242508111);
		}

		[Test]
		public void GetRequests_Basic_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.getRequests?offset=0&count=3&v=5.44&access_token=token";

			const string json =
				@"{
                    'response': {
                      items: [242508111]
                    }
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var ids = cat.GetRequests(offset: 0, count: 3);

			ids.Count.ShouldEqual(1);
			ids[0].ShouldEqual(242508111);
		}

		[Test]
		public void GetRequest_EmptyCollection()
		{
			const string url = "https://api.vk.com/method/friends.getRequests?offset=0&count=3&extended=1&need_mutual=1&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': []
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var ids = cat.GetRequests(offset: 0, count: 3, extended: true, needMutual: true);

			ids.ShouldNotBeNull();
			ids.Count.ShouldEqual(0);
		}

		[Test]
		public void GetRecent_OneItem()
		{
			const string url = "https://api.vk.com/method/friends.getRecent?count=3&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': [
                      242508111
                    ]
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var ids = cat.GetRecent(3);

			ids.ShouldNotBeNull();
			ids.Count.ShouldEqual(1);
			ids[0].ShouldEqual(242508111);
		}

		[Test]
		public void Edit_NormalCase()
		{
			const string url = "https://api.vk.com/method/friends.edit?user_id=242508111&list_ids=2&v=5.44&access_token=token";
			const string json =
				@"{
                    'response': 1
                  }";

			var cat = GetMockedFriendsCategory(url, json);

			var result = cat.Edit(242508111, new long[] { 2 });

			result.ShouldBeTrue();
		}
	}
}