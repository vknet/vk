using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Docs;

public class DocsSaveTests : CategoryBaseTest
{
	protected override string Folder => "Docs";

	[Fact]
	public void Save()
	{
		Url = "https://api.vk.com/method/docs.save";
		ReadCategoryJsonPath("Save");

		var docUploadResult = ReadJson("Categories", Folder, "DocUploadResult");

		var result = Api.Docs.Save(docUploadResult, "IMG_907");

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void Save2()
	{
		Url = "https://api.vk.com/method/docs.save";
		ReadCategoryJsonPath("Save2");

		var docUploadResult = ReadJson("Categories", Folder, "DocUploadResult");

		var result = Api.Docs.Save(docUploadResult, "IMG_907");

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void Save3()
	{
		Url = "https://api.vk.com/method/docs.save";
		ReadCategoryJsonPath("Save3");

		var docUploadResult = ReadJson("Categories", Folder, "DocUploadResult");

		var result = Api.Docs.Save(docUploadResult, "IMG_907");

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void Save_Type()
	{
		Url = "https://api.vk.com/method/docs.save";
		ReadCategoryJsonPath("Save3");

		var docUploadResult = ReadJson("Categories", Folder, "DocUploadResult");

		var result = Api.Docs.Save(docUploadResult, "IMG_907");

		result.Should()
			.NotBeEmpty();

		var item = result.FirstOrDefault();

		item.Should()
			.NotBeNull();

		var doc = item.Instance as Document;

		doc.Should()
			.NotBeNull();

		doc.Type.Should()
			.Be(DocumentTypeEnum.Text);
	}
}