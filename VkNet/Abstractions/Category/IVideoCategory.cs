using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IVideoCategoryAsync"/>
	public interface IVideoCategory : IVideoCategoryAsync
	{
		/// <inheritdoc cref="IVideoCategoryAsync.GetAsync"/>
		VkCollection<Video> Get(VideoGetParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.EditAsync"/>
		bool Edit(VideoEditParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.AddAsync"/>
		long Add(long videoId, long ownerId, long? targetId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.SaveAsync"/>
		Video Save(VideoSaveParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.DeleteAsync"/>
		bool Delete(long videoId, long? ownerId = null, long? targetId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.RestoreAsync"/>
		bool Restore(long videoId, long? ownerId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.SearchAsync"/>
		VkCollection<Video> Search(VideoSearchParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.GetAlbumsAsync"/>
		VkCollection<VideoAlbum> GetAlbums(long? ownerId = null, long? offset = null, long? count = null, bool? extended = null,
											bool? needSystem = null);

		/// <inheritdoc cref="IVideoCategoryAsync.AddAlbumAsync"/>
		long AddAlbum(string title, long? groupId = null, IEnumerable<Privacy> privacy = null);

		/// <inheritdoc cref="IVideoCategoryAsync.EditAlbumAsync"/>
		bool EditAlbum(long albumId, string title, long? groupId = null, Privacy privacy = null);

		/// <inheritdoc cref="IVideoCategoryAsync.DeleteAlbumAsync"/>
		bool DeleteAlbum(long albumId, long? groupId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.GetCommentsAsync"/>
		VkCollection<Comment> GetComments(VideoGetCommentsParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.CreateCommentAsync"/>
		long CreateComment(VideoCreateCommentParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.DeleteCommentAsync"/>
		bool DeleteComment(long commentId, long? ownerId);

		/// <inheritdoc cref="IVideoCategoryAsync.RestoreCommentAsync"/>
		bool RestoreComment(long commentId, long? ownerId);

		/// <inheritdoc cref="IVideoCategoryAsync.EditCommentAsync"/>
		bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null);

		/// <inheritdoc cref="IVideoCategoryAsync.ReportAsync"/>
		bool Report(long videoId, ReportReason reason, long? ownerId, string comment = null, string searchQuery = null);

		/// <inheritdoc cref="IVideoCategoryAsync.ReportCommentAsync"/>
		bool ReportComment(long commentId, long ownerId, ReportReason reason);

		/// <inheritdoc cref="IVideoCategoryAsync.GetAlbumByIdAsync"/>
		VideoAlbum GetAlbumById(long albumId, long? ownerId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.ReorderAlbumsAsync"/>
		bool ReorderAlbums(long albumId, long? ownerId, long? before, long? after);

		/// <inheritdoc cref="IVideoCategoryAsync.ReorderVideosAsync"/>
		bool ReorderVideos(VideoReorderVideosParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.AddToAlbumAsync"/>
		VkCollection<ulong> AddToAlbum(long ownerId, long videoId, IEnumerable<string> albumIds, long? targetId = null,
										long? albumId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.RemoveFromAlbumAsync"/>
		bool RemoveFromAlbum(long ownerId, long videoId, IEnumerable<string> albumIds, long? targetId = null, long? albumId = null);

		/// <inheritdoc cref="IVideoCategoryAsync.GetAlbumsByVideoAsync"/>
		VkCollection<VideoAlbum> GetAlbumsByVideo(long? targetId, long ownerId, long videoId, bool? extended);

		/// <inheritdoc cref="IVideoCategoryAsync.GetCatalogAsync"/>
		ReadOnlyCollection<VideoCatalog> GetCatalog(VideoGetCatalogParams @params);

		/// <inheritdoc cref="IVideoCategoryAsync.GetCatalogSectionAsync"/>
		ReadOnlyCollection<VideoCatalogItem> GetCatalogSection(string sectionId, string from, long? count = null, bool? extended = null);

		/// <inheritdoc cref="IVideoCategoryAsync.HideCatalogSectionAsync"/>
		bool HideCatalogSection(long sectionId);
	}
}