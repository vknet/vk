using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Notes;

public class NotesCategoryTests : CategoryBaseTest
{
	protected override string Folder => "Notes";

	[Test]
	[DisplayName("Add")]
	public void Add()
	{
		Url = "https://api.vk.ru/method/notes.add";
		ReadCategoryJsonPath(nameof(Add));

		var result = Api.Notes.Add(new());

		result.Should()
			.Be(11825220);
	}

	[Test]
	[DisplayName("Create comment")]
	public void CreateComment()
	{
		Url = "https://api.vk.ru/method/notes.createComment";
		ReadCategoryJsonPath(nameof(CreateComment));

		var result = Api.Notes.CreateComment(new());

		result.Should()
			.Be(11825220);
	}

	[Test]
	[DisplayName("Delete")]
	public void Delete()
	{
		Url = "https://api.vk.ru/method/notes.delete";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.Delete(11825220);

		result.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("Delete comment")]
	public void DeleteComment()
	{
		Url = "https://api.vk.ru/method/notes.deleteComment";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.DeleteComment(new());

		result.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("Edit")]
	public void Edit()
	{
		Url = "https://api.vk.ru/method/notes.edit";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.Edit(new());

		result.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("Edit comment")]
	public void EditComment()
	{
		Url = "https://api.vk.ru/method/notes.editComment";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.EditComment(new());

		result.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("Get")]
	public void Get()
	{
		Url = "https://api.vk.ru/method/notes.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.Notes.Get(new());

		result.Should()
			.NotBeEmpty();
	}

	[Test]
	[DisplayName("Get by id")]
	public void GetById()
	{
		Url = "https://api.vk.ru/method/notes.getById";
		ReadCategoryJsonPath(nameof(GetById));

		var result = Api.Notes.GetById(new());

		result.Should()
			.NotBeNull();
	}

	[Test]
	[DisplayName("Get comments")]
	public void GetComments()
	{
		Url = "https://api.vk.ru/method/notes.getComments";
		ReadCategoryJsonPath(nameof(GetComments));

		var result = Api.Notes.GetComments(new());

		result.Should()
			.NotBeEmpty();
	}

	[Test]
	[DisplayName("Restore comment")]
	public void RestoreComment()
	{
		Url = "https://api.vk.ru/method/notes.restoreComment";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notes.RestoreComment(new());

		result.Should()
			.BeTrue();
	}
}