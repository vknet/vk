using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Secure
{
	[TestFixture]
	public class SecureTests : CategoryBaseTest
	{
		protected override string Folder => "Secure";

		[Test]
		public void SendSmsNotification()
		{
			Url = "https://api.vk.com/method/secure.sendSMSNotification";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Secure.SendSmsNotification(123, "SMS Message");

			Assert.That(app, Is.True);
		}
	}
}