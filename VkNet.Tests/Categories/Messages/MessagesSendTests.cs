using System;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{
    [TestFixture]
    public class MessagesSendTests : BaseTest
    {
        private MessagesCategory Messages => GetMockedMessagesCategory();

        private MessagesCategory GetMockedMessagesCategory()
        {
            return new MessagesCategory(Api);
        }


        [Test]
        public void AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            Assert.That(() => cat.Send(new MessagesSendParams {UserId = 1, Message = "Привет, Паша!"}),
                Throws.InstanceOf<AccessTokenInvalidException>());
        }

        [Test]
        public void DefaultFields_MessageId()
        {
            Url = "https://api.vk.com/method/messages.send";
            Json =
                @"{
					'response': 4457
				  }";

            var id = Messages.Send(new MessagesSendParams
            {
                UserId = 7550525,
                Message = "Test from vk.net ;) # 2"
            });
            Assert.That(id, Is.EqualTo(4457));
        }

        [Test]
        public void RussianText_MessageId()
        {
            Url = "https://api.vk.com/method/messages.send";
            Json =
                @"{
					'response': 4464
				  }";
            var id = Messages.Send(new MessagesSendParams
            {
                UserId = 7550525,
                Message = "Работает # 2 --  еще разок"
            });
            Assert.That(id, Is.EqualTo(4464));
        }

        [Test]
        public void EmptyMessage_ThrowsInvalidParameterException()
        {
            Assert.That(() => Messages.Send(new MessagesSendParams
            {
                UserId = 7550525,
                Message = ""
            }), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CoordsMessage()
        {
            Url = "https://api.vk.com/method/messages.send";
            Json = @"{
			    'response': 4464
			}";
            
            var id = Messages.Send(new MessagesSendParams
            {
                UserId = 7550525,
                Message = "г. Таганрог, ул. Фрунзе 66А",
                Lat = 47.217451,
                Longitude = 38.922743
            });
            
            Assert.That(id, Is.EqualTo(4464));
        }

        [Test]
        public void Exception_TooMuchSentMessages()
        {
            Url = "https://api.vk.com/method/messages.send";
            Json =
                @"{
					'error': {
					  'error_code': 913,
					  'error_msg': 'Unknown error occured',
					  'request_params': [
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";
            
            Assert.That(() => Messages.Send(new MessagesSendParams
            {
                UserId = 7550525,
                Message = "г. Таганрог, ул. Фрунзе 66А",
                Lat = 47.217451,
                Longitude = 38.922743
            }), Throws.InstanceOf<TooMuchSentMessagesException>());
        }

        [Test]
        public void Exception_MessageIsTooLong()
        {
            Url = "https://api.vk.com/method/messages.send";
            Json =
                @"{
					'error': {
					  'error_code': 914,
					  'error_msg': 'Unknown error occured',
					  'request_params': [
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";
            
            Assert.That(() => Messages.Send(new MessagesSendParams
            {
                UserId = 7550525,
                Message = "г. Таганрог, ул. Фрунзе 66А",
                Lat = 47.217451,
                Longitude = 38.922743
            }), Throws.InstanceOf<MessageIsTooLongException>());
        }
    }
}