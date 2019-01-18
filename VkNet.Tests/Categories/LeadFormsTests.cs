using System;
using NUnit.Framework;
using VkNet.Model.LeadForms;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class LeadFormsTests : CategoryBaseTest
	{
		protected override string Folder => "LeadForms";

		[Test]
		public void Create()
		{
			Url = "https://api.vk.com/method/leadForms.create";
			ReadCategoryJsonPath(nameof(Create));

			var result = Api.LeadForms.Create(new LeadFormsCreateParams
			{
				GroupId = 103292418,
				Name = "kwedkjn",
				Title = "kjn",
				Description = "kjn",
				Questions = "[{}]",
				PolicyLinkUrl = "ya.ru"
			});

			Assert.NotNull(result);
			Assert.AreEqual(1, result.FormId);
			Assert.AreEqual(new Uri("https://vk.com/apform_id=1#form_id=1"), result.Url);
		}
	}
}