using System;
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
			Assert.AreEqual(3, ex.InnerExceptions.Count);
		}

		[Test]
		public void IfResponseIsEmptyThen_ThrowArgumentException()
		{
			// Act
			var exception = Assert.Throws<ArgumentException>(() => ExecuteErrorsHandler.GetExecuteExceptions(null));

			// Assert
			Assert.AreEqual("response", exception.ParamName);
			Assert.IsInstanceOf<ArgumentException>(exception);
		}
	}
}