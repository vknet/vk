using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Exception;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class StatusCategoryTest : BaseTest
	{
		private StatusCategory GetMockedStatusCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new StatusCategory(Api);
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

			var status = GetMockedStatusCategory(url, json);
			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			var ex = Assert.Throws<PermissionToPerformThisActionException>(() => status.Get(1));
			Assert.That(ex.Message, Is.EqualTo("Permission to perform this action is denied"));
		}

		[Ignore("")]
		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var status = new StatusCategory(new VkApi());
			Assert.That(() => status.Get(1), Throws.InstanceOf<AccessTokenInvalidException>());
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

			var status = GetMockedStatusCategory(url, json);
			var actual = status.Get(1);

			Assert.That(actual, Is.Not.Null);
			Assert.That(actual.Text, Is.EqualTo("Тараканы! – Собачье Сердце"));
			Assert.That(actual.Audio, Is.Not.Null);
			Assert.That(actual.Audio.Id, Is.EqualTo(158073513));
			Assert.That(actual.Audio.OwnerId, Is.EqualTo(4793858));
			Assert.That(actual.Audio.Artist, Is.EqualTo("Тараканы!"));
			Assert.That(actual.Audio.Title, Is.EqualTo("Собачье Сердце"));
			Assert.That(actual.Audio.Duration, Is.EqualTo(230));
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

			var status = GetMockedStatusCategory(url, json);
			var actual = status.Get(1);

			Assert.That(actual, Is.Not.Null);
			Assert.That(actual.Text, Is.EqualTo("it really work!!!"));
			Assert.That(actual.Audio, Is.Null);
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

			var status = GetMockedStatusCategory(url, json);
			Assert.That(() => status.Set("test"), Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Ignore("")]
		[Test]
		public void Set_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var status = new StatusCategory(new VkApi());
			Assert.That(() => status.Set("test"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Set_SimpleText_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/status.set";

			const string json =
					@"{
                    'response': 1
                  }";

			var status = GetMockedStatusCategory(url, json);
			var result = status.Set("test test test");

			Assert.That(result, Is.True);
		}
	}
}