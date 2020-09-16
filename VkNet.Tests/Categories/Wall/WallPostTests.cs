using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;

namespace VkNet.Tests.Categories.Wall
{

	public class WallPostTests : CategoryBaseTest
	{
		protected override string Folder => "Wall";

		[Test]
		public void Post_ReturnValidateNeeded()
		{
			Url = "https://api.vk.com/method/wall.post";
			ReadErrorsJsonFile(17);

			Assert.That(() => VkErrors.IfErrorThrowException(Json), Throws.TypeOf<NeedValidationException>());
		}

		[Test]
		public void Post_AccessToAddingPostDenied()
		{
			Url = "https://api.vk.com/method/wall.post";
			ReadErrorsJsonFile(214);

			Assert.Throws<PostLimitException>(() => Api.Wall.Post(new WallPostParams()));
		}
	}
}