using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class DisableOnlineTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void DisableOnline()
		{
			Url = "https://api.vk.com/method/groups.disableOnline";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.DisableOnline(3);

			Assert.IsTrue(result);
		}
	}
}