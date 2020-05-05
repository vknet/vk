using System;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Template.Carousel;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class CarouselBuilderTests
	{
		private const string Payload =
			"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

		[Test]
		public void AddButton_PayloadMaxLength255_VkKeyboardPayloadMaxLengthException()
		{
			var builder = new CarouselElementBuilder();

			Assert.Throws<VkKeyboardPayloadMaxLengthException>(() => builder.AddButton("Button", Payload + Payload));
		}

		[Test]
		public void AddButton_PayloadMaxLength255_Success()
		{
			var builder = new CarouselElementBuilder();

			Assert.DoesNotThrow(() => builder.AddButton("Button", Payload));
		}

		[Test]
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

			builder.SetAction(new CarouselElementAction
			{
				Link = uri,
				Type = carouselType
			});
			builder.SetDescription(description);
			builder.SetPhotoId(photoId);
			builder.SetTitle(title);
			builder.AddButton(buttonLabel, buttonPayload, buttonColor, buttonType);
			var carousel = builder.Build();

			Assert.AreEqual(builder.Action.Link, uri);
			Assert.AreEqual(builder.Action.Type, carouselType);
			Assert.AreEqual(builder.Description, description);
			Assert.AreEqual(builder.Title, title);
			Assert.AreEqual(builder.PhotoId, photoId);

			Assert.AreEqual(carousel.Action.Link, uri);
			Assert.AreEqual(carousel.Action.Type, carouselType);
			Assert.AreEqual(carousel.Description, description);
			Assert.AreEqual(carousel.Title, title);
			Assert.AreEqual(carousel.PhotoId, photoId);
		}

		[Test]
		public void ClearButtons()
		{
			var builder = new CarouselElementBuilder();
			builder.AddButton("label", "");
			builder.ClearButtons();
			Assert.AreEqual(builder.Buttons.Count, 0);
		}
	}
}
