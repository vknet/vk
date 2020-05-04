using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AudioCategory
	{
		/// <inheritdoc />
		public Task<long> AddAsync(long audioId, long ownerId, string accessKey = null, long? groupId = null, long? albumId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Add(audioId, ownerId, accessKey, groupId, albumId));
		}

		/// <inheritdoc />
		public Task<AudioPlaylist> CreatePlaylistAsync(long ownerId, string title, string description = null,
														IEnumerable<string> audioIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreatePlaylist(ownerId, title, description, audioIds));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(long audioId, long ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Delete(audioId, ownerId));
		}

		/// <inheritdoc />
		public Task<bool> DeletePlaylistAsync(long ownerId, long playlistId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeletePlaylist(ownerId, playlistId));
		}

		/// <inheritdoc />
		public Task<long> EditAsync(AudioEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Edit(@params));
		}

		/// <inheritdoc />
		public Task<bool> EditPlaylistAsync(long ownerId, int playlistId, string title, string description = null,
											IEnumerable<string> audioIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditPlaylist(ownerId, playlistId, title, description, audioIds));
		}

		/// <inheritdoc />
		public Task<VkCollection<Audio>> GetAsync(AudioGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Get(@params));
		}

		/// <inheritdoc />
		public Task<VkCollection<AudioPlaylist>> GetPlaylistsAsync(long ownerId, uint? count = null, uint? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPlaylists(ownerId, count, offset));
		}

		/// <inheritdoc />
		public Task<AudioPlaylist> GetPlaylistByIdAsync(long ownerId, long playlistId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPlaylistById(ownerId, playlistId));
		}

		/// <inheritdoc />
		public Task<IEnumerable<object>> GetBroadcastListAsync(AudioBroadcastFilter filter = null, bool? active = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBroadcastList(filter, active));
		}

		/// <inheritdoc />
		public Task<IEnumerable<Audio>> GetByIdAsync(IEnumerable<string> audios)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetById(audios));
		}

		/// <inheritdoc />
		public Task<AudioGetCatalogResult> GetCatalogAsync(uint? count, bool? extended, UsersFields fields = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCatalog(count, extended, fields));
		}

		/// <inheritdoc />
		public Task<long> GetCountAsync(long ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCount(ownerId));
		}

		/// <inheritdoc />
		public Task<Lyrics> GetLyricsAsync(long lyricsId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLyrics(lyricsId));
		}

		/// <inheritdoc />
		public Task<IEnumerable<Audio>> GetPopularAsync(bool onlyEng = false, AudioGenre? genre = null, uint? count = null,
														uint? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPopular(onlyEng, genre, count, offset));
		}

		/// <inheritdoc />
		public Task<VkCollection<Audio>> GetRecommendationsAsync(string targetAudio = null, long? userId = null, uint? count = null,
																uint? offset = null, bool? shuffle = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRecommendations(targetAudio, userId, count, offset, shuffle));
		}

		/// <inheritdoc />
		public Task<Uri> GetUploadServerAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetUploadServer);
		}

		/// <inheritdoc />
		public Task<IEnumerable<long>> AddToPlaylistAsync(long ownerId, long playlistId, IEnumerable<string> audioIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddToPlaylist(ownerId, playlistId, audioIds));
		}

		/// <inheritdoc />
		public Task<bool> ReorderAsync(long audioId, long? ownerId, long? before, long? after)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Reorder(audioId, ownerId, before, after));
		}

		/// <inheritdoc />
		public Task<Audio> RestoreAsync(long audioId, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Restore(audioId, ownerId));
		}

		/// <inheritdoc />
		public Task<Audio> SaveAsync(string response, string artist = null, string title = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Save(response, artist, title));
		}

		/// <inheritdoc />
		public Task<VkCollection<Audio>> SearchAsync(AudioSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Search(@params));
		}

		/// <inheritdoc />
		public Task<IEnumerable<long>> SetBroadcastAsync(string audio = null, IEnumerable<long> targetIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetBroadcast(audio, targetIds));
		}
	}
}