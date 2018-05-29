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
			var result = Api.Call<User>(methodName: "friends.getRequests", parameters: VkParameters.Empty);
			Assert.That(actual: result.Id, expression: Is.EqualTo(expected: 165614770));
		}

		[Test]
		public void MultiPropertyUid()
		{
			Json = @"{'uid': 165614770}";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<User>(methodName: "friends.getRequests", parameters: VkParameters.Empty);
			Assert.That(actual: result.Id, expression: Is.EqualTo(expected: 165614770));
		}

		[Test]
		public void MultiPropertyUserId()
		{
			Json = @"{'user_id': 165614770}";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<User>(methodName: "friends.getRequests", parameters: VkParameters.Empty);
			Assert.That(actual: result.Id, expression: Is.EqualTo(expected: 165614770));
		}

		[Test(Description = "Поле 'name' может иметь одно слово")]
		public void Name_ShouldCanBeOneWord()
		{
			Json = "{'name': 'бот'}";
			var response = GetResponse();
			var user = User.FromJson(response: response);
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "бот"));
			Assert.That(actual: user.LastName, expression: Is.Null);
		}

		[Test]
		public void ShouldHaveField_Trending()
		{
			var user = new User();
			Assert.That(actual: user, expression: Has.Property(name: "Trending"));
		}

		[Test]
		public void Trending_ShouldBeFalse()
		{
			Json = "{'trending':0}";
			var response = GetResponse();
			var user = User.FromJson(response: response);
			Assert.That(actual: user.Trending, expression: Is.False);
		}

		[Test]
		public void Trending_ShouldBeFalse2()
		{
			Json = "{}";
			var response = GetResponse();
			var user = User.FromJson(response: response);
			Assert.That(actual: user.Trending, expression: Is.False);
		}

		[Test]
		public void Trending_ShouldBeTrue()
		{
			Json = "{'trending':1}";
			var response = GetResponse();
			var user = User.FromJson(response: response);
			Assert.That(actual: user.Trending, expression: Is.True);
		}
	}
}