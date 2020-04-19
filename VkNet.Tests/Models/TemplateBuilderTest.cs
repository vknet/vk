
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
			builder.AddTemplateElement(new CarouselElementBuilder().SetTitle("title").Build());
			builder.SetType(TemplateType.Carousel);
			var template = builder.Build();

			Assert.AreEqual(builder.Type, TemplateType.Carousel);
			Assert.AreEqual(template.Type, TemplateType.Carousel);
		}
	}
}
