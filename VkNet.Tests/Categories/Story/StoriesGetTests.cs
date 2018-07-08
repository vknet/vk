using NUnit.Framework;

namespace VkNet.Tests.Categories.Story
{
	[TestFixture]
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
	}
}