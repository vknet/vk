using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class GetClientsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void GetClients()
		{
			Url = "https://api.vk.com/method/ads.getClients";

			ReadCategoryJsonPath(nameof(Api.Ads.GetClients));

			var result = Api.Ads.GetClients(123213);

			result[0].Id.Should().Be(123);
		}
	}
}