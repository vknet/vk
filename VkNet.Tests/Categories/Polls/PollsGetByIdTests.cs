using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Polls
{
	[TestFixture]
	public class PollsGetByIdTests : BaseTest
	{
		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/polls.getById";
			Json = @"{
			  'response': {
				'id': 305731205,
				'owner_id': -47544652,
				'created': 1537891221,
				'question': '� ���� ������ ���� ������������?',
				'votes': 35464,
				'answers': [
				  {
					'id': 1028729429,
					'text': '� ���� � ��� �������',
					'votes': 25637,
					'rate': 72.29
				  },
				  {
					'id': 1028729430,
					'text': '� ����� ��������',
					'votes': 9827,
					'rate': 27.71
				  }
				],
				'anonymous': false,
				'multiple': false,
				'answer_ids': [
				  1028729429
				],
				'end_date': 0,
				'closed': false,
				'is_board': false,
				'can_edit': false,
				'can_vote': true,
				'can_report': true,
				'can_share': true,
				'author_id': -47544652,
				'friends': [
				  {
					'id': 455233028
				  },
				  {
					'id': 504736359
				  },
				  {
					'id': 34382168
				  }
				]
			  }
			}
			";

			var result = Api.PollsCategory.GetById(new PollsGetByIdParams
			{
				PollId = 123
			});

			Assert.NotNull(result);
		}
	}
}