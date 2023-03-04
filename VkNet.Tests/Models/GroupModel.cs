using FluentAssertions;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class GroupModel : BaseTest
{
	[Fact]
	public void ShouldHaveField_Trending()
	{
		var group = new Group();

		group.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeFalse()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeFalse));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<Group>("friends.getRequests", VkParameters.Empty);


		result.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeFalse2()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeFalse2));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<Group>("friends.getRequests", VkParameters.Empty);


		result.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeTrue()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeTrue));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<Group>("friends.getRequests", VkParameters.Empty);


		result.Trending.Should()
			.BeTrue();
	}
}