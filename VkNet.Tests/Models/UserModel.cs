using FluentAssertions;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class UserModel : BaseTest
{
	[Fact]
	public void MultiPropertyId()
	{
		ReadJsonFile("Models", nameof(MultiPropertyId));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Id.Should()
			.Be(165614770);
	}

	[Fact]
	public void MultiPropertyUid()
	{
		ReadJsonFile("Models", nameof(MultiPropertyUid));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Id.Should()
			.Be(165614770);
	}

	[Fact]
	public void MultiPropertyUserId()
	{
		ReadJsonFile("Models", nameof(MultiPropertyUserId));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Id.Should()
			.Be(165614770);
	}

	[Fact(DisplayName = "Поле 'name' может иметь одно слово")]
	public void Name_ShouldCanBeOneWord()
	{
		ReadJsonFile("Models", nameof(Name_ShouldCanBeOneWord));

		var response = GetResponse();
		var user = User.FromJson(response);

		user.FirstName.Should()
			.Be("бот");

		user.LastName.Should()
			.BeNull();
	}

	[Fact]
	public void ShouldHaveField_CanAccessClosed()
	{
		var user = new User();

		user.CanAccessClosed.Should()
			.BeNull();
	}

	[Fact]
	public void ShouldHaveField_IsClosed()
	{
		var user = new User();

		user.IsClosed.Should()
			.BeNull();
	}

	[Fact]
	public void ShouldHaveField_Trending()
	{
		var user = new User();

		user.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeFalse()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeFalse));

		var response = GetResponse();
		var user = User.FromJson(response);

		user.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeFalse2()
	{
		ReadJsonFile(JsonPaths.Object);

		var response = GetResponse();
		var user = User.FromJson(response);

		user.Trending.Should()
			.BeFalse();
	}

	[Fact]
	public void Trending_ShouldBeTrue()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeTrue));

		var response = GetResponse();
		var user = User.FromJson(response);

		user.Trending.Should()
			.BeTrue();
	}
}