using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Abstractions.Category;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public class AudioCategory : IAudioCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с аудиозаписями.
		/// </summary>
        /// <param name="vk"> Api vk.com </param>
        public AudioCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public long Add(long audioId, long ownerId, long? groupId = null, long? albumId = null)
		{
			var parameters = new VkParameters
			{
				{ "audio_id", audioId },
				{ "owner_id", ownerId },
				{ "group_id", groupId },
				{ "album_id", albumId }
			};

			return _vk.Call<long>("audio.add", parameters);
		}

		/// <inheritdoc />
		public AudioPlaylist CreatePlaylist(long ownerId, string title, string description = null, IEnumerable<string> audioIds = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "title", title },
				{ "description", description },
				{ "audio_ids", audioIds }
			};

			return _vk.Call<AudioPlaylist>("audio.createPlaylist", parameters);
		}

		/// <inheritdoc />
		public bool Delete(long audioId, long ownerId)
		{
			var parameters = new VkParameters
			{
				{ "audio_id", audioId },
				{ "owner_id", ownerId }
			};

			return _vk.Call<bool>("audio.delete", parameters);
		}

		/// <inheritdoc />
		public bool DeletePlaylist(long ownerId, long playlistId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "playlist_id", playlistId }
			};

			return _vk.Call<bool>("audio.deletePlaylist", parameters);
		}

		/// <inheritdoc />
		public long Edit(AudioEditParams @params)
		{
			return _vk.Call<long>("audio.edit", @params);
		}

		/// <inheritdoc />
		[Obsolete(
			"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.deleteAlbum и audio.moveToAlbum устарели.")]
		public bool EditAlbum(string title, long albumId, long? groupId = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => title);

			var parameters = new VkParameters
			{
				{ "title", title },
				{ "group_id", groupId },
				{ "album_id", albumId }
			};

			return _vk.Call<bool>("audio.editAlbum", parameters);
		}

		/// <inheritdoc />
		public IEnumerable<Audio> Get(AudioGetParams @params, out User user)
		{
			VkResponseArray response = _vk.Call("audio.get", @params);

			IEnumerable<VkResponse> items = response.ToList();

			user = null;

			if (@params.NeedUser.HasValue && @params.NeedUser.Value && items.Any())
			{
				user = items.First();
				items = items.Skip(1);
			}

			return items.ToReadOnlyCollectionOf<Audio>(r => r);
		}

		/// <inheritdoc />
		[Obsolete(
			"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.deleteAlbum и audio.moveToAlbum устарели.")]
		public VkCollection<AudioAlbum> GetAlbums(long? ownerId = null, uint? count = null, uint? offset = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call<VkCollection<AudioAlbum>>("audio.getAlbums", parameters);
		}

		/// <inheritdoc />
		public UserOrGroup GetBroadcastList(AudioBroadcastFilter filter = null, bool? active = null)
		{
			var parameters = new VkParameters
			{
				{ "filter", filter },
				{ "active", active }
			};

			return _vk.Call("audio.getBroadcastList", parameters);
		}

		/// <inheritdoc />
		public IEnumerable<Audio> GetById(IEnumerable<string> audios)
		{
			var parameters = new VkParameters
			{
				{ "audios", audios }
			};

			return _vk.Call<ReadOnlyCollection<Audio>>("audio.getById", parameters);
		}

		/// <inheritdoc />
		public long GetCount(long ownerId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId }
			};

			return _vk.Call<long>("audio.getCount", parameters);
		}

		/// <inheritdoc />
		public Lyrics GetLyrics(long lyricsId)
		{
			var parameters = new VkParameters
			{
				{ "lyrics_id", lyricsId }
			};

			return _vk.Call<Lyrics>("audio.getLyrics", parameters);
		}

		/// <inheritdoc />
		public IEnumerable<Audio> GetPopular(bool onlyEng = false, AudioGenre? genre = null, uint? count = null, uint? offset = null)
		{
			var parameters = new VkParameters
			{
				{ "only_eng", onlyEng },
				{ "genre_id", genre },
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call<ReadOnlyCollection<Audio>>("audio.getPopular", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Audio> GetRecommendations(string targetAudio = null, long? userId = null, uint? count = null,
													uint? offset = null, bool? shuffle = null)
		{
			var parameters = new VkParameters
			{
				{ "target_audio", targetAudio },
				{ "user_id", userId },
				{ "offset", offset },
				{ "count", count },
				{ "shuffle", shuffle }
			};

			return _vk.Call<VkCollection<Audio>>("audio.getRecommendations", parameters);
		}

		/// <inheritdoc />
		public Uri GetUploadServer()
		{
			var response = _vk.Call("audio.getUploadServer", VkParameters.Empty);

			return response["upload_url"];
		}

		/// <inheritdoc />
		[Obsolete(
			"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.deleteAlbum и audio.moveToAlbum устарели. ")]
		public bool MoveToAlbum(long albumId, IEnumerable<long> audioIds, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "album_id", albumId },
				{ "group_id", groupId },
				{ "audio_ids", audioIds }
			};

			return _vk.Call<bool>("audio.moveToAlbum", parameters);
		}

		/// <inheritdoc />
		public bool Reorder(long audioId, long? ownerId, long? before, long? after)
		{
			var parameters = new VkParameters
			{
				{ "audio_id", audioId },
				{ "owner_id", ownerId },
				{ "before", before },
				{ "after", after }
			};

			return _vk.Call<bool>("audio.reorder", parameters);
		}

		/// <inheritdoc />
		public Audio Restore(long audioId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "audio_id", audioId },
				{ "owner_id", ownerId }
			};

			return _vk.Call<Audio>("audio.restore", parameters);
		}

		/// <inheritdoc />
		public Audio Save(string response, string artist = null, string title = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => response);
			var responseJson = JObject.Parse(response);
			var server = responseJson["server"].ToString();
			var hash = responseJson["hash"].ToString();
			var audio = responseJson["audio"].ToString();

			var parameters = new VkParameters
			{
				{ "server", server },
				{ "audio", Uri.EscapeDataString(audio) },
				{ "hash", hash },
				{ "artist", artist },
				{ "title", title }
			};

			return _vk.Call<Audio>("audio.save", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Audio> Search(AudioSearchParams @params)
		{
			return _vk.Call<VkCollection<Audio>>("audio.search", @params);
		}

		/// <inheritdoc />
		public IEnumerable<long> SetBroadcast(string audio = null, IEnumerable<long> targetIds = null)
		{
			var parameters = new VkParameters
			{
				{ "audio", audio },
				{ "target_ids", targetIds }
			};

			return _vk.Call<ReadOnlyCollection<long>>("audio.setBroadcast", parameters);
		}
	}
}