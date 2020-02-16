using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
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
		public void Call_ThrowsImpossibleToCompileCode_12()
		{
			Url = "https://api.vk.com/method/execute";
			ReadErrorsJsonFile(12);

			Assert.Throws<ImpossibleToCompileCodeException>(() =>
				Api.Call("execute", VkParameters.Empty, true));
		}

		[Test]
		public void Call_ThrowsPostLimitException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(214);

			Assert.Throws<PostLimitException>(() =>
				Api.Call("messages.send", VkParameters.Empty, true));
		}

		[Test]
		public void Call_ThrowsPostLimitException_103()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(103);

			Assert.Throws<OutOfLimitsException>(() =>
				Api.Call("messages.send", VkParameters.Empty, true));
		}

		[Test]
		public void IfErrorThrowException_GroupAccessDenied_ThrowAccessDeniedException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(260);

			var ex = Assert.Throws<GroupsListAccessDeniedException>(() => Api.Call("messages.send", VkParameters.Empty, true));

			StringAssert.AreEqualIgnoringCase("Access to the groups list is denied due to the user privacy settings.", ex.Message);
		}

		[Test]
		public void IfErrorThrowException_NormalCase_NothingExceptions()
		{
			Url = "https://api.vk.com/method/messages.send";
			var json = ReadJson("VkErrors", nameof(IfErrorThrowException_NormalCase_NothingExceptions));

			VkErrors.IfErrorThrowException(json);
		}

		[Test]
		public void IfErrorThrowException_UserAuthorizationFail_ThrowUserAuthorizationFailException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(5);
			var ex = Assert.Throws<UserAuthorizationFailException>(() => Api.Call("messages.send", VkParameters.Empty, true));

			Assert.That(ex.Message, Is.EqualTo("User authorization failed: access_token was given to another ip address."));
			Assert.That(ex.ErrorCode, Is.EqualTo(5));
		}

		[Test]
		public void IfErrorThrowException_WrongJson_ThrowVkApiException()
		{
			const string json = "ThisIsNotJson";
			var ex = Assert.Throws<VkApiException>(() => VkErrors.IfErrorThrowException(json));

			Assert.That(ex.Message, Is.EqualTo("Wrong json data."));
		}

		[Test]
		public void ThrowIfNumberIsNegative_ExpressionVersion_Long()
		{
			const long paramName = -1;

			var ex = Assert.Throws<ArgumentException>(() => VkErrors.ThrowIfNumberIsNegative(() => paramName));
			StringAssert.StartsWith("Отрицательное значение.", ex.Message);
		}

		[Test]
		public void ThrowIfNumberIsNegative_ExpressionVersion_NullableLong()
		{
			long? param = -1;
			var ex = Assert.Throws<ArgumentException>(() => VkErrors.ThrowIfNumberIsNegative(() => param));

			StringAssert.StartsWith("Отрицательное значение.", ex.Message);
			StringAssert.Contains("param", ex.Message);
		}

		[Test]
		public void ThrowIfNumberIsNegative_InnerTestClass_ThrowException()
		{
			var cls = new TestClass();
			Assert.Throws<ArgumentException>(() => cls.Execute(-2));
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
	}
}