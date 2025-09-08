using System.Linq;
using AwesomeAssertions;
using VkNet.Exception;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class KeyboardBuilderTests
{
	private const char Filler = '0';

	private static readonly string Payload200 = string.Join("", Enumerable.Repeat(Filler, 200));

	[Fact(DisplayName = "Label min length255 vk keyboard label min length exception")]
	public void LabelMinLength255_VkKeyboardLabelMinLengthException()
	{
		// Arrange
		var builder = new KeyboardBuilder();
		const string label = "";

		// Assert
		FluentActions.Invoking(() => builder.AddButton("", Payload200))
			.Should()
			.ThrowExactly<VkKeyboardLabelMinLengthException>()
			.And.Message.Should()
			.Be(string.Format(KeyboardBuilder.MinLabelLengthExceptionTemplate, label));
	}

	[Fact(DisplayName = "Add button payload max length255 vk keyboard payload max length exception")]
	public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
	{
		// Arrange
		var builder = new KeyboardBuilder();
		var currentPayload = $"{{\"b\":\"{Payload200 + Payload200}\"}}";

		// Assert
		FluentActions.Invoking(() => builder.AddButton("Button", Payload200 + Payload200))
			.Should()
			.ThrowExactly<VkKeyboardPayloadMaxLengthException>()
			.And.Message.Should()
			.Be(string.Format(KeyboardBuilder.ButtonPayloadLengthExceptionTemplate, currentPayload));
	}

	[Fact(DisplayName = "Add button payload max length255 success")]
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

	[Fact(DisplayName = "Add line max button lines vk keyboard max buttons exception")]
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

	[Fact(DisplayName = "Add line max button lines success")]
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

	[Fact(DisplayName = "Add button max buttons per line vk keyboard max buttons exception")]
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

	[Fact(DisplayName = "Add button max buttons per line success")]
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

	[Fact(DisplayName = "Build payload max length255 vk keyboard payload max length exception")]
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

	[Fact(DisplayName = "Build payload max length255 success")]
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

	[Fact(DisplayName = "Build max button lines vk keyboard max buttons exception")]
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

	[Fact(DisplayName = "Build max button lines success")]
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