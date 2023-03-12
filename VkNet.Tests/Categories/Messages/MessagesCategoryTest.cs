using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Attachments;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class MessagesCategoryTest : MessagesBaseTests
{
	[Fact]
	public void AddChatUser_NormalCase_True()
	{
		Url = "https://api.vk.com/method/messages.addChatUser";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.AddChatUser(2, 7550525);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void CreateChat_NormalCase_ChatId()
	{
		Url = "https://api.vk.com/method/messages.createChat";
		ReadCategoryJsonPath(nameof(CreateChat_NormalCase_ChatId));

		var chatId = Api.Messages.CreateChat(new ulong[]
			{
				5041431,
				10657891
			},
			"test chat's title");

		chatId.Should()
			.Be(3);
	}

	[Fact]
	public void Delete_Id4446_True()
	{
		Url = "https://api.vk.com/method/messages.delete";

		ReadCategoryJsonPath(nameof(Delete_Id4446_True));

		var result = Api.Messages.Delete(new ulong[]
			{
				4446
			},
			false,
			null,
			false);

		result[4446]
			.Should()
			.BeTrue();
	}

	[Fact]
	public void Delete_Id999999_False()
	{
		Url = "https://api.vk.com/method/messages.delete";

		ReadErrorsJsonFile(1);

		FluentActions.Invoking(() => Api.Messages.Delete(new ulong[]
				{
					999999
				},
				false,
				null,
				false))
			.Should()
			.ThrowExactly<UnknownException>();
	}

	[Fact]
	public void Delete_Multiple_4457And4464_True()
	{
		Url = "https://api.vk.com/method/messages.delete";

		ReadCategoryJsonPath(nameof(Delete_Multiple_4457And4464_True));

		var dict = Api.Messages.Delete(new ulong[]
			{
				4457,
				4464
			},
			false,
			null,
			false);

		dict.Should()
			.HaveCount(2);

		dict[4457]
			.Should()
			.BeTrue();

		dict[4464]
			.Should()
			.BeTrue();
	}

	[Fact]
	public void EditChat_NormalCase_True()
	{
		Url = "https://api.vk.com/method/messages.editChat";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.EditChat(2, "new title");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Get_NormalCase_V521()
	{
		Url = "https://api.vk.com/method/messages.get";

		ReadCategoryJsonPath(nameof(Get_NormalCase_V521));

		var messages = Api.Messages.Get(new());

		messages.TotalCount.Should()
			.Be(5);

		messages.Should()
			.NotBeNull();

		messages.Messages.Should()
			.HaveCount(2);

		var message = messages.Messages.FirstOrDefault();

		message.Should()
			.NotBeNull();

		message.Body.Should()
			.Be("fun");

		message.Id.Should()
			.Be(34);

		message.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1398242416));

		message.ReadState.Should()
			.Be(MessageReadState.Unreaded);

		message.Type.Should()
			.Be(MessageType.Received);

		message.UserId.Should()
			.Be(562508789);

		message.Title.Should()
			.Be(" ... ");

		var message1 = messages.Messages.Skip(1)
			.FirstOrDefault();

		message1.Should()
			.NotBeNull();

		message1.Body.Should()
			.Be("very");

		message1.Id.Should()
			.Be(33);

		message1.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1398242415));

		message1.ReadState.Should()
			.Be(MessageReadState.Unreaded);

		message1.Type.Should()
			.Be(MessageType.Received);

		message1.UserId.Should()
			.Be(562508789);

		message1.Title.Should()
			.Be(" ... ");
	}

	[Fact]
	public void Get_WithLastMessageIdParam_NormalCase_V521()
	{
		Url = "https://api.vk.com/method/messages.get";

		ReadCategoryJsonPath(nameof(Get_WithLastMessageIdParam_NormalCase_V521));

		var messages = Api.Messages.Get(new()
		{
			LastMessageId = 30
		});

		messages.TotalCount.Should()
			.Be(5);

		messages.Should()
			.NotBeNull();

		messages.Messages.Should()
			.HaveCount(1);

		var message = messages.Messages.FirstOrDefault();

		message.Should()
			.NotBeNull();

		message.Id.Should()
			.Be(31);

		message.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1398242412));

		message.Type.Should()
			.Be(MessageType.Received);

		message.UserId.Should()
			.Be(123508789);

		message.ReadState.Should()
			.Be(MessageReadState.Unreaded);

		message.Title.Should()
			.Be(" ... ");

		message.Body.Should()
			.Be("may");
	}

	[Fact]
	public void GetById_Multiple_NormalCase_Messages()
	{
		Url = "https://api.vk.com/method/messages.getById";

		ReadCategoryJsonPath(nameof(GetById_Multiple_NormalCase_Messages));

		var msgs = Api.Messages.GetById(new ulong[]
			{
				1,
				3,
				5
			},
			null);

		msgs.TotalCount.Should()
			.Be(3);

		msgs.Should()
			.HaveCount(3);

		msgs[2]
			.Id.Should()
			.Be(5);

		msgs[2]
			.Type.Should()
			.Be(MessageType.Received);

		msgs[2]
			.UserId.Should()
			.Be(684559);

		msgs[2]
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		msgs[2]
			.Title.Should()
			.Be("Re(2): Как там зачетная неделя продвигаетсо?)");

		msgs[2]
			.Body.Should()
			.Be("Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)");

		msgs[1]
			.Id.Should()
			.Be(3);

		msgs[1]
			.Type.Should()
			.Be(MessageType.Sended);

		msgs[1]
			.UserId.Should()
			.Be(684559);

		msgs[1]
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		msgs[1]
			.Title.Should()
			.Be("Re: Как там зачетная неделя продвигаетсо?)");

		msgs[1]
			.Body.Should()
			.Be("Парят и парят во все дыры)... у тебя как?");

		msgs[0]
			.Id.Should()
			.Be(1);

		msgs[0]
			.Type.Should()
			.Be(MessageType.Received);

		msgs[0]
			.UserId.Should()
			.Be(684559);

		msgs[0]
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		msgs[0]
			.Title.Should()
			.Be(" ... ");

		msgs[0]
			.Body.Should()
			.Be("Привеееет!!!!!!!!!!!");
	}

	[Fact]
	public void GetById_NormalCase_Message()
	{
		Url = "https://api.vk.com/method/messages.getById";

		ReadCategoryJsonPath(nameof(GetById_NormalCase_Message));

		var msg = Api.Messages.GetById(new ulong[]
				{
					1
				},
				null)
			.FirstOrDefault();

		msg.Should()
			.NotBeNull();

		// ReSharper disable PossibleNullReferenceException
		msg.Id.Should()
			.Be(265999);

		msg.Date.Should()
			.Be(new(2020,
				2,
				12,
				9,
				7,
				42,
				DateTimeKind.Utc));

		msg.Type.Should()
			.Be(MessageType.Sended);

		msg.PeerId.Should()
			.Be(228907945);

		msg.Attachments.Should()
			.HaveCount(1);

		// ReSharper restore PossibleNullReferenceException
	}

	[Fact]
	public void GetChat_NormalCase_ChatObject()
	{
		Url = "https://api.vk.com/method/messages.getChat";

		ReadCategoryJsonPath(nameof(GetChat_NormalCase_ChatObject));

		var chat = Api.Messages.GetChat(2);

		chat.Id.Should()
			.Be(2);

		chat.Title.Should()
			.Be("test chat title");

		chat.AdminId.Should()
			.Be(4793858);

		chat.Users.Should()
			.HaveCount(3);

		chat.Users.ElementAt(0)
			.Should()
			.Be(4793858);

		chat.Users.ElementAt(1)
			.Should()
			.Be(5041431);

		chat.Users.ElementAt(2)
			.Should()
			.Be(10657891);
	}

	[Fact]
	public void GetChatUsers_ChatId_UserIds()
	{
		Url = "https://api.vk.com/method/messages.getChatUsers";

		ReadCategoryJsonPath(nameof(GetChatUsers_ChatId_UserIds));

		var users = Api.Messages.GetChatUsers(new List<long>
				{
					2
				})
			.ToList();

		users.Should()
			.HaveCount(3);
	}

	[Fact]
	public void GetChatUsers_ChatIdWithFields_Users()
	{
		Url = "https://api.vk.com/method/messages.getChatUsers";

		ReadCategoryJsonPath(nameof(GetChatUsers_ChatIdWithFields_Users));

		var chat = Api.Messages.GetChatUsers(new List<long>
			{
				2,
				5
			},
			UsersFields.Education, null);

		chat.Users.Should()
			.HaveCount(3);

		chat.Users[0]
			.Id.Should()
			.Be(4793858);

		chat.Users[0]
			.FirstName.Should()
			.Be("Антон");

		chat.Users[0]
			.LastName.Should()
			.Be("Жидков");

		chat.Users[0]
			.Education.Should()
			.BeNull();

		chat.Users[0]
			.InvitedBy.Should()
			.Be(4793858);

		chat.Users[1]
			.Id.Should()
			.Be(5041431);

		chat.Users[1]
			.FirstName.Should()
			.Be("Тайфур");

		chat.Users[1]
			.LastName.Should()
			.Be("Касеев");

		chat.Users[1]
			.Education.UniversityId.Should()
			.Be(431);

		chat.Users[1]
			.InvitedBy.Should()
			.Be(4793858);

		chat.Users[2]
			.Id.Should()
			.Be(10657891);

		chat.Users[2]
			.FirstName.Should()
			.Be("Максим");

		chat.Users[2]
			.LastName.Should()
			.Be("Денисов");

		chat.Users[2]
			.Education.UniversityId.Should()
			.Be(431);

		chat.Users[2]
			.Education.FacultyId.Should()
			.Be(3162);

		chat.Users[2]
			.Education.Graduation.Should()
			.Be(2011);

		chat.Users[2]
			.InvitedBy.Should()
			.Be(4793858);
	}

	[Fact]
	public void GetDialogs_NormalCase_Messages()
	{
		Url = "https://api.vk.com/method/messages.getDialogs";
		ReadCategoryJsonPath(nameof(GetDialogs_NormalCase_Messages));

		var msgs = Api.Messages.GetDialogs(new()
		{
			Count = 77128,
			Offset = 0,
			Unread = false
		});

		msgs.TotalCount.Should()
			.Be(299);

		msgs.Messages.Should()
			.HaveCount(20);

		msgs.Messages[0].Message
			.Id.Should()
			.Be(266284);

		msgs.Messages[0].Message
			.Date.Should()
			.Be(new(2020,
				2,
				16,
				9,
				50,
				50,
				DateTimeKind.Utc));

		msgs.Messages[0].Message
			.Type.Should()
			.Be(MessageType.Sended);

		msgs.Messages[0].Message
			.UserId.Should()
			.Be(71469725);

		msgs.Messages[0].Message
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		msgs.Messages[0].Message
			.Body.Should()
			.Be("&#128514;");
	}

	[Fact]
	public void GetHistory_ContainsRepost_Error46()
	{
		Url = "https://api.vk.com/method/messages.getHistory";
		ReadCategoryJsonPath(nameof(GetHistory_ContainsRepost_Error46));

		var msgs = Api.Messages.GetHistory(new()
		{
			UserId = 7712
		});

		// assertions
		msgs.TotalCount.Should()
			.Be(1940);

		var msg = msgs.Messages.FirstOrDefault();

		msg.Should()
			.NotBeNull();

		msg.Attachments.Should()
			.HaveCount(1);

		var wall = msg.Attachments[0]
			.Instance as Model.Attachments.Wall;

		wall.Should()
			.NotBeNull();

		wall.Id.Should()
			.Be(6194);

		wall.FromId.Should()
			.Be(-1267);

		wall.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1414992610));

		wall.PostType.Should()
			.Be(PostType.Post);

		wall.Text.Should()
			.BeEmpty();

		wall.Comments.Count.Should()
			.Be(3);

		wall.Comments.CanPost.Should()
			.BeFalse();

		wall.Likes.Count.Should()
			.Be(9191);

		wall.Likes.UserLikes.Should()
			.BeTrue();

		wall.Likes.CanLike.Should()
			.BeFalse();

		wall.Likes.CanPublish.Should()
			.BeTrue();

		wall.Reposts.Count.Should()
			.Be(953);

		wall.Reposts.UserReposted.Should()
			.BeFalse();

		wall.Attachments.Count.Should()
			.Be(1);

		var photo = wall.Attachments[0]
			.Instance as Photo;

		photo.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetHistory_ContainsSticker_Error47()
	{
		Url = "https://api.vk.com/method/messages.getHistory";
		ReadCategoryJsonPath(nameof(GetHistory_ContainsSticker_Error47));

		var msgs = Api.Messages.GetHistory(new()
		{
			UserId = 7712,
			Count = 5,
			Offset = 3
		});

		// asserts
		msgs.TotalCount.Should()
			.Be(6);

		msgs.Messages.Count()
			.Should()
			.Be(1);

		var msg = msgs.Messages.FirstOrDefault();

		msg.Should()
			.NotBeNull();

		msg.Attachments.Should()
			.HaveCount(1);

		var sticker = msg.Attachments[0]
			.Instance as Sticker;

		sticker.Should()
			.NotBeNull();

		sticker.Id.Should()
			.Be(12345);

		sticker.ProductId.Should()
			.Be(54321);
	}

	[Fact]
	public void GetHistory_NormalCaseAllFields_Messages()
	{
		Url = "https://api.vk.com/method/messages.getHistory";
		ReadCategoryJsonPath(nameof(GetHistory_NormalCaseAllFields_Messages));

		var msgs = Api.Messages.GetHistory(new());
		var messages = msgs.Messages.ToList();

		msgs.TotalCount.Should()
			.Be(1493);

		messages.Should()
			.ContainSingle();

		messages[0]
			.Id.Should()
			.Be(266005);

		messages[0]
			.Text.Should()
			.Be("Спс бро");

		messages[0]
			.PeerId.Should()
			.Be(228907945);

		messages[0]
			.Date.Should()
			.Be(new(2020,
				2,
				12,
				17,
				26,
				01,
				DateTimeKind.Utc));
	}

	[Fact]
	public void GetLastActivity_NormalCast_LastActivityObject()
	{
		Url = "https://api.vk.com/method/messages.getLastActivity";
		ReadCategoryJsonPath(nameof(GetLastActivity_NormalCast_LastActivityObject));

		var activity = Api.Messages.GetLastActivity(77128);

		activity.UserId.Should()
			.Be(77128);

		activity.IsOnline.Should()
			.BeFalse();

		activity.Time.Should()
			.Be(new(2012,
				8,
				9,
				3,
				57,
				25,
				DateTimeKind.Utc));
	}

	[Fact]
	public void GetLongPollServer_NormalCase_LongPollServerResponse()
	{
		Url = "https://api.vk.com/method/messages.getLongPollServer";
		ReadCategoryJsonPath(nameof(GetLongPollServer_NormalCase_LongPollServerResponse));

		var response = Api.Messages.GetLongPollServer();

		response.Key.Should()
			.Be("6f4120988efaf3a7d398054b5bb5d019c5844bz3");

		response.Server.Should()
			.Be("im46.vk.com/im1858");

		response.Ts.Should()
			.Be("1627957305");
	}

	[Fact]
	public void GetLongPollServer_ThrowArgumentNullException() => FluentActions.Invoking(() => Api.Messages.GetLongPollServer())
		.Should()
		.ThrowExactly<ArgumentException>();

	[Fact]
	public void MarkAsRead_Multiple_NormalCase_True()
	{
		Url = "https://api.vk.com/method/messages.markAsRead";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.MarkAsRead(null);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void MarkAsRead_NormalCase_True()
	{
		Url = "https://api.vk.com/method/messages.markAsRead";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.MarkAsRead(null);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void RemoveChatUser_NormalCase_True()
	{
		Url = "https://api.vk.com/method/messages.removeChatUser";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.RemoveChatUser(2, 7550525);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Restore_NormalCase_True()
	{
		Url = "https://api.vk.com/method/messages.restore";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.Restore(134);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Search_NormalCase_Messages()
	{
		Url = "https://api.vk.com/method/messages.search";
		ReadCategoryJsonPath(nameof(Search_NormalCase_Messages));

		var result = Api.Messages.Search(new()
		{
			Query = "привет",
			Count = 3
		});

		result.Count.Should()
			.Be(18);

		var messages = result.Items.ToList();

		messages.Should()
			.NotBeNull();

		messages.Should()
			.HaveCount(3);

		messages[2]
			.Id.Should()
			.Be(131291);

		messages[2]
			.Date.Should()
			.Be(new(2015,
				10,
				06,
				4,
				33,
				24,
				DateTimeKind.Utc));

		messages[2]
			.UserId.Should()
			.Be(310881357);

		messages[2]
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		messages[2]
			.Title.Should()
			.Be(" ... ");

		messages[2]
			.Body.Should()
			.Be("привет, антон))");

		messages[1]
			.Id.Should()
			.Be(131304);

		messages[1]
			.Date.Should()
			.Be(new(2015,
				10,
				6,
				9,
				17,
				57,
				DateTimeKind.Utc));

		messages[1]
			.UserId.Should()
			.Be(72815776);

		messages[1]
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		messages[1]
			.Title.Should()
			.Be(" ... ");

		messages[1]
			.Body.Should()
			.Be("Привет");

		messages[0]
			.Id.Should()
			.Be(131307);

		messages[0]
			.Date.Should()
			.Be(new(2015,
				10,
				6,
				9,
				26,
				26,
				DateTimeKind.Utc));

		messages[0]
			.UserId.Should()
			.Be(72815776);

		messages[0]
			.ReadState.Should()
			.Be(MessageReadState.Readed);

		messages[0]
			.Title.Should()
			.Be(" ... ");

		messages[0]
			.Body.Should()
			.Be("Привет");
	}

	[Fact]
	public void Search_NotExistedQuery_EmptyList()
	{
		Url = "https://api.vk.com/method/messages.search";

		ReadJsonFile(JsonPaths.EmptyVkCollection);

		var msgs = Api.Messages.Search(new()
		{
			Query = "fsjkadoivhjioashdpfisd",
			Count = 3
		});

		msgs.Count.Should()
			.Be(0);
	}

	[Fact]
	public void SearchDialogs_EmptyResponse_MessageResponseWithEmptyLists()
	{
		Url = "https://api.vk.com/method/messages.searchDialogs";
		ReadJsonFile(JsonPaths.EmptyArray);

		var response = Api.Messages.SearchDialogs("привет");

		response.Chats.Should()
			.BeEmpty();
		response.Groups.Should()
			.BeEmpty();
		response.Users.Should()
			.BeEmpty();
	}

	[Fact]
	public void SearchDialogs_NastyaQuery_TwoProfiles()
	{
		Url = "https://api.vk.com/method/messages.searchDialogs";
		ReadCategoryJsonPath(nameof(SearchDialogs_NastyaQuery_TwoProfiles));

		var response = Api.Messages.SearchDialogs("Настя");

		response.Users.Should()
			.HaveCount(2);

		response.Chats.Should()
			.BeEmpty();

		response.Users.ElementAt(0)
			.Id.Should()
			.Be(7503978);

		response.Users.ElementAt(0)
			.FirstName.Should()
			.Be("Настя");

		response.Users.ElementAt(0)
			.LastName.Should()
			.Be("Иванова");

		response.Users.ElementAt(1)
			.Id.Should()
			.Be(68274561);

		response.Users.ElementAt(1)
			.FirstName.Should()
			.Be("Настя");

		response.Users.ElementAt(1)
			.LastName.Should()
			.Be("Петрова");
	}

	[Fact]
	public void SearchDialogs_ProfileAndChat_Response()
	{
		Url = "https://api.vk.com/method/messages.searchDialogs";
		ReadCategoryJsonPath(nameof(SearchDialogs_ProfileAndChat_Response));

		var response = Api.Messages.SearchDialogs("Маша");

		response.Users.Should()
			.HaveCount(1);

		response.Chats.Should()
			.HaveCount(1);

		response.Users[0]
			.Id.Should()
			.Be(1708231);

		response.Users[0]
			.FirstName.Should()
			.Be("Григорий");

		response.Users[0]
			.LastName.Should()
			.Be("Клюшников");

		response.Chats[0]
			.Id.Should()
			.Be(109);

		response.Chats[0]
			.Title.Should()
			.Be("Андрей, Григорий");

		response.Chats[0]
			.Users.Should()
			.HaveCount(3);

		response.Chats[0]
			.Users.ElementAt(0)
			.Should()
			.Be(66748);

		response.Chats[0]
			.Users.ElementAt(1)
			.Should()
			.Be(6492);

		response.Chats[0]
			.Users.ElementAt(2)
			.Should()
			.Be(1708231);
	}
}