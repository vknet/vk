using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Docs;

public class DocsGetMessagesUploadServerTests : CategoryBaseTest
{
	protected override string Folder => "Docs";

	[Fact]
	public void GetMessagesUploadServerTest()
	{
		Url = "https://api.vk.com/method/docs.getMessagesUploadServer";
		ReadCategoryJsonPath("DocGetMessagesUploadServerResult");

		var serverInfo = Api.Docs.GetMessagesUploadServer(504736359, DocMessageType.Graffiti);

		serverInfo.UploadUrl.Should()
			.NotBeEmpty();
	}
}