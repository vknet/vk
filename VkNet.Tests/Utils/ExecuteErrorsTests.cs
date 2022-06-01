using System;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	public class ExecuteErrorsTests : BaseTest
	{
		[Test]
		public void IfResponseContainInvalidJson_ThrowJsonException()
		{
			// Arrange
			var response = new VkResponse(new JRaw("{"));

			// Act
			FluentActions.Invoking(() => ExecuteErrorsHandler.GetExecuteExceptions(response))
				.Should()
				.ThrowExactly<JsonSerializationException>();
		}

		[Test]
		public void IfResponseContainsExecuteErrors_ThanReturnAggregateException()
		{
			// Arrange
			Url = "https://api.vk.com/method/execute";
			ReadJsonFile("Errors", nameof(ExecuteErrorsHandler));

			// Act
			var ex = ExecuteErrorsHandler.GetExecuteExceptions(Json);

			// Assert
			ex.InnerExceptions.Count.Should().Be(3);
		}

		[Test]
		public void IfResponseIsEmptyThen_ThrowArgumentException()
		{
			// Act
			FluentActions.Invoking(() => ExecuteErrorsHandler.GetExecuteExceptions(null))
				.Should()
				.ThrowExactly<ArgumentException>()
				.And.ParamName.Should()
				.Be("response");
		}
	}
}