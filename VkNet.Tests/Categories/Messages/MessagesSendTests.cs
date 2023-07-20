using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using VkNet.Categories;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesSendTests : MessagesBaseTests
{
	[Fact]
	public void AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var cat = new MessagesCategory(new VkApi());

		FluentActions.Invoking(() => cat.Send(new()
			{
				UserId = 1,
				Message = "Привет, Паша!",
				RandomId = 1
			}))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void CoordsMessage()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(CoordsMessage));

		var id = Api.Messages.Send(new()
		{
			UserId = 7550525,
			Message = "г. Таганрог, ул. Фрунзе 66А",
			Lat = 47.217451,
			Longitude = 38.922743,
			RandomId = 1
		});

		id.Should()
			.Be(4464);
	}

	[Fact]
	public void DefaultFields_MessageId()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(DefaultFields_MessageId));

		var id = Api.Messages.Send(new()
		{
			UserId = 7550525,
			Message = "Test from vk.net ;) # 2",
			RandomId = 1
		});

		id.Should()
			.Be(4457);
	}

	[Fact]
	public void EmptyMessage_ThrowsInvalidParameterException() => FluentActions.Invoking(() => Api.Messages.Send(new()
		{
			UserId = 7550525,
			Message = ""
		}))
		.Should()
		.ThrowExactly<ArgumentException>();

	[Fact]
	public void Exception_MessageIsTooLong()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadErrorsJsonFile(914);

		FluentActions.Invoking(() => Api.Messages.Send(new()
			{
				UserId = 7550525,
				Message = "г. Таганрог, ул. Фрунзе 66А",
				Lat = 47.217451,
				Longitude = 38.922743,
				RandomId = 1
			}))
			.Should()
			.ThrowExactly<MessageIsTooLongException>();
	}

	[Fact]
	public void Exception_TooMuchSentMessages()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadErrorsJsonFile(913);

		FluentActions.Invoking(() => Api.Messages.Send(new()
			{
				UserId = 7550525,
				Message = "г. Таганрог, ул. Фрунзе 66А",
				Lat = 47.217451,
				Longitude = 38.922743,
				RandomId = 1
			}))
			.Should()
			.ThrowExactly<TooMuchSentMessagesException>();
	}

	[Fact]
	public void MessagesSend_RandomIdNotRequiredInLessThan_5_90_ArgumentException()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSend_RandomIdNotRequiredInLessThan_5_90_ArgumentException));

		Api.VkApiVersion.SetVersion(5, 88);

		var id = Api.Messages.Send(new()
		{
			UserId = 7550525,
			Message = "Работает # 2 --  еще разок"
		});

		id.Should()
			.Be(4464);
	}

	[Fact]
	public void MessagesSend_RandomIdRequired_ArgumentException()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSend_RandomIdRequired_ArgumentException));

		FluentActions.Invoking(() => Api.Messages.Send(new()
			{
				UserIds = new List<long>
				{
					7550525
				},
				Message = "г. Таганрог, ул. Фрунзе 66А",
				Lat = 47.217451,
				Longitude = 38.922743
			}))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void MessagesSend_SetUserIdsParam_ArgumentException()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSend_SetUserIdsParam_ArgumentException));

		FluentActions.Invoking(() => Api.Messages.Send(new()
			{
				UserIds = new List<long>
				{
					7550525
				},
				Message = "г. Таганрог, ул. Фрунзе 66А",
				Lat = 47.217451,
				Longitude = 38.922743
			}))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void MessagesSendToUserIds_NoSetUserIdsParam_ArrayResult()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSendToUserIds_NoSetUserIdsParam_ArrayResult));

		var result = Api.Messages.SendToUserIds(new()
		{
			UserIds = new List<long>
			{
				7550525
			},
			Message = "г. Таганрог, ул. Фрунзе 66А",
			Lat = 47.217451,
			Longitude = 38.922743
		});

		result.Should()
			.NotBeEmpty();

		var message = result.FirstOrDefault();

		message.Should()
			.NotBeNull();

		message.PeerId.Should()
			.Be(32190123);

		message.MessageId.Should()
			.Be(210525);
	}

	[Fact]
	public void MessagesSendToPeerIds_NoSetPeerIdsParam_ArrayResult()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSendToPeerIds_NoSetPeerIdsParam_ArrayResult));

		FluentActions.Invoking(() => Api.Messages.Send(new()
		{
			Message = "г. Таганрог, ул. Фрунзе 66А",
			Lat = 47.217451,
			Longitude = 38.922743
		}))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void MessagesSendToPeerIds_SetUserIdsParam_ArrayResult()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSendToPeerIds_SetUserIdsParam_ArrayResult));

		FluentActions.Invoking(() => Api.Messages.Send(new()
		{
			UserIds = new List<long>
			{
				7550525
			},
			Message = "г. Таганрог, ул. Фрунзе 66А",
			Lat = 47.217451,
			Longitude = 38.922743
		}))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void MessagesSendToPeerIds_SetPeerIdParam_ArrayResult()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSendToPeerIds_SetPeerIdParam_ArrayResult));

		FluentActions.Invoking(() => Api.Messages.Send(new()
		{
			PeerId = 7550525,
			Message = "г. Таганрог, ул. Фрунзе 66А",
			Lat = 47.217451,
			Longitude = 38.922743
		}))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void MessagesSendToPeerIds_Send_ArrayResult()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(MessagesSendToPeerIds_Send_ArrayResult));

		var result = Api.Messages.SendToPeerIds(new()
		{
			PeerIds = new List<long>
			{
				7550525
			},
			Message = "г. Таганрог, ул. Фрунзе 66А",
			Lat = 47.217451,
			Longitude = 38.922743
		});

		result.Should()
			.NotBeEmpty();

		var message = result.FirstOrDefault();

		message.Should()
			.NotBeNull();

		message.PeerId.Should()
			.Be(32190123);

		message.MessageId.Should()
			.Be(210525);
	}

	[Fact]
	public void RussianText_MessageId()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(RussianText_MessageId));

		var id = Api.Messages.Send(new()
		{
			UserId = 7550525,
			Message = "Работает # 2 --  еще разок",
			RandomId = 1
		});

		id.Should()
			.Be(4464);
	}

	[Fact]
	public void Template_Carousel()
	{
		Url = "https://api.vk.com/method/messages.send";
		ReadCategoryJsonPath(nameof(Template_Carousel));

		var button = new MessageKeyboardButton
		{
			Color = KeyboardButtonColor.Primary,
			Action = new()
			{
				Type = KeyboardButtonActionType.Text,
				Label = "Label"
			}
		};

		var buttons = new[]
		{
			button
		};

		var carouselAction = new CarouselElementAction
		{
			Link = new("https://vk.com/"),
			Type = CarouselElementActionType.OpenLink
		};

		var carousel = new CarouselElement
		{
			Description = "Desc",
			Action = carouselAction,
			Buttons = buttons,
			PhotoId = "-126102803_425491011",
			Title = "Title"
		};

		var templateElements = new[]
		{
			carousel
		};

		var template = new MessageTemplate
		{
			Type = TemplateType.Carousel,
			Elements = templateElements
		};

		var id = Api.Messages.Send(new()
		{
			UserId = 7550525,
			Message = "Работает # 2 --  еще разок",
			RandomId = 1,
			Template = template
		});

		id.Should()
			.Be(4464);
	}
}