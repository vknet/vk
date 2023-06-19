using System;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class CarouselBuilderTests
{
	private const string Payload =
		"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

	[Fact]
	public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
	{
		var builder = new CarouselElementBuilder();

		FluentActions.Invoking(() => builder.AddButton("Button", Payload + Payload))
			.Should()
			.ThrowExactly<VkKeyboardPayloadMaxLengthException>();
	}

	[Fact]
	public void AddButton_PayloadMaxLength255_Success()
	{
		var builder = new CarouselElementBuilder();

		FluentActions.Invoking(() => builder.AddButton("Button", Payload))
			.Should()
			.NotThrow();
	}

	[Fact]
	public void CreateCarousel()
	{
		var builder = new CarouselElementBuilder();
		var uri = new Uri("https://google.com/");
		var carouselType = CarouselElementActionType.OpenLink;
		const string description = "testdescription";
		const string photoId = "-123218_50548844";
		const string title = "testtitle";
		const string buttonLabel = "label";
		const string buttonPayload = "payload";
		var buttonColor = KeyboardButtonColor.Default;
		const string buttonType = "button";

		builder.SetAction(new()
		{
			Link = uri,
			Type = carouselType
		});

		builder.SetDescription(description);
		builder.SetPhotoId(photoId);
		builder.SetTitle(title);
		builder.AddButton(buttonLabel, buttonPayload, buttonColor, buttonType);
		var carousel = builder.Build();

		uri.Should()
			.Be(builder.Action.Link);

		carouselType.Should()
			.Be(builder.Action.Type);

		description.Should()
			.Be(builder.Description);

		title.Should()
			.Be(builder.Title);

		photoId.Should()
			.Be(builder.PhotoId);

		uri.Should()
			.Be(carousel.Action.Link);

		carouselType.Should()
			.Be(carousel.Action.Type);

		description.Should()
			.Be(carousel.Description);

		title.Should()
			.Be(carousel.Title);

		photoId.Should()
			.Be(carousel.PhotoId);
	}

	[Fact]
	public void ClearButtons()
	{
		var builder = new CarouselElementBuilder();
		builder.AddButton("label", "");
		builder.ClearButtons();

		builder.Buttons.Should()
			.BeEmpty();
	}
}