using NUnit.Framework;
using VkNet.Model.RequestParams.Groups;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class SetLongPollSettingsTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void SetLongPollSettings()
		{
			Url = "https://api.vk.com/method/groups.setLongPollSettings";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.SetLongPollSettings(new SetLongPollSettingsParams());

			Assert.IsTrue(result);
		}
	}
}