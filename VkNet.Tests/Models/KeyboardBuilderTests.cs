using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model.Keyboard;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class KeyboardBuilderTests
	{
		private const string Payload =
			"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

		[Test]
		public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			var exception = Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", Payload + Payload));

			// Assert
			var currentPayload = $"{{\"button\":\"{Payload + Payload}\"}}";
			Assert.AreEqual(string.Format(KeyboardBuilder.ButtonPayloadLengthExceptionTemplate, currentPayload), exception.Message);
		}

		[Test]
		public void AddButton_PayloadMaxLength255_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act

			// Assert
			Assert.DoesNotThrow(() => builder.AddButton("Button", Payload));
		}

		[Test]
		public void Build_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			builder.AddButton("Button", Payload)
				.AddButton("Button", Payload)
				.AddLine()
				.AddButton("Button", Payload)
				.AddButton("Button", Payload);

			// Assert
			var exception = Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", Payload));
			Assert.AreEqual(KeyboardBuilder.SumPayloadLengthExceptionTemplate, exception.Message);
		}

		[Test]
		public void Build_PayloadMaxLength255_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			builder.AddButton("Button", Payload)
				.AddLine()
				.AddButton("Button", Payload);

			// Assert
			Assert.DoesNotThrow(() => builder.Build());
		}
	}
}