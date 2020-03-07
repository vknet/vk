using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class CreateTargetGroupTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CreateTargetGroup()
		{
			Url = "https://api.vk.com/method/ads.createTargetGroup";

			ReadCategoryJsonPath(nameof(Api.Ads.CreateTargetGroup));

			var result = Api.Ads.CreateTargetGroup(new CreateTargetGroupParams
			{
				AccountId = 1605245430,
				Name = "123123",
				Lifetime = 720
			});

			Assert.That(result.Id, Is.EqualTo(1488));
		}
	}
}