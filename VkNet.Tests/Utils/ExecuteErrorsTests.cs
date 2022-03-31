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
			var exception = Assert.Throws<JsonSerializationException>(() => ExecuteErrorsHandler.GetExecuteExceptions(response));

			// Assert
			Assert.IsInstanceOf<JsonSerializationException>(exception);
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
			var exception = Assert.Throws<ArgumentException>(() => ExecuteErrorsHandler.GetExecuteExceptions(null));

			// Assert
			exception.ParamName.Should().Be("response");
			Assert.IsInstanceOf<ArgumentException>(exception);
		}
	}
}