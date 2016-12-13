using System;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
    [TestFixture]
    public class VkErrorsTest : BaseTest
    {
        private class TestClass
        {
            public void Execute(int count)
            {
                VkErrors.ThrowIfNumberIsNegative(() => count);
            }
        }

        [Test]
        public void ThrowIfNumberNotInRange_LessThenMin_ThrowsException()
        {
	        Assert.Throws<ArgumentOutOfRangeException>(() => VkErrors.ThrowIfNumberNotInRange(2, 5, 10));
        }

        [Test]
        public void ThrowIfNumberNotInRange_MoreThanMax_ThrowsException()
        {
			Assert.Throws<ArgumentOutOfRangeException>(() => VkErrors.ThrowIfNumberNotInRange(12, 5, 10));
		}

        [Test]
        public void ThrowIfNumberNotInRange_ValueInRange_ExceptionNotThrowed()
        {
            VkErrors.ThrowIfNumberNotInRange(5, 2, 7);
            VkErrors.ThrowIfNumberNotInRange(5, 5, 7);
            VkErrors.ThrowIfNumberNotInRange(5, 2, 5);
        }

        [Test]
        public void ThrowIfNumberIsNegative_InnerTestClass_ThrowException()
        {
            var cls = new TestClass();
			Assert.Throws<ArgumentException>(() => cls.Execute(-2));
		}

        [Test, Ignore("На MONO код падает")]
        public void ThrowIfNullOrEmpty_EmptyString_ThrowException()
        {
			// TODO На MONO код падает
			var param = "";
			var ex = Assert.Throws<ArgumentNullException>(() => VkErrors.ThrowIfNullOrEmpty(() => param));

			StringAssert.StartsWith("Значение не может быть неопределенным", ex.Message);
			StringAssert.Contains("param", ex.Message);

        }

        [Test]
        public void ThrowIfNumberIsNegative_ExpressionVersion_NullabeLong()
        {
            long? param = -1;
			var ex = Assert.Throws<ArgumentException>(() => VkErrors.ThrowIfNumberIsNegative(() => param));

			StringAssert.StartsWith("Отрицательное значение.", ex.Message);
			StringAssert.Contains("param", ex.Message);
		}

		[Test]
		[Ignore("")] // TODO important: strange error, with nullable long everytihng ok, check later on windows OS
		public void ThrowIfNumberIsNegative_ExpressionVersion_Long()
        {
            const long paramName = -1;

			var ex = Assert.Throws<ArgumentException>(() => VkErrors.ThrowIfNumberIsNegative(() => paramName));
			StringAssert.StartsWith("Отрицательное значение.", ex.Message);
			StringAssert.Contains("paramName", ex.Message);
		}

        [Test]
        public void IfErrorThrowException_NormalCase_NothingExceptions()
        {
            const string json =
                @"{
                    'response': [
                      {
                        'uid': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров',
                        'university': '1',
                        'university_name': 'СПбГУ',
                        'faculty': '0',
                        'faculty_name': '',
                        'graduation': '0'
                      }
                    ]
                  }";

            VkErrors.IfErrorThrowException(json);
        }

        [Test]
        public void IfErrorThrowException_UserAuthorizationFail_ThrowUserAuthorizationFailExcption()
        {
            const string json =
                @"{
                    'error': {
                      'error_code': 5,
                      'error_msg': 'User authorization failed: invalid access_token.',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'getProfiles'
                        },
                        {
                          'key': 'uid',
                          'value': '1'
                        },
                        {
                          'key': 'access_token',
                          'value': 'sfastybdsjhdg'
                        }
                      ]
                    }
                  }";

			var ex = Assert.Throws<UserAuthorizationFailException>(() => VkErrors.IfErrorThrowException(json));

			Assert.That(ex.Message, Is.EqualTo("User authorization failed: invalid access_token."));
		}

        [Test]
        public void IfErrorThrowException_GroupAccessDenied_ThrowAccessDeniedException()
        {
            const string json =
                @"{
                    'error': {
                      'error_code': 260,
                      'error_msg': 'Access to the groups list is denied due to the user privacy settings.',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'getGroups'
                        },
                        {
                          'key': 'uid',
                          'value': '1'
                        },
                        {
                          'key': 'access_token',
                          'value': '2f3e43eb608a87632f68d140d82f5a9efa22f772f7765eb2f49f67514987c5e'
                        }
                      ]
                    }
                  }";
	        var ex = Assert.Throws<AccessDeniedException>(() => VkErrors.IfErrorThrowException(json));
			StringAssert.AreEqualIgnoringCase("Access to the groups list is denied due to the user privacy settings.", ex.Message);
        }

        [Test]
        public void IfErrorThrowException_WrongJson_ThrowVkApiException()
        {
            const string json = "ThisIsNotJson";
			var ex = Assert.Throws<VkApiException>(() => VkErrors.IfErrorThrowException(json));

			Assert.That(ex.Message, Is.EqualTo("Wrong json data."));
		}

		[Test]
		public void Call_ThrowsCaptchaNeededException()
		{
			Url = "https://api.vk.com/method/messages.send?v=" + VkApi.VkApiVersion ;
			Json =
				@"{
					'error': {
					  'error_code': 14,
					  'error_msg': 'Captcha needed',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'messages.send'
						},
						{
						  'key': 'uid',
						  'value': '242508553'
						},
						{
						  'key': 'message',
						  'value': 'hello10'
						},
						{
						  'key': 'type',
						  'value': '0'
						},
						{
						  'key': 'access_token',
						  'value': '1fe7889c3395722934b1'
						}
					  ],
					  'captcha_sid': '548747100691',
					  'captcha_img': 'http://api.vk.com/captcha.php?sid=548747100284&s=1'
					}
				  }";
			var ex = Assert.Throws<CaptchaNeededException>(() => Api.Call("messages.send", VkParameters.Empty, true));
			Assert.That(ex.Sid, Is.EqualTo(548747100691));
			Assert.That(ex.Img, Is.EqualTo(new Uri("http://api.vk.com/captcha.php?sid=548747100284&s=1")));
		}
	}
}