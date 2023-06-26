using System.Linq;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class TemplateBuilderTest
{
	[Fact]
	public void CreateTemplate()
	{
		var builder = new TemplateBuilder();

		builder.AddTemplateElement(new CarouselElementBuilder().SetTitle("title")
			.SetDescription("test")
			.SetPhotoId("-123218_50548844")
			.SetAction(new()
			{
				Link = new("https://google.com/"),
				Type = CarouselElementActionType.OpenLink
			})
			.AddButton("label", "")
			.Build());

		builder.SetType(TemplateType.Carousel);
		var template = builder.Build();

		TemplateType.Carousel.Should()
			.Be(builder.Type);

		TemplateType.Carousel.Should()
			.Be(template.Type);
	}

	[Fact]
	public void PartialTemplate()
	{
		var builder = new TemplateBuilder();

		builder.AddTemplateElement(new CarouselElementBuilder()
			.SetTitle("title")
			.Build());

		builder.Elements.First()
			.Title.Should()
			.Be("title");
	}

	[Fact]
	public void ClearElements()
	{
		var builder = new TemplateBuilder();

		builder.AddTemplateElement(new CarouselElementBuilder()
			.SetTitle("title")
			.Build());

		builder.ClearElements();

		builder.Elements.Should()
			.BeEmpty();
	}

	[Fact]
	public void TheNumberOfElementsIsMoreThan10()
	{
		var builder = new TemplateBuilder();

		for (var i = 0; i < 10; i++)
		{
			builder.AddTemplateElement(new CarouselElementBuilder()
				.SetTitle("title")
				.Build());
		}

		FluentActions.Invoking(() =>
				builder.AddTemplateElement(new CarouselElementBuilder()
					.SetTitle("title")
					.Build()))
			.Should()
			.ThrowExactly<TooMuchElementsInTemplateException>();
	}
}