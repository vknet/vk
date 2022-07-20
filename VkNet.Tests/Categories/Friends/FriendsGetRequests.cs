using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Friends
{


	public class FriendsGetRequests : CategoryBaseTest
	{
		protected override string Folder => "Friends";

		[Fact]
		public void DefaultParams()
		{
			Url = "https://api.vk.com/method/friends.getRequests";

			ReadCategoryJsonPath(nameof(Api.Friends.GetRequests));

			var result = Api.Friends.GetRequests(new FriendsGetRequestsParams());
			result.Should().NotBeNull();
			result.Count.Should().Be(1);
		}

		[Fact]
		public void Extended()
		{
			Url = "https://api.vk.com/method/friends.getRequests";

			ReadCategoryJsonPath(nameof(Api.Friends.GetRequestsExtended));

			var result = Api.Friends.GetRequestsExtended(new FriendsGetRequestsParams
			{
				Extended = true
			});

			result.Should().NotBeNull();
			result.Should().ContainSingle();
		}
	}
}