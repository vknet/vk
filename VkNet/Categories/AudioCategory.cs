using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с аудиозаписями.
	/// </summary>
	public class AudioCategory
	{
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с аудиозаписями.
		/// </summary>
		/// <param name="vk"> Api vk.com </param>
		public AudioCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает количество аудиозаписей пользователя или сообщества.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца аудиозаписей (пользователь или сообщество). Обратите
		/// внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число,
		/// обязательный параметр (Целое число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает число, равное количеству аудиозаписей на
		/// странице пользователя или
		/// сообщества.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getCount
		/// </remarks>
		public long GetCount(long ownerId)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
			};

			return _vk.Call(methodName: "audio.getCount", parameters: parameters);
		}

		/// <summary>
		/// Возвращает текст аудиозаписи.
		/// </summary>
		/// <param name="lyricsId">
		/// Идентификатор текста аудиозаписи, информацию о котором необходимо вернуть.
		/// целое число,
		/// обязательный параметр (Целое число, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект lyrics c полями lyrics_id —
		/// идентификатор текста и text — текст
		/// аудиозаписи.
		/// В качестве переводов строк в тексте используется /n.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getLyrics
		/// </remarks>
		public Lyrics GetLyrics(long lyricsId)
		{
			var parameters = new VkParameters
			{
					{ "lyrics_id", lyricsId }
			};

			return _vk.Call(methodName: "audio.getLyrics", parameters: parameters);
		}

		/// <summary>
		/// Возвращает информацию об аудиозаписях.
		/// </summary>
		/// <param name="audios">
		/// Идентификаторы аудиозаписей, информацию о которых необходимо вернуть, в виде
		/// {owner_id}_{audio_id}. список строк, разделенных через запятую, обязательный
		/// параметр (Список строк, разделенных
		/// через запятую, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов audio. Обратите внимание,
		/// что ссылки на аудиозаписи привязаны
		/// к ip адресу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getById
		/// </remarks>
		public ReadOnlyCollection<Audio> GetById(IEnumerable<string> audios)
		{
			if (!audios.Any())
			{
				throw new ArgumentNullException(paramName: nameof(audios));
			}

			var parameters = new VkParameters { { "audios", audios } };
			VkResponseArray response = _vk.Call(methodName: "audio.getById", parameters: parameters);

			return response.ToReadOnlyCollectionOf<Audio>(selector: x => x);
		}

		/// <summary>
		/// Возвращает информацию об аудиозаписях.
		/// </summary>
		/// <param name="audios">
		/// Идентификаторы аудиозаписей, информацию о которых необходимо вернуть, в виде
		/// {owner_id}_{audio_id}. список строк, разделенных через запятую, обязательный
		/// параметр (Список строк, разделенных
		/// через запятую, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов audio. Обратите внимание,
		/// что ссылки на аудиозаписи привязаны
		/// к ip адресу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getById
		/// </remarks>
		public ReadOnlyCollection<Audio> GetById(params string[] audios)
		{
			return GetById(audios: (IEnumerable<string>) audios);
		}

		/// <summary>
		/// Возвращает список аудиозаписей пользователя или сообщества.
		/// </summary>
		/// <param name="user"> Данные о пользователе. </param>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов audio.
		/// Если был задан параметр need_user=1, дополнительно возвращается объект user,
		/// содержащий поля:
		/// id — идентификатор пользователя;
		/// photo — url фотографии профиля;
		/// name — имя и фамилия пользователя;
		/// name_gen — имя пользователя в родительном падеже.
		/// Обратите внимание, что ссылки на mp3 привязаны к ip-адресу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.get
		/// </remarks>
		public ReadOnlyCollection<Audio> Get(out User user, AudioGetParams @params)
		{
			VkResponseArray response = _vk.Call(methodName: "audio.get", parameters: @params);

			IEnumerable<VkResponse> items = response.ToList();

			user = null;

			if (@params.NeedUser.HasValue && @params.NeedUser.Value && items.Any())
			{
				user = items.First();
				items = items.Skip(count: 1);
			}

			return items.ToReadOnlyCollectionOf<Audio>(selector: r => r);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки аудиозаписей.
		/// </summary>
		/// <returns>
		/// После успешного выполнения возвращает объект с единственным полем upload_url.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getUploadServer
		/// </remarks>
		public Uri GetUploadServer()
		{
			var response = _vk.Call(methodName: "audio.getUploadServer", parameters: VkParameters.Empty);

			return response[key: "upload_url"];
		}

		/// <summary>
		/// Возвращает список аудиозаписей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="params"> Критерии поиска </param>
		/// <returns>
		/// Список объектов класса Audio.
		/// </returns>
		/// <exception cref="System.ArgumentNullException"> Query is null or empty.;query </exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Audio
		/// Страница документации ВКонтакте http://vk.com/dev/audio.search
		/// </remarks>
		public VkCollection<Audio> Search(AudioSearchParams @params)
		{
			if (string.IsNullOrWhiteSpace(value: @params.Query))
			{
				throw new ArgumentNullException(paramName: nameof(@params.Query), message: "Query is null or empty.");
			}

			return _vk.Call(methodName: "audio.search", parameters: @params).ToVkCollectionOf<Audio>(selector: r => r);
		}

		/// <summary>
		/// Копирует аудиозапись на страницу пользователя или группы.
		/// </summary>
		/// <param name="audioId">
		/// Идентификатор аудиозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца аудиозаписи (пользователь или сообщество). целое число,
		/// обязательный
		/// параметр (Целое число, обязательный параметр).
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (если аудиозапись необходимо скопировать в список
		/// сообщества). целое
		/// число (Целое число).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома, в который нужно переместить аудиозапись. положительное
		/// число
		/// (Положительное число).
		/// </param>
		/// <param name="captchaSid">
		/// Id капчи (только если для вызова метода необходимо
		/// ввести капчу)
		/// </param>
		/// <param name="captchaKey">
		/// Текст капчи (только если для вызова метода необходимо
		/// ввести капчу)
		/// </param>
		/// <returns>
		/// После успешного выполнения  возвращает идентификатор созданной аудиозаписи.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.add
		/// </remarks>
		public long Add(long audioId
						, long ownerId
						, long? groupId = null
						, long? albumId = null
						, long? captchaSid = null
						, string captchaKey = null)
		{
			var parameters = new VkParameters
			{
					{ "audio_id", audioId }
					, { "owner_id", ownerId }
					, { "group_id", groupId }
					, { "album_id", albumId }
					, { "captcha_sid", captchaSid }
					, { "captcha_key", captchaKey }
			};

			return _vk.Call(methodName: "audio.add", parameters: parameters);
		}

		/// <summary>
		/// Удаляет аудиозапись со страницы пользователя или сообщества.
		/// </summary>
		/// <param name="audioId">
		/// Идентификатор аудиозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца аудиозаписи (пользователь или сообщество). целое число,
		/// обязательный
		/// параметр (Целое число, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.delete
		/// </remarks>
		public bool Delete(long audioId, long ownerId)
		{
			var parameters = new VkParameters
			{
					{ "audio_id", audioId }
					, { "owner_id", ownerId }
			};

			return _vk.Call(methodName: "audio.delete", parameters: parameters);
		}

		/// <summary>
		/// Редактирует данные аудиозаписи на странице пользователя или сообщества.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает id текста, введенного пользователем
		/// (lyrics_id), если текст не был введен,
		/// вернет 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.edit
		/// </remarks>
		public long Edit(AudioEditParams @params)
		{
			if (@params.Artist == null)
			{
				throw new ArgumentNullException(paramName: nameof(@params.Artist), message: "Artist parameter can not be null.");
			}

			if (@params.Title == null)
			{
				throw new ArgumentNullException(paramName: nameof(@params.Title), message: "Title parameter can not be null.");
			}

			if (@params.Text == null)
			{
				throw new ArgumentNullException(paramName: nameof(@params.Text), message: "Text parameter can not be null.");
			}

			return _vk.Call(methodName: "audio.edit", parameters: @params);
		}

		/// <summary>
		/// Восстанавливает аудиозапись после удаления.
		/// </summary>
		/// <param name="audioId">
		/// Идентификатор аудиозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца аудиозаписи (пользователь или сообщество). По умолчанию
		/// — идентификатор
		/// текущего пользователя. целое число, по умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию
		/// идентификатор текущего пользователя).
		/// </param>
		/// <returns>
		/// В случае успешного восстановления аудиозаписи возвращает объект аудиозаписи.
		/// Если время хранения удаленной аудиозаписи истекло (обычно это 20 минут), сервер
		/// вернет ошибку 202 (Cache expired).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.restore
		/// </remarks>
		public Audio Restore(long audioId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
					{ "audio_id", audioId }
					, { "owner_id", ownerId }
			};

			return _vk.Call(methodName: "audio.restore", parameters: parameters);
		}

		/// <summary>
		/// Изменяет порядок аудиозаписи, перенося ее между аудиозаписями, идентификаторы
		/// которых переданы параметрами after и
		/// before.
		/// </summary>
		/// <param name="audioId">
		/// Идентификатор аудиозаписи, которую нужно переместить. положительное число,
		/// обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца аудиозаписи (пользователь или сообщество). По умолчанию
		/// — идентификатор
		/// текущего пользователя. целое число, по умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию
		/// идентификатор текущего пользователя).
		/// </param>
		/// <param name="before">
		/// Идентификатор аудиозаписи, перед которой нужно поместить композицию aid. целое
		/// число (Целое
		/// число).
		/// </param>
		/// <param name="after">
		/// Идентификатор аудиозаписи, после  которой нужно поместить композицию aid. целое
		/// число (Целое
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.reorder
		/// </remarks>
		public bool Reorder(long audioId, long? ownerId, long? before, long? after)
		{
			var parameters = new VkParameters
			{
					{ "audio_id", audioId }
					, { "owner_id", ownerId }
					, { "before", before }
					, { "after", after }
			};

			return _vk.Call(methodName: "audio.reorder", parameters: parameters);
		}

		/// <summary>
		/// Создает пустой альбом аудиозаписей.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества (если альбом нужно создать в сообществе).
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="title">
		/// Название альбома. строка, обязательный параметр (Строка,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор (album_id) созданного
		/// альбома.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.addAlbum
		/// </remarks>
		[Obsolete(message:
				"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.addAlbum, audio.deleteAlbum и audio.moveToAlbum устарели. ")]
		public long AddAlbum(string title, long? groupId = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => title);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "title", title }
			};

			var response = _vk.Call(methodName: "audio.addAlbum", parameters: parameters);

			return response[key: "album_id"];
		}

		/// <summary>
		/// Редактирует название альбома аудиозаписей.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, которому принадлежит альбом. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="title">
		/// Новое название для альбома. строка, обязательный параметр (Строка, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.editAlbum
		/// </remarks>
		[Obsolete(message:
				"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.addAlbum, audio.deleteAlbum и audio.moveToAlbum устарели. ")]
		public bool EditAlbum(string title, long albumId, long? groupId = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => title);

			var parameters = new VkParameters
			{
					{ "title", title }
					, { "group_id", groupId }
					, { "album_id", albumId }
			};

			return _vk.Call(methodName: "audio.editAlbum", parameters: parameters);
		}

		/// <summary>
		/// Удаляет альбом аудиозаписей.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, которому принадлежит альбом. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.deleteAlbum
		/// </remarks>
		[Obsolete(message:
				"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.addAlbum, audio.deleteAlbum и audio.moveToAlbum устарели. ")]
		public bool DeleteAlbum(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "album_id", albumId }
			};

			return _vk.Call(methodName: "audio.deleteAlbum", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список аудиозаписей из раздела "Популярное".
		/// </summary>
		/// <param name="onlyEng">
		/// 1 – возвращать только зарубежные аудиозаписи. 0 – возвращать все аудиозаписи.
		/// (по умолчанию)
		/// флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или
		/// 0).
		/// </param>
		/// <param name="genre">
		/// Идентификатор жанра из списка жанров. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества аудиозаписей.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество возвращаемых аудиозаписей. положительное число, максимальное
		/// значение 1000, по умолчанию
		/// 100 (Положительное число, максимальное значение 1000, по умолчанию 100).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов audio. Обратите внимание,
		/// что ссылки на аудиозаписи привязаны
		/// к ip адресу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getPopular
		/// </remarks>
		public ReadOnlyCollection<Audio> GetPopular(bool onlyEng = false, AudioGenre? genre = null, uint? count = null, uint? offset = null)
		{
			var parameters = new VkParameters
			{
					{ "only_eng", onlyEng }
					, { "genre_id", genre }
					, { "offset", offset }
			};

			if (count <= 1000)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			VkResponseArray response = _vk.Call(methodName: "audio.getPopular", parameters: parameters);

			return response.ToReadOnlyCollectionOf<Audio>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список альбомов аудиозаписей пользователя или группы.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, у которого необходимо получить
		/// список альбомов с
		/// аудио. целое число, по умолчанию идентификатор текущего пользователя (Целое
		/// число, по умолчанию идентификатор
		/// текущего пользователя).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества альбомов.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество альбомов, которое необходимо вернуть. положительное число, по
		/// умолчанию 50, максимальное
		/// значение 100 (Положительное число, по умолчанию 50, максимальное значение 100).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество альбомов с аудиозаписями
		/// и массив объектов album, каждый из
		/// которых содержит следующие поля:
		/// id — идентификатор альбома;
		/// owner_id — идентификатор владельца альбома;
		/// title — название альбома.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getAlbums
		/// </remarks>
		[Obsolete(message:
				"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.addAlbum, audio.deleteAlbum и audio.moveToAlbum устарели. ")]
		public VkCollection<AudioAlbum> GetAlbums(long ownerId, uint? count = null, uint? offset = null)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
					, { "offset", offset }
					, { "count", count }
			};

			return _vk.Call(methodName: "audio.getAlbums", parameters: parameters).ToVkCollectionOf<AudioAlbum>(selector: x => x);
		}

		/// <summary>
		/// Перемещает аудиозаписи в альбом.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, в котором размещены аудиозаписи. Если параметр не
		/// указан, работа
		/// ведется с аудиозаписями текущего пользователя. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома, в который нужно переместить аудиозаписи. положительное
		/// число
		/// (Положительное число).
		/// </param>
		/// <param name="audioIds">
		/// Идентификаторы аудиозаписей, которые требуется переместить. список
		/// положительных чисел,
		/// разделенных запятыми, обязательный параметр (Список положительных чисел,
		/// разделенных запятыми, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// Обратите внимание, в одном альбоме не может быть более 1000 аудиозаписей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.moveToAlbum
		/// </remarks>
		[Obsolete(message:
				"5.65 Методы audio.getAlbums, audio.addAlbum, audio.editAlbum, audio.addAlbum, audio.deleteAlbum и audio.moveToAlbum устарели. ")]
		public bool MoveToAlbum(long albumId, IEnumerable<long> audioIds, long? groupId = null)
		{
			var parameters = new VkParameters
			{
					{ "album_id", albumId }
					, { "group_id", groupId }
					, { "audio_ids", audioIds }
			};

			return _vk.Call(methodName: "audio.moveToAlbum", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список рекомендуемых аудиозаписей на основе списка воспроизведения
		/// заданного пользователя или на основе
		/// одной выбранной аудиозаписи.
		/// </summary>
		/// <param name="targetAudio">
		/// Идентификатор аудиозаписи, на основе которой будет строиться список
		/// рекомендаций.
		/// Используется вместо параметра uid. Идентификатор представляет из себя
		/// разделённые знаком подчеркивания id
		/// пользователя, которому принадлежит аудиозапись, и id самой аудиозаписи. Если
		/// аудиозапись принадлежит сообществу, то
		/// в качестве первого параметра используется -id сообщества. строка (Строка).
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя для получения списка рекомендаций на основе его
		/// набора аудиозаписей (по
		/// умолчанию — идентификатор текущего пользователя). положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="offset">
		/// Смещение относительно первой найденной аудиозаписи для выборки определенного
		/// подмножества.
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество возвращаемых аудиозаписей. положительное число, максимальное
		/// значение 1000, по умолчанию
		/// 100 (Положительное число, максимальное значение 1000, по умолчанию 100).
		/// </param>
		/// <param name="shuffle">
		/// 1 — включен случайный порядок. флаг, может принимать значения 1 или 0 (Флаг,
		/// может принимать
		/// значения 1 или 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов audio. Обратите внимание,
		/// что ссылки на аудиозаписи привязаны
		/// к ip адресу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getRecommendations
		/// </remarks>
		public ReadOnlyCollection<Audio> GetRecommendations(long? userId = null
															, uint? count = null
															, uint? offset = null
															, bool shuffle = true
															, string targetAudio = "")
		{
			var parameters = new VkParameters
			{
					{ "target_audio", targetAudio }
					, { "user_id", userId }
					, { "offset", offset }
					, { "count", count }
					, { "shuffle", shuffle }
			};

			VkResponseArray response = _vk.Call(methodName: "audio.getRecommendations", parameters: parameters);

			return response.ToReadOnlyCollectionOf<Audio>(selector: x => x);
		}

		/// <summary>
		/// Транслирует аудиозапись в статус пользователю или сообществу.
		/// </summary>
		/// <param name="audio">
		/// Идентификатор аудиозаписи, которая будет отображаться в статусе, в формате
		/// owner_id_audio_id.
		/// Например, 1_190442705. Если параметр не указан, аудиостатус указанных сообществ
		/// и пользователя будет удален. строка
		/// (Строка).
		/// </param>
		/// <param name="targetIds">
		/// Перечисленные через запятую идентификаторы сообществ и пользователя, которым
		/// будет
		/// транслироваться аудиозапись. Идентификаторы сообществ должны быть заданы в
		/// формате "-gid", где gid - идентификатор
		/// сообщества. Например, 1,-34384434. По умолчанию аудиозапись транслируется
		/// текущему пользователю. список целых
		/// чисел, разделенных запятыми, количество элементов должно составлять не более 20
		/// (Список целых чисел, разделенных
		/// запятыми, количество элементов должно составлять не более 20).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает массив идентификаторов сообществ и
		/// пользователя, которым был установлен
		/// или удален аудиостатус.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.setBroadcast
		/// </remarks>
		public ReadOnlyCollection<long> SetBroadcast(string audio, IEnumerable<long> targetIds)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => audio);

			var parameters = new VkParameters
			{
					{ "audio", audio }
					, { "target_ids", targetIds }
			};

			VkResponseArray response = _vk.Call(methodName: "audio.setBroadcast", parameters: parameters);

			return response.ToReadOnlyCollectionOf<long>(selector: x => x);
		}

		/// <summary>
		/// Сохраняет аудиозаписи после успешной загрузки.
		/// </summary>
		/// <param name="response">
		/// Параметр, возвращаемый в результате загрузки аудиофайла
		/// на сервер.
		/// </param>
		/// <param name="artist"> Автор композиции. По умолчанию берется из ID3 тегов. </param>
		/// <param name="title"> Название композиции. По умолчанию берется из ID3 тегов. </param>
		/// <returns> Возвращает массив из объектов с загруженными аудиозаписями. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.save
		/// </remarks>
		public Audio Save(string response, string artist = null, string title = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => response);
			var responseJson = JObject.Parse(json: response);
			var server = responseJson[propertyName: "server"].ToString();
			var hash = responseJson[propertyName: "hash"].ToString();
			var audio = responseJson[propertyName: "audio"].ToString();

			var parameters = new VkParameters
			{
					{ "server", server }
					, { "audio", Uri.EscapeDataString(stringToEscape: audio) }
					, { "hash", hash }
					, { "artist", artist }
					, { "title", title }
			};

			return _vk.Call(methodName: "audio.save", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список друзей, которые транслируют музыку в статус.
		/// </summary>
		/// <param name="active">
		/// <c> true </c> — будут возвращены только друзья и сообщества, которые
		/// транслируют музыку в данный
		/// момент. По умолчанию возвращаются все.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов друзей с дополнительным
		/// полем status_audio — объект
		/// аудиозаписи,
		/// установленной в статус (если аудиозапись транслируется в текущей момент).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getBroadcastList
		/// </remarks>
		public ReadOnlyCollection<User> GetBroadcastListFriends(bool active = false)
		{
			var parameters = new VkParameters
			{
					{ "filter", "friends" }
					, { "active", active }
			};

			VkResponseArray response = _vk.Call(methodName: "audio.getBroadcastList", parameters: parameters);

			return response.ToReadOnlyCollectionOf<User>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список друзей и сообществ пользователя, которые транслируют музыку в
		/// статус.
		/// </summary>
		/// <param name="filter">
		/// Определяет, какие типы объектов необходимо получить. Возможны следующие
		/// значения параметра:
		/// friends — только друзья;
		/// groups — только сообщества;
		/// all — друзья и сообщества. строка, по умолчанию all (Строка, по умолчанию all).
		/// </param>
		/// <param name="active">
		/// 1 — будут возвращены только друзья и сообщества, которые транслируют музыку в
		/// данный момент. По
		/// умолчанию возвращаются все. флаг, может принимать значения 1 или 0 (Флаг, может
		/// принимать значения 1 или 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов друзей и сообществ с
		/// дополнительным полем status_audio —
		/// объект аудиозаписи, установленной в статус (если аудиозапись транслируется в
		/// текущей момент).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getBroadcastList
		/// </remarks>
		public UserOrGroup GetBroadcastList(string filter = null, bool? active = null)
		{
			var parameters = new VkParameters
			{
					{ "filter", filter }
					, { "active", active }
			};

			return _vk.Call(methodName: "audio.getBroadcastList", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список сообществ пользователя, которые транслируют музыку в статус.
		/// </summary>
		/// <param name="active">
		/// <c> true </c> — будут возвращены только друзья и сообщества, которые
		/// транслируют музыку в данный
		/// момент. По умолчанию возвращаются все.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов сообществ с
		/// дополнительным полем status_audio — объект
		/// аудиозаписи,
		/// установленной в статус (если аудиозапись транслируется в текущей момент).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/audio.getBroadcastList
		/// </remarks>
		public ReadOnlyCollection<Group> GetBroadcastListGroup(bool active = false)
		{
			var parameters = new VkParameters
			{
					{ "filter", "groups" }
					, { "active", active }
			};

			VkResponseArray response = _vk.Call(methodName: "audio.getBroadcastList", parameters: parameters);

			return response.ToReadOnlyCollectionOf<Group>(selector: x => x);
		}
	}
}