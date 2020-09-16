using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class GetLongPollSettingsTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void GetLongPollSettings()
		{
			Url = "https://api.vk.com/method/groups.getLongPollSettings";

			ReadCategoryJsonPath(nameof(GetLongPollSettings));

			var result = Api.Groups.GetLongPollSettings(123456);

			Assert.AreEqual("5.50", result.ApiVersion);

			Assert.IsTrue(result.IsEnabled);
			Assert.NotNull(result.Events);
		}
	}
}