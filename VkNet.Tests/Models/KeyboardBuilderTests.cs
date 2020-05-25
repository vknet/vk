using NUnit.Framework;
using System.Linq;
using VkNet.Exception;
using VkNet.Model.Keyboard;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class KeyboardBuilderTests
	{
		private const char Filler = '0';

		private static readonly string Payload200 = string.Join("", Enumerable.Repeat(Filler, 200));

		[Test]
		public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			var exception = Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", Payload200 + Payload200));

			// Assert
			var currentPayload = $"{{\"button\":\"{Payload200 + Payload200}\"}}";
			Assert.AreEqual(string.Format(KeyboardBuilder.ButtonPayloadLengthExceptionTemplate, currentPayload), exception.Message);
		}

		[Test]
		public void AddButton_PayloadMaxLength255_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act

			// Assert
			Assert.DoesNotThrow(() => builder.AddButton("Button", Payload200));
		}

		[Test]
		public void AddLine_MaxButtonLines_VkKeyboardMaxButtonsException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			for (int i = 0; i < KeyboardBuilder.MaxButtonLines; i++)
			{
				builder.AddLine();
			}

			// Assert
			var exception = Assert.Throws<VkKeyboardMaxButtonsException>(() => builder.AddLine());
			Assert.AreEqual(KeyboardBuilder.MaxButtonLinesExceptionTemplate, exception.Message);
		}

		[Test]
		public void AddLine_MaxButtonLines_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			for (int i = 0; i < KeyboardBuilder.MaxButtonLines - 1; i++)
			{
				builder.AddLine();
			}

			// Assert
			Assert.DoesNotThrow(() => builder.AddLine());
		}

		[Test]
		public void AddButton_MaxButtonsPerLine_VkKeyboardMaxButtonsException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			for (int i = 0; i < KeyboardBuilder.MaxButtonsPerLine; i++)
			{
				builder.AddButton("sample label", "sample extra");
			}

			// Assert
			var exception = Assert.Throws<VkKeyboardMaxButtonsException>(() => builder.AddButton("sample label", "sample extra"));
			Assert.AreEqual(KeyboardBuilder.MaxButtonsPerLineExceptionTemplate, exception.Message);
		}

		[Test]
		public void AddButton_MaxButtonsPerLine_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			for (int i = 0; i < KeyboardBuilder.MaxButtonsPerLine - 1; i++)
			{
				builder.AddButton("sample label", "sample extra");
			}

			// Assert
			Assert.DoesNotThrow(() => builder.AddButton("sample label", "sample extra"));
		}

		[Test]
		public void Build_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			builder.AddButton("Button", Payload200)
				.AddButton("Button", Payload200)
				.AddLine()
				.AddButton("Button", Payload200)
				.AddButton("Button", Payload200);

			// Assert
			var exception = Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", Payload200));
			Assert.AreEqual(KeyboardBuilder.SumPayloadLengthExceptionTemplate, exception.Message);
		}

		[Test]
		public void Build_PayloadMaxLength255_Success()
		{
			// Arrange
			var builder = new KeyboardBuilder();

			// Act
			builder.AddButton("Button", Payload200)
				.AddLine()
				.AddButton("Button", Payload200);

			// Assert
			Assert.DoesNotThrow(() => builder.Build());
		}
	}
}