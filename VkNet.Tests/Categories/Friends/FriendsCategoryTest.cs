using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Friends
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class FriendsCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Test]
		public void Add_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.add";
			ReadJsonFile(JsonPaths.True);

			var status = Api.Friends.Add(242508, "hello, user!", false);

			Assert.That(status, Is.EqualTo(AddFriendStatus.Sended));
		}

		[Test]
		public void AddList_NameIsEmpty_ThrowException()
		{
			Assert.That(() => Api.Friends.AddList("", null), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void AddList_OnlyName_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.addList";
			ReadCategoryJsonPath(nameof(AddList_OnlyName_NormalCase));

			var id = Api.Friends.AddList("тестовая метка", null);

			Assert.That(id, Is.EqualTo(1));
		}

		[Test]
		public void AddList_WithUserIds_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.addList";
			ReadCategoryJsonPath(nameof(AddList_WithUserIds_NormalCase));

			var id = Api.Friends.AddList("тестовая метка",
				new long[]
				{
					1,
					2
				});

			Assert.That(id, Is.EqualTo(2));
		}

		[Test]
		public void AreFriends_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(new VkApi());

			Assert.That(() => cat.AreFriends(new long[]
				{
					2,
					3
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void AreFriends_FourTypes_RightFriendStatuses()
		{
			Url = "https://api.vk.com/method/friends.areFriends";
			ReadCategoryJsonPath(nameof(AreFriends_FourTypes_RightFriendStatuses));

			var dict = Api.Friends.AreFriends(new long[]
			{
				24181068,
				22911407,
				155810539,
				3505305
			});

			Assert.NotNull(dict);
			Assert.That(dict.Count, Is.EqualTo(4));
			Assert.That(dict.FirstOrDefault()?.FriendStatus, Is.EqualTo(FriendStatus.NotFriend));
			Assert.That(dict.Skip(1).FirstOrDefault()?.FriendStatus, Is.EqualTo(FriendStatus.Friend));

			Assert.That(dict.Skip(2).FirstOrDefault()?.FriendStatus, Is.EqualTo(FriendStatus.InputRequest));

			Assert.That(dict.Skip(3).FirstOrDefault()?.FriendStatus, Is.EqualTo(FriendStatus.OutputRequest));
		}

		[Test]
		public void AreFriends_NullInput_ThrowArgumentNullException()
		{
			Assert.That(() => Api.Friends.AreFriends(null), Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void Delete_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.delete";
			ReadCategoryJsonPath(nameof(Delete_NormalCase));

			var status = Api.Friends.Delete(24250);

			Assert.That(status.OutRequestDeleted, Is.True);
		}

		[Test]
		public void DeleteAllRequests_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.deleteAllRequests";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Friends.DeleteAllRequests();

			Assert.That(result, Is.True);
		}

		[Test]
		public void DeleteList_IdIsNegative_ThrowException()
		{
			Assert.That(() => Api.Friends.DeleteList(-1), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void DeleteList_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.deleteList";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Friends.DeleteList(2);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Edit_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.edit";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Friends.Edit(242508111,
				new long[]
				{
					2
				});

			Assert.That(result, Is.True);
		}

		[Test]
		public void EditList_EditName_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.editList";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Friends.EditList(2, "new тестовая метка");

			Assert.That(result, Is.True);
		}

		[Test]
		public void EditList_ListIdIsNegative_ThrowException()
		{
			Assert.That(() => Api.Friends.EditList(-1), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(new VkApi());

			Assert.That(() => cat.Get(new FriendsGetParams
				{
					UserId = 1
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_FirstNameLastName_ListOfObjects()
		{
			Url = "https://api.vk.com/method/friends.get";
			ReadCategoryJsonPath(nameof(Get_FirstNameLastName_ListOfObjects));

			var lst = Api.Friends.Get(new FriendsGetParams
			{
				Count = 3,
				Fields = ProfileFields.FirstName|ProfileFields.LastName,
				UserId = 1
			});

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
		public void Get_FriendsForDurov_ListOfFriends()
		{
			Url = "https://api.vk.com/method/friends.get";
			ReadCategoryJsonPath(nameof(Get_FriendsForDurov_ListOfFriends));

			var users = Api.Friends.Get(new FriendsGetParams
				{
					ListId = 1
				})
				.ToList();

			Assert.That(users.Count, Is.EqualTo(5));
			Assert.That(users[0].Id, Is.EqualTo(2));
			Assert.That(users[1].Id, Is.EqualTo(5));
			Assert.That(users[2].Id, Is.EqualTo(6));
			Assert.That(users[3].Id, Is.EqualTo(7));
			Assert.That(users[4].Id, Is.EqualTo(12));
		}

		[Test]
		public void GetAppUsers_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(new VkApi());
			Assert.That(() => cat.GetAppUsers(), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetAppUsers_NoOne_EmptyList()
		{
			Url = "https://api.vk.com/method/friends.getAppUsers";
			ReadJsonFile(JsonPaths.EmptyArray);

			var users = Api.Friends.GetAppUsers().ToList();

			Assert.That(users.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetAppUsers_ThreeUsers_ListOfObjects()
		{
			Url = "https://api.vk.com/method/friends.getAppUsers";
			ReadCategoryJsonPath(nameof(GetAppUsers_ThreeUsers_ListOfObjects));

			var ids = Api.Friends.GetAppUsers().ToList();

			Assert.That(ids.Count, Is.EqualTo(3));
			Assert.That(ids[0], Is.EqualTo(15221));
			Assert.That(ids[1], Is.EqualTo(17836));
			Assert.That(ids[2], Is.EqualTo(19194));
		}

		[Test]
		public void GetLists_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.getLists";
			ReadCategoryJsonPath(nameof(GetLists_NormalCase));

			var list = Api.Friends.GetLists();

			Assert.That(list.Count, Is.EqualTo(2));

			Assert.That(list[0].Id, Is.EqualTo(1));
			Assert.That(list[0].Name, Is.EqualTo("тестовая метка"));

			Assert.That(list[1].Id, Is.EqualTo(2));
			Assert.That(list[1].Name, Is.EqualTo("лист 3"));
		}

		[Test]
		public void GetMutual_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var category = new FriendsCategory(new VkApi());

			Assert.That(() => category.GetMutual(new FriendsGetMutualParams
				{
					TargetUid = 2,
					SourceUid = 3
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetMutual_NoOne_EmptyList()
		{
			Url = "https://api.vk.com/method/friends.getMutual";
			ReadJsonFile(JsonPaths.EmptyArray);

			var users = Api.Friends.GetMutual(new FriendsGetMutualParams
				{
					TargetUid = 2,
					SourceUid = 1
				})
				.ToList();

			Assert.That(users.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetMutual_ThreeUsers_ListOfObjects()
		{
			Url = "https://api.vk.com/method/friends.getMutual";
			ReadCategoryJsonPath(nameof(GetMutual_ThreeUsers_ListOfObjects));

			var ids = Api.Friends.GetMutual(new FriendsGetMutualParams
				{
					TargetUid = 2,
					SourceUid = 1
				})
				.ToList();

			Assert.That(ids.Count, Is.EqualTo(1));
		}

		[Test]
		public void GetOnline_EmptyAccessToken_ThrowAccessTokenInvalidException()
		{
			var cat = new FriendsCategory(new VkApi());

			Assert.That(() => cat.GetOnline(new FriendsGetOnlineParams
				{
					UserId = 1
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetOnline_Ex()
		{
			Url = "https://api.vk.com/method/friends.getOnline";
			ReadCategoryJsonPath(nameof(GetOnline_Ex));

			var users = Api.Friends.GetOnline(new FriendsGetOnlineParams
			{
				OnlineMobile = true
			});

			Assert.That(users.Online.Count, Is.EqualTo(1));
			Assert.That(users.MobileOnline.Count, Is.EqualTo(5));
		}

		[Test]
		public void GetOnline_FiveUsers_ListOfObjects()
		{
			Url = "https://api.vk.com/method/friends.getOnline";
			ReadCategoryJsonPath(nameof(GetOnline_FiveUsers_ListOfObjects));

			var users = Api.Friends.GetOnline(new FriendsGetOnlineParams
			{
				UserId = 1
			});

			Assert.That(users.Online.Count, Is.EqualTo(5));
			Assert.That(users.Online[0], Is.EqualTo(5));
			Assert.That(users.Online[1], Is.EqualTo(467));
			Assert.That(users.Online[2], Is.EqualTo(2943));
			Assert.That(users.Online[3], Is.EqualTo(4424));
			Assert.That(users.Online[4], Is.EqualTo(13033));
		}

		[Test]
		public void GetOnline_NoOne_EmptyList()
		{
			Url = "https://api.vk.com/method/friends.getOnline";
			ReadJsonFile(JsonPaths.EmptyArray);

			var users = Api.Friends.GetOnline(new FriendsGetOnlineParams
			{
				UserId = 1
			});

			Assert.That(users.Online.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetRecent_OneItem()
		{
			Url = "https://api.vk.com/method/friends.getRecent";
			ReadCategoryJsonPath(nameof(GetRecent_OneItem));

			var ids = Api.Friends.GetRecent(3);

			Assert.That(ids, Is.Not.Null);
			Assert.That(ids.Count, Is.EqualTo(1));
			Assert.That(ids[0], Is.EqualTo(242508111));
		}

		[Test]
		public void GetRequest_count_unread()
		{
			Url = "https://api.vk.com/method/friends.getRequests";
			ReadCategoryJsonPath(nameof(GetRequest_count_unread));

			var ids = Api.Friends.GetRequests(new FriendsGetRequestsParams
			{
				Offset = 0,
				Count = 3,
				Extended = false,
				NeedMutual = false
			});

			Assert.That(ids, Is.Not.Null);
			Assert.That(ids.CountUnread, Is.EqualTo(1));
			Assert.That(ids.Count, Is.EqualTo(171));
			Assert.That(ids.Items, Is.Not.Empty);
		}

		[Test]
		public void GetRequest_EmptyCollection()
		{
			Url = "https://api.vk.com/method/friends.getRequests";
			ReadCategoryJsonPath(nameof(GetRequest_EmptyCollection));

			var ids = Api.Friends.GetRequestsExtended(new FriendsGetRequestsParams
			{
				Offset = 0,
				Count = 3,
				Extended = true,
				NeedMutual = true
			});

			Assert.That(ids, Is.Not.Null);
			Assert.That(ids.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetRequests_Basic_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.getRequests";
			ReadCategoryJsonPath(nameof(GetRequests_Basic_NormalCase));

			var ids = Api.Friends.GetRequests(new FriendsGetRequestsParams
			{
				Offset = 0,
				Count = 3
			});

			Assert.That(ids, Is.Not.Null);
			Assert.That(ids.Items[0], Is.EqualTo(242508111));
		}

		[Test]
		public void GetRequests_Extended_NormalCase()
		{
			Url = "https://api.vk.com/method/friends.getRequests";
			ReadCategoryJsonPath(nameof(GetRequests_Extended_NormalCase));

			var ids = Api.Friends.GetRequestsExtended(new FriendsGetRequestsParams
			{
				Offset = 0,
				Count = 3,
				Extended = true,
				NeedMutual = true
			});

			Assert.That(ids, Is.Not.Null);
			Assert.That(ids.Count, Is.EqualTo(1));
			Assert.That(ids[0].UserId, Is.EqualTo(242508111));
		}
	}
}