
using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Template;
using VkNet.Model.Template.Carousel;

namespace VkNet.Tests.Models
{
	[TestFixture]
	class TemplateBuilderTest
	{
		[Test]
		public void CreateTemplate()
		{
			var builder = new TemplateBuilder();
			builder.AddTemplateElement(
				new CarouselElementBuilder().
					SetTitle("title")
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

			Assert.AreEqual(builder.Type, TemplateType.Carousel);
			Assert.AreEqual(template.Type, TemplateType.Carousel);
		}

		[Test]
		public void PartialTemplate()
		{
			var builder = new TemplateBuilder();

			builder.AddTemplateElement(new CarouselElementBuilder()
				.SetTitle("title")
				.Build());
			Assert.AreEqual(builder.Elements.First().Title, "title");
		}

		[Test]
		public void ClearElements()
		{
			var builder = new TemplateBuilder();

			builder.AddTemplateElement(new CarouselElementBuilder()
				.SetTitle("title")
				.Build());

			builder.ClearElements();
			Assert.AreEqual(builder.Elements.Count, 0);
		}
	}
}
