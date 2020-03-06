using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetClientsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetClients()
		{
			Url = "https://api.vk.com/method/ads.getClients";

			ReadCategoryJsonPath(nameof(Api.Ads.GetClients));

			var result = Api.Ads.GetClients(123213);

			Assert.That(result[0].Id, Is.EqualTo(123));
		}
	}
}