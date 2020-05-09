using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Docs
{
	[TestFixture]
	public class DocsGetMessagesUploadServerTests : CategoryBaseTest
	{
		protected override string Folder => "Docs";

		[Test]
		public void GetMessagesUploadServerTest()
		{
			Url = "https://api.vk.com/method/docs.getMessagesUploadServer";
			ReadCategoryJsonPath("DocGetMessagesUploadServerResult");

			var serverInfo = Api.Docs.GetMessagesUploadServer(504736359, DocMessageType.Graffiti);
			Assert.IsNotEmpty(serverInfo.UploadUrl);
		}
	}
}