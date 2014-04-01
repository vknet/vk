using System;
using NUnit.Framework;

using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
    using VkNet.Utils.Tests;

    [TestFixture]
    public class VkErrorsTest
    {
        [Test]
        public void ThrowIfNullOrEmpty_EmptyString_ThrowException()
        {
            string param = string.Empty;

            var ex = ExceptionAssert.Throws<ArgumentNullException>(() => VkErrors.ThrowIfNullOrEmpty(() => param));

            ex.Message.ShouldEqual("Значение не может быть неопределенным.\r\nИмя параметра: param");
        }

        [Test]
        public void ThrowIfNumberIsNegative_ExpressionVersion_NullabeLong()
        {
            long? paramName = -1;

            var ex = ExceptionAssert.Throws<ArgumentException>(() => VkErrors.ThrowIfNumberIsNegative(() => paramName));

            ex.Message.ShouldEqual("Отрицательное значение.\r\nИмя параметра: paramName");
        }

        [Test]
        public void ThrowIfNumberIsNegative_ExpressionVersion_Long()
        {
            long paramName = -1;

            var ex = ExceptionAssert.Throws<ArgumentException>(() => VkErrors.ThrowIfNumberIsNegative(() => paramName));

            ex.Message.ShouldEqual("Отрицательное значение.\r\nИмя параметра: paramName");
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
        [ExpectedException(typeof(UserAuthorizationFailException), ExpectedMessage = "User authorization failed: invalid access_token.")]
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

            VkErrors.IfErrorThrowException(json);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "Access to the groups list is denied due to the user privacy settings.")]
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

            VkErrors.IfErrorThrowException(json);
        }

        [Test]
        [Ignore]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "Wrong json data.")]
        public void IfErrorThrowException_WrongJson_ThrowVkApiException()
        {
            const string json = "ThisIsNotJson";
            VkErrors.IfErrorThrowException(json);
        }
    }
}