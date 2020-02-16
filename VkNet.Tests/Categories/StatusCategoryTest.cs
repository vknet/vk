using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class StatusCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Status";

		[Test]
		public void Get_AccessDenied_ThrowAccessDeniedException()
		{
			Url = "https://api.vk.com/method/status.get";
			ReadErrorsJsonFile(7);

			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			var ex = Assert.Throws<PermissionToPerformThisActionException>(() => Api.Status.Get(1));
			Assert.That(ex.Message, Is.EqualTo("Permission to perform this action is denied"));
		}

		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var status = new StatusCategory(new VkApi());
			Assert.That(() => status.Get(1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_Audio_ReturnStatus()
		{
			Url = "https://api.vk.com/method/status.get";

			ReadCategoryJsonPath(nameof(Get_Audio_ReturnStatus));

			var actual = Api.Status.Get(1);

			Assert.That(actual, Is.Not.Null);
			Assert.That(actual.Text, Is.EqualTo("Тараканы! – Собачье Сердце"));
			Assert.That(actual.Audio, Is.Not.Null);
			Assert.That(actual.Audio.Id, Is.EqualTo(158073513));
			Assert.That(actual.Audio.OwnerId, Is.EqualTo(4793858));
			Assert.That(actual.Audio.Artist, Is.EqualTo("Тараканы!"));
			Assert.That(actual.Audio.Title, Is.EqualTo("Собачье Сердце"));
			Assert.That(actual.Audio.Duration, Is.EqualTo(230));
			Assert.That(actual.Audio.Url.OriginalString, Is.EqualTo(expected: "https://cs1-43v4/lR-RTwXXMk_q1RrO_-g"));

			Assert.That(actual.Audio.LyricsId, Is.EqualTo(expected: 7985406));
		}

		[Test]
		public void Get_SimpleText_ReturnStatus()
		{
			Url = "https://api.vk.com/method/status.get";
			ReadCategoryJsonPath(nameof(Get_SimpleText_ReturnStatus));

			var actual = Api.Status.Get(1);

			Assert.That(actual, Is.Not.Null);
			Assert.That(actual.Text, Is.EqualTo("it really work!!!"));
			Assert.That(actual.Audio, Is.Null);
		}

		[Test]
		public void Set_AccessDenied_ThrowAccessDeniedException()
		{
			Url = "https://api.vk.com/method/status.set";
			ReadErrorsJsonFile(7);

			Assert.That(() => Api.Status.Set("test"), Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Test]
		public void Set_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var status = new StatusCategory(new VkApi());
			Assert.That(() => status.Set("test"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Set_SimpleText_ReturnTrue()
		{
			Url = "https://api.vk.com/method/status.set";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Status.Set("test test test");

			Assert.That(result, Is.True);
		}
	}
}