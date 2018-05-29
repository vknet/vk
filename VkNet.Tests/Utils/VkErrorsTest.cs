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
				VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			}
		}

		[Test]
		public void Call_ThrowsCaptchaNeededException()
		{
			Url = "https://api.vk.com/method/messages.send";

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

			var ex = Assert.Throws<CaptchaNeededException>(code: () =>
					Api.Call(methodName: "messages.send", parameters: VkParameters.Empty, skipAuthorization: true));

			Assert.That(actual: ex.Sid, expression: Is.EqualTo(expected: 548747100691));

			Assert.That(actual: ex.Img
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://api.vk.com/captcha.php?sid=548747100284&s=1")));
		}

		[Test]
		public void Call_ThrowsImpossibleToCompileCode_12()
		{
			Url = "https://api.vk.com/method/execute";

			Json =
					@"{
                    'error': {
                        'error_code': 12,
                        'error_msg': 'Unable to compile code: undefined identifier \'test\' in line 1',
                        'request_params': [
                            {
                                'key': 'oauth',
                                'value': '1'
                            },
                            {
                                'key': 'method',
                                'value': 'execute'
                            },
                            {
                                'key': 'code',
                                'value': 'test'
                            },
                            {
                                'key': 'v',
                                'value': '5.78'
                            }
                        ]
                    }
                }";

			Assert.Throws<ImpossibleToCompileCodeException>(code: () =>
					Api.Call(methodName: "execute", parameters: VkParameters.Empty, skipAuthorization: true));
		}

		[Test]
		public void Call_ThrowsPostLimitException()
		{
			Url = "https://api.vk.com/method/messages.send";

			Json =
					@"{
					'error': {
						'error_code': 214,
						'error_msg': 'Access to adding post denied: you can only add 50 posts a day',
						'request_params': [
							{
								'key': 'oauth',
								'value': '1'
							},
							{
								'key': 'method',
								'value': 'wall.post'
							},
							{
								'key': 'owner_id',
								'value': '-166621386'
							},
							{
								'key': 'message',
								'value': 'РРіСЂР° #24\nРЎС‚Р°С‚СѓСЃ: Р°РєС‚РёРІРЅР°'
							},
							{
								'key': 'v',
								'value': '5.74'
							}
						]
					}
				}";

			Assert.Throws<PostLimitException>(code: () =>
					Api.Call(methodName: "messages.send", parameters: VkParameters.Empty, skipAuthorization: true));
		}

		[Test]
		public void Call_ThrowsPostLimitException_103()
		{
			Url = "https://api.vk.com/method/messages.send";

			Json =
					@"{
					'error': {
						'error_code': 103,
						'error_msg': 'Access to adding post denied: you can only add 50 posts a day',
						'request_params': [
							{
								'key': 'oauth',
								'value': '1'
							},
							{
								'key': 'method',
								'value': 'wall.post'
							},
							{
								'key': 'owner_id',
								'value': '-166621386'
							},
							{
								'key': 'message',
								'value': 'РРіСЂР° #24\nРЎС‚Р°С‚СѓСЃ: Р°РєС‚РёРІРЅР°'
							},
							{
								'key': 'v',
								'value': '5.74'
							}
						]
					}
				}";

			Assert.Throws<OutOfLimitsException>(code: () =>
					Api.Call(methodName: "messages.send", parameters: VkParameters.Empty, skipAuthorization: true));
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

			var ex = Assert.Throws<GroupsListAccessDeniedException>(code: () => VkErrors.IfErrorThrowException(json: json));

			StringAssert.AreEqualIgnoringCase(expected: "Access to the groups list is denied due to the user privacy settings.",
					actual: ex.Message);
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

			VkErrors.IfErrorThrowException(json: json);
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

			var ex = Assert.Throws<UserAuthorizationFailException>(code: () => VkErrors.IfErrorThrowException(json: json));

			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "User authorization failed: invalid access_token."));
			Assert.That(actual: ex.ErrorCode, expression: Is.EqualTo(expected: 5));
		}

		[Test]
		public void IfErrorThrowException_WrongJson_ThrowVkApiException()
		{
			const string json = "ThisIsNotJson";
			var ex = Assert.Throws<VkApiException>(code: () => VkErrors.IfErrorThrowException(json: json));

			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "Wrong json data."));
		}

		[Test]
		[Ignore(reason: "")] // TODO important: strange error, with nullable long everytihng ok, check later on windows OS
		public void ThrowIfNumberIsNegative_ExpressionVersion_Long()
		{
			const long paramName = -1;

			var ex = Assert.Throws<ArgumentException>(code: () => VkErrors.ThrowIfNumberIsNegative(expr: () => paramName));
			StringAssert.StartsWith(expected: "Отрицательное значение.", actual: ex.Message);
			StringAssert.Contains(expected: "paramName", actual: ex.Message);
		}

		[Test]
		public void ThrowIfNumberIsNegative_ExpressionVersion_NullabeLong()
		{
			long? param = -1;
			var ex = Assert.Throws<ArgumentException>(code: () => VkErrors.ThrowIfNumberIsNegative(expr: () => param));

			StringAssert.StartsWith(expected: "Отрицательное значение.", actual: ex.Message);
			StringAssert.Contains(expected: "param", actual: ex.Message);
		}

		[Test]
		public void ThrowIfNumberIsNegative_InnerTestClass_ThrowException()
		{
			var cls = new TestClass();
			Assert.Throws<ArgumentException>(code: () => cls.Execute(count: -2));
		}

		[Test]
		public void ThrowIfNumberNotInRange_LessThenMin_ThrowsException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(code: () => VkErrors.ThrowIfNumberNotInRange(value: 2, min: 5, max: 10));
		}

		[Test]
		public void ThrowIfNumberNotInRange_MoreThanMax_ThrowsException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(code: () => VkErrors.ThrowIfNumberNotInRange(value: 12, min: 5, max: 10));
		}

		[Test]
		public void ThrowIfNumberNotInRange_ValueInRange_ExceptionNotThrowed()
		{
			VkErrors.ThrowIfNumberNotInRange(value: 5, min: 2, max: 7);
			VkErrors.ThrowIfNumberNotInRange(value: 5, min: 5, max: 7);
			VkErrors.ThrowIfNumberNotInRange(value: 5, min: 2, max: 5);
		}
	}
}