using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]

	public class MessagesSendMessageEventAnswerTests : MessagesBaseTests
	{
		[Test]
		public void SendMessageEventAnswer()
		{
			Url = "https://api.vk.com/method/messages.sendMessageEventAnswer";
			ReadJsonFile(JsonPaths.True);
			var data = new EventData
			{
				Type = MessageEventType.SnowSnackbar,
				Text = "text"
			};

			var result = Api.Messages.SendMessageEventAnswer("testEventId", 1, 1, data);

			Assert.IsTrue(result);
		}
	}
}