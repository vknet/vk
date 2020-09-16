using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class ImportTargetContactsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void ImportTargetContacts()
		{
			Url = "https://api.vk.com/method/ads.importTargetContacts";

			ReadCategoryJsonPath(nameof(Api.Ads.ImportTargetContacts));

			var result = Api.Ads.ImportTargetContacts(new ImportTargetContactsParams
			{
				AccountId = 1605245430,
				Contacts = new List<string> { "79534998632", "79534998633" },
				TargetGroupId = 29859003
			});

			Assert.That(result, Is.EqualTo(2));
		}
	}
}