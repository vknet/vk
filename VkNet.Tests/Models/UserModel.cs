using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class UserModel : BaseTest
	{
		[Test]
		public void MultiPropertyId()
		{
			Json = @"{'id': 165614770}";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);
			Assert.That(result.Id, Is.EqualTo(165614770));
		}

		[Test]
		public void MultiPropertyUid()
		{
			Json = @"{'uid': 165614770}";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);
			Assert.That(result.Id, Is.EqualTo(165614770));
		}

		[Test]
		public void MultiPropertyUserId()
		{
			Json = @"{'user_id': 165614770}";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<User>("friends.getRequests", VkParameters.Empty);
			Assert.That(result.Id, Is.EqualTo(165614770));
		}

		[Test(Description = "Поле 'name' может иметь одно слово")]
		public void Name_ShouldCanBeOneWord()
		{
			Json = "{'name': 'бот'}";
			var response = GetResponse();
			var user = User.FromJson(response);
			Assert.That(user.FirstName, Is.EqualTo("бот"));
			Assert.That(user.LastName, Is.Null);
		}

		[Test]
		public void ShouldHaveField_Trending()
		{
			var user = new User();
			Assert.That(user, Has.Property("Trending"));
		}

		[Test]
		public void Trending_ShouldBeFalse()
		{
			Json = "{'trending':0}";
			var response = GetResponse();
			var user = User.FromJson(response);
			Assert.That(user.Trending, Is.False);
		}

		[Test]
		public void Trending_ShouldBeFalse2()
		{
			Json = "{}";
			var response = GetResponse();
			var user = User.FromJson(response);
			Assert.That(user.Trending, Is.False);
		}

		[Test]
		public void Trending_ShouldBeTrue()
		{
			Json = "{'trending':1}";
			var response = GetResponse();
			var user = User.FromJson(response);
			Assert.That(user.Trending, Is.True);
		}
	}
}