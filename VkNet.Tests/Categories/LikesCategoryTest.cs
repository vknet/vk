using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
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

			Assert.That(like, Is.EqualTo(5));
		}

		[Test]
		public void Delete_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.delete";
			ReadCategoryJsonPath(nameof(Delete_NormalCase));

			var like = Api.Likes.Delete(LikeObjectType.Post, 701, null);

			Assert.That(like, Is.EqualTo(4));
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

			Assert.That(like.Count, Is.EqualTo(5));
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

			Assert.That(like.Users.Count, Is.EqualTo(5));
			Assert.That(like.Users.First().Id, Is.EqualTo(32190123));
			Assert.That(like.Users.First().FirstName, Is.EqualTo("Максим"));
			Assert.That(like.Users.First().LastName, Is.EqualTo("Инютин"));
			Assert.That(like.Groups.Count, Is.EqualTo(0));
		}

		[Test]
		public void IsLiked_NormalCase()
		{
			Url = "https://api.vk.com/method/likes.isLiked";
			ReadCategoryJsonPath(nameof(IsLiked_NormalCase));
			bool copied;

			var like = Api.Likes.IsLiked(out copied, LikeObjectType.Post, 701);

			Assert.That(like, Is.EqualTo(true));
			Assert.That(copied, Is.EqualTo(false));
		}
	}
}