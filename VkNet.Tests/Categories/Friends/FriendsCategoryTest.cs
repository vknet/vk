using System;
using System.Linq;
using FluentAssertions;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Friends;

public class FriendsCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Friends";

	[Fact]
	public void Add_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.add";
		ReadJsonFile(JsonPaths.True);

		var status = Api.Friends.Add(242508, "hello, user!", false);

		status.Should()
			.Be(AddFriendStatus.Sended);
	}

	[Fact]
	public void AddList_NameIsEmpty_ThrowException() => FluentActions.Invoking(() => Api.Friends.AddList("", null))
		.Should()
		.ThrowExactly<ArgumentNullException>();

	[Fact]
	public void AddList_OnlyName_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.addList";
		ReadCategoryJsonPath(nameof(AddList_OnlyName_NormalCase));

		var id = Api.Friends.AddList("тестовая метка", null);

		id.Should()
			.Be(1);
	}

	[Fact]
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

		id.Should()
			.Be(2);
	}

	[Fact]
	public void AreFriends_EmptyAccessToken_ThrowAccessTokenInvalidException()
	{
		var cat = new FriendsCategory(new VkApi());

		FluentActions.Invoking(() => cat.AreFriends(new long[]
			{
				2,
				3
			}))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
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

		dict.Should()
			.NotBeNull();

		dict.Should()
			.HaveCount(4);

		(dict.FirstOrDefault()
				?.FriendStatus).Should()
			.Be(FriendStatus.NotFriend);

		(dict.Skip(1)
				.FirstOrDefault()
				?.FriendStatus).Should()
			.Be(FriendStatus.Friend);

		(dict.Skip(2)
				.FirstOrDefault()
				?.FriendStatus).Should()
			.Be(FriendStatus.InputRequest);

		(dict.Skip(3)
				.FirstOrDefault()
				?.FriendStatus).Should()
			.Be(FriendStatus.OutputRequest);
	}

	[Fact]
	public void AreFriends_NullInput_ThrowArgumentNullException() => FluentActions.Invoking(() => Api.Friends.AreFriends(null))
		.Should()
		.ThrowExactly<ArgumentNullException>();

	[Fact]
	public void Delete_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.delete";
		ReadCategoryJsonPath(nameof(Delete_NormalCase));

		var status = Api.Friends.Delete(24250);

		status.OutRequestDeleted.Should()
			.BeTrue();
	}

	[Fact]
	public void DeleteAllRequests_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.deleteAllRequests";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Friends.DeleteAllRequests();

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void DeleteList_IdIsNegative_ThrowException() => FluentActions.Invoking(() => Api.Friends.DeleteList(-1))
		.Should()
		.ThrowExactly<ArgumentException>();

	[Fact]
	public void DeleteList_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.deleteList";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Friends.DeleteList(2);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Edit_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.edit";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Friends.Edit(242508111,
			new long[]
			{
				2
			});

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void EditList_EditName_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.editList";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Friends.EditList(2, "new тестовая метка");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void EditList_ListIdIsNegative_ThrowException() => FluentActions.Invoking(() => Api.Friends.EditList(-1))
		.Should()
		.ThrowExactly<ArgumentException>();

	[Fact]
	public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
	{
		var cat = new FriendsCategory(new VkApi());

		FluentActions.Invoking(() => cat.Get(new()
			{
				UserId = 1
			}))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void Get_FirstNameLastName_ListOfObjects()
	{
		Url = "https://api.vk.com/method/friends.get";
		ReadCategoryJsonPath(nameof(Get_FirstNameLastName_ListOfObjects));

		var lst = Api.Friends.Get(new()
		{
			Count = 3,
			Fields = ProfileFields.FirstName|ProfileFields.LastName,
			UserId = 1
		});

		lst.Should()
			.HaveCount(3);

		lst[0]
			.Id.Should()
			.Be(2);

		lst[0]
			.FirstName.Should()
			.Be("Александра");

		lst[0]
			.LastName.Should()
			.Be("Владимирова");

		lst[0]
			.Online.Should()
			.BeFalse();

		lst[1]
			.Id.Should()
			.Be(5);

		lst[1]
			.FirstName.Should()
			.Be("Илья");

		lst[1]
			.LastName.Should()
			.Be("Перекопский");

		lst[1]
			.Online.Should()
			.BeFalse();

		lst[2]
			.Id.Should()
			.Be(6);

		lst[2]
			.FirstName.Should()
			.Be("Николай");

		lst[2]
			.LastName.Should()
			.Be("Дуров");

		lst[2]
			.Online.Should()
			.BeFalse();
	}

	[Fact]
	public void Get_FriendsForDurov_ListOfFriends()
	{
		Url = "https://api.vk.com/method/friends.get";
		ReadCategoryJsonPath(nameof(Get_FriendsForDurov_ListOfFriends));

		var users = Api.Friends.Get(new()
			{
				ListId = 1
			})
			.ToList();

		users.Should()
			.HaveCount(5);

		users.Should()
			.SatisfyRespectively(x => x.Id.Should()
					.Be(2),
				x => x.Id.Should()
					.Be(5),
				x => x.Id.Should()
					.Be(6),
				x => x.Id.Should()
					.Be(7),
				x => x.Id.Should()
					.Be(12));
	}

	[Fact]
	public void GetAppUsers_EmptyAccessToken_ThrowAccessTokenInvalidException()
	{
		var cat = new FriendsCategory(new VkApi());

		FluentActions.Invoking(() => cat.GetAppUsers())
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetAppUsers_NoOne_EmptyList()
	{
		Url = "https://api.vk.com/method/friends.getAppUsers";
		ReadJsonFile(JsonPaths.EmptyArray);

		var users = Api.Friends.GetAppUsers()
			.ToList();

		users.Should()
			.BeEmpty();
	}

	[Fact]
	public void GetAppUsers_ThreeUsers_ListOfObjects()
	{
		Url = "https://api.vk.com/method/friends.getAppUsers";
		ReadCategoryJsonPath(nameof(GetAppUsers_ThreeUsers_ListOfObjects));

		var ids = Api.Friends.GetAppUsers()
			.ToList();

		ids.Should()
			.HaveCount(3);

		ids.Should()
			.HaveElementAt(0, 15221);

		ids.Should()
			.HaveElementAt(1, 17836);

		ids.Should()
			.HaveElementAt(2, 19194);
	}

	[Fact]
	public void GetLists_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.getLists";
		ReadCategoryJsonPath(nameof(GetLists_NormalCase));

		var list = Api.Friends.GetLists();

		list.Should()
			.HaveCount(2);

		list[0]
			.Id.Should()
			.Be(1);

		list[0]
			.Name.Should()
			.Be("тестовая метка");

		list[1]
			.Id.Should()
			.Be(2);

		list[1]
			.Name.Should()
			.Be("лист 3");
	}

	[Fact]
	public void GetMutual_EmptyAccessToken_ThrowAccessTokenInvalidException()
	{
		var category = new FriendsCategory(new VkApi());

		FluentActions.Invoking(() => category.GetMutual(new()
			{
				TargetUid = 2,
				SourceUid = 3
			}))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetMutual_NoOne_EmptyList()
	{
		Url = "https://api.vk.com/method/friends.getMutual";
		ReadJsonFile(JsonPaths.EmptyArray);

		var users = Api.Friends.GetMutual(new()
			{
				TargetUid = 2,
				SourceUid = 1
			})
			.ToList();

		users.Should()
			.BeEmpty();
	}

	[Fact]
	public void GetMutual_ThreeUsers_ListOfObjects()
	{
		Url = "https://api.vk.com/method/friends.getMutual";
		ReadCategoryJsonPath(nameof(GetMutual_ThreeUsers_ListOfObjects));

		var ids = Api.Friends.GetMutual(new()
			{
				TargetUid = 2,
				SourceUid = 1
			})
			.ToList();

		ids.Should()
			.ContainSingle();
	}

	[Fact]
	public void GetOnline_EmptyAccessToken_ThrowAccessTokenInvalidException()
	{
		var cat = new FriendsCategory(new VkApi());

		FluentActions.Invoking(() => cat.GetOnline(new()
			{
				UserId = 1
			}))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetOnline_Ex()
	{
		Url = "https://api.vk.com/method/friends.getOnline";
		ReadCategoryJsonPath(nameof(GetOnline_Ex));

		var users = Api.Friends.GetOnline(new()
		{
			OnlineMobile = true
		});

		users.Online.Should()
			.HaveCount(1);

		users.MobileOnline.Should()
			.HaveCount(5);
	}

	[Fact]
	public void GetOnline_FiveUsers_ListOfObjects()
	{
		Url = "https://api.vk.com/method/friends.getOnline";
		ReadCategoryJsonPath(nameof(GetOnline_FiveUsers_ListOfObjects));

		var users = Api.Friends.GetOnline(new()
		{
			UserId = 1
		});

		users.Online.Should()
			.HaveCount(5);

		users.Online[0]
			.Should()
			.Be(5);

		users.Online[1]
			.Should()
			.Be(467);

		users.Online[2]
			.Should()
			.Be(2943);

		users.Online[3]
			.Should()
			.Be(4424);

		users.Online[4]
			.Should()
			.Be(13033);
	}

	[Fact]
	public void GetOnline_NoOne_EmptyList()
	{
		Url = "https://api.vk.com/method/friends.getOnline";
		ReadJsonFile(JsonPaths.EmptyArray);

		var users = Api.Friends.GetOnline(new()
		{
			UserId = 1
		});

		users.Online.Should()
			.BeEmpty();
	}

	[Fact]
	public void GetRecent_OneItem()
	{
		Url = "https://api.vk.com/method/friends.getRecent";
		ReadCategoryJsonPath(nameof(GetRecent_OneItem));

		var ids = Api.Friends.GetRecent(3);

		ids.Should()
			.NotBeNull();

		ids.Should()
			.ContainSingle();

		ids.Should()
			.HaveElementAt(0, 242508111);
	}

	[Fact]
	public void GetRequest_count_unread()
	{
		Url = "https://api.vk.com/method/friends.getRequests";
		ReadCategoryJsonPath(nameof(GetRequest_count_unread));

		var ids = Api.Friends.GetRequests(new()
		{
			Offset = 0,
			Count = 3,
			Extended = false,
			NeedMutual = false
		});

		ids.Should()
			.NotBeNull();

		ids.CountUnread.Should()
			.Be(1);

		ids.Count.Should()
			.Be(171);

		ids.Items.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetRequest_EmptyCollection()
	{
		Url = "https://api.vk.com/method/friends.getRequests";
		ReadCategoryJsonPath(nameof(GetRequest_EmptyCollection));

		var ids = Api.Friends.GetRequestsExtended(new()
		{
			Offset = 0,
			Count = 3,
			Extended = true,
			NeedMutual = true
		});

		ids.Should()
			.NotBeNull();

		ids.Should()
			.BeEmpty();
	}

	[Fact]
	public void GetRequests_Basic_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.getRequests";
		ReadCategoryJsonPath(nameof(GetRequests_Basic_NormalCase));

		var ids = Api.Friends.GetRequests(new()
		{
			Offset = 0,
			Count = 3
		});

		ids.Should()
			.NotBeNull();

		ids.Items[0]
			.Should()
			.Be(242508111);
	}

	[Fact]
	public void GetRequests_Extended_NormalCase()
	{
		Url = "https://api.vk.com/method/friends.getRequests";
		ReadCategoryJsonPath(nameof(GetRequests_Extended_NormalCase));

		var ids = Api.Friends.GetRequestsExtended(new()
		{
			Offset = 0,
			Count = 3,
			Extended = true,
			NeedMutual = true
		});

		ids.Should()
			.NotBeNull();

		ids.Should()
			.ContainSingle();

		ids[0]
			.UserId.Should()
			.Be(242508111);
	}
}