using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Notes;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class NotesCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Notes";

		[Test]
		public void Add()
		{
			Json = @"
            {
				'response': 11825220
			}";

			Url = "https://api.vk.com/method/notes.add";
			var result = Api.Notes.Add(new NotesAddParams());
			Assert.AreEqual(11825220, result);
		}

		[Test]
		public void CreateComment()
		{
			Json = @"
			{
				'response': 11825220
			}";

			Url = "https://api.vk.com/method/notes.createComment";
			var result = Api.Notes.CreateComment(new NotesCreateCommentParams());
			Assert.AreEqual(11825220, result);
		}

		[Test]
		public void Delete()
		{
			Url = "https://api.vk.com/method/notes.delete";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.Delete(11825220);

			Assert.True(result);
		}

		[Test]
		public void DeleteComment()
		{
			Url = "https://api.vk.com/method/notes.deleteComment";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.DeleteComment(new NotesDeleteCommentParams());

			Assert.True(result);
		}

		[Test]
		public void Edit()
		{
			Url = "https://api.vk.com/method/notes.edit";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.Edit(new NotesEditParams());

			Assert.True(result);
		}

		[Test]
		public void EditComment()
		{
			Url = "https://api.vk.com/method/notes.editComment";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.EditComment(new NotesEditCommentParams());

			Assert.True(result);
		}

		[Test]
		public void Get()
		{
			Json = @"
			{
				'response': {
					'count': 123,
					items: [
						{
							'id': 11801953,
							'owner_id': 66748,
							'comments': 0,
							'date': 1437379505,
							'title': 'Без названия',
							'text': 'text',
							'view_url': 'https://m.vk.com/63a975c&lang=en'
						}
					]
				}
			}";

			Url = "https://api.vk.com/method/notes.get";
			var result = Api.Notes.Get(new NotesGetParams());
			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetById()
		{
			Json = @"
			{
				'response': {
					'id': 11801953,
					'owner_id': 66748,
					'comments': 0,
					'date': 1437379505,
					'title': 'Без названия',
					'text': 'text',
					'view_url': 'https://m.vk.com/63a975c&lang=en'
				}
			}";

			Url = "https://api.vk.com/method/notes.getById";
			var result = Api.Notes.GetById(new NotesGetByIdParams());
			Assert.IsNotNull(result);
		}

		[Test]
		public void GetComments()
		{
			Json = @"
			{
				'response': {
					'count': 0,
					'items': [{
						'id': '26575410',
						'uid': '185014513',
						'nid': '11751647',
						'date': '1367265714',
						'message': '<!--rid:2360-->new comment ',
						'reply_to': '0',
						'oid': 2314852
					}]
				}
			}";

			Url = "https://api.vk.com/method/notes.getComments";
			var result = Api.Notes.GetComments(new NotesGetCommentParams());
			Assert.IsNotEmpty(result);
		}

		[Test]
		public void RestoreComment()
		{
			Url = "https://api.vk.com/method/notes.restoreComment";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.RestoreComment(new NotesRestoreCommentParams());

			Assert.True(result);
		}
	}
}