using AwesomeAssertions;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class UserModel : BaseTest
{
	[Fact(DisplayName = "Multi property id")]
	public void MultiPropertyId()
	{
		ReadJsonFile("Models", nameof(MultiPropertyId));

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Id.Should()
			.Be(165614770);
	}

	[Fact(DisplayName = "Multi property uid")]
	public void MultiPropertyUid()
	{
		ReadJsonFile("Models", nameof(MultiPropertyUid));

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Id.Should()
			.Be(165614770);
	}

	[Fact(DisplayName = "Multi property user id")]
	public void MultiPropertyUserId()
	{
		ReadJsonFile("Models", nameof(MultiPropertyUserId));

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Id.Should()
			.Be(165614770);
	}

	[Fact(DisplayName = "Поле 'name' может иметь одно слово")]
	public void Name_ShouldCanBeOneWord()
	{
		ReadJsonFile("Models", nameof(Name_ShouldCanBeOneWord));

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.FirstName.Should()
			.Be("бот");

		result.LastName.Should()
			.BeNull();
	}

	[Fact(DisplayName = "Should have field can access closed")]
	public void ShouldHaveField_CanAccessClosed()
	{
		var user = new User();

		user.CanAccessClosed.Should()
			.BeNull();
	}

	[Fact(DisplayName = "Should have field is closed")]
	public void ShouldHaveField_IsClosed()
	{
		var user = new User();

		user.IsClosed.Should()
			.BeNull();
	}

	[Fact(DisplayName = "Should have field trending")]
	public void ShouldHaveField_Trending()
	{
		var user = new User();

		user.Trending.Should()
			.BeFalse();
	}

	[Fact(DisplayName = "Trending should be false")]
	public void Trending_ShouldBeFalse()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeFalse));

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Trending.Should()
			.BeFalse();
	}

	[Fact(DisplayName = "Trending should be false2")]
	public void Trending_ShouldBeFalse2()
	{
		ReadJsonFile(JsonPaths.Object);

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Trending.Should()
			.BeFalse();
	}

	[Fact(DisplayName = "Trending should be true")]
	public void Trending_ShouldBeTrue()
	{
		ReadJsonFile("Models", nameof(Trending_ShouldBeTrue));

		Url = "https://api.vk.ru/method/friends.getRequests";
		var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);

		result.Trending.Should()
			.BeTrue();
	}
}