using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class EnableOnlineTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void EnableOnline()
		{
			Url = "https://api.vk.com/method/groups.enableOnline";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.EnableOnline(3);

			Assert.IsTrue(result);
		}
	}
}