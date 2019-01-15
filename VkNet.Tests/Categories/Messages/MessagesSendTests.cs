using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesSendTests : MessagesBaseTests
	{
		[Test]
		public void AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var cat = new MessagesCategory(new VkApi());

			Assert.That(() => cat.Send(new MessagesSendParams
				{
					UserId = 1,
					Message = "Привет, Паша!",
					RandomId = 1
				}),
				Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void CoordsMessage()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(CoordsMessage));

			var id = Api.Messages.Send(new MessagesSendParams
			{
				UserId = 7550525, Message = "г. Таганрог, ул. Фрунзе 66А", Lat = 47.217451, Longitude = 38.922743,
				RandomId = 1
			});

			Assert.That(id, Is.EqualTo(4464));
		}

		[Test]
		public void DefaultFields_MessageId()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(DefaultFields_MessageId));

			var id = Api.Messages.Send(new MessagesSendParams
			{
				UserId = 7550525, Message = "Test from vk.net ;) # 2",
				RandomId = 1
			});

			Assert.That(id, Is.EqualTo(4457));
		}

		[Test]
		public void EmptyMessage_ThrowsInvalidParameterException()
		{
			Assert.That(() => Api.Messages.Send(new MessagesSendParams
				{
					UserId = 7550525, Message = ""
				}),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void Exception_MessageIsTooLong()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(914);

			Assert.That(() => Api.Messages.Send(new MessagesSendParams
				{
					UserId = 7550525, Message = "г. Таганрог, ул. Фрунзе 66А", Lat = 47.217451, Longitude = 38.922743,
					RandomId = 1
				}),
				Throws.InstanceOf<MessageIsTooLongException>());
		}

		[Test]
		public void Exception_TooMuchSentMessages()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(913);

			Assert.That(() => Api.Messages.Send(new MessagesSendParams
				{
					UserId = 7550525, Message = "г. Таганрог, ул. Фрунзе 66А", Lat = 47.217451, Longitude = 38.922743,
					RandomId = 1
				}),
				Throws.InstanceOf<TooMuchSentMessagesException>());
		}

		[Test]
		public void MessagesSend_SetUserIdsParam_ArgumentException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(MessagesSend_SetUserIdsParam_ArgumentException));

			Assert.That(() => Api.Messages.Send(new MessagesSendParams
				{
					UserIds = new List<long> { 7550525 }, Message = "г. Таганрог, ул. Фрунзе 66А", Lat = 47.217451, Longitude = 38.922743
				}),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void MessagesSendToUserIds_NoSetUserIdsParam_ArrayResult()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(MessagesSendToUserIds_NoSetUserIdsParam_ArrayResult));

			var result = Api.Messages.SendToUserIds(new MessagesSendParams
			{
				UserIds = new List<long> { 7550525 }, Message = "г. Таганрог, ул. Фрунзе 66А", Lat = 47.217451, Longitude = 38.922743
			});

			Assert.IsNotEmpty(result);
			var message = result.FirstOrDefault();
			Assert.NotNull(message);
			Assert.AreEqual(32190123, message.PeerId);
			Assert.AreEqual(210525, message.MessageId);
		}

		[Test]
		public void RussianText_MessageId()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(RussianText_MessageId));

			var id = Api.Messages.Send(new MessagesSendParams
			{
				UserId = 7550525, Message = "Работает # 2 --  еще разок",
				RandomId = 1
			});

			Assert.That(id, Is.EqualTo(4464));
		}

		[Test]
		public void MessagesSend_RandomIdRequired_ArgumentException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(MessagesSend_RandomIdRequired_ArgumentException));

			Assert.That(() => Api.Messages.Send(new MessagesSendParams
				{
					UserIds = new List<long> { 7550525 }, Message = "г. Таганрог, ул. Фрунзе 66А", Lat = 47.217451, Longitude = 38.922743
				}),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void MessagesSend_RandomIdNotRequiredInLessThan_5_90_ArgumentException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadCategoryJsonPath(nameof(MessagesSend_RandomIdNotRequiredInLessThan_5_90_ArgumentException));

			Api.VkApiVersion.SetVersion(5, 88);

			var id = Api.Messages.Send(new MessagesSendParams
			{
				UserId = 7550525, Message = "Работает # 2 --  еще разок"
			});

			Assert.That(id, Is.EqualTo(4464));
		}
	}
}