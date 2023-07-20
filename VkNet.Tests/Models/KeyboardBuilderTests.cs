using System.Linq;
using FluentAssertions;
using VkNet.Exception;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class KeyboardBuilderTests
{
	private const char Filler = '0';

	private static readonly string Payload200 = string.Join("", Enumerable.Repeat(Filler, 200));

	[Fact]
	public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
	{
		// Arrange
		var builder = new KeyboardBuilder();
		var currentPayload = $"{{\"button\":\"{Payload200 + Payload200}\"}}";

		// Assert
		FluentActions.Invoking(() => builder.AddButton("Button", Payload200 + Payload200))
			.Should()
			.ThrowExactly<VkKeyboardPayloadMaxLengthException>()
			.And.Message.Should()
			.Be(string.Format(KeyboardBuilder.ButtonPayloadLengthExceptionTemplate, currentPayload));
	}

	[Fact]
	public void AddButton_PayloadMaxLength255_Success()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act

		// Assert
		FluentActions.Invoking(() => builder.AddButton("Button", Payload200))
			.Should()
			.NotThrow();
	}

	[Fact]
	public void AddLine_MaxButtonLines_VkKeyboardMaxButtonsException()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		for (var i = 0; i < KeyboardBuilder.MaxButtonLines; i++)
		{
			builder.AddLine();
		}

		// Assert
		FluentActions.Invoking(() => builder.AddLine())
			.Should()
			.ThrowExactly<VkKeyboardMaxButtonsException>()
			.And.Message.Should()
			.Be(KeyboardBuilder.MaxButtonLinesExceptionTemplate);
	}

	[Fact]
	public void AddLine_MaxButtonLines_Success()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		for (var i = 0; i < KeyboardBuilder.MaxButtonLines - 1; i++)
		{
			builder.AddLine();
		}

		// Assert
		FluentActions.Invoking(() => builder.AddLine())
			.Should()
			.NotThrow();
	}

	[Fact]
	public void AddButton_MaxButtonsPerLine_VkKeyboardMaxButtonsException()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		for (var i = 0; i < KeyboardBuilder.MaxButtonsPerLine; i++)
		{
			builder.AddButton("sample label", "sample extra");
		}

		// Assert
		FluentActions.Invoking(() => builder.AddButton("sample label", "sample extra"))
			.Should()
			.ThrowExactly<VkKeyboardMaxButtonsException>()
			.And.Message.Should()
			.Be(KeyboardBuilder.MaxButtonsPerLineExceptionTemplate);
	}

	[Fact]
	public void AddButton_MaxButtonsPerLine_Success()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		for (var i = 0; i < KeyboardBuilder.MaxButtonsPerLine - 1; i++)
		{
			builder.AddButton("sample label", "sample extra");
		}

		// Assert
		FluentActions.Invoking(() => builder.AddButton("sample label", "sample extra"))
			.Should()
			.NotThrow();
	}

	[Fact]
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
		FluentActions.Invoking(() => builder.AddButton("Button", Payload200))
			.Should()
			.ThrowExactly<VkKeyboardPayloadMaxLengthException>()
			.And.Message.Should()
			.Be(KeyboardBuilder.SumPayloadLengthExceptionTemplate);
	}

	[Fact]
	public void Build_PayloadMaxLength255_Success()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		builder.AddButton("Button", Payload200)
			.AddLine()
			.AddButton("Button", Payload200);

		// Assert
		FluentActions.Invoking(() => builder.Build())
			.Should()
			.NotThrow();
	}

	[Fact]
	public void Build_MaxButtonLines_VkKeyboardMaxButtonsException()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		for (var i = 0; i < KeyboardBuilder.MaxButtonLines; i++)
		{
			builder.AddLine();
		}

		// Assert
		FluentActions.Invoking(() =>
			{
				builder.AddLine();
				builder.Build();
			})
			.Should()
			.ThrowExactly<VkKeyboardMaxButtonsException>()
			.And.Message.Should()
			.Be(KeyboardBuilder.MaxButtonLinesExceptionTemplate);
	}

	[Fact]
	public void Build_MaxButtonLines_Success()
	{
		// Arrange
		var builder = new KeyboardBuilder();

		// Act
		for (var i = 0; i < KeyboardBuilder.MaxButtonLines; i++)
		{
			builder.AddLine();
		}

		// Assert
		FluentActions.Invoking(() => builder.Build())
			.Should()
			.NotThrow();
	}
}