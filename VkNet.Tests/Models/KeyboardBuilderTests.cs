using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.Keyboard;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class KeyboardBuilderTests
	{
		const string payload =
			"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

		[Test]
		public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			var exception = Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", payload + payload));

			// Assert
			var currentPayload = $"{{\"button\":\"{payload + payload}\"}}";
			Assert.AreEqual(string.Format(KeyboardBuilder.ButtonPayloadLengthExceptionTemplate, currentPayload), exception.Message);
		}

		[Test]
		public void AddButton_PayloadMaxLength255_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act

			// Assert
			Assert.DoesNotThrow(() => builder.AddButton("Button", payload));
		}

		[Test]
		public void Build_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			builder.AddButton("Button", payload)
				.AddButton("Button", payload)
				.AddLine()
				.AddButton("Button", payload)
				.AddButton("Button", payload);

			// Assert
			var exception = Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", payload));
			Assert.AreEqual(KeyboardBuilder.SumPayloadLengthExceptionTemplate, exception.Message);
		}

		[Test]
		public void Build_PayloadMaxLength255_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			builder.AddButton("Button", payload)
				.AddLine()
				.AddButton("Button", payload);

			// Assert
			Assert.DoesNotThrow(() => builder.Build());
		}
	}
}