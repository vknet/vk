using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams.Stories;

namespace VkNet.Tests.Categories.Story
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class StoriesGetTests : BaseTest
	{
		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/stories.get";

			Json =
				@"{
			   'response':{
			      'count':1,
			      'items':[[{
			               'id':930826,
			               'owner_id':465742902,
			               'date':1530989545,
			               'can_see':1,
			               'type':'photo',
			               'photo':{
			                  'id':456239408,
			                  'album_id':-81,
			                  'owner_id':465742902,
			                  'sizes':[
			                     {
			                        'type':'temp',
			                        'url':'https://story0.us/0d4/aoRw4F2Nh1g.jpg',
			                        'width':28,
			                        'height':50
			                     }
			                  ],
			                  'text':'',
			                  'date':1530989545
			               },
			               'can_share':1,
			               'can_comment':0,
			               'can_reply':0,
			               'views':1,
			               'seen':1,
			               'replies':{
			                  'count':0,
			                  'new':0
			               }
			            }
			      ]]
			   }
			}";

			var result = Api.Stories.Get();

			Assert.That(1, Is.EqualTo(result.Count));
		}

		[Test]
		public void GetBanned()
		{
			Url = "https://api.vk.com/method/stories.getBanned";

			Json = @"{
					   'response': {
					      'count': 1,
					      'items': [
					         123456789
					      ],
					      'profiles': [
					         {
					            'id': 123456789,
					            'first_name': 'Иван',
					            'last_name': 'Иванов'
					         }
					      ],
					      'groups': []
					   }
					}";

			var result = Api.Stories.GetBanned();
			var userId = result.Items.FirstOrDefault();

			Assert.That(result.Count, Is.EqualTo(1));
			Assert.NotNull(userId);
		}

		[Test]
		public void GetPhotoUploadServer()
		{
			Url = "https://api.vk.com/method/stories.getPhotoUploadServer";

			Json = @"{
					   'response':{
					      'upload_url':'https://pu.vk.com/Tk0YjM0MjRmNzA5NSJ9',
					      'peer_ids':[]
					   }
					}";

			var result = Api.Stories.GetPhotoUploadServer(new GetPhotoUploadServerParams { AddToNews = true });

			Assert.NotNull(result.UploadUrl);
		}

		[Test]
		public void GetReplies()
		{
			Url = "https://api.vk.com/method/stories.getReplies";

			Json = @"{
					   'response':{
					      'count':1,
					      'items':[[
					            {
					               'id':999556,
					               'owner_id':123456789,
					               'date':1531245080,
					               'can_see':1,
					               'type':'photo',
					               'photo':{
					                  'id':123456789,
					                  'album_id':-81,
					                  'owner_id':123456789,
					                  'sizes':[
					                     {
					                        'type':'temp',
					                        'url':'https://story0.us/7ba/0qnhJtKbfmo.jpg',
					                        'width':28,
					                        'height':50
					                     }
					                  ],
					                  'text':'',
					                  'date':1531245080
					               },
					               'can_share':1,
					               'can_comment':1,
					               'can_reply':1,
					               'parent_story_owner_id':123456789,
					               'parent_story_id':937385,
					               'parent_story':{
					                  'id':937385,
					                  'owner_id':123456789,
					                  'date':1531239676,
					                  'can_see':1,
					                  'type':'photo',
					                  'photo':{
					                     'id':123456789,
					                     'album_id':-81,
					                     'owner_id':123456789,
					                     'sizes':[
					                        {
					                           'type':'temp',
					                           'url':'https://story0.us/50f/A_9UNRNpvMc.jpg',
					                           'width':28,
					                           'height':50
					                        }
					                     ],
					                     'text':'',
					                     'date':1531239676
					                  },
					                  'can_share':1,
					                  'can_comment':0,
					                  'can_reply':0,
					                  'views':1,
					                  'replies':{
					                     'count':1,
					                     'new':0
					                  },
					                  'access_key':'123456789qwerty'
					               },
					               'replies':{
					                  'count':0
					               },
					               'access_key':'123456789qwerty'
					            }
					         ]],
					      'profiles':[
					         {
					            'id':123456789,
					            'first_name':'Null',
					            'last_name':'Null',
					            'sex':2,
					            'screen_name':'id123456789',
					            'photo_50':'https://pp.userap/vekAEzCxU.jpg?ava=1',
					            'photo_100':'https://pp.userap/N1dVAh9p8.jpg?ava=1',
					            'online':0
					         },
					         {
					            'id':123456789,
					            'first_name':'Null',
					            'last_name':'Null',
					            'sex':1,
					            'screen_name':'test',
					            'photo_50':'https://vk.com/im/camera_50.png?ava=1',
					            'photo_100':'https://vk.com/im/amera_100.png?ava=1',
					            'online':1
					         }
					      ],
					      'groups':[]
					   }
					}";

			var result = Api.Stories.GetReplies(12345679, 123456789, null, true, new List<string>());

			Assert.That(result.Count, Is.EqualTo(1));
		}

		[Test]
		public void GetViewers()
		{
			Url = "https://api.vk.com/method/stories.getViewers";

			Json = @"{
					   'response':{
					      'count':1,
					      'items':[
					         {
					            'type':'profile',
					            'id':123456789,
					            'first_name':'qwe',
					            'last_name':'qwe'
					         }
					      ]
					   }
					}";

			var users = Api.Stories.GetViewers(123456789, 123456789);
			var userId = users.FirstOrDefault();

			Assert.That(users.Count, Is.EqualTo(1));
			Assert.NotNull(userId);
		}

		[Test]
		public void GetStats()
		{
			Url = "https://api.vk.com/method/stories.getStats";

			Json = @"{
					   'response': {
					      'views': {
					         'state': 'on',
					         'count': 0
					      },
					      'replies': {
					         'state': 'on',
					         'count': 1
					      },
					      'answer': {
					         'state': 'on',
					         'count': 0
					      },
					      'shares': {
					         'state': 'on',
					         'count': 0
					      },
					      'subscribers': {
					         'state': 'on',
					         'count': 0
					      },
					      'bans': {
					         'state': 'on',
					         'count': 0
					      },
					      'open_link': {
					         'state': 'hidden'
					      }
					   }
					}";

			var stats = Api.Stories.GetStats(123456789, 123456789);

			Assert.NotNull(stats.Views);
			Assert.NotNull(stats.Answer);
			Assert.NotNull(stats.Bans);
			Assert.NotNull(stats.OpenLink);
			Assert.NotNull(stats.Replies);
			Assert.NotNull(stats.Subscribers);
			Assert.NotNull(stats.Shares);
		}

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/stories.getById";

			Json = @"{
					   'response':{
					      'count':1,
					      'items':[
					         {
					            'id':937385,
					            'owner_id':123456789,
					            'date':1531239676,
					            'can_see':1,
					            'type':'photo',
					            'photo':{
					               'id':123456789,
					               'album_id':-81,
					               'owner_id':12345679,
					               'sizes':[
					                  {
					                     'type':'temp',
					                     'url':'https://story0.us/50f/A_9UNRNpvMc.jpg',
					                     'width':28,
					                     'height':50
					                  }
					               ],
					               'text':'',
					               'date':1531239676
					            },
					            'can_share':1,
					            'can_comment':0,
					            'can_reply':0,
					            'views':1,
					            'replies':{
					               'count':1,
					               'new':0
					            }
					         }
					      ],
					      'profiles':[
					         {
					            'id':123456789,
					            'first_name':'Null',
					            'last_name':'Null'
					         }
					      ],
					      'groups':[]
					   }
					}";

			var stories = Api.Stories.GetById(new List<string> { "123456789_123456789" }, true, new List<string>());
			var story = stories.Items.FirstOrDefault();

			Assert.That(stories.Count, Is.EqualTo(1));
			Assert.NotNull(story);
		}
	}
}