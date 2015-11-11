using System;
using NUnit.Framework;

using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
    using FluentNUnit;

    [TestFixture]
    public class VkErrorsTest
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
            This.Action(() => VkErrors.ThrowIfNumberNotInRange(2, 5, 10)).Throws<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ThrowIfNumberNotInRange_MoreThanMax_ThrowsException()
        {
            This.Action(() => VkErrors.ThrowIfNumberNotInRange(12, 5, 10)).Throws<ArgumentOutOfRangeException>();
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
            This.Action(() => cls.Execute(-2)).Throws<ArgumentException>();
        }

        [Test]
        public void ThrowIfNullOrEmpty_EmptyString_ThrowException()
        {
            string param = string.Empty;

            var ex = This.Action(() => VkErrors.ThrowIfNullOrEmpty(() => param)).Throws<ArgumentNullException>();

			//ex.Message.ShouldStartsWith("Значение не может быть неопределенным").ShouldContains("param");
	        Assert.Throws<ArgumentNullException>(() => VkErrors.ThrowIfNullOrEmpty(() => param));
        }

        [Test]
        public void ThrowIfNumberIsNegative_ExpressionVersion_NullabeLong()
        {
            long? paramName = -1;

            var ex = This.Action(() => VkErrors.ThrowIfNumberIsNegative(() => paramName)).Throws<ArgumentException>();

            ex.Message.ShouldStartsWith("Отрицательное значение.").ShouldContains("paramName");
        }

		[Test, Ignore] // TODO important: strange error, with nullable long everytihng ok, check later on windows OS
        public void ThrowIfNumberIsNegative_ExpressionVersion_Long()
        {
            const long paramName = -1;

            var ex = This.Action(() => VkErrors.ThrowIfNumberIsNegative(() => paramName)).Throws<ArgumentException>();

            ex.Message.ShouldStartsWith("Отрицательное значение.").ShouldContains("paramName");
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

            This.Action(() => VkErrors.IfErrorThrowException(json)).Throws<UserAuthorizationFailException>()
                .Message.ShouldEqual("User authorization failed: invalid access_token.");
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

            This.Action(() => VkErrors.IfErrorThrowException(json)).Throws<AccessDeniedException>()
                .Message.ShouldEqual("Access to the groups list is denied due to the user privacy settings.");
        }

        [Test]
        public void IfErrorThrowException_WrongJson_ThrowVkApiException()
        {
            const string json = "ThisIsNotJson";
            This.Action(() => VkErrors.IfErrorThrowException(json)).Throws<VkApiException>()
                .Message.ShouldEqual("Wrong json data.");
        }
    }
}