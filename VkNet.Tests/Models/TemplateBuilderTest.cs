using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Template;
using VkNet.Model.Template.Carousel;

namespace VkNet.Tests.Models
{
	[TestFixture]
	internal class TemplateBuilderTest
	{
		[Test]
		public void CreateTemplate()
		{
			var builder = new TemplateBuilder();

			builder.AddTemplateElement(new CarouselElementBuilder().SetTitle("title")
				.SetDescription("test")
				.SetPhotoId("-123218_50548844")
				.SetAction(new CarouselElementAction()
				{
					Link = new Uri("https://google.com/"),
					Type = CarouselElementActionType.OpenLink
				})
				.AddButton("label", "")
				.Build());

			builder.SetType(TemplateType.Carousel);
			var template = builder.Build();

			TemplateType.Carousel.Should().Be(builder.Type);
			TemplateType.Carousel.Should().Be(template.Type);
		}

		[Test]
		public void PartialTemplate()
		{
			var builder = new TemplateBuilder();

			builder.AddTemplateElement(new CarouselElementBuilder()
				.SetTitle("title")
				.Build());

			builder.Elements.First().Title.Should().Be("title");
		}

		[Test]
		public void ClearElements()
		{
			var builder = new TemplateBuilder();

			builder.AddTemplateElement(new CarouselElementBuilder()
				.SetTitle("title")
				.Build());

			builder.ClearElements();
			builder.Elements.Should().BeEmpty();
		}

		[Test]
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
}