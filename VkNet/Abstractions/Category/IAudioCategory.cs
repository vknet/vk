using System;
using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IAudioCategoryAsync" />
	public interface IAudioCategory : IAudioCategoryAsync
	{
		/// <inheritdoc cref="IAudioCategoryAsync.AddAsync"/>
		long Add(long audioId, long ownerId, string accessKey = null, long? groupId = null, long? albumId = null);

		/// <inheritdoc cref="IAudioCategoryAsync.CreatePlaylistAsync"/>
		AudioPlaylist CreatePlaylist(long ownerId, string title, string description = null, IEnumerable<string> audioIds = null);

		/// <inheritdoc cref="IAudioCategoryAsync.DeleteAsync"/>
		bool Delete(long audioId, long ownerId);

		/// <inheritdoc cref="IAudioCategoryAsync.DeletePlaylistAsync"/>
		bool DeletePlaylist(long ownerId, long playlistId);

		/// <inheritdoc cref="IAudioCategoryAsync.EditAsync"/>
		long Edit(AudioEditParams @params);

		/// <inheritdoc cref="IAudioCategoryAsync.EditPlaylistAsync"/>
		bool EditPlaylist(long ownerId, int playlistId, string title, string description = null, IEnumerable<string> audioIds = null);

		/// <inheritdoc cref="IAudioCategoryAsync.GetAsync"/>
		VkCollection<Audio> Get(AudioGetParams @params);

		/// <inheritdoc cref="IAudioCategoryAsync.GetPlaylistsAsync"/>
		VkCollection<AudioPlaylist> GetPlaylists(long ownerId, uint? count = null, uint? offset = null);

		/// <inheritdoc cref="IAudioCategoryAsync.GetPlaylistByIdAsync"/>
		AudioPlaylist GetPlaylistById(long ownerId, long playlistId);

		/// <inheritdoc cref="IAudioCategoryAsync.GetBroadcastListAsync"/>
		IEnumerable<object> GetBroadcastList(AudioBroadcastFilter filter = null, bool? active = null);

		/// <inheritdoc cref="IAudioCategoryAsync.GetByIdAsync"/>
		IEnumerable<Audio> GetById(IEnumerable<string> audios);

		/// <inheritdoc cref="IAudioCategoryAsync.GetCatalogAsync"/>
		AudioGetCatalogResult GetCatalog(uint? count, bool? extended, UsersFields fields = null);

		/// <inheritdoc cref="IAudioCategoryAsync.GetCountAsync"/>
		long GetCount(long ownerId);

		/// <inheritdoc cref="IAudioCategoryAsync.GetLyricsAsync"/>
		Lyrics GetLyrics(long lyricsId);

		/// <inheritdoc cref="IAudioCategoryAsync.GetPopularAsync"/>
		IEnumerable<Audio> GetPopular(bool onlyEng = false, AudioGenre? genre = null, uint? count = null, uint? offset = null);

		/// <inheritdoc cref="IAudioCategoryAsync.GetRecommendationsAsync"/>
		VkCollection<Audio> GetRecommendations(string targetAudio = null, long? userId = null, uint? count = null,
												uint? offset = null, bool? shuffle = null);

		/// <inheritdoc cref="IAudioCategoryAsync.GetUploadServerAsync"/>
		Uri GetUploadServer();

		/// <inheritdoc cref="IAudioCategoryAsync.AddToPlaylistAsync"/>
		IEnumerable<long> AddToPlaylist(long ownerId, long playlistId, IEnumerable<string> audioIds);

		/// <inheritdoc cref="IAudioCategoryAsync.ReorderAsync"/>
		bool Reorder(long audioId, long? ownerId, long? before, long? after);

		/// <inheritdoc cref="IAudioCategoryAsync.RestoreAsync"/>
		Audio Restore(long audioId, long? ownerId = null);

		/// <inheritdoc cref="IAudioCategoryAsync.SaveAsync"/>
		Audio Save(string response, string artist = null, string title = null);

		/// <inheritdoc cref="IAudioCategoryAsync.SearchAsync"/>
		VkCollection<Audio> Search(AudioSearchParams @params);

		/// <inheritdoc cref="IAudioCategoryAsync.SetBroadcastAsync"/>
		IEnumerable<long> SetBroadcast(string audio = null, IEnumerable<long> targetIds = null);
	}
}