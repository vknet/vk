using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Polls
{
	[TestFixture]
	public class GetBackgroundsTest : CategoryBaseTest
	{
		protected override string Folder => "Polls";

		[Test]
		public void GetBackgrounds()
		{
			Url = "https://api.vk.com/method/polls.getBackgrounds";

			ReadCategoryJsonPath(nameof(Api.PollsCategory.GetBackgrounds));

			var result = Api.PollsCategory.GetBackgrounds();

			Assert.That(result[0].Type, Is.TypeOf<PollBackgroundType>());
			Assert.That(result[0].Angle, Is.EqualTo("225"));
			Assert.That(result[0].Points[0].Color, Is.EqualTo("f24973"));
			Assert.That(result[0].Points[0].Position, Is.EqualTo(0));

			Assert.That(result[1].Type, Is.TypeOf<PollBackgroundType>());
			Assert.That(result[1].Angle, Is.EqualTo("180"));
			Assert.That(result[1].Points[1].Color, Is.EqualTo("2f733f"));
			Assert.That(result[1].Points[1].Position, Is.EqualTo(1));
		}
	}
}