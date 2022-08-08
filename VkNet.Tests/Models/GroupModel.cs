using FluentAssertions;
using VkNet.Model;
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

		var response = GetResponse();
		var group = Group.FromJson(response);

		group.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeFalse2()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeFalse2));

		var response = GetResponse();
		var group = Group.FromJson(response);

		group.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeTrue()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeTrue));

		var response = GetResponse();
		var group = Group.FromJson(response);

		group.Trending.Should()
			.BeTrue();
	}
}