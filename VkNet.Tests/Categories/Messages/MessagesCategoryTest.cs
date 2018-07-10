using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage(category: "ReSharper", checkId: "PublicMembersMustHaveComments")]
	public class MessagesCategoryTest : BaseTest
	{
		public MessagesCategory Cat => GetMockedMessagesCategory();

		private MessagesCategory GetMockedMessagesCategory()
		{
			return new MessagesCategory(vk: Api);
		}

		[Test]
		public void AddChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.AddChatUser(chatId: 2, userId: 2), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void AddChatUser_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.addChatUser";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.AddChatUser(chatId: 2, userId: 7550525);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void CreateChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.CreateChat(userIds: new ulong[]
					{
						1,
						2
					},
					title: "hi, friends"),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void CreateChat_NormalCase_ChatId()
		{
			Url = "https://api.vk.com/method/messages.createChat";

			Json =
				@"{
					'response': 3
				  }";

			var chatId = Cat.CreateChat(userIds: new ulong[]
				{
					5041431,
					10657891
				},
				title: "test chat's title");

			Assert.That(actual: chatId, expression: Is.EqualTo(expected: 3));
		}

		[Test]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.Delete(messageIds: new ulong[] { 1 }, spam: false, deleteForAll: false),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Delete_Id4446_True()
		{
			Url = "https://api.vk.com/method/messages.delete";

			Json =
				@"{
					'response': {
					  '4446': 1
					}
				  }";

			var result = Cat.Delete(messageIds: new ulong[] { 4446 }, spam: false, deleteForAll: false);

			Assert.That(actual: result[key: 4446], expression: Is.True);
		}

		[Test]
		public void Delete_Id999999_False()
		{
			Url = "https://api.vk.com/method/messages.delete";

			Json =
				@"{
					'error': {
					  'error_code': 1,
					  'error_msg': 'Unknown error occured',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'messages.delete'
						},
						{
						  'key': 'mids',
						  'value': '999999'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			Assert.That(del: () => Cat.Delete(messageIds: new ulong[] { 999999 }, spam: false, deleteForAll: false),
				expr: Throws.InstanceOf<VkApiException>());
		}

		[Test]
		public void Delete_Multipre_4457And4464_True()
		{
			Url = "https://api.vk.com/method/messages.delete";

			Json =
				@"{
					'response': {
					  '4457': 1,
					  '4464': 1
					}
				  }";

			var dict = Cat.Delete(messageIds: new ulong[]
				{
					4457,
					4464
				},
				spam: false,
				deleteForAll: false);

			Assert.That(actual: dict.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: dict[key: 4457], expression: Is.True);
			Assert.That(actual: dict[key: 4464], expression: Is.True);
		}

		[Test]
		public void DeleteDialog_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.DeleteDialog(userId: 111), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void EditChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.EditChat(chatId: 2, title: "new title"), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void EditChat_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.editChat";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.EditChat(chatId: 2, title: "new title");
			Assert.True(condition: result);
		}

		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.Get(@params: new MessagesGetParams()), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_NormalCase_V521()
		{
			Url = "https://api.vk.com/method/messages.get";

			Json =
				@"{
					'response': {
					  'count': 5,
					  'items': [
						{
						  'id': 34,
						  'date': 1398242416,
						  'out': 0,
						  'user_id': 562508789,
						  'read_state': 0,
						  'title': ' ... ',
						  'body': 'fun'
						},
						{
						  'id': 33,
						  'date': 1398242415,
						  'out': 0,
						  'user_id': 562508789,
						  'read_state': 0,
						  'title': ' ... ',
						  'body': 'very'
						}
					  ]
					}
				  }";

			var messages = Cat.Get(@params: new MessagesGetParams());

			Assert.That(actual: messages.TotalCount, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: messages, expression: Is.Not.Null);
			Assert.That(actual: messages.Messages.Count, expression: Is.EqualTo(expected: 2));

			var message = messages.Messages.FirstOrDefault();
			Assert.That(actual: message, expression: Is.Not.Null);
			Assert.That(actual: message.Body, expression: Is.EqualTo(expected: "fun"));
			Assert.That(actual: message.Id, expression: Is.EqualTo(expected: 34));
			Assert.That(actual: message.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1398242416)));
			Assert.That(actual: message.ReadState, expression: Is.EqualTo(expected: MessageReadState.Unreaded));
			Assert.That(actual: message.Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: message.UserId, expression: Is.EqualTo(expected: 562508789));
			Assert.That(actual: message.Title, expression: Is.EqualTo(expected: " ... "));

			var message1 = messages.Messages.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: message1, expression: Is.Not.Null);
			Assert.That(actual: message1.Body, expression: Is.EqualTo(expected: "very"));
			Assert.That(actual: message1.Id, expression: Is.EqualTo(expected: 33));
			Assert.That(actual: message1.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1398242415)));
			Assert.That(actual: message1.ReadState, expression: Is.EqualTo(expected: MessageReadState.Unreaded));
			Assert.That(actual: message1.Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: message1.UserId, expression: Is.EqualTo(expected: 562508789));
			Assert.That(actual: message1.Title, expression: Is.EqualTo(expected: " ... "));
		}

		[Test]
		public void Get_WithLastMessageIdParam_NormalCase_V521()
		{
			Url = "https://api.vk.com/method/messages.get";

			Json =
				@"{
					'response': {
					  'count': 5,
					  'items': [
						{
						  'id': 31,
						  'date': 1398242412,
						  'out': 0,
						  'user_id': 123508789,
						  'read_state': 0,
						  'title': ' ... ',
						  'body': 'may'
						}
					  ]
					}
				  }";

			var messages = Cat.Get(@params: new MessagesGetParams
			{
				LastMessageId = 30
			});

			Assert.That(actual: messages.TotalCount, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: messages, expression: Is.Not.Null);
			Assert.That(actual: messages.Messages.Count, expression: Is.EqualTo(expected: 1));

			var message = messages.Messages.FirstOrDefault();
			Assert.That(actual: message, expression: Is.Not.Null);
			Assert.That(actual: message.Id, expression: Is.EqualTo(expected: 31));
			Assert.That(actual: message.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1398242412)));
			Assert.That(actual: message.Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: message.UserId, expression: Is.EqualTo(expected: 123508789));
			Assert.That(actual: message.ReadState, expression: Is.EqualTo(expected: MessageReadState.Unreaded));
			Assert.That(actual: message.Title, expression: Is.EqualTo(expected: " ... "));
			Assert.That(actual: message.Body, expression: Is.EqualTo(expected: "may"));
		}

		[Test]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.GetById(messageId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.GetById(messageIds: new ulong[]
				{
					1,
					3,
					5
				}),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_Multiple_NormalCase_Messages()
		{
			Url = "https://api.vk.com/method/messages.getById";

			Json =
				@"{
					'response': {
					  'count': 3,
					  'items': [{
						'id': 1,
						'date': 1197929120,
						'out': 0,
						'user_id': 684559,
						'read_state': 1,
						'title': ' ... ',
						'body': 'Привеееет!!!!!!!!!!!'
					  },
					  {
						'id': 3,
						'date': 1198616980,
						'out': 1,
						'user_id': 684559,
						'read_state': 1,
						'title': 'Re: Как там зачетная неделя продвигаетсо?)',
						'body': 'Парят и парят во все дыры)... у тебя как?'
					  },
					  {
						'id': 5,
						'date': 1198617408,
						'out': 0,
						'user_id': 684559,
						'read_state': 1,
						'title': 'Re(2): Как там зачетная неделя продвигаетсо?)',
						'body': 'Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)'
					  }]
					}
				  }";

			var msgs = Cat.GetById(messageIds: new ulong[]
			{
				1,
				3,
				5
			});

			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: msgs.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: msgs[index: 2].Id, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: msgs[index: 2].Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: msgs[index: 2].UserId, expression: Is.EqualTo(expected: 684559));
			Assert.That(actual: msgs[index: 2].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs[index: 2].Title, expression: Is.EqualTo(expected: "Re(2): Как там зачетная неделя продвигаетсо?)"));

			Assert.That(actual: msgs[index: 2].Body,
				expression: Is.EqualTo(expected: "Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)"));

			Assert.That(actual: msgs[index: 1].Id, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: msgs[index: 1].Type, expression: Is.EqualTo(expected: MessageType.Sended));
			Assert.That(actual: msgs[index: 1].UserId, expression: Is.EqualTo(expected: 684559));
			Assert.That(actual: msgs[index: 1].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs[index: 1].Title, expression: Is.EqualTo(expected: "Re: Как там зачетная неделя продвигаетсо?)"));
			Assert.That(actual: msgs[index: 1].Body, expression: Is.EqualTo(expected: "Парят и парят во все дыры)... у тебя как?"));
			Assert.That(actual: msgs[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: msgs[index: 0].Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: msgs[index: 0].UserId, expression: Is.EqualTo(expected: 684559));
			Assert.That(actual: msgs[index: 0].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs[index: 0].Title, expression: Is.EqualTo(expected: " ... "));
			Assert.That(actual: msgs[index: 0].Body, expression: Is.EqualTo(expected: "Привеееет!!!!!!!!!!!"));
		}

		[Test]
		[Ignore(reason: "")]
		public void GetById_NormalCase_Message()
		{
			Url = "https://api.vk.com/method/messages.getById";

			Json =
				@"{
					'response': [
					  1,
					  {
						'id': 1,
						'date': 1197929120,
						'out': 0,
						'user_id': 684559,
						'read_state': 1,
						'title': ' ... ',
						'body': 'Привеееет!!!!!!!!!!!'
					  }
					]
				  }";

			var msg = Cat.GetById(messageId: 1);

			Assert.That(actual: msg.Id, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: msg.Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2007,
					month: 12,
					day: 18,
					hour: 2,
					minute: 5,
					second: 20,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msg.Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: msg.UserId, expression: Is.EqualTo(expected: 684559));
			Assert.That(actual: msg.ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msg.Title, expression: Is.EqualTo(expected: " ... "));
			Assert.That(actual: msg.Body, expression: Is.EqualTo(expected: "Привеееет!!!!!!!!!!!"));
		}

		[Test]
		public void GetChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.GetChat(chatId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetChat_NormalCase_ChatObject()
		{
			Url = "https://api.vk.com/method/messages.getChat";

			Json =
				@"{
					'response': {
					  'type': 'chat',
					  'id': 2,
					  'title': 'test chat title',
					  'admin_id': '4793858',
					  'users': [
						4793858,
						5041431,
						10657891
					  ]
					}
				  }";

			var chat = Cat.GetChat(chatId: 2);

			Assert.That(actual: chat.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: chat.Title, expression: Is.EqualTo(expected: "test chat title"));
			Assert.That(actual: chat.AdminId, expression: Is.EqualTo(expected: 4793858));
			Assert.That(actual: chat.Users.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: chat.Users.ElementAt(index: 0), expression: Is.EqualTo(expected: 4793858));
			Assert.That(actual: chat.Users.ElementAt(index: 1), expression: Is.EqualTo(expected: 5041431));
			Assert.That(actual: chat.Users.ElementAt(index: 2), expression: Is.EqualTo(expected: 10657891));
		}

		[Test]
		public void GetChatUsers_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.GetChatUsers(chatIds: new List<long> { 2 }, fields: null, nameCase: null),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetChatUsers_ChatId_UserIds()
		{
			Url = "https://api.vk.com/method/messages.getChatUsers";

			Json =
				@"{
					'response': {
                        2: [
					  4793858,
					  5041431,
					  10657891
					]}
				  }";

			var users = Cat.GetChatUsers(chatIds: new List<long> { 2 }, fields: null, nameCase: null).ToList();

			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 3));
		}

		[Test]
		public void GetChatUsers_ChatIdWithFields_Users()
		{
			Url = "https://api.vk.com/method/messages.getChatUsers";

			Json =
				@"{
					'response': {
                        2: [{
						'uid': 4793858,
						'first_name': 'Антон',
						'last_name': 'Жидков',
						'university': 0,
						'university_name': '',
						'faculty': 0,
						'faculty_name': '',
						'graduation': 0,
						'invited_by': 4793858
					  },
					  {
						'uid': 5041431,
						'first_name': 'Тайфур',
						'last_name': 'Касеев',
						'university': 431,
						'university_name': 'ВолгГТУ',
						'faculty': 3162,
						'faculty_name': 'Электроники и вычислительной техники',
						'graduation': 2012,
						'invited_by': 4793858
					  },
					  {
						'uid': 10657891,
						'first_name': 'Максим',
						'last_name': 'Денисов',
						'university': 431,
						'university_name': 'ВолгГТУ',
						'faculty': 3162,
						'faculty_name': 'Электроники и вычислительной техники',
						'graduation': 2011,
						'invited_by': 4793858
					  }
					]}
				  }";

			var users = Cat.GetChatUsers(chatIds: new List<long> { 2 }, fields: UsersFields.Education, nameCase: null);

			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: users[index: 0].Id, expression: Is.EqualTo(expected: 4793858));
			Assert.That(actual: users[index: 0].FirstName, expression: Is.EqualTo(expected: "Антон"));
			Assert.That(actual: users[index: 0].LastName, expression: Is.EqualTo(expected: "Жидков"));
			Assert.That(actual: users[index: 0].Education, expression: Is.Null);
			Assert.That(actual: users[index: 0].InvitedBy, expression: Is.EqualTo(expected: 4793858));

			Assert.That(actual: users[index: 1].Id, expression: Is.EqualTo(expected: 5041431));
			Assert.That(actual: users[index: 1].FirstName, expression: Is.EqualTo(expected: "Тайфур"));
			Assert.That(actual: users[index: 1].LastName, expression: Is.EqualTo(expected: "Касеев"));
			Assert.That(actual: users[index: 1].Education.UniversityId, expression: Is.EqualTo(expected: 431));
			Assert.That(actual: users[index: 1].InvitedBy, expression: Is.EqualTo(expected: 4793858));

			Assert.That(actual: users[index: 2].Id, expression: Is.EqualTo(expected: 10657891));
			Assert.That(actual: users[index: 2].FirstName, expression: Is.EqualTo(expected: "Максим"));
			Assert.That(actual: users[index: 2].LastName, expression: Is.EqualTo(expected: "Денисов"));
			Assert.That(actual: users[index: 2].Education.UniversityId, expression: Is.EqualTo(expected: 431));
			Assert.That(actual: users[index: 2].Education.FacultyId, expression: Is.EqualTo(expected: 3162));
			Assert.That(actual: users[index: 2].Education.Graduation, expression: Is.EqualTo(expected: 2011));
			Assert.That(actual: users[index: 2].InvitedBy, expression: Is.EqualTo(expected: 4793858));
		}

		[Test]
		public void GetDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.GetDialogs(@params: new MessagesDialogsGetParams
				{
					Count = 0,
					Offset = 201
				}),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		[Ignore(reason: "")]
		public void GetDialogs_NormalCase_Messages()
		{
			Url = "https://api.vk.com/method/messages.getDialogs";

			Json =
				@"{
					'response': [
					  18,
					  {
						'id': 2105,
						'date': 1285442252,
						'out': 0,
						'user_id': 77128,
						'read_state': 1,
						'title': 'Re(15): Привет!',
						'body': 'не..не зеленая точно...'
					  }
					]
				  }";

			var msgs = Cat.GetDialogs(@params: new MessagesDialogsGetParams
			{
				Count = 77128,
				Offset = 0,
				Unread = false
			});

			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 18));
			Assert.That(actual: msgs.Messages.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: msgs.Messages[index: 0].Id, expression: Is.EqualTo(expected: 2105));

			Assert.That(actual: msgs.Messages[index: 0].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2010,
					month: 9,
					day: 25,
					hour: 19,
					minute: 17,
					second: 32,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs.Messages[index: 0].Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: msgs.Messages[index: 0].UserId, expression: Is.EqualTo(expected: 77128));
			Assert.That(actual: msgs.Messages[index: 0].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs.Messages[index: 0].Title, expression: Is.EqualTo(expected: "Re(15): Привет!"));
			Assert.That(actual: msgs.Messages[index: 0].Body, expression: Is.EqualTo(expected: "не..не зеленая точно..."));
		}

		[Test]
		public void GetHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.GetHistory(@params: new MessagesGetHistoryParams
				{
					Reversed = false,
					UserId = 1
				}),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetHistory_ContainsRepost_Error46()
		{
			Url = "https://api.vk.com/method/messages.getHistory";

			Json = @"{
			   'response':{
				  'count':1940,
				  'items':[
					 {
						'id':1234,
						'body':'',
						'user_id':4321,
						'from_id':,
						'date':1414993364,
						'read_state':1,
						'out':1,
						'attachments':[
						   {
							  'type':'wall',
							  'wall':{
								 'id':6194,
								 'from_id':-1267,
								 'to_id':-7654,
								 'date':1414992610,
								 'post_type':'post',
								 'text':'',
								 'attachments':[
									{
									   'type':'photo',
									   'photo':{
										  'id':76352,
										  'album_id':-7,
										  'owner_id':-9816,
										  'user_id':198,
										  'photo_75':'https://pp.vk.me/...b/uKU7pKtHLe0.jpg',
										  'photo_130':'https://pp.vk.me/...c/WZJpkmJWBto.jpg',
										  'photo_604':'https://pp.vk.me/...d/Kp44mAbDqSk.jpg',
										  'width':604,
										  'height':402,
										  'text':'',
										  'date':1414992613,
										  'post_id':928719,
										  'access_key':'test_access_key'
									   }
									}
								 ],
								 'post_source':{
									'type':'api'
								 },
								 'comments':{
									'count':3,
									'can_post':0
								 },
								 'likes':{
									'count':9191,
									'user_likes':1,
									'can_like':0,
									'can_publish':1
								 },
								 'reposts':{
									'count':953,
									'user_reposted':0
								 }
							  }
						   }
						]
					 }
				  ]
			   }
			}";

			var msgs = Cat.GetHistory(@params: new MessagesGetHistoryParams
			{
				UserId = 7712
			});

			// assertions
			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 1940));
			var msg = msgs.Messages.FirstOrDefault();
			Assert.That(actual: msg, expression: Is.Not.Null);
			Assert.That(actual: msg.Attachments.Count, expression: Is.EqualTo(expected: 1));

			var wall = msg.Attachments[index: 0].Instance as Wall;

			Assert.That(actual: wall, expression: Is.Not.Null);
			Assert.That(actual: wall.Id, expression: Is.EqualTo(expected: 6194));
			Assert.That(actual: wall.FromId, expression: Is.EqualTo(expected: -1267));

			Assert.That(actual: wall.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1414992610)));
			Assert.That(actual: wall.PostType, expression: Is.EqualTo(expected: PostType.Post));
			Assert.That(actual: wall.Text, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: wall.Comments.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: wall.Comments.CanPost, expression: Is.False);
			Assert.That(actual: wall.Likes.Count, expression: Is.EqualTo(expected: 9191));
			Assert.That(actual: wall.Likes.UserLikes, expression: Is.True);
			Assert.That(actual: wall.Likes.CanLike, expression: Is.False);
			Assert.That(actual: wall.Likes.CanPublish, expression: Is.EqualTo(expected: true));
			Assert.That(actual: wall.Reposts.Count, expression: Is.EqualTo(expected: 953));
			Assert.That(actual: wall.Reposts.UserReposted, expression: Is.False);
			Assert.That(actual: wall.Attachments.Count, expression: Is.EqualTo(expected: 1));

			var photo = wall.Attachments[index: 0].Instance as Photo;
			Assert.That(actual: photo, expression: Is.Not.Null);
		}

		[Test]
		public void GetHistory_ContainsSticker_Error47()
		{
			Url = "https://api.vk.com/method/messages.getHistory";

			Json = @"{
	'response': {
		'count': 6,
		'items': [
			{
				'id': 890123,
				'body': '',
				'user_id': 45678,
				'from_id': 876543,
				'date': 1415205537,
				'read_state': 1,
				'out': 0,
				'attachments': [
					{
						'type': 'sticker',
						'sticker': {
							'id': 12345,
							'product_id': 54321,
							'images': [],
							'images_with_background': []
						}
					}
				]
			}
		]
	}
}";

			var msgs = Cat.GetHistory(@params: new MessagesGetHistoryParams
			{
				UserId = 7712,
				Count = 5,
				Offset = 3
			});

			// asserts
			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: msgs.Messages.Count, expression: Is.EqualTo(expected: 1));
			var msg = msgs.Messages.FirstOrDefault();

			Assert.That(actual: msg, expression: Is.Not.Null);
			Assert.That(actual: msg.Attachments.Count, expression: Is.EqualTo(expected: 1));

			var sticker = msg.Attachments[index: 0].Instance as Sticker;
			Assert.That(actual: sticker, expression: Is.Not.Null);

			Assert.That(actual: sticker.Id, expression: Is.EqualTo(expected: 12345));
			Assert.That(actual: sticker.ProductId, expression: Is.EqualTo(expected: 54321));
		}

		[Test]
		[Ignore(reason: "")]
		public void GetHistory_NormalCaseAllFields_Messages()
		{
			Url = "https://api.vk.com/method/messages.getHistory";

			Json =
				@"{
					'response': [
					  18,
					  {
						'body': 'Таких литовкиных и сычевых',
						'id': 2093,
						'user_id': 4793858,
						'from_id': 4793858,
						'date': 1285439088,
						'read_state': 1,
						'out': 1
					  },
					  {
						'body': 'в одноклассниках и в майле есть.',
						'id': 2094,
						'user_id': 7712,
						'from_id': 7712,
						'date': 1285439216,
						'read_state': 1,
						'out': 0
					  },
					  {
						'body': 'думаю пива предложит попить',
						'id': 2095,
						'user_id': 4793858,
						'from_id': 4793858,
						'date': 1285439644,
						'read_state': 1,
						'out': 1
					  }
					]
				  }";

			var msgs = Cat.GetHistory(@params: new MessagesGetHistoryParams());

			Assert.That(actual: msgs.Messages[index: 2].Body, expression: Is.EqualTo(expected: "думаю пива предложит попить"));
			Assert.That(actual: msgs.Messages[index: 2].Id, expression: Is.EqualTo(expected: 2095));
			Assert.That(actual: msgs.Messages[index: 2].UserId, expression: Is.EqualTo(expected: 4793858));

			Assert.That(actual: msgs.Messages[index: 2].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2010,
					month: 9,
					day: 25,
					hour: 18,
					minute: 34,
					second: 4,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs.Messages[index: 2].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs.Messages[index: 2].Type, expression: Is.EqualTo(expected: MessageType.Sended));

			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 18));
			Assert.That(actual: msgs.Messages.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: msgs.Messages[index: 0].Id, expression: Is.EqualTo(expected: 2093));
			Assert.That(actual: msgs.Messages[index: 0].Body, expression: Is.EqualTo(expected: "Таких литовкиных и сычевых"));
			Assert.That(actual: msgs.Messages[index: 0].UserId, expression: Is.EqualTo(expected: 4793858));

			Assert.That(actual: msgs.Messages[index: 0].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2010,
					month: 9,
					day: 25,
					hour: 18,
					minute: 24,
					second: 48,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs.Messages[index: 0].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs.Messages[index: 0].Type, expression: Is.EqualTo(expected: MessageType.Sended));

			Assert.That(actual: msgs.Messages[index: 1].Body, expression: Is.EqualTo(expected: "в одноклассниках и в майле есть."));
			Assert.That(actual: msgs.Messages[index: 1].Id, expression: Is.EqualTo(expected: 2094));
			Assert.That(actual: msgs.Messages[index: 1].UserId, expression: Is.EqualTo(expected: 7712));

			Assert.That(actual: msgs.Messages[index: 1].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2010,
					month: 9,
					day: 25,
					hour: 18,
					minute: 26,
					second: 56,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs.Messages[index: 1].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs.Messages[index: 1].Type, expression: Is.EqualTo(expected: MessageType.Received));
		}

		[Test]
		public void GetLastActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.GetLastActivity(userId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetLastActivity_NormalCast_LastActivityObject()
		{
			Url = "https://api.vk.com/method/messages.getLastActivity";

			Json =
				@"{
					'response': {
					  'online': 0,
					  'time': 1344484645
					}
				  }";

			var activity = Cat.GetLastActivity(userId: 77128);

			Assert.That(actual: activity.UserId, expression: Is.EqualTo(expected: 77128));
			Assert.That(actual: activity.IsOnline, expression: Is.False);

			Assert.That(actual: activity.Time,
				expression: Is.EqualTo(expected: new DateTime(year: 2012,
					month: 8,
					day: 9,
					hour: 3,
					minute: 57,
					second: 25,
					kind: DateTimeKind.Utc)));
		}

		[Test]
		public void GetLongPollServer_NormalCase_LongPollServerResponse()
		{
			Url = "https://api.vk.com/method/messages.getLongPollServer";

			Json =
				@"{
					'response': {
					  'key': '6f4120988efaf3a7d398054b5bb5d019c5844bz3',
					  'server': 'im46.vk.com/im1858',
					  'ts': 1627957305
					}
				  }";

			var response = Api.Messages.GetLongPollServer();

			Assert.That(actual: response.Key, expression: Is.EqualTo(expected: "6f4120988efaf3a7d398054b5bb5d019c5844bz3"));
			Assert.That(actual: response.Server, expression: Is.EqualTo(expected: "im46.vk.com/im1858"));
			Assert.That(actual: response.Ts, expression: Is.EqualTo(expected: 1627957305));
		}

		[Test]
		public void GetLongPollServer_ThrowArgumentNullException()
		{
			Assert.That(del: () => Api.Messages.GetLongPollServer(), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void MarkAsRead_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.MarkAsRead(messageIds: new List<long> { 1 }, peerId: null),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void MarkAsRead_Multiple_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsRead";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsRead(messageIds: new long[]
				{
					2,
					3
				},
				peerId: null);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void MarkAsRead_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsRead";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsRead(messageIds: new List<long> { 1 }, peerId: null);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void RemoveChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.RemoveChatUser(chatId: 2, userId: 2), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void RemoveChatUser_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.removeChatUser";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.RemoveChatUser(chatId: 2, userId: 7550525);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.Restore(messageId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Restore_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.restore";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.Restore(messageId: 134);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());

			Assert.That(del: () => cat.Search(@params: new MessagesSearchParams
				{
					Query = "привет"
				}),
				expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		[Ignore(reason: "")]
		public void Search_NormalCase_Messages()
		{
			Url = "https://api.vk.com/method/messages.search";

			Json = @"{
				response: {
					count: 18,
					items: [{
					id: 131307,
					date: 1444123586,
					out: 0,
					user_id: 72815776,
					read_state: 1,
					title: ' ... ',
					body: 'Привет'
					}, {
					id: 131304,
					date: 1444123077,
					out: 1,
					user_id: 72815776,
					read_state: 1,
					title: ' ... ',
					body: 'Привет'
					}, {
					id: 131291,
					date: 1444106004,
					out: 0,
					user_id: 310881357,
					read_state: 1,
					title: ' ... ',
					body: 'Привет&#128139;',
					emoji: 1
					}]
			}";

			var msgs = Cat.Search(@params: new MessagesSearchParams
			{
				Query = "привет",
				Count = 3
			});

			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 680));
			Assert.That(actual: msgs.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: msgs[index: 2].Id, expression: Is.EqualTo(expected: 4414));

			Assert.That(actual: msgs[index: 2].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2012,
					month: 7,
					day: 13,
					hour: 8,
					minute: 46,
					second: 32,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs[index: 2].Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: msgs[index: 2].UserId, expression: Is.EqualTo(expected: 245242));
			Assert.That(actual: msgs[index: 2].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs[index: 2].Title, expression: Is.EqualTo(expected: " ... "));
			Assert.That(actual: msgs[index: 2].Body, expression: Is.EqualTo(expected: "привет, антон))"));

			Assert.That(actual: msgs[index: 1].Id, expression: Is.EqualTo(expected: 4415));

			Assert.That(actual: msgs[index: 1].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2012,
					month: 7,
					day: 13,
					hour: 8,
					minute: 46,
					second: 48,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs[index: 1].Type, expression: Is.EqualTo(expected: MessageType.Sended));
			Assert.That(actual: msgs[index: 1].UserId, expression: Is.EqualTo(expected: 245242));
			Assert.That(actual: msgs[index: 1].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs[index: 1].Title, expression: Is.EqualTo(expected: " ... "));
			Assert.That(actual: msgs[index: 1].Body, expression: Is.EqualTo(expected: "привет))"));

			Assert.That(actual: msgs[index: 0].Id, expression: Is.EqualTo(expected: 4442));

			Assert.That(actual: msgs[index: 0].Date,
				expression: Is.EqualTo(expected: new DateTime(year: 2012,
					month: 7,
					day: 31,
					hour: 20,
					minute: 2,
					second: 52,
					kind: DateTimeKind.Utc)));

			Assert.That(actual: msgs[index: 0].Type, expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: msgs[index: 0].UserId, expression: Is.EqualTo(expected: 1016149));
			Assert.That(actual: msgs[index: 0].ReadState, expression: Is.EqualTo(expected: MessageReadState.Readed));
			Assert.That(actual: msgs[index: 0].Title, expression: Is.EqualTo(expected: "..."));
			Assert.That(actual: msgs[index: 0].Body, expression: Is.EqualTo(expected: "Привет, Антон! Как дела?"));
		}

		[Test]
		[Ignore(reason: "")]
		public void Search_NotExistedQuery_EmptyList()
		{
			Url = "https://api.vk.com/method/messages.search";

			Json =
				@"{
					'response': [
					  0
					]
				  }";

			var msgs = Cat.Search(@params: new MessagesSearchParams
			{
				Query = "fsjkadoivhjioashdpfisd",
				Count = 3
			});

			Assert.That(actual: msgs.TotalCount, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: msgs.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void SearchDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.SearchDialogs(query: "hello"), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SearchDialogs_EmptyResponse_MessageResponseWithEmptyLists()
		{
			Url = "https://api.vk.com/method/messages.searchDialogs";

			Json = @"{
                    'response': []
                  }";

			var response = Cat.SearchDialogs(query: "привет");

			Assert.That(actual: response, expression: Is.Null);
		}

		[Test]
		public void SearchDialogs_NastyaQuery_TwoProfiles()
		{
			Url = "https://api.vk.com/method/messages.searchDialogs";

			Json =
				@"{
					'response': [
					  {
						'type': 'profile',
						'uid': 7503978,
						'first_name': 'Настя',
						'last_name': 'Иванова'
					  },
					  {
						'type': 'profile',
						'uid': 68274561,
						'first_name': 'Настя',
						'last_name': 'Петрова'
					  }
					]
				  }";

			var response = Cat.SearchDialogs(query: "Настя");

			Assert.That(actual: response.Users.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: response.Chats.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: response.Users.ElementAt(index: 0).Id, expression: Is.EqualTo(expected: 7503978));
			Assert.That(actual: response.Users.ElementAt(index: 0).FirstName, expression: Is.EqualTo(expected: "Настя"));
			Assert.That(actual: response.Users.ElementAt(index: 0).LastName, expression: Is.EqualTo(expected: "Иванова"));
			Assert.That(actual: response.Users.ElementAt(index: 1).Id, expression: Is.EqualTo(expected: 68274561));
			Assert.That(actual: response.Users.ElementAt(index: 1).FirstName, expression: Is.EqualTo(expected: "Настя"));
			Assert.That(actual: response.Users.ElementAt(index: 1).LastName, expression: Is.EqualTo(expected: "Петрова"));
		}

		[Test]
		public void SearchDialogs_ProfileAndChat_Response()
		{
			Url = "https://api.vk.com/method/messages.searchDialogs";

			Json =
				@"{
					'response': [
					  {
						'type': 'profile',
						'uid': 1708231,
						'first_name': 'Григорий',
						'last_name': 'Клюшников'
					  },
					  {
						'type': 'chat',
						'id': 109,
						'title': 'Андрей, Григорий',
						'users': [
						  66748,
						  6492,
						  1708231
						]
					  }
					]
				  }";

			var response = Cat.SearchDialogs(query: "Маша");

			Assert.That(actual: response.Users.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: response.Chats.Count, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: response.Users[index: 0].Id, expression: Is.EqualTo(expected: 1708231));
			Assert.That(actual: response.Users[index: 0].FirstName, expression: Is.EqualTo(expected: "Григорий"));
			Assert.That(actual: response.Users[index: 0].LastName, expression: Is.EqualTo(expected: "Клюшников"));

			Assert.That(actual: response.Chats[index: 0].Id, expression: Is.EqualTo(expected: 109));
			Assert.That(actual: response.Chats[index: 0].Title, expression: Is.EqualTo(expected: "Андрей, Григорий"));
			Assert.That(actual: response.Chats[index: 0].Users.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: response.Chats[index: 0].Users.ElementAt(index: 0), expression: Is.EqualTo(expected: 66748));
			Assert.That(actual: response.Chats[index: 0].Users.ElementAt(index: 1), expression: Is.EqualTo(expected: 6492));
			Assert.That(actual: response.Chats[index: 0].Users.ElementAt(index: 2), expression: Is.EqualTo(expected: 1708231));
		}

		[Test]
		public void SetActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(vk: new VkApi());
			Assert.That(del: () => cat.SetActivity(userId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetActivity_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.setActivity";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.SetActivity(userId: 7550525);

			Assert.That(actual: result, expression: Is.True);
		}
	}
}