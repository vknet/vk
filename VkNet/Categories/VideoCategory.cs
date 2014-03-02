using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
    public class VideoCategory
    {
        private readonly VkApi _vk;

        public VideoCategory(VkApi vk)
        {
            _vk = vk;
        }

        public ReadOnlyCollection<Video> Get(long? ownerId = null, long? albumId = null, VideoWidth width = VideoWidth.Medium160, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(ownerId, "ownerId");
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

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public long Add(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => ownerId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            VkResponse response = _vk.Call("video.add", parameters);

            return response;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Delete(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => ownerId);

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
            VkErrors.ThrowIfNumberIsNegative(() => ownerId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.restore", parameters);
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

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
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

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

        public void CreateComment()
        {
            throw new NotImplementedException();
        }

        public void DeleteComment()
        {
            throw new NotImplementedException();
        }

        public void RestoreComment()
        {
            throw new NotImplementedException();
        }

        public void EditComment()
        {
            throw new NotImplementedException();
        }

        public void GetTags()
        {
            throw new NotImplementedException();
        }

        public void PutTag()
        {
            throw new NotImplementedException();
        }

        public void RemoveTag()
        {
            throw new NotImplementedException();
        }

        public void GetNewTags()
        {
            throw new NotImplementedException();
        }

        public void Report()
        {
            throw new NotImplementedException();
        }

        public void ReportComment()
        {
            throw new NotImplementedException();
        }
    }
}