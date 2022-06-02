using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Likes
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class LikesCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Likes";

		[Test]
		public void Add_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.add";
			ReadCategoryJsonPath(nameof(Add_NormalCase));

			var like = Api.Likes.Add(new LikesAddParams
			{
				Type = LikeObjectType.Post,
				ItemId = 701
			});

			like.Should().Be(5);
		}

		[Test]
		public void Delete_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.delete";
			ReadCategoryJsonPath(nameof(Delete_NormalCase));

			var like = Api.Likes.Delete(LikeObjectType.Post, 701, null);

			like.Should().Be(4);
		}

		[Test]
		public void GetList_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.getList";
			ReadCategoryJsonPath(nameof(GetList_NormalCase));

			var like = Api.Likes.GetList(new LikesGetListParams
			{
				ItemId = 701
			});

			like.Should().HaveCount(5);
		}

		[Test]
		public void GetListEx_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.getList";
			ReadCategoryJsonPath(nameof(GetListEx_NormalCase));

			var like = Api.Likes.GetListEx(new LikesGetListParams
			{
				ItemId = 701
			});

			like.Users.Should().HaveCount(5);
			like.Users.First().Id.Should().Be(32190123);
			like.Users.First().FirstName.Should().Be("Максим");
			like.Users.First().LastName.Should().Be("Инютин");
			like.Groups.Should().BeEmpty();
		}

		[Test]
		public void IsLiked_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.isLiked";
			ReadCategoryJsonPath(nameof(IsLiked_NormalCase));

			var like = Api.Likes.IsLiked(out var copied, LikeObjectType.Post, 701);

			like.Should().BeTrue();
			copied.Should().BeFalse();
		}
	}
}