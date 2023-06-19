using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Likes;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class LikesCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Likes";

	[Fact]
	public void Add_NormalCase()
	{
		Url = "https://api.vk.com/method/likes.add";
		ReadCategoryJsonPath(nameof(Add_NormalCase));

		var like = Api.Likes.Add(new()
		{
			Type = LikeObjectType.Post,
			ItemId = 701
		});

		like.Should()
			.Be(5);
	}

	[Fact]
	public void Delete_NormalCase()
	{
		Url = "https://api.vk.com/method/likes.delete";
		ReadCategoryJsonPath(nameof(Delete_NormalCase));

		var like = Api.Likes.Delete(LikeObjectType.Post, 701);

		like.Should()
			.Be(4);
	}

	[Fact]
	public void GetList_NormalCase()
	{
		Url = "https://api.vk.com/method/likes.getList";
		ReadCategoryJsonPath(nameof(GetList_NormalCase));

		var like = Api.Likes.GetList(new()
		{
			ItemId = 701
		});

		like.Should()
			.HaveCount(5);
	}

	[Fact]
	public void GetListEx_NormalCase()
	{
		Url = "https://api.vk.com/method/likes.getList";
		ReadCategoryJsonPath(nameof(GetListEx_NormalCase));

		var like = Api.Likes.GetListEx(new()
		{
			ItemId = 701
		});

		like.Users.Should()
			.HaveCount(5);

		like.Users.First()
			.Id.Should()
			.Be(32190123);

		like.Users.First()
			.FirstName.Should()
			.Be("Максим");

		like.Users.First()
			.LastName.Should()
			.Be("Инютин");

		like.Groups.Should()
			.BeEmpty();
	}

	[Fact]
	public void IsLiked_NormalCase()
	{
		Url = "https://api.vk.com/method/likes.isLiked";
		ReadCategoryJsonPath(nameof(IsLiked_NormalCase));

		var like = Api.Likes.IsLiked(out var copied, LikeObjectType.Post, 701);

		like.Should()
			.BeTrue();

		copied.Should()
			.BeFalse();
	}
}