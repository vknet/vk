using System.Diagnostics.CodeAnalysis;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Categories
{
	using System;
	using System.Linq;
	using Moq;
	using NUnit.Framework;
	using VkNet.Categories;
	using VkNet.Utils;
	using FluentNUnit;

	using Enums;
	using Enums.Filters;
	using Exception;
	using Model.RequestParams;

	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class MessagesCategoryTest
	{
		public string Json;
		public string Url;

		public MessagesCategory Cat
		{
			get { return GetMockedMessagesCategory(); }
		}

		[SetUp]
		public void SetUp()
		{
			Url = "";
			Json = "";
		}

		private MessagesCategory GetMockedMessagesCategory()
		{
			var browser = Mock.Of<IBrowser>(m => m.GetJson(Url) == Json);
			return new MessagesCategory(new VkApi { AccessToken = "token", Browser = browser});
		}

		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			int totalCount;
			This.Action(() => cat.Get(MessageType.Received, out totalCount)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			int totalCount;
			int unreadCount;
			This.Action(() => cat.GetDialogs(out totalCount, out unreadCount, 0, 201)).Throws<AccessTokenInvalidException>();
		}

		[Test, Ignore]
		public void GetDialogs_NormalCase_Messages()
		{
			Url = "https://api.vk.com/method/messages.getDialogs?count=77128&offset=0&unread=0&preview_length=3&v=5.28&access_token=token";
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

			int totalCount;
			int unreadCount;
			var msgs = Cat.GetDialogs(out totalCount, out unreadCount, 77128, 0, false, null, null).ToList();

			Assert.That(totalCount, Is.EqualTo(18));
			Assert.That(msgs.Count, Is.EqualTo(1));
			Assert.That(msgs[0].Id, Is.EqualTo(2105));
			Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2010, 9, 25, 19, 17, 32, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[0].UserId, Is.EqualTo(77128));
			Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[0].Title, Is.EqualTo("Re(15): Привет!"));
			Assert.That(msgs[0].Body, Is.EqualTo("не..не зеленая точно..."));
		}

		[Test]
		public void GetHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			int totalCount;
			This.Action(() => cat.GetHistory(out totalCount, false, 1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetHistory_ContainsSticker_Error47()
		{
			Url = "https://api.vk.com/method/messages.getHistory?uid=7712&offset=5&rev=0&count=3&v=5.37&access_token=token";
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
							'photo_64': 'https: //vk.com/im...ckers/134/64b.png',
							'photo_128': 'https: //vk.com/im...kers/134/128b.png',
							'photo_256': 'https: //vk.com/im...kers/134/256b.png',
							'width': 256,
							'height': 256
						}
					}
				]
			}
		]
	}
}";
			int totalCount;
			var msg = Cat.GetHistory(out totalCount, false, 7712,  5, 3).ToList();

			// asserts
			totalCount.ShouldEqual(6);
			msg.Count.ShouldEqual(1);
			msg[0].Attachments.Count.ShouldEqual(1);

			var sticker = msg[0].Attachments[0].Instance as Sticker;
			sticker.ShouldNotBeNull();

			sticker.Id.ShouldEqual(12345);
			sticker.ProductId.ShouldEqual(54321);
			sticker.Photo64.ShouldEqual("https: //vk.com/im...ckers/134/64b.png");
			sticker.Photo128.ShouldEqual("https: //vk.com/im...kers/134/128b.png");
			sticker.Photo256.ShouldEqual("https: //vk.com/im...kers/134/256b.png");
			sticker.Width.ShouldEqual(256);
			sticker.Height.ShouldEqual(256);

		}

		[Test]
		public void GetHistory_ContainsRepost_Error46()
		{
			Url = "https://api.vk.com/method/messages.getHistory?uid=7712&offset=5&rev=1&count=3&v=5.37&access_token=token";
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

			int totalCount;
			var msg = Cat.GetHistory(out totalCount, false, 7712,  5, 3, null, true).ToList();

			// assertions
			totalCount.ShouldEqual(1940);
			msg[0].Attachments.Count.ShouldEqual(1);

			var wall = msg[0].Attachments[0].Instance as Wall;
			wall.ShouldNotBeNull();

			wall.Id.ShouldEqual(6194);
			wall.FromId.ShouldEqual(-1267);
			wall.ToId.ShouldEqual(-7654);
			wall.Date.ShouldEqual(new DateTime(2014, 11, 3, 5, 30, 10, DateTimeKind.Utc).ToLocalTime());
			wall.PostType.ShouldEqual("post");
			wall.Text.ShouldEqual(string.Empty);

			wall.Comments.Count.ShouldEqual(3);
			wall.Comments.CanPost.ShouldBeFalse();

			wall.Likes.Count.ShouldEqual(9191);
			wall.Likes.UserLikes.ShouldBeTrue();
			wall.Likes.CanLike.ShouldBeFalse();
			wall.Likes.CanPublish.ShouldEqual(true);

			wall.Reposts.Count.ShouldEqual(953);
			wall.Reposts.UserReposted.ShouldBeFalse();

			wall.Attachments.Count.ShouldEqual(1);
			var photo = wall.Attachments[0].Instance as Photo;
			photo.ShouldNotBeNull();
		}

		[Test, Ignore]
		public void GetHistory_NormalCaseAllFields_Messages()
		{
			Url = "https://api.vk.com/method/messages.getHistory?uid=7712&offset=5&count=3&rev=1&access_token=token";
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
			
			int totalCount;
			var msgs = Cat.GetHistory( out totalCount, false, 7712, 5, 3,null, true).ToList();

			Assert.That(msgs[2].Body, Is.EqualTo("думаю пива предложит попить"));
			Assert.That(msgs[2].Id, Is.EqualTo(2095));
			Assert.That(msgs[2].UserId, Is.EqualTo(4793858));
			Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2010, 9, 25, 18, 34, 4, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Sended));
			
			Assert.That(totalCount, Is.EqualTo(18));
			Assert.That(msgs.Count, Is.EqualTo(3));

			Assert.That(msgs[0].Id, Is.EqualTo(2093));
			Assert.That(msgs[0].Body, Is.EqualTo("Таких литовкиных и сычевых"));
			Assert.That(msgs[0].UserId, Is.EqualTo(4793858));
			Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2010, 9, 25, 18, 24, 48, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Sended));
			
			Assert.That(msgs[1].Body, Is.EqualTo("в одноклассниках и в майле есть."));
			Assert.That(msgs[1].Id, Is.EqualTo(2094));
			Assert.That(msgs[1].UserId, Is.EqualTo(7712));
			Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2010, 9, 25, 18, 26, 56, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Received));
		}
		
		[Test]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.GetById(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			int totalCount;
			This.Action(() => cat.GetById(out totalCount, new ulong[] { 1, 3, 5 })).Throws<AccessTokenInvalidException>();
		}

		[Test, Ignore]
		public void GetById_NormalCase_Message()
		{
			Url = "https://api.vk.com/method/messages.getById?message_ids=1&v=5.28&access_token=token";
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

			var msg = Cat.GetById(1);

			Assert.That(msg.Id, Is.EqualTo(1));
			Assert.That(msg.Date, Is.EqualTo(new DateTime(2007, 12, 18, 2, 5, 20)));
			Assert.That(msg.Type, Is.EqualTo(MessageType.Received));
			Assert.That(msg.UserId, Is.EqualTo(684559));
			Assert.That(msg.ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msg.Title, Is.EqualTo(" ... "));
			Assert.That(msg.Body, Is.EqualTo("Привеееет!!!!!!!!!!!"));
		}

		[Test, Ignore]
		public void GetById_Multiple_NormalCase_Messages()
		{
			Url = "https://api.vk.com/method/messages.getById?message_ids=1,3,5&v=5.28&access_token=token";
			Json =
				@"{
					'response': [
					  3,
					  {
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
					  }
					]
				  }";
			
			int totalCount;
			var msgs = Cat.GetById(out totalCount, new ulong[] { 1, 3, 5 }).ToList();

			Assert.That(totalCount, Is.EqualTo(3));
			Assert.That(msgs.Count, Is.EqualTo(3));

			Assert.That(msgs[2].Id, Is.EqualTo(5));
			Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2007, 12, 26, 1, 16, 48)));
			Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[2].UserId, Is.EqualTo(684559));
			Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[2].Title, Is.EqualTo("Re(2): Как там зачетная неделя продвигаетсо?)"));
			Assert.That(msgs[2].Body, Is.EqualTo("Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)"));

			Assert.That(msgs[1].Id, Is.EqualTo(3));
			Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2007, 12, 26, 1, 9, 40)));
			Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Sended));
			Assert.That(msgs[1].UserId, Is.EqualTo(684559));
			Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[1].Title, Is.EqualTo("Re: Как там зачетная неделя продвигаетсо?)"));
			Assert.That(msgs[1].Body, Is.EqualTo("Парят и парят во все дыры)... у тебя как?"));
			Assert.That(msgs[0].Id, Is.EqualTo(1));
			Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2007, 12, 18, 2, 5, 20)));
			Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[0].UserId, Is.EqualTo(684559));
			Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[0].Title, Is.EqualTo(" ... "));
			Assert.That(msgs[0].Body, Is.EqualTo("Привеееет!!!!!!!!!!!"));
		}

		[Test]
		public void SearchDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.SearchDialogs("hello")).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void SearchDialogs_EmptyResponse_MessageResponseWithEmptyLists()
		{
			Url = "https://api.vk.com/method/messages.searchDialogs?q=привет&v=5.44&access_token=token";
			Json = @"{
                    'response': []
                  }";

			var response = Cat.SearchDialogs("привет");

			Assert.That(response, Is.Null);
		}

		[Test]
		public void SearchDialogs_NastyaQuery_TwoProfiles()
		{
			Url = "https://api.vk.com/method/messages.searchDialogs?q=Настя&v=5.44&access_token=token";
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
			Url = "https://api.vk.com/method/messages.searchDialogs?q=Маша&v=5.44&access_token=token";
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
			Assert.That(response.Chats[0].Users.Count(), Is.EqualTo(3));
			Assert.That(response.Chats[0].Users.ElementAt(0), Is.EqualTo(66748));
			Assert.That(response.Chats[0].Users.ElementAt(1), Is.EqualTo(6492));
			Assert.That(response.Chats[0].Users.ElementAt(2), Is.EqualTo(1708231));
		}

		[Test]
		public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			int totalCount;
			This.Action(() => cat.Search("привет", out totalCount)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		[Ignore]
		public void Search_NormalCase_Messages()
		{
			Url = "https://api.vk.com/method/messages.search?q=привет&count=3&v=5.37&access_token=token";
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

			int totalCount;
			var msgs = Cat.Search("привет", out totalCount, 3).ToList();

			Assert.That(totalCount, Is.EqualTo(680));
			Assert.That(msgs.Count, Is.EqualTo(3));

			Assert.That(msgs[2].Id, Is.EqualTo(4414));
			Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2012, 7, 13, 8, 46, 32, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[2].UserId, Is.EqualTo(245242));
			Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[2].Title, Is.EqualTo(" ... "));
			Assert.That(msgs[2].Body, Is.EqualTo("привет, антон))"));

			Assert.That(msgs[1].Id, Is.EqualTo(4415));
			Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2012, 7, 13, 8, 46, 48, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Sended));
			Assert.That(msgs[1].UserId, Is.EqualTo(245242));
			Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[1].Title, Is.EqualTo(" ... "));
			Assert.That(msgs[1].Body, Is.EqualTo("привет))"));
			
			Assert.That(msgs[0].Id, Is.EqualTo(4442));
			Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2012, 7, 31, 20, 2, 52, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
			Assert.That(msgs[0].UserId, Is.EqualTo(1016149));
			Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
			Assert.That(msgs[0].Title, Is.EqualTo("..."));
			Assert.That(msgs[0].Body, Is.EqualTo("Привет, Антон! Как дела?"));
		}

		[Test]
		[Ignore]
		public void Search_NotExistedQuery_EmptyList()
		{
			Url = "https://api.vk.com/method/messages.search?q=fsjkadoivhjioashdpfisd&count=3&v=5.37&access_token=token";
			Json =
				@"{
					'response': [
					  0
					]
				  }";


			int totalCount;
			var msgs = Cat.Search("fsjkadoivhjioashdpfisd", out totalCount, 3).ToList();

			Assert.That(totalCount, Is.EqualTo(0));
			Assert.That(msgs.Count, Is.EqualTo(0));
		}
		
		[Test]
		public void Send_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.Send(new MessageSendParams {UserId = 1, Message = "Привет, Паша!" })).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Send_DefaultFields_MessageId()
		{
			Url = "https://api.vk.com/method/messages.send?user_id=7550525&message=Test+from+vk.net+%3b)+%23+2&v=5.44&access_token=token";
			Json =
				@"{
					'response': 4457
				  }";

			var id = Cat.Send(new MessageSendParams
			{
				UserId = 7550525,
				Message = "Test from vk.net ;) # 2"
			});
			Assert.That(id, Is.EqualTo(4457));
		}

		[Test]
		public void Send_RussianText_MessageId()
		{
			Url = "https://api.vk.com/method/messages.send?user_id=7550525&message=%d0%a0%d0%b0%d0%b1%d0%be%d1%82%d0%b0%d0%b5%d1%82+%23+2+--++%d0%b5%d1%89%d0%b5+%d1%80%d0%b0%d0%b7%d0%be%d0%ba&v=5.44&access_token=token";
			Json =
				@"{
					'response': 4464
				  }";
			var id = Cat.Send(new MessageSendParams
			{
				UserId = 7550525,
				Message = "Работает # 2 --  еще разок"
			});
			Assert.That(id, Is.EqualTo(4464));
		}

		[Test]
		public void Send_EmptyMessage_ThrowsInvalidParameterException()
		{
			This.Action(() => Cat.Send(1, false, "")).Throws<ArgumentException>();
		}

		[Test]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.Delete(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Delete_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.Delete(new ulong[] { 1 })).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Delete_Id4446_True()
		{
			Url = "https://api.vk.com/method/messages.delete?message_ids=4446&v=5.37&access_token=token";
			Json =
				@"{
					'response': {
					  '4446': 1
					}
				  }";

			var result = Cat.Delete(4446);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Delete_Multipre_4457And4464_True()
		{
			Url = "https://api.vk.com/method/messages.delete?message_ids=4457,4464&v=5.37&access_token=token";
			Json =
				@"{
					'response': {
					  '4457': 1,
					  '4464': 1
					}
				  }";

			var dict = Cat.Delete((new ulong[] {4457, 4464}));

			Assert.That(dict.Count, Is.EqualTo(2));
			Assert.That(dict[4457], Is.True);
			Assert.That(dict[4464], Is.True);
		}

		[Test]
		public void Delete_Id999999_False()
		{
			Url = "https://api.vk.com/method/messages.delete?message_ids=999999&v=5.37&access_token=token";
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

			This.Action(() => Cat.Delete(999999)).Throws<VkApiException>();
		}
		
		[Test]
		public void DeleteDialog_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.DeleteDialog(111, false)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void DeleteDialog_UserId_DeleteAllMessages()
		{
			Url = "https://api.vk.com/method/messages.deleteDialog?user_id=4460019&v=5.44&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.DeleteDialog(4460019, false);

			Assert.That(result, Is.True);
		}

		[Test]
		public void DeleteDialog_WithAllInputParams_DeleteTwoMessages()
		{
			Url = "https://api.vk.com/method/messages.deleteDialog?user_id=4460019&offset=2&count=2&v=5.44&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.DeleteDialog(4460019, false, null, 2, 2);

			Assert.That(result, Is.True);
		}
		
		[Test]
		public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.Restore(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Restore_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.restore?message_id=134&v=5.37&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.Restore(134);

			Assert.That(result, Is.True);
		}
		
		[Test]
		[Ignore]
		public void MarkAsNew_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.MarkAsNew(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		[Ignore]
		public void MarkAsNew_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsNew?mids=1&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsNew(1);

			Assert.That(result, Is.True);
		}

		[Test]
		[Ignore]
		public void MarkAsNew_Multiple_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsNew?mids=2,3&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsNew(new ulong[] {2, 3});

			Assert.That(result, Is.True);
		}

		[Test]
		public void MarkAsRead_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.MarkAsRead(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void MarkAsRead_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsRead?mids=1&v=5.37&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsRead(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public void MarkAsRead_Multiple_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.markAsRead?mids=2,3&v=5.37&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.MarkAsRead(new ulong[]{2, 3});

			Assert.That(result, Is.True);
		}

		[Test]
		public void SetActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.SetActivity(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void SetActivity_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.setActivity?used_id=7550525&type=typing&v=5.44&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.SetActivity(7550525);

			Assert.That(result, Is.True);
		}
		
		[Test]
		public void GetLastActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.GetLastActivity(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetLastActivity_NormalCast_LastActivityObject()
		{
			Url = "https://api.vk.com/method/messages.getLastActivity?user_id=77128&v=5.37&access_token=token";
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
			Assert.That(activity.Time, Is.EqualTo(new DateTime(2012, 8, 9, 3, 57, 25, DateTimeKind.Utc).ToLocalTime()));
		}

		[Test]
		public void GetChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.GetChat(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetChat_NormalCase_ChatObject()
		{
			Url = "https://api.vk.com/method/messages.getChat?chat_id=2&v=5.37&access_token=token";
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
			Assert.That(chat.Users.Count(), Is.EqualTo(3));
			Assert.That(chat.Users.ElementAt(0), Is.EqualTo(4793858));
			Assert.That(chat.Users.ElementAt(1), Is.EqualTo(5041431));
			Assert.That(chat.Users.ElementAt(2), Is.EqualTo(10657891));
		}
		
		[Test]
		public void CreateChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.CreateChat(new ulong[] { 1, 2 }, "hi, friends")).Throws<AccessTokenInvalidException>();
		}

		[Test]
		
		//BUG: не работает, т.к. апостроф (в test chat's title) парсится в %27
		public void CreateChat_NormalCase_ChatId()
		{
			Url = "https://api.vk.com/method/messages.createChat?uids=5041431,10657891&title=test+chat%27s+title&v=5.37&access_token=token";
			Json =
				@"{
					'response': 3
				  }";

			var chatId = Cat.CreateChat(new ulong[] { 5041431, 10657891 }, "test chat's title");

			Assert.That(chatId, Is.EqualTo(3));
		}
		
		[Test]
		public void EditChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.EditChat(2, "new title")).Throws<AccessTokenInvalidException>();
		}

		[Test]
		[Ignore("undone")]
		public void EditChat_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.editChat?chat_id=2&title=new+title&access_token=token";
			Json =
				@"{
					'response': 1
				  }"; 
			
			var result = Cat.EditChat(2, "new title");
		}

		[Test]
		public void GetChatUsers_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.GetChatUsers(2)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetChatUsers_ChatId_UserIds()
		{
			Url = "https://api.vk.com/method/messages.getChatUsers?chat_id=2&v=5.37&access_token=token";
			Json =
				@"{
					'response': [
					  4793858,
					  5041431,
					  10657891
					]
				  }";

			var users = Cat.GetChatUsers(2).ToList();

			Assert.That(users.Count, Is.EqualTo(3));
			Assert.That(users[0], Is.EqualTo(4793858));
			Assert.That(users[1], Is.EqualTo(5041431));
			Assert.That(users[2], Is.EqualTo(10657891));
		}

		[Test]
		public void GetChatUsers_ChatIdWithFields_Users()
		{
			Url = "https://api.vk.com/method/messages.getChatUsers?chat_id=2&fields=education&v=5.37&access_token=token";
			Json =
				@"{
					'response': [
					  {
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
					]
				  }";

			var users = Cat.GetChatUsers(2, ProfileFields.Education).ToList();

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
		public void AddChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.AddChatUser(2, 2)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void AddChatUser_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.addChatUser?chat_id=2&uid=7550525&v=5.37&access_token=token";
			Json =
				@"{
					'response': 1
				  }"; 

			var result = Cat.AddChatUser(2, 7550525);

			Assert.That(result, Is.True);
		}
		
		[Test]
		public void RemoveChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.RemoveChatUser(2, 2)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void RemoveChatUser_NormalCase_True()
		{
			Url = "https://api.vk.com/method/messages.removeChatUser?chat_id=2&uid=7550525&v=5.37&access_token=token";
			Json =
				@"{
					'response': 1
				  }";

			var result = Cat.RemoveChatUser(2, 7550525);

			Assert.That(result, Is.True);
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void GetLongPollHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{

		}

		[Test]
		public void GetLongPollServer_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());
			This.Action(() => cat.GetLongPollServer()).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetLongPollServer_NormalCase_LongPollServerResponse()
		{
			Url = "https://api.vk.com/method/messages.getLongPollServer?use_ssl=0&need_pts=0&v=5.37&access_token=token";
			Json =
				@"{
					'response': {
					  'key': '6f4120988efaf3a7d398054b5bb5d019c5844bz3',
					  'server': 'im46.vk.com/im1858',
					  'ts': 1627957305
					}
				  }";

			var response = Cat.GetLongPollServer();

			Assert.That(response.Key, Is.EqualTo("6f4120988efaf3a7d398054b5bb5d019c5844bz3"));
			Assert.That(response.Server, Is.EqualTo("im46.vk.com/im1858"));
			Assert.That(response.Ts, Is.EqualTo(1627957305));
		}

		#region Get
		[Test]
		public void Get_CountAndOffsetAreNegatives_ThrowExceptions()
		{
			int total;

			This.Action(() => Cat.Get(MessageType.Received, out total, 201)).Throws<ArgumentException>();
			This.Action(() => Cat.Get(MessageType.Received, out total, offset: 0)).Throws<ArgumentException>();
		}

		[Test]
		public void Get_WithLastMessageIdParam_NormalCase_V521()
		{
			Url = "https://api.vk.com/method/messages.get?out=0&preview_length=0&last_message_id=30&count=20&v=5.44&access_token=token";

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

			int total;
			var messages = Cat.Get(MessageType.Received, out total, lastMessageId: 30);

			total.ShouldEqual(5);
			messages.Count.ShouldEqual(1);

			messages[0].Id.ShouldEqual(31);
			messages[0].Date.ShouldEqual(new DateTime(2014, 4, 23, 8, 40, 12, DateTimeKind.Utc).ToLocalTime());
			messages[0].Type.ShouldEqual(MessageType.Received);
			messages[0].UserId.ShouldEqual(123508789);
			messages[0].ReadState.ShouldEqual(MessageReadState.Unreaded);
			messages[0].Title.ShouldEqual(" ... ");
			messages[0].Body.ShouldEqual("may");
		}

		[Test]
		public void Get_NormalCase_V521()
		{
			Url = "https://api.vk.com/method/messages.get?out=0&preview_length=0&count=2&v=5.44&access_token=token";
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

			int total;
			var messages = Cat.Get(MessageType.Received, out total, 2);

			total.ShouldEqual(5);
			messages.Count.ShouldEqual(2);

			messages[0].Body.ShouldEqual("fun");
			messages[0].Id.ShouldEqual(34);
			messages[0].Date.ShouldEqual(new DateTime(2014, 4, 23, 8, 40, 16, DateTimeKind.Utc).ToLocalTime());
			messages[0].ReadState.ShouldEqual(MessageReadState.Unreaded);
			messages[0].Type.ShouldEqual(MessageType.Received);
			messages[0].UserId.ShouldEqual(562508789);
			messages[0].Title.ShouldEqual(" ... ");
			
			messages[1].Body.ShouldEqual("very");
			messages[1].Id.ShouldEqual(33);
			messages[1].Date.ShouldEqual(new DateTime(2014, 4, 23, 8, 40, 15, DateTimeKind.Utc).ToLocalTime());
			messages[1].ReadState.ShouldEqual(MessageReadState.Unreaded);
			messages[1].Type.ShouldEqual(MessageType.Received);
			messages[1].UserId.ShouldEqual(562508789);
			messages[1].Title.ShouldEqual(" ... ");
		}
		#endregion
	}
}