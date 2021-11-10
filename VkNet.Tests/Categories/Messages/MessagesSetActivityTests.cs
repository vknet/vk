using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesSetActivityTests : MessagesBaseTests
	{
		[Test]
		public void Messages_SetActivity_Without_PeerId_And_GroupId_Throws()
		{
			Assert.Throws<VkApiException>(() => Api.Messages.SetActivity("some_user_id", MessageActivityType.Typing));
		}

		[Test]
		public void Messages_SetActivity_With_Both_PeerId_And_GroupId_Throws()
		{
			Assert.Throws<VkApiException>(() => Api.Messages.SetActivity("some_user_id", MessageActivityType.Typing, 125, 125));
		}

		[Test]
		public void Messages_SetActivity_With_PeerId_DoesntFail()
		{
			Url = "https://api.vk.com/method/messages.setActivity";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.SetActivity("7550525", MessageActivityType.Typing, 1);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Messages_SetActivity_With_GroupId_DoesntFail()
		{
			Url = "https://api.vk.com/method/messages.setActivity";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.SetActivity("7550525", MessageActivityType.Typing, null, 2);

			Assert.That(result, Is.True);
		}
	}
}