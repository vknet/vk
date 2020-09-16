using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class RemoveTargetContactsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void RemoveTargetContacts()
		{
			Url = "https://api.vk.com/method/ads.removeTargetContacts";

			ReadCategoryJsonPath(nameof(Api.Ads.RemoveTargetContacts));

			var result = Api.Ads.RemoveTargetContacts(new RemoveTargetContactsParams
			{
				AccountId = 1605245430,
				Contacts = new List<string> { "79534998632", "79534998633" },
				TargetGroupId = 29859003
			});

			Assert.That(result.Result, Is.EqualTo(true));
		}
	}
}