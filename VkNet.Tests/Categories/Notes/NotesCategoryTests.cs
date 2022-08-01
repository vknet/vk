using FluentAssertions;
using VkNet.Model.RequestParams.Notes;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Notes;

public class NotesCategoryTests : CategoryBaseTest
{
	protected override string Folder => "Notes";

	[Fact]
	public void Add()
	{
		Url = "https://api.vk.com/method/notes.add";
		ReadCategoryJsonPath(nameof(Add));

		var result = Api.Notes.Add(new());

		result.Should()
			.Be(11825220);
	}

	[Fact]
	public void CreateComment()
	{
		Url = "https://api.vk.com/method/notes.createComment";
		ReadCategoryJsonPath(nameof(CreateComment));

		var result = Api.Notes.CreateComment(new());

		result.Should()
			.Be(11825220);
	}

	[Fact]
	public void Delete()
	{
		Url = "https://api.vk.com/method/notes.delete";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.Delete(11825220);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void DeleteComment()
	{
		Url = "https://api.vk.com/method/notes.deleteComment";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.DeleteComment(new());

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Edit()
	{
		Url = "https://api.vk.com/method/notes.edit";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.Edit(new());

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void EditComment()
	{
		Url = "https://api.vk.com/method/notes.editComment";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.EditComment(new());

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Get()
	{
		Url = "https://api.vk.com/method/notes.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.Notes.Get(new());

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetById()
	{
		Url = "https://api.vk.com/method/notes.getById";
		ReadCategoryJsonPath(nameof(GetById));

		var result = Api.Notes.GetById(new());

		result.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetComments()
	{
		Url = "https://api.vk.com/method/notes.getComments";
		ReadCategoryJsonPath(nameof(GetComments));

		var result = Api.Notes.GetComments(new());

		result.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void RestoreComment()
	{
		Url = "https://api.vk.com/method/notes.restoreComment";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.RestoreComment(new());

		result.Should()
			.BeTrue();
	}
}