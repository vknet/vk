using System;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.LeadForms;

public class LeadFormsTests : CategoryBaseTest
{
	protected override string Folder => "LeadForms";

	[Fact(DisplayName = "Create")]
	public void Create()
	{
		Url = "https://api.vk.ru/method/leadForms.create";
		ReadCategoryJsonPath(nameof(Create));

		var result = Api.LeadForms.Create(new()
		{
			GroupId = 103292418,
			Name = "kwedkjn",
			Title = "kjn",
			Description = "kjn",
			Questions = "[{}]",
			PolicyLinkUrl = "ya.ru"
		});

		result.Should()
			.NotBeNull();

		result.FormId.Should()
			.Be(1);

		result.Url.Should()
			.Be(new Uri("https://vk.ru/apform_id=1#form_id=1"));
	}

	[Fact(DisplayName = "Delete")]
	public void Delete()
	{
		Url = "https://api.vk.ru/method/leadForms.delete";
		ReadCategoryJsonPath(nameof(Delete));

		var result = Api.LeadForms.Delete(103292418, 1);

		result.Should()
			.NotBeNull();

		result.FormId.Should()
			.Be(1);
	}

	[Fact(DisplayName = "Get")]
	public void Get()
	{
		Url = "https://api.vk.ru/method/leadForms.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.LeadForms.Get(103292418, 1);

		result.Should()
			.NotBeNull();

		result.FormId.Should()
			.Be(2);
	}

	[Fact(DisplayName = "List")]
	public void List()
	{
		Url = "https://api.vk.ru/method/leadForms.list";
		ReadCategoryJsonPath(nameof(List));

		var result = Api.LeadForms.List(103292418);

		result.Should()
			.NotBeNull();

		result.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Get upload url")]
	public void GetUploadUrl()
	{
		Url = "https://api.vk.ru/method/leadForms.getUploadURL";
		ReadCategoryJsonPath(nameof(GetUploadUrl));

		var result = Api.LeadForms.GetUploadURL();

		result.Should()
			.NotBeNull();

		result.Should()
			.Be(new Uri("https://pu.vk.ru1d95424ffe4e4983a6a"));
	}

	[Fact(DisplayName = "Update")]
	public void Update()
	{
		Url = "https://api.vk.ru/method/leadForms.update";
		ReadCategoryJsonPath(nameof(Update));

		var result = Api.LeadForms.Update(new()
		{
			GroupId = 103292418,
			Name = "kwedkjn",
			Title = "kjn",
			Description = "kjn",
			Questions = "[{}]",
			PolicyLinkUrl = "ya.ru"
		});

		result.Should()
			.NotBeNull();

		result.FormId.Should()
			.Be(2);

		result.Url.Should()
			.Be(new Uri("https://vk.ru/apform_id=2#form_id=2"));
	}
}