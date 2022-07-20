using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PhotoCategory : IPhotoCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		///  api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public PhotoCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public PhotoAlbum CreateAlbum(PhotoCreateAlbumParams @params)
		{
			if (@params.PrivacyView == null)
			{
				@params.PrivacyView = new List<Privacy>();
			}

			if (@params.PrivacyComment == null)
			{
				@params.PrivacyComment = new List<Privacy>();
			}

			if (@params.Title.Length < 2)
			{
				throw new VkApiException(message: "Параметр title обязательный, минимальная длина 2 символа");
			}

			var parameters = new VkParameters
			{
				{ "title", @params.Title },
				{ "group_id", @params.GroupId },
				{ "description", @params.Description },
				{ "privacy_view", string.Join(separator: ",", values: @params.PrivacyView) },
				{ "privacy_comment", string.Join(separator: ",", values: @params.PrivacyComment) },
				{ "upload_by_admins_only", @params.UploadByAdminsOnly }, { "comments_disabled", @params.CommentsDisabled }
			};

			return _vk.Call("photos.createAlbum", parameters);
		}

		/// <inheritdoc />
		public bool EditAlbum(PhotoEditAlbumParams @params)
		{
			if (@params.PrivacyView == null)
			{
				@params.PrivacyView = new List<Privacy>();
			}

			if (@params.PrivacyComment == null)
			{
				@params.PrivacyComment = new List<Privacy>();
			}

			var parameters = new VkParameters
			{
				{ "album_id", @params.AlbumId }
				, { "title", @params.Title }
				, { "description", @params.Description }
				, { "owner_id", @params.OwnerId }
				, { "privacy_view", string.Join(separator: ",", values: @params.PrivacyView) }
				, { "privacy_comment", string.Join(separator: ",", values: @params.PrivacyComment) }
				, { "upload_by_admins_only", @params.UploadByAdminsOnly }
				, { "comments_disabled", @params.CommentsDisabled }
			};

			return _vk.Call("photos.editAlbum", parameters);
		}

		/// <inheritdoc />
		public VkCollection<PhotoAlbum> GetAlbums(PhotoGetAlbumsParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("photos.getAlbums", new VkParameters
				{
					{ "owner_id", @params.OwnerId }
					, { "album_ids", @params.AlbumIds }
					, { "offset", @params.Offset }
					, { "count", @params.Count }
					, { "need_system", @params.NeedSystem }
					, { "need_covers", @params.NeedCovers }
					, { "photo_sizes", @params.PhotoSizes }
				}, skipAuthorization)
				.ToVkCollectionOf<PhotoAlbum>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Photo> Get(PhotoGetParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("photos.get", new VkParameters
				{
					{ "owner_id", @params.OwnerId }
					, { "album_id", @params.AlbumId }
					, { "photo_ids", @params.PhotoIds }
					, { "rev", @params.Reversed }
					, { "extended", @params.Extended }
					, { "feed_type", @params.FeedType }
					, { "feed", @params.Feed }
					, { "photo_sizes", @params.PhotoSizes }
					, { "offset", @params.Offset }
					, { "count", @params.Count }
				}, skipAuthorization)
				.ToVkCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public int GetAlbumsCount(long? userId = null, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "group_id", groupId }
			};

			return _vk.Call("photos.getAlbumsCount", parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Photo> GetById(IEnumerable<string> photos
												, bool? extended = null
												, bool? photoSizes = null
												, bool skipAuthorization = false)
		{
			var parameters = new VkParameters
			{
				{ "photos", photos },
				{ "extended", extended },
				{ "photo_sizes", photoSizes }
			};

			VkResponseArray response = _vk.Call("photos.getById", parameters, skipAuthorization);

			return response.ToReadOnlyCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public UploadServerInfo GetUploadServer(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "album_id", albumId },
				{ "group_id", groupId }
			};

			return _vk.Call("photos.getUploadServer", parameters);
		}

		/// <inheritdoc />
		public UploadServerInfo GetOwnerPhotoUploadServer(long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId }
			};

			return _vk.Call("photos.getOwnerPhotoUploadServer", parameters);
		}

		/// <inheritdoc />
		public UploadServerInfo GetChatUploadServer(ulong chatId, ulong? cropX = null, ulong? cropY = null, ulong? cropWidth = null)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "crop_x", cropX },
				{ "crop_y", cropY },
				{ "crop_width", cropWidth }
			};

			return _vk.Call("photos.getChatUploadServer", parameters);
		}

		/// <inheritdoc />
		public Photo SaveOwnerPhoto(string response)
		{
			var responseJson = response.ToJObject();
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photo = responseJson[propertyName: "photo"].ToString();

			var parameters = new VkParameters
			{
				{ "server", server },
				{ "hash", hash },
				{ "photo", photo }
			};

			return _vk.Call("photos.saveOwnerPhoto", parameters);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public Photo SaveOwnerPhoto(string response, long? captchaSid, string captchaKey)
		{
			return SaveOwnerPhoto(response);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Photo> SaveWallPhoto(string response, ulong? userId, ulong? groupId = null, string caption = null)
		{
			var responseJson = response.ToJObject();
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photo = responseJson[propertyName: "photo"].ToString();

			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "group_id", groupId },
				{ "photo", photo },
				{ "caption", caption },
				{ "server", server },
				{ "hash", hash }
			};

			VkResponseArray responseVk = _vk.Call("photos.saveWallPhoto", parameters);

			return responseVk.ToReadOnlyCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public UploadServerInfo GetWallUploadServer(long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("photos.getWallUploadServer", parameters);
		}

		/// <inheritdoc />
		public UploadServerInfo GetMessagesUploadServer(long? groupId)
		{
			return _vk.Call("photos.getMessagesUploadServer",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Photo> SaveMessagesPhoto(string response)
		{
			var responseJson = response.ToJObject();
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photo = responseJson[propertyName: "photo"].ToString();

			var parameters = new VkParameters
			{
				{ "photo", photo },
				{ "hash", hash },
				{ "server", server }
			};

			VkResponseArray result = _vk.Call("photos.saveMessagesPhoto", parameters);

			return result.ToReadOnlyCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public UploadServerInfo GetOwnerCoverPhotoUploadServer(long groupId
																, long? cropX = null
																, long? cropY = null
																, long? cropX2 = 795L
																, long? cropY2 = 200L)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "crop_x", cropX },
				{ "crop_y", cropY },
				{ "crop_x2", cropX2 },
				{ "crop_y2", cropY2 }
			};

			return _vk.Call("photos.getOwnerCoverPhotoUploadServer", parameters);
		}

		/// <inheritdoc />
		public GroupCover SaveOwnerCoverPhoto(string response)
		{
			var responseJson = response.ToJObject();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photo = responseJson[propertyName: "photo"].ToString();

			var parameters = new VkParameters
			{
				{ "photo", photo },
				{ "hash", hash }
			};

			return _vk.Call("photos.saveOwnerCoverPhoto", parameters);
		}

		/// <inheritdoc />
		public bool Report(long ownerId, ulong photoId, ReportReason reason)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "reason", reason }
			};

			return _vk.Call("photos.report", parameters);
		}

		/// <inheritdoc />
		public bool ReportComment(long ownerId, ulong commentId, ReportReason reason)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "reason", reason }
			};

			return _vk.Call("photos.reportComment", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Photo> Search(PhotoSearchParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("photos.search", new VkParameters
				{
					{ "q", @params.Query }
					, { "lat", @params.Latitude }
					, { "long", @params.Longitude }
					, { "start_time", @params.StartTime }
					, { "end_time", @params.EndTime }
					, { "sort", @params.Sort }
					, { "offset", @params.Offset }
					, { "count", @params.Count }
					, { "radius", @params.Radius }
				}, skipAuthorization)
				.ToVkCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Photo> Save(PhotoSaveParams @params)
		{
			var responseJson = @params.SaveFileResponse.ToJObject();
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photosList = responseJson[propertyName: "photos_list"].ToString();

			var parameters = new VkParameters
			{
				{ "album_id", @params.AlbumId }
				, { "group_id", @params.GroupId }
				, { "server", server }
				, { "photos_list", photosList }
				, { "hash", hash }
				, { "latitude", @params.Latitude }
				, { "longitude", @params.Longitude }
				, { "caption", @params.Caption }
			};

			VkResponseArray response = _vk.Call("photos.save", parameters);

			return response.ToReadOnlyCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public long Copy(long ownerId, ulong photoId, string accessKey = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "access_key", accessKey }
			};

			return _vk.Call("photos.copy", parameters);
		}

		/// <inheritdoc />
		public bool Edit(PhotoEditParams @params)
		{
			return _vk.Call("photos.edit", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "photo_id", @params.PhotoId }
				, { "caption", @params.Caption }
				, { "latitude", @params.Latitude }
				, { "longitude", @params.Longitude }
				, { "place_str", @params.PlaceStr }
				, { "foursquare_id", @params.FoursquareId }
				, { "delete_place", @params.DeletePlace }
				, { "captcha_sid", @params.CaptchaSid }
				, { "captcha_key", @params.CaptchaKey }
			});
		}

		/// <inheritdoc />
		public bool Move(long targetAlbumId, ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "target_album_id", targetAlbumId },
				{ "photo_id", photoId }
			};

			return _vk.Call("photos.move", parameters);
		}

		/// <inheritdoc />
		public bool MakeCover(ulong photoId, long? ownerId = null, long? albumId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "album_id", albumId }
			};

			return _vk.Call("photos.makeCover", parameters);
		}

		/// <inheritdoc />
		public bool ReorderAlbums(long albumId, long? ownerId = null, long? before = null, long? after = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "before", before },
				{ "after", after }
			};

			return _vk.Call("photos.reorderAlbums", parameters);
		}

		/// <inheritdoc />
		public bool ReorderPhotos(ulong photoId, long? ownerId = null, long? before = null, long? after = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "before", before },
				{ "after", after }
			};

			return _vk.Call("photos.reorderPhotos", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Photo> GetAll(PhotoGetAllParams @params)
		{
			return _vk.Call("photos.getAll", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "extended", @params.Extended }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
				, { "photo_sizes", @params.PhotoSizes }
				, { "no_service_albums", @params.NoServiceAlbums }
				, { "need_hidden", @params.NeedHidden }
				, { "skip_hidden", @params.SkipHidden }
			}).ToVkCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Photo> GetUserPhotos(PhotoGetUserPhotosParams @params)
		{
			return _vk.Call("photos.getUserPhotos", new VkParameters
			{
				{ "user_id", @params.UserId }
				, { "count", @params.Count }
				, { "offset", @params.Offset }
				, { "extended", @params.Extended }
				, { "sort", @params.Sort }
			}).ToVkCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public bool DeleteAlbum(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "album_id", albumId },
				{ "group_id", groupId }
			};

			return _vk.Call("photos.deleteAlbum", parameters);
		}

		/// <inheritdoc />
		public bool Delete(ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId }
			};

			return _vk.Call("photos.delete", parameters);
		}

		/// <inheritdoc />
		public bool Restore(ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId }
			};

			return _vk.Call("photos.restore", parameters);
		}

		/// <inheritdoc />
		public bool ConfirmTag(ulong photoId, ulong tagId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "tag_id", tagId }
			};

			return _vk.Call("photos.confirmTag", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetComments(PhotoGetCommentsParams @params)
		{
			return _vk.Call("photos.getComments", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "photo_id", @params.PhotoId }
				, { "need_likes", @params.NeedLikes }
				, { "start_comment_id", @params.StartCommentId }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
				, { "sort", @params.Sort }
				, { "access_key", @params.AccessKey }
				, { "extended", @params.Extended }
				, { "fields", @params.Fields }
			}).ToVkCollectionOf<Comment>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetAllComments(PhotoGetAllCommentsParams @params)
		{
			return _vk.Call("photos.getAllComments", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "album_id", @params.AlbumId }
				, { "need_likes", @params.NeedLikes }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
			}).ToVkCollectionOf<Comment>(selector: x => x);
		}

		/// <inheritdoc />
		public long CreateComment(PhotoCreateCommentParams @params)
		{
			if (@params.Message.Length > 2048)
			{
				throw new VkApiException(message: "Максимальное количество символов: 2048.");
			}

			var parameters = new VkParameters
			{
				{ "owner_id", @params.OwnerId },
				{ "photo_id", @params.PhotoId },
				{ "message", @params.Message },
				{ "attachments", @params.Attachments },
				{ "from_group", @params.FromGroup },
				{ "reply_to_comment", @params.ReplyToComment },
				{ "sticker_id", @params.StickerId },
				{ "access_key", @params.AccessKey },
				{ "guid", @params.Guid }
			};

			return _vk.Call("photos.createComment", parameters);
		}

		/// <inheritdoc />
		public bool DeleteComment(ulong commentId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("photos.deleteComment", parameters);
		}

		/// <inheritdoc />
		public long RestoreComment(ulong commentId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("photos.restoreComment", parameters);
		}

		/// <inheritdoc />
		public bool EditComment(ulong commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "message", message },
				{ "attachments", attachments }
			};

			return _vk.Call("photos.editComment", parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Tag> GetTags(ulong photoId, long? ownerId = null, string accessKey = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "access_key", accessKey }
			};

			VkResponseArray response = _vk.Call("photos.getTags", parameters);

			return response.ToReadOnlyCollectionOf<Tag>(selector: x => x);
		}

		/// <inheritdoc />
		public ulong PutTag(PhotoPutTagParams @params)
		{
			return _vk.Call("photos.putTag", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "photo_id", @params.PhotoId }
				, { "user_id", @params.UserId }
				, { "x", @params.X }
				, { "y", @params.Y }
				, { "x2", @params.X2 }
				, { "y2", @params.Y2 }
			});
		}

		/// <inheritdoc />
		public bool RemoveTag(ulong tagId, ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "photo_id", photoId },
				{ "tag_id", tagId }
			};

			return _vk.Call("photos.removeTag", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Photo> GetNewTags(uint? offset = null, uint? count = null)
		{
			var parameters = new VkParameters
			{
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call("photos.getNewTags", parameters).ToVkCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public UploadServerInfo GetMarketUploadServer(long groupId
													, bool? mainPhoto = null
													, long? cropX = null
													, long? cropY = null
													, long? cropWidth = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "main_photo", mainPhoto },
				{ "crop_x", cropX },
				{ "crop_y", cropY },
				{ "crop_width", cropWidth }
			};

			return _vk.Call("photos.getMarketUploadServer", parameters);
		}

		/// <inheritdoc />
		public UploadServerInfo GetMarketAlbumUploadServer(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("photos.getMarketAlbumUploadServer", parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Photo> SaveMarketPhoto(long groupId, string response)
		{
			var responseJson = response.ToJObject();
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photo = responseJson[propertyName: "photo"].ToString();
			var cropData = responseJson[propertyName: "crop_data"]?.ToString();
			var cropHash = responseJson[propertyName: "crop_hash"]?.ToString();

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "photo", photo },
				{ "server", server },
				{ "hash", hash },
				{ "crop_data", cropData },
				{ "crop_hash", cropHash }
			};

			return _vk.Call("photos.saveMarketPhoto", parameters).ToReadOnlyCollectionOf<Photo>(selector: x => x);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Photo> SaveMarketAlbumPhoto(long groupId, string response)
		{
			var responseJson = response.ToJObject();
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var photo = responseJson[propertyName: "photo"].ToString();

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "photo", photo },
				{ "server", server },
				{ "hash", hash }
			};

			return _vk.Call("photos.saveMarketAlbumPhoto", parameters)
				.ToReadOnlyCollectionOf<Photo>(selector: x => x);
		}
	}
}