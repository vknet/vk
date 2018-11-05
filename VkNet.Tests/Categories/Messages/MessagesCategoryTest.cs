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
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class MessagesCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Messages";

		public MessagesCategory Cat => GetMockedMessagesCategory();

		private MessagesCategory GetMockedMessagesCategory()
		{
			return new MessagesCategory(Api);
		}

		[Test]
		public void AddChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.AddChatUser(2, 2), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void AddChatUser_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.addChatUser";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.AddChatUser(2, 7550525);

			Assert.That(result, Is.True);
		}

		[Test]
		public void CreateChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.CreateChat(new ulong[]
					{
						1,
						2
					},
					"hi, friends"),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void CreateChat_NormalCase_ChatId()
		{
			Url = "https://api.vk.com/method/messages.createChat";

			Json =
				@"{
					'response': 3
				  }";

			var chatId = Cat.CreateChat(new ulong[]
				{
					5041431,
					10657891
				},
				"test chat's title");

			Assert.That(chatId, Is.EqualTo(3));
		}

		[Test]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.Delete(new ulong[] { 1 }, false, null, false),
				Throws.InstanceOf<AccessTokenInvalidException>());
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

			var result = Cat.Delete(new ulong[] { 4446 }, false, null, false);

			Assert.That(result[4446], Is.True);
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

			Assert.That(() => Cat.Delete(new ulong[] { 999999 }, false, null, false),
				Throws.InstanceOf<VkApiException>());
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

			var dict = Cat.Delete(new ulong[]
				{
					4457,
					4464
				},
				false,
				null,
				false);

			Assert.That(dict.Count, Is.EqualTo(2));
			Assert.That(dict[4457], Is.True);
			Assert.That(dict[4464], Is.True);
		}

		[Test]
		public void DeleteDialog_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.DeleteDialog(111), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void EditChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.EditChat(2, "new title"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void EditChat_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.editChat";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.EditChat(2, "new title");
			Assert.True(result);
		}

		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.Get(new MessagesGetParams()), Throws.InstanceOf<AccessTokenInvalidException>());
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

			var messages = Cat.Get(new MessagesGetParams());

			Assert.That(messages.TotalCount, Is.EqualTo(5));
			Assert.That(messages, Is.Not.Null);
			Assert.That(messages.Messages.Count, Is.EqualTo(2));

			var message = messages.Messages.FirstOrDefault();
			Assert.That(message, Is.Not.Null);
			Assert.That(message.Body, Is.EqualTo("fun"));
			Assert.That(message.Id, Is.EqualTo(34));
			Assert.That(message.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1398242416)));
			Assert.That(message.ReadState, Is.EqualTo(MessageReadState.Unreaded));
			Assert.That(message.Type, Is.EqualTo(MessageType.Received));
			Assert.That(message.UserId, Is.EqualTo(562508789));
			Assert.That(message.Title, Is.EqualTo(" ... "));

			var message1 = messages.Messages.Skip(1).FirstOrDefault();
			Assert.That(message1, Is.Not.Null);
			Assert.That(message1.Body, Is.EqualTo("very"));
			Assert.That(message1.Id, Is.EqualTo(33));
			Assert.That(message1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1398242415)));
			Assert.That(message1.ReadState, Is.EqualTo(MessageReadState.Unreaded));
			Assert.That(message1.Type, Is.EqualTo(MessageType.Received));
			Assert.That(message1.UserId, Is.EqualTo(562508789));
			Assert.That(message1.Title, Is.EqualTo(" ... "));
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

			var messages = Cat.Get(new MessagesGetParams
			{
				LastMessageId = 30
			});

			Assert.That(messages.TotalCount, Is.EqualTo(5));
			Assert.That(messages, Is.Not.Null);
			Assert.That(messages.Messages.Count, Is.EqualTo(1));

			var message = messages.Messages.FirstOrDefault();
			Assert.That(message, Is.Not.Null);
			Assert.That(message.Id, Is.EqualTo(31));
			Assert.That(message.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1398242412)));
			Assert.That(message.Type, Is.EqualTo(MessageType.Received));
			Assert.That(message.UserId, Is.EqualTo(123508789));
			Assert.That(message.ReadState, Is.EqualTo(MessageReadState.Unreaded));
			Assert.That(message.Title, Is.EqualTo(" ... "));
			Assert.That(message.Body, Is.EqualTo("may"));
		}

		[Test]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.GetById(new ulong[] { 1 }, null), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.GetById(new ulong[]
					{
						1,
						3,
						5
					},
					null),
				Throws.InstanceOf<AccessTokenInvalidException>());
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

			var msgs = Cat.GetById(new ulong[]
				{
					1,
					3,
					5
				},
				null);

			Assert.That(msgs.TotalCount, Is.EqualTo(3));
			Assert.That(msgs.Count, Is.EqualTo(3));

			Assert.That(msgs[2].Id, Is.EqualTo(5));
			Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[2].UserId, Is.EqualTo(684559));
			Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[2].Title, Is.EqualTo("Re(2): Как там зачетная неделя продвигаетсо?)"));

			Assert.That(msgs[2].Body,
				Is.EqualTo("Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)"));

			Assert.That(msgs[1].Id, Is.EqualTo(3));
			Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Sended));
			Assert.That(msgs[1].UserId, Is.EqualTo(684559));
			Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[1].Title, Is.EqualTo("Re: Как там зачетная неделя продвигаетсо?)"));
			Assert.That(msgs[1].Body, Is.EqualTo("Парят и парят во все дыры)... у тебя как?"));
			Assert.That(msgs[0].Id, Is.EqualTo(1));
			Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[0].UserId, Is.EqualTo(684559));
			Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[0].Title, Is.EqualTo(" ... "));
			Assert.That(msgs[0].Body, Is.EqualTo("Привеееет!!!!!!!!!!!"));
		}

		[Test]
		[Ignore("")]
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

			var msg = Cat.GetById(new ulong[] { 1 }, null).FirstOrDefault();

			Assert.That(msg.Id, Is.EqualTo(1));

			Assert.That(msg.Date,
				Is.EqualTo(new DateTime(2007,
					12,
					18,
					2,
					5,
					20,
					DateTimeKind.Utc)));

			Assert.That(msg.Type, Is.EqualTo(MessageType.Received));
			Assert.That(msg.UserId, Is.EqualTo(684559));
			Assert.That(msg.ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msg.Title, Is.EqualTo(" ... "));
			Assert.That(msg.Body, Is.EqualTo("Привеееет!!!!!!!!!!!"));
		}

		[Test]
		public void GetChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.GetChat(1), Throws.InstanceOf<AccessTokenInvalidException>());
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

			var chat = Cat.GetChat(2);

			Assert.That(chat.Id, Is.EqualTo(2));
			Assert.That(chat.Title, Is.EqualTo("test chat title"));
			Assert.That(chat.AdminId, Is.EqualTo(4793858));
			Assert.That(chat.Users.Count, Is.EqualTo(3));
			Assert.That(chat.Users.ElementAt(0), Is.EqualTo(4793858));
			Assert.That(chat.Users.ElementAt(1), Is.EqualTo(5041431));
			Assert.That(chat.Users.ElementAt(2), Is.EqualTo(10657891));
		}

		[Test]
		public void GetChatUsers_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.GetChatUsers(new List<long> { 2 }, null, null),
				Throws.InstanceOf<AccessTokenInvalidException>());
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

			var users = Cat.GetChatUsers(new List<long> { 2 }, null, null).ToList();

			Assert.That(users.Count, Is.EqualTo(3));
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

			var users = Cat.GetChatUsers(new List<long> { 2 }, UsersFields.Education, null);

			Assert.That(users.Count, Is.EqualTo(3));
			Assert.That(users[0].Id, Is.EqualTo(4793858));
			Assert.That(users[0].FirstName, Is.EqualTo("Антон"));
			Assert.That(users[0].LastName, Is.EqualTo("Жидков"));
			Assert.That(users[0].Education, Is.Null);
			Assert.That(users[0].InvitedBy, Is.EqualTo(4793858));

			Assert.That(users[1].Id, Is.EqualTo(5041431));
			Assert.That(users[1].FirstName, Is.EqualTo("Тайфур"));
			Assert.That(users[1].LastName, Is.EqualTo("Касеев"));
			Assert.That(users[1].Education.UniversityId, Is.EqualTo(431));
			Assert.That(users[1].InvitedBy, Is.EqualTo(4793858));

			Assert.That(users[2].Id, Is.EqualTo(10657891));
			Assert.That(users[2].FirstName, Is.EqualTo("Максим"));
			Assert.That(users[2].LastName, Is.EqualTo("Денисов"));
			Assert.That(users[2].Education.UniversityId, Is.EqualTo(431));
			Assert.That(users[2].Education.FacultyId, Is.EqualTo(3162));
			Assert.That(users[2].Education.Graduation, Is.EqualTo(2011));
			Assert.That(users[2].InvitedBy, Is.EqualTo(4793858));
		}

		[Test]
		public void GetDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.GetDialogs(new MessagesDialogsGetParams
				{
					Count = 0,
					Offset = 201
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		[Ignore("")]
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

			var msgs = Cat.GetDialogs(new MessagesDialogsGetParams
			{
				Count = 77128,
				Offset = 0,
				Unread = false
			});

			Assert.That(msgs.TotalCount, Is.EqualTo(18));
			Assert.That(msgs.Messages.Count, Is.EqualTo(1));
			Assert.That(msgs.Messages[0].Id, Is.EqualTo(2105));

			Assert.That(msgs.Messages[0].Date,
				Is.EqualTo(new DateTime(2010,
					9,
					25,
					19,
					17,
					32,
					DateTimeKind.Utc)));

			Assert.That(msgs.Messages[0].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs.Messages[0].UserId, Is.EqualTo(77128));
			Assert.That(msgs.Messages[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs.Messages[0].Title, Is.EqualTo("Re(15): Привет!"));
			Assert.That(msgs.Messages[0].Body, Is.EqualTo("не..не зеленая точно..."));
		}

		[Test]
		public void GetHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.GetHistory(new MessagesGetHistoryParams
				{
					Reversed = false,
					UserId = 1
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
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
						'from_id': 1234567890,
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

			var msgs = Cat.GetHistory(new MessagesGetHistoryParams
			{
				UserId = 7712
			});

			// assertions
			Assert.That(msgs.TotalCount, Is.EqualTo(1940));
			var msg = msgs.Messages.FirstOrDefault();
			Assert.That(msg, Is.Not.Null);
			Assert.That(msg.Attachments.Count, Is.EqualTo(1));

			var wall = msg.Attachments[0].Instance as Model.Wall;

			Assert.That(wall, Is.Not.Null);
			Assert.That(wall.Id, Is.EqualTo(6194));
			Assert.That(wall.FromId, Is.EqualTo(-1267));

			Assert.That(wall.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1414992610)));
			Assert.That(wall.PostType, Is.EqualTo(PostType.Post));
			Assert.That(wall.Text, Is.EqualTo(string.Empty));
			Assert.That(wall.Comments.Count, Is.EqualTo(3));
			Assert.That(wall.Comments.CanPost, Is.False);
			Assert.That(wall.Likes.Count, Is.EqualTo(9191));
			Assert.That(wall.Likes.UserLikes, Is.True);
			Assert.That(wall.Likes.CanLike, Is.False);
			Assert.That(wall.Likes.CanPublish, Is.EqualTo(true));
			Assert.That(wall.Reposts.Count, Is.EqualTo(953));
			Assert.That(wall.Reposts.UserReposted, Is.False);
			Assert.That(wall.Attachments.Count, Is.EqualTo(1));

			var photo = wall.Attachments[0].Instance as Photo;
			Assert.That(photo, Is.Not.Null);
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

			var msgs = Cat.GetHistory(new MessagesGetHistoryParams
			{
				UserId = 7712,
				Count = 5,
				Offset = 3
			});

			// asserts
			Assert.That(msgs.TotalCount, Is.EqualTo(6));
			Assert.That(msgs.Messages.Count, Is.EqualTo(1));
			var msg = msgs.Messages.FirstOrDefault();

			Assert.That(msg, Is.Not.Null);
			Assert.That(msg.Attachments.Count, Is.EqualTo(1));

			var sticker = msg.Attachments[0].Instance as Sticker;
			Assert.That(sticker, Is.Not.Null);

			Assert.That(sticker.Id, Is.EqualTo(12345));
			Assert.That(sticker.ProductId, Is.EqualTo(54321));
		}

		[Test]
		[Ignore("")]
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

			var msgs = Cat.GetHistory(new MessagesGetHistoryParams());
			var messages = msgs.Messages.ToList();

			Assert.That(messages[2].Body, Is.EqualTo("думаю пива предложит попить"));
			Assert.That(messages[2].Id, Is.EqualTo(2095));
			Assert.That(messages[2].UserId, Is.EqualTo(4793858));

			Assert.That(messages[2].Date,
				Is.EqualTo(new DateTime(2010,
					9,
					25,
					18,
					34,
					4,
					DateTimeKind.Utc)));

			Assert.That(messages[2].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(messages[2].Type, Is.EqualTo(MessageType.Sended));

			Assert.That(msgs.TotalCount, Is.EqualTo(18));
			Assert.That(messages.Count, Is.EqualTo(3));

			Assert.That(messages[0].Id, Is.EqualTo(2093));
			Assert.That(messages[0].Body, Is.EqualTo("Таких литовкиных и сычевых"));
			Assert.That(messages[0].UserId, Is.EqualTo(4793858));

			Assert.That(messages[0].Date,
				Is.EqualTo(new DateTime(2010,
					9,
					25,
					18,
					24,
					48,
					DateTimeKind.Utc)));

			Assert.That(messages[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(messages[0].Type, Is.EqualTo(MessageType.Sended));

			Assert.That(messages[1].Body, Is.EqualTo("в одноклассниках и в майле есть."));
			Assert.That(messages[1].Id, Is.EqualTo(2094));
			Assert.That(messages[1].UserId, Is.EqualTo(7712));

			Assert.That(messages[1].Date,
				Is.EqualTo(new DateTime(2010,
					9,
					25,
					18,
					26,
					56,
					DateTimeKind.Utc)));

			Assert.That(messages[1].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(messages[1].Type, Is.EqualTo(MessageType.Received));
		}

		[Test]
		public void GetLastActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.GetLastActivity(1), Throws.InstanceOf<AccessTokenInvalidException>());
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

			var activity = Cat.GetLastActivity(77128);

			Assert.That(activity.UserId, Is.EqualTo(77128));
			Assert.That(activity.IsOnline, Is.False);

			Assert.That(activity.Time,
				Is.EqualTo(new DateTime(2012,
					8,
					9,
					3,
					57,
					25,
					DateTimeKind.Utc)));
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

			Assert.That(response.Key, Is.EqualTo("6f4120988efaf3a7d398054b5bb5d019c5844bz3"));
			Assert.That(response.Server, Is.EqualTo("im46.vk.com/im1858"));
			Assert.That(response.Ts, Is.EqualTo("1627957305"));
		}

		[Test]
		public void GetLongPollServer_ThrowArgumentNullException()
		{
			Assert.That(() => Api.Messages.GetLongPollServer(), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void MarkAsRead_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.MarkAsRead(null),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void MarkAsRead_Multiple_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsRead";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsRead(null);

			Assert.That(result, Is.True);
		}

		[Test]
		public void MarkAsRead_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsRead";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsRead(null);

			Assert.That(result, Is.True);
		}

		[Test]
		public void RemoveChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.RemoveChatUser(2, 2), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void RemoveChatUser_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.removeChatUser";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.RemoveChatUser(2, 7550525);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.Restore(1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Restore_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.restore";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.Restore(134);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.Search(new MessagesSearchParams
				{
					Query = "привет"
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		[Ignore("")]
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

			var result = Cat.Search(new MessagesSearchParams
			{
				Query = "привет",
				Count = 3
			});

			var msgs = result.Items;

			Assert.That(result.Count, Is.EqualTo(680));
			Assert.NotNull(msgs);
			Assert.That(msgs.Count, Is.EqualTo(3));

			Assert.That(msgs[2].Id, Is.EqualTo(4414));

			Assert.That(msgs[2].Date,
				Is.EqualTo(new DateTime(2012,
					7,
					13,
					8,
					46,
					32,
					DateTimeKind.Utc)));

			Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[2].UserId, Is.EqualTo(245242));
			Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[2].Title, Is.EqualTo(" ... "));
			Assert.That(msgs[2].Body, Is.EqualTo("привет, антон))"));

			Assert.That(msgs[1].Id, Is.EqualTo(4415));

			Assert.That(msgs[1].Date,
				Is.EqualTo(new DateTime(2012,
					7,
					13,
					8,
					46,
					48,
					DateTimeKind.Utc)));

			Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Sended));
			Assert.That(msgs[1].UserId, Is.EqualTo(245242));
			Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[1].Title, Is.EqualTo(" ... "));
			Assert.That(msgs[1].Body, Is.EqualTo("привет))"));

			Assert.That(msgs[0].Id, Is.EqualTo(4442));

			Assert.That(msgs[0].Date,
				Is.EqualTo(new DateTime(2012,
					7,
					31,
					20,
					2,
					52,
					DateTimeKind.Utc)));

			Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[0].UserId, Is.EqualTo(1016149));
			Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[0].Title, Is.EqualTo("..."));
			Assert.That(msgs[0].Body, Is.EqualTo("Привет, Антон! Как дела?"));
		}

		[Test]
		[Ignore("")]
		public void Search_NotExistedQuery_EmptyList()
		{
			Url = "https://api.vk.com/method/messages.search";

			ReadCategoryJsonPath(JsonPaths.EmptyVkCollection);

			var msgs = Cat.Search(new MessagesSearchParams
			{
				Query = "fsjkadoivhjioashdpfisd",
				Count = 3
			});

			Assert.That(msgs.Count, Is.EqualTo(0));
		}

		[Test]
		public void SearchDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.SearchDialogs("hello"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SearchDialogs_EmptyResponse_MessageResponseWithEmptyLists()
		{
			Url = "https://api.vk.com/method/messages.searchDialogs";
			ReadJsonFile(JsonPaths.EmptyArray);

			var response = Cat.SearchDialogs("привет");

			Assert.That(response, Is.Null);
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

			var response = Cat.SearchDialogs("Настя");

			Assert.That(response.Users.Count, Is.EqualTo(2));
			Assert.That(response.Chats.Count, Is.EqualTo(0));
			Assert.That(response.Users.ElementAt(0).Id, Is.EqualTo(7503978));
			Assert.That(response.Users.ElementAt(0).FirstName, Is.EqualTo("Настя"));
			Assert.That(response.Users.ElementAt(0).LastName, Is.EqualTo("Иванова"));
			Assert.That(response.Users.ElementAt(1).Id, Is.EqualTo(68274561));
			Assert.That(response.Users.ElementAt(1).FirstName, Is.EqualTo("Настя"));
			Assert.That(response.Users.ElementAt(1).LastName, Is.EqualTo("Петрова"));
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

			var response = Cat.SearchDialogs("Маша");

			Assert.That(response.Users.Count, Is.EqualTo(1));
			Assert.That(response.Chats.Count, Is.EqualTo(1));

			Assert.That(response.Users[0].Id, Is.EqualTo(1708231));
			Assert.That(response.Users[0].FirstName, Is.EqualTo("Григорий"));
			Assert.That(response.Users[0].LastName, Is.EqualTo("Клюшников"));

			Assert.That(response.Chats[0].Id, Is.EqualTo(109));
			Assert.That(response.Chats[0].Title, Is.EqualTo("Андрей, Григорий"));
			Assert.That(response.Chats[0].Users.Count, Is.EqualTo(3));
			Assert.That(response.Chats[0].Users.ElementAt(0), Is.EqualTo(66748));
			Assert.That(response.Chats[0].Users.ElementAt(1), Is.EqualTo(6492));
			Assert.That(response.Chats[0].Users.ElementAt(2), Is.EqualTo(1708231));
		}

		[Test]
		public void SetActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			Assert.That(() => cat.SetActivity(1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetActivity_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.setActivity";

			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.SetActivity(7550525);

			Assert.That(result, Is.True);
		}
	}
}