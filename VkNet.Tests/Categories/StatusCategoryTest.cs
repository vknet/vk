using NUnit.Framework;
using VkNet.Categories;
using VkNet.Exception;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class StatusCategoryTest : BaseTest
	{
		private StatusCategory GetMockedStatusCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new StatusCategory(vk: Api);
		}

		[Test]
		public void Get_AccessDenied_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/status.get";

			const string json =
					@"{
                    'error': {
                      'error_code': 7,
                      'error_msg': 'Permission to perform this action is denied',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'status.get'
                        },
                        {
                          'key': 'user_id',
                          'value': '4793858'
                        },
                        {
                          'key': 'access_token',
                          'value': 'bf0403a1ef4f5ca4bf52913da3bf60deb0bbf4dbf4d25a1a7dba6b3476c3192'
                        }
                      ]
                    }
                  }";

			var status = GetMockedStatusCategory(url: url, json: json);
			var ex = Assert.Throws<PermissionToPerformThisActionException>(code: () => status.Get(userId: 1));
			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "Permission to perform this action is denied"));
		}

		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var status = new StatusCategory(vk: new VkApi());
			Assert.That(del: () => status.Get(userId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_Audio_ReturnStatus()
		{
			const string url = "https://api.vk.com/method/status.get";

			const string json =
					@"{
                    'response': {
                      'text': 'Тараканы! – Собачье Сердце',
                      'audio': {
						'id': 158073513,
						'owner_id': 4793858,
						'artist': 'Тараканы!',
						'title': 'Собачье Сердце',
						'duration': 230,
						'date': 1533704475,
						'url': 'https://cs1-43v4/lR-RTwXXMk_q1RrO_-g',
						'lyrics_id': 7985406,
						'genre_id': 3,
						'is_hq': true
                      }
                    }
                  }";

			var status = GetMockedStatusCategory(url: url, json: json);
			var actual = status.Get(userId: 1);

			Assert.That(actual: actual, expression: Is.Not.Null);
			Assert.That(actual: actual.Text, expression: Is.EqualTo(expected: "Тараканы! – Собачье Сердце"));
			Assert.That(actual: actual.Audio, expression: Is.Not.Null);
			Assert.That(actual: actual.Audio.Id, expression: Is.EqualTo(expected: 158073513));
			Assert.That(actual: actual.Audio.OwnerId, expression: Is.EqualTo(expected: 4793858));
			Assert.That(actual: actual.Audio.Artist, expression: Is.EqualTo(expected: "Тараканы!"));
			Assert.That(actual: actual.Audio.Title, expression: Is.EqualTo(expected: "Собачье Сердце"));
			Assert.That(actual: actual.Audio.Duration, expression: Is.EqualTo(expected: 230));

			Assert.That(actual: actual.Audio.Url.OriginalString
					, expression: Is.EqualTo(expected: "https://cs1-43v4/lR-RTwXXMk_q1RrO_-g"));

			Assert.That(actual: actual.Audio.LyricsId, expression: Is.EqualTo(expected: 7985406));
		}

		[Test]
		public void Get_SimpleText_ReturnStatus()
		{
			const string url = "https://api.vk.com/method/status.get";

			const string json =
					@"{
                    'response': {
                      'text': 'it really work!!!'
                    }
                  }";

			var status = GetMockedStatusCategory(url: url, json: json);
			var actual = status.Get(userId: 1);

			Assert.That(actual: actual, expression: Is.Not.Null);
			Assert.That(actual: actual.Text, expression: Is.EqualTo(expected: "it really work!!!"));
			Assert.That(actual: actual.Audio, expression: Is.Null);
		}

		[Test]
		public void Set_AccessDenied_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/status.set";

			const string json =
					@"{
                    'error': {
                      'error_code': 7,
                      'error_msg': 'Permission to perform this action is denied',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'status.set'
                        },
                        {
                          'key': 'text',
                          'value': 'test'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

			var status = GetMockedStatusCategory(url: url, json: json);
			Assert.That(del: () => status.Set(text: "test"), expr: Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Test]
		public void Set_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var status = new StatusCategory(vk: new VkApi());
			Assert.That(del: () => status.Set(text: "test"), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Set_SimpleText_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/status.set";

			const string json =
					@"{
                    'response': 1
                  }";

			var status = GetMockedStatusCategory(url: url, json: json);
			var result = status.Set(text: "test test test");

			Assert.That(actual: result, expression: Is.True);
		}
	}
}