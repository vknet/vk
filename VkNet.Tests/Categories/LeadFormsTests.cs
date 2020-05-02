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

		[Test]
		public void Delete()
		{
			Url = "https://api.vk.com/method/leadForms.delete";
			ReadCategoryJsonPath(nameof(Delete));

			var result = Api.LeadForms.Delete(103292418, 1);
			Assert.NotNull(result);
			Assert.AreEqual(1, result.FormId);
		}

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/leadForms.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.LeadForms.Get(103292418, 1);
			Assert.NotNull(result);
			Assert.AreEqual(2, result.FormId);
		}

		[Test]
		public void List()
		{
			Url = "https://api.vk.com/method/leadForms.list";
			ReadCategoryJsonPath(nameof(List));

			var result = Api.LeadForms.List(103292418);
			Assert.NotNull(result);
			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetUploadUrl()
		{
			Url = "https://api.vk.com/method/leadForms.getUploadURL";
			ReadCategoryJsonPath(nameof(GetUploadUrl));

			var result = Api.LeadForms.GetUploadUrl();

			Assert.NotNull(result);
			Assert.AreEqual(new Uri("https://pu.vk.com1d95424ffe4e4983a6a"), result);
		}

		[Test]
		public void Update()
		{
			Url = "https://api.vk.com/method/leadForms.update";
			ReadCategoryJsonPath(nameof(Update));

			var result = Api.LeadForms.Update(new LeadFormsUpdateParams
			{
				GroupId = 103292418,
				Name = "kwedkjn",
				Title = "kjn",
				Description = "kjn",
				Questions = "[{}]",
				PolicyLinkUrl = "ya.ru"
			});

			Assert.NotNull(result);
			Assert.AreEqual(2, result.FormId);
			Assert.AreEqual(new Uri("https://vk.com/apform_id=2#form_id=2"), result.Url);
		}
	}
}