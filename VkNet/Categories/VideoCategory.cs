namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using JetBrains.Annotations;

    using Enums;
    using Model;
    using Utils;

    public class VideoCategory
    {
        private readonly VkApi _vk;

        public VideoCategory(VkApi vk)
        {
            _vk = vk;
        }

        [Pure]
        public ReadOnlyCollection<Video> Get(long? ownerId = null, long? albumId = null, VideoWidth width = VideoWidth.Medium160, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(albumId, "albumId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"owner_id", ownerId},
                    {"album_id", albumId},
                    {"width", width},
                    {"count", count},
                    {"offset", offset},
                    {"extended", extended},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.get", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        public bool Edit(long videoId, long? ownerId = null, string name = null, string desc = null, string privacyView = null, string privacyComment = null, bool isRepeat = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"name", name},
                    {"desc", desc},
                    {"privacy_view", privacyView},
                    {"privacy_comment", privacyComment},
                    {"repeat", isRepeat},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.edit", parameters);
        }

        public long Add(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            VkResponse response = _vk.Call("video.add", parameters);

            return response;
        }

        public Video Save(string name = "", string description = "", bool isPrivate = false, bool isPostToWall = false, string link = "", long? groupId = null, long? albumId = null, bool isRepeat = false)
        {
            var parameters = new VkParameters
                {
                    {"name", name},
                    {"description", description},
                    {"is_private", isPrivate},
                    {"wallpost", isPostToWall},
                    {"link", link},
                    {"group_id", groupId},
                    {"album_id", albumId},
                    {"repeat", isRepeat},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.save", parameters);
        }

        public bool Delete(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.delete", parameters);
        }

        public bool Restore(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.restore", parameters);
        }

        [Pure]
        public ReadOnlyCollection<Video> Search(string query, VideoSort sort, bool isHd = false, bool isAdult = false, VideoFilters filters = null, bool isSearchOwn = false, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => query);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"q", query},
                    {"sort", sort},
                    {"hd", isHd},
                    {"adult", isAdult},
                    {"filters", filters},
                    {"search_own", isSearchOwn},
                    {"offset", offset},
                    {"count", count},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.search", parameters);
            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        [Pure]
        public ReadOnlyCollection<Video> GetUserVideos(long userId, int? count = null, int? offset = null)
        {
            throw new NotImplementedException("Метод некорректно работает на самом сервере вконтакте");

            VkErrors.ThrowIfNumberIsNegative(userId, "userId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.getUserVideos", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        [Pure]
        public ReadOnlyCollection<VideoAlbum> GetAlbums(long ownerId, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"owner_id", ownerId},
                    {"count", count},
                    {"offset", offset},
                    {"extended", extended},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.getAlbums", parameters);

            return response.ToReadOnlyCollectionOf<VideoAlbum>(x => x);
        }

        public long AddAlbum(string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => title);
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
                {
                    {"group_id", groupId},
                    {"title", title},
                    {"v", _vk.Version}
                };
            
            VkResponse response = _vk.Call("video.addAlbum", parameters);

            return response["album_id"];
        }

        public bool EditAlbum(long albumId, string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => title);
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
                {
                    {"album_id", albumId},
                    {"title", title},
                    {"group_id", groupId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.editAlbum", parameters);
        }

        public bool DeleteAlbum(long albumId, long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
           
            var parameters = new VkParameters
                {
                    {"group_id", groupId},
                    {"album_id", albumId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.deleteAlbum", parameters);
        }

        public bool MoveToAlbum(IEnumerable<long> videoIds, long albumId, long? groupId = null)
        {
            if (videoIds == null)
                throw new ArgumentNullException("Не указаны идентификаторы видеозаписей.", "videoIds");

            VkErrors.ThrowIfNumberIsNegative(() => albumId);

            var parameters = new VkParameters { { "album_id", albumId }, { "group_id", groupId } };
            parameters.Add("video_ids", videoIds);
            parameters.Add("v", _vk.Version);

            return _vk.Call("video.moveToAlbum", parameters);
        }

        [Pure]
        public ReadOnlyCollection<Comment> GetComments(long videoId, long? ownerId = null, bool needLikes = false, int? count = null, int? offset = null, CommentsSort sort = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"need_likes", needLikes},
                    {"count", count},
                    {"offset", offset},
                    {"sort", sort},
                    {"v", _vk.Version}
                };

            VkResponse response = _vk.Call("video.getComments", parameters);

            return response.ToReadOnlyCollectionOf<Comment>(x => x);
        }

        public long CreateComment(Attachment attach)
        {
            // todo сделать версию с прикладыванием приложения
            throw new NotImplementedException();
        }

        public long CreateComment(long videoId, string message, long? ownerId, bool isFromGroup = false)
        {
            VkErrors.ThrowIfNullOrEmpty(() => message);
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"message", message},
                    {"from_group", isFromGroup},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.createComment", parameters);
        }

        public bool DeleteComment(long commentId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters { { "comment_id", commentId }, { "owner_id", ownerId }, {"v", _vk.Version} };

            return _vk.Call("video.deleteComment", parameters);
        }

        public bool RestoreComment(long commentId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters { { "comment_id", commentId }, { "owner_id", ownerId }, { "v", _vk.Version } };

            return _vk.Call("video.restoreComment", parameters);
        }

        public bool EditComment(Attachment attach)
        {
            // todo add version with attachment
            throw new NotImplementedException();
        }

        public bool EditComment(long commentId, string message, long? ownerId)
        {
            VkErrors.ThrowIfNullOrEmpty(() => message);
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters
                {
                    {"comment_id", commentId},
                    {"message", message},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.editComment", parameters);
        }

        // todo add unit test
        [Pure]
        public void GetTags(long videoId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters { { "video_id", videoId }, { "owner_id", ownerId }, {"v", _vk.Version} };

            VkResponseArray response = _vk.Call("video.getTags", parameters);

            throw new NotImplementedException();
        }

        // todo add unit tests
        public long PutTag(long videoId, long userId, long? ownerId, string taggedName)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"tagged_name", taggedName},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.putTag", parameters);

            throw new NotImplementedException();
        }

        // todo add unit test
        public bool RemoveTag(long tagId, long videoId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => tagId);
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"tag_id", tagId},
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.removeTag", parameters);

            throw new NotImplementedException();
        }

        // todo add unit test + parse new fields
        [Pure]
        public ReadOnlyCollection<Video> GetNewTags(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.getNewTags", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);

            throw new NotImplementedException();
        }

        public bool Report(long videoId, VideoReportType reason, long? ownerId, string comment = null, string searchQuery = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"reason", reason},
                    {"comment", comment},
                    {"search_query", searchQuery},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.report", parameters);
        }

        public bool ReportComment(long commentId, long ownerId, VideoReportType reason)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);

            var parameters = new VkParameters
                {
                    {"comment_id", commentId},
                    {"owner_id", ownerId},
                    {"reason", reason},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.reportComment", parameters);
        }
    }
}