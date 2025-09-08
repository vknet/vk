using System;
using AwesomeAssertions;
using VkNet.Exception;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

public class VkErrorsTest : BaseTest
{
	[Fact(DisplayName = "Call throws impossible to compile code 12")]
	public void Call_ThrowsImpossibleToCompileCode_12()
	{
		Url = "https://api.vk.ru/method/execute";
		ReadErrorsJsonFile(12);

		FluentActions.Invoking(() =>
				Api.Call("execute", VkParameters.Empty, true))
			.Should()
			.ThrowExactly<ImpossibleToCompileCodeException>();
	}

	[Fact(DisplayName = "Call throws post limit exception")]
	public void Call_ThrowsPostLimitException()
	{
		Url = "https://api.vk.ru/method/messages.send";
		ReadErrorsJsonFile(214);

		FluentActions.Invoking(() =>
				Api.Call("messages.send", VkParameters.Empty, true))
			.Should()
			.ThrowExactly<PostLimitException>();
	}

	[Fact(DisplayName = "Call throws post limit exception 103")]
	public void Call_ThrowsPostLimitException_103()
	{
		Url = "https://api.vk.ru/method/messages.send";
		ReadErrorsJsonFile(103);

		FluentActions.Invoking(() =>
				Api.Call("messages.send", VkParameters.Empty, true))
			.Should()
			.ThrowExactly<OutOfLimitsException>();
	}

	[Fact(DisplayName = "If error throw exception group access denied throw access denied exception")]
	public void IfErrorThrowException_GroupAccessDenied_ThrowAccessDeniedException()
	{
		Url = "https://api.vk.ru/method/messages.send";
		ReadErrorsJsonFile(260);

		FluentActions.Invoking(() => Api.Call("messages.send", VkParameters.Empty, true))
			.Should()
			.ThrowExactly<GroupsListAccessDeniedException>()
			.And.Message.Should()
			.BeEquivalentTo("Access to the groups list is denied due to the user privacy settings.");
	}

	[Fact(DisplayName = "If error throw exception normal case nothing exceptions")]
	public void IfErrorThrowException_NormalCase_NothingExceptions()
	{
		Url = "https://api.vk.ru/method/messages.send";
		var json = ReadJson("VkErrors", nameof(IfErrorThrowException_NormalCase_NothingExceptions));

		VkErrors.IfErrorThrowException(json);
	}

	[Fact(DisplayName = "If error throw exception user authorization fail throw user authorization fail exception")]
	public void IfErrorThrowException_UserAuthorizationFail_ThrowUserAuthorizationFailException()
	{
		Url = "https://api.vk.ru/method/messages.send";
		ReadErrorsJsonFile(5);

		var ex = FluentActions.Invoking(() => Api.Call("messages.send", VkParameters.Empty, true))
			.Should()
			.ThrowExactly<UserAuthorizationFailException>()
			.And;

		ex.Message.Should()
			.Be("User authorization failed: access_token was given to another ip address.");

		ex.ErrorCode.Should()
			.Be(5);
	}

	[Fact(DisplayName = "If error throw exception wrong json throw vk api exception")]
	public void IfErrorThrowException_WrongJson_ThrowVkApiException()
	{
		const string json = "ThisIsNotJson";

		FluentActions.Invoking(() => VkErrors.IfErrorThrowException(json))
			.Should()
			.ThrowExactly<VkApiException>()
			.And.Message.Should()
			.Be("Wrong json data.");
	}

	[Fact(DisplayName = "Throw if number is negative expression version long")]
	public void ThrowIfNumberIsNegative_ExpressionVersion_Long()
	{
		const long paramName = -1;

		FluentActions.Invoking(() => VkErrors.ThrowIfNumberIsNegative(() => paramName))
			.Should()
			.ThrowExactly<ArgumentException>()
			.And.Message.Should()
			.StartWith("Отрицательное значение.");
	}

	[Fact(DisplayName = "Throw if number is negative expression version nullable long")]
	public void ThrowIfNumberIsNegative_ExpressionVersion_NullableLong()
	{
		long? param = -1;

		var ex = FluentActions.Invoking(() => VkErrors.ThrowIfNumberIsNegative(() => param))
			.Should()
			.ThrowExactly<ArgumentException>()
			.And;

		ex.Message.Should()
			.StartWith("Отрицательное значение.");

		ex.Message.Should()
			.Contain("param");
	}

	[Fact(DisplayName = "Throw if number is negative inner test class throw exception")]
	public void ThrowIfNumberIsNegative_InnerTestClass_ThrowException()
	{
		var cls = new TestClass();

		FluentActions.Invoking(() => cls.Execute(-2))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact(DisplayName = "Throw if number not in range less then min throws exception")]
	public void ThrowIfNumberNotInRange_LessThenMin_ThrowsException() => FluentActions
		.Invoking(() => VkErrors.ThrowIfNumberNotInRange(2, 5, 10))
		.Should()
		.ThrowExactly<ArgumentOutOfRangeException>();

	[Fact(DisplayName = "Throw if number not in range more than max throws exception")]
	public void ThrowIfNumberNotInRange_MoreThanMax_ThrowsException() => FluentActions
		.Invoking(() => VkErrors.ThrowIfNumberNotInRange(12, 5, 10))
		.Should()
		.ThrowExactly<ArgumentOutOfRangeException>();

	[Fact(DisplayName = "Throw if number not in range value in range exception not throwed")]
	public void ThrowIfNumberNotInRange_ValueInRange_ExceptionNotThrowed()
	{
		FluentActions.Invoking(() => VkErrors.ThrowIfNumberNotInRange(5, 2, 7))
			.Should()
			.NotThrow();

		FluentActions.Invoking(() => VkErrors.ThrowIfNumberNotInRange(5, 5, 7))
			.Should()
			.NotThrow();

		FluentActions.Invoking(() => VkErrors.ThrowIfNumberNotInRange(5, 2, 5))
			.Should()
			.NotThrow();
	}

	private class TestClass
	{
		public void Execute(int count) => VkErrors.ThrowIfNumberIsNegative(() => count);
	}
}