using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с аудиозаписями.
/// </summary>
public interface IAudioCategoryAsync
{
	/// <summary>
	/// Копирует аудиозапись на страницу пользователя или группы.
	/// </summary>
	/// <param name="audioId">
	/// Идентификатор аудиозаписи.
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца аудиозаписи.
	/// </param>
	/// <param name="accessKey">
	/// Ключ доступа.
	/// </param>
	/// <param name="groupId">
	/// Идентификатор сообщества (если аудиозапись необходимо скопировать в список
	/// сообщества).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома, в который нужно переместить аудиозапись.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор созданной аудиозаписи.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.add
	/// </remarks>
	Task<long> AddAsync(long audioId,
						long ownerId,
						string accessKey = null,
						long? groupId = null,
						long? albumId = null,
						CancellationToken token = default);

	/// <summary>
	/// Создает пустой плейлист.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца (пользователь или сообщество).
	/// </param>
	/// <param name="title">
	/// Название плейлиста.
	/// </param>
	/// <param name="description">
	/// Описание плейлиста.
	/// </param>
	/// <param name="audioIds">
	/// Идентификаторы аудиозаписей, которые необходимо добавить в альбом, в виде
	/// {owner_id}_{audio_id}.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <see cref="AudioPlaylist"/>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте -неизвестно-.
	/// </remarks>
	Task<AudioPlaylist> CreatePlaylistAsync(long ownerId,
											string title,
											string description = null,
											IEnumerable<string> audioIds = null,
											CancellationToken token = default);

	/// <summary>
	/// Удаляет аудиозапись со страницы пользователя или сообщества.
	/// </summary>
	/// <param name="audioId">
	/// Идентификатор аудиозаписи.
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца аудиозаписи (пользователь или сообщество).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.delete
	/// </remarks>
	Task<bool> DeleteAsync(long audioId,
							long ownerId,
							CancellationToken token = default);

	/// <summary>
	/// Удаляет альбом аудиозаписей.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца (пользователь или сообщество).
	/// </param>
	/// <param name="playlistId">
	/// Идентификатор плейлиста.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте -неизвестно-.
	/// </remarks>
	Task<bool> DeletePlaylistAsync(long ownerId,
									long playlistId,
									CancellationToken token = default);

	/// <summary>
	/// Редактирует данные аудиозаписи на странице пользователя или сообщества.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает id текста, введенного пользователем
	/// (lyrics_id), если текст не был введен, вернет 0.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.edit
	/// </remarks>
	Task<long> EditAsync(AudioEditParams @params,
						CancellationToken token = default);

	/// <summary>
	/// Редактирует плейлист.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца (пользователь или сообщество).
	/// </param>
	/// <param name="playlistId">
	/// Идентификатор плейлиста.
	/// </param>
	/// <param name="title">
	/// Новое название для плейлиста.
	/// </param>
	/// <param name="description">
	/// Новое описание для плейлиста.
	/// </param>
	/// <param name="audioIds">
	/// Идентификаторы аудиозаписей, в виде {owner_id}_{audio_id}.
	/// Чтобы добавить аудиозаписи необходимо перечислить
	/// идентификаторы всех имеющихся аудиозаписей в плейлисте + новые.
	/// Не указывайте идентификаторы аудиозаписей, которые необходимо удалить.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте -неизвестно-.
	/// </remarks>
	Task<bool> EditPlaylistAsync(long ownerId,
								int playlistId,
								string title,
								string description = null,
								IEnumerable<string> audioIds = null,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список аудиозаписей пользователя или сообщества.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов <see cref="Audio"/>.
	/// Обратите внимание, что ссылки на mp3 привязаны к ip-адресу.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.get
	/// </remarks>
	Task<VkCollection<Audio>> GetAsync(AudioGetParams @params,
										CancellationToken token = default);

	/// <summary>
	/// Возвращает список плейлистов пользователя или группы.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества.
	/// </param>
	/// <param name="offset">
	/// Смещение, необходимое для выборки определенного подмножества плейлистов.
	/// </param>
	/// <param name="count">
	/// Количество плейлистов, которое необходимо вернуть. По умолчанию -неизвестно-, максимальное значение -неизвестно-.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает общее количество альбомов с аудиозаписями
	/// и массив объектов <see cref="AudioPlaylist"/>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте -неизвестно-.
	/// </remarks>
	Task<VkCollection<AudioPlaylist>> GetPlaylistsAsync(long ownerId,
														uint? count = null,
														uint? offset = null,
														CancellationToken token = default);

	/// <summary>
	/// Возвращает <see cref="AudioPlaylist"/> пользователя или группы.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества.
	/// </param>
	/// <param name="playlistId">
	/// Идентификатор плейлиста.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <see cref="AudioPlaylist"/>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте -неизвестно-.
	/// </remarks>
	Task<AudioPlaylist> GetPlaylistByIdAsync(long ownerId,
											long playlistId,
											CancellationToken token = default);

	/// <summary>
	/// Возвращает список друзей и сообществ пользователя, которые транслируют музыку в
	/// статус.
	/// </summary>
	/// <param name="filter">
	/// Определяет, какие типы объектов необходимо получить.
	/// </param>
	/// <param name="active">
	/// true — будут возвращены только друзья и сообщества, которые транслируют музыку в
	/// данный момент.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов <see cref="User"/> и <see cref="Group"/> с
	/// дополнительным полем status_audio — объект аудиозаписи, установленной в статус
	/// (если аудиозапись транслируется в текущей момент).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getBroadcastList
	/// </remarks>
	Task<IEnumerable<object>> GetBroadcastListAsync(AudioBroadcastFilter filter = null,
													bool? active = null,
													CancellationToken token = default);

	/// <summary>
	/// Возвращает информацию об аудиозаписях.
	/// </summary>
	/// <param name="audios">
	/// Идентификаторы аудиозаписей, информацию о которых необходимо вернуть, в виде
	/// {owner_id}_{audio_id}.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов <see cref="Audio"/>. Обратите внимание,
	/// что ссылки на аудиозаписи привязаны
	/// к ip адресу.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getById
	/// </remarks>
	Task<IEnumerable<Audio>> GetByIdAsync(IEnumerable<string> audios,
										CancellationToken token = default);

	/// <summary>
	/// Возвращает каталог пользователя.
	/// </summary>
	/// <param name="count">
	/// Количество каталогов необходимое вернуть.
	/// </param>
	/// <param name="extended">
	/// Возвращает дополнительную информацию о каталоге.
	/// </param>
	/// <param name="fields">
	/// Дополнительные поля
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект <see cref="AudioGetCatalogResult"/>. Обратите внимание,
	/// что ссылки на аудиозаписи привязаны
	/// к ip адресу.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getById
	/// </remarks>
	Task<AudioGetCatalogResult> GetCatalogAsync(uint? count,
												bool? extended,
												UsersFields fields = null,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает количество аудиозаписей пользователя или сообщества.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца аудиозаписей (пользователь или сообщество). Обратите
	/// внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает число, равное количеству аудиозаписей на
	/// странице пользователя или сообщества.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getCount
	/// </remarks>
	Task<long> GetCountAsync(long ownerId,
							CancellationToken token = default);

	/// <summary>
	/// Возвращает текст аудиозаписи.
	/// </summary>
	/// <param name="lyricsId">
	/// Идентификатор текста аудиозаписи, информацию о котором необходимо вернуть.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект <see cref="Lyrics"/>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getLyrics
	/// </remarks>
	Task<Lyrics> GetLyricsAsync(long lyricsId,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список аудиозаписей из раздела "Популярное".
	/// </summary>
	/// <param name="onlyEng">
	/// true – возвращать только зарубежные аудиозаписи. false – возвращать все аудиозаписи.
	/// </param>
	/// <param name="genre">
	/// Идентификатор жанра из списка жанров.
	/// </param>
	/// <param name="offset">
	/// Смещение, необходимое для выборки определенного подмножества аудиозаписей.
	/// </param>
	/// <param name="count">
	/// Количество возвращаемых аудиозаписей. Максимальное
	/// значение 1000, по умолчанию 100.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов <see cref="Audio"/>. Обратите внимание,
	/// что ссылки на аудиозаписи привязаны
	/// к ip адресу.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getPopular
	/// </remarks>
	Task<IEnumerable<Audio>> GetPopularAsync(bool onlyEng = false,
											AudioGenre? genre = null,
											uint? count = null,
											uint? offset = null,
											CancellationToken token = default);

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
	/// в качестве первого параметра используется -id сообщества.
	/// </param>
	/// <param name="userId">
	/// Идентификатор пользователя для получения списка рекомендаций на основе его
	/// набора аудиозаписей (по
	/// умолчанию — идентификатор текущего пользователя).
	/// </param>
	/// <param name="offset">
	/// Смещение относительно первой найденной аудиозаписи для выборки определенного
	/// подмножества.
	/// </param>
	/// <param name="count">
	/// Количество возвращаемых аудиозаписей. Максимальное значение 1000, по умолчанию 100.
	/// </param>
	/// <param name="shuffle">
	/// true — включен случайный порядок.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов <see cref="Audio"/>. Обратите внимание,
	/// что ссылки на аудиозаписи привязаны к ip адресу.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getRecommendations
	/// </remarks>
	Task<VkCollection<Audio>> GetRecommendationsAsync(string targetAudio = null,
													long? userId = null,
													uint? count = null,
													uint? offset = null,
													bool? shuffle = null,
													CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки аудиозаписей.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект с единственным полем upload_url.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getUploadServer
	/// </remarks>
	Task<UploadServer> GetUploadServerAsync(CancellationToken token = default);

	/// <summary>
	/// Перемещает аудиозаписи в плейлист.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца (пользователь или сообщество).
	/// </param>
	/// <param name="playlistId">
	/// Идентификатор плейлиста.
	/// </param>
	/// <param name="audioIds">
	/// Идентификаторы аудиозаписей, которые требуется переместить, в виде {owner_id}_{audio_id}.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения список идентификаторов аудиозаписей.
	/// Обратите внимание, в одном альбоме не может быть более 1000 аудиозаписей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте -неизвестно-
	/// </remarks>
	Task<IEnumerable<long>> AddToPlaylistAsync(long ownerId,
												long playlistId,
												IEnumerable<string> audioIds,
												CancellationToken token = default);

	/// <summary>
	/// Изменяет порядок аудиозаписи, перенося ее между аудиозаписями, идентификаторы
	/// которых переданы параметрами after и before.
	/// </summary>
	/// <param name="audioId">
	/// Идентификатор аудиозаписи, которую нужно переместить.
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца аудиозаписи (пользователь или сообщество). По умолчанию
	/// — идентификатор текущего пользователя.
	/// </param>
	/// <param name="before">
	/// Идентификатор аудиозаписи, перед которой нужно поместить композицию.
	/// </param>
	/// <param name="after">
	/// Идентификатор аудиозаписи, после  которой нужно поместить композицию.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.reorder
	/// </remarks>
	Task<bool> ReorderAsync(long audioId,
							long? ownerId,
							long? before,
							long? after,
							CancellationToken token = default);

	/// <summary>
	/// Восстанавливает аудиозапись после удаления.
	/// </summary>
	/// <param name="audioId">
	/// Идентификатор аудиозаписи.
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца аудиозаписи (пользователь или сообщество). По умолчанию
	/// — идентификатор текущего пользователя.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// В случае успешного восстановления аудиозаписи возвращает объект <see cref="Audio"/>.
	/// Если время хранения удаленной аудиозаписи истекло (обычно это 20 минут), сервер
	/// вернет ошибку 202 (Cache expired).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.restore
	/// </remarks>
	Task<Audio> RestoreAsync(long audioId,
							long? ownerId = null,
							CancellationToken token = default);

	/// <summary>
	/// Сохраняет аудиозаписи после успешной загрузки.
	/// </summary>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки аудиофайла
	/// на сервер.
	/// </param>
	/// <param name="artist"> Автор композиции. По умолчанию берется из ID3 тегов. </param>
	/// <param name="title"> Название композиции. По умолчанию берется из ID3 тегов. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> Возвращает обьект загруженной аудиозаписи. </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.save
	/// </remarks>
	Task<Audio> SaveAsync(string response,
						string artist = null,
						string title = null,
						CancellationToken token = default);

	/// <summary>
	/// Возвращает список аудиозаписей в соответствии с заданным критерием поиска.
	/// </summary>
	/// <param name="params"> Критерии поиска </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Список объектов <see cref="Audio"/>.
	/// </returns>
	/// <remarks>
	/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
	/// содержащей Settings.Audio
	/// Страница документации ВКонтакте http://vk.com/dev/audio.search
	/// </remarks>
	Task<VkCollection<Audio>> SearchAsync(AudioSearchParams @params,
										CancellationToken token = default);

	/// <summary>
	/// Транслирует аудиозапись в статус пользователю или сообществу.
	/// </summary>
	/// <param name="audio">
	/// Идентификатор аудиозаписи, которая будет отображаться в статусе, в формате
	/// {owner_id}_{audio_id}.
	/// Например, 1_190442705. Если параметр не указан, аудиостатус указанных сообществ
	/// и пользователя будет удален.
	/// </param>
	/// <param name="targetIds">
	/// Перечисленные через запятую идентификаторы сообществ и пользователя, которым
	/// будет транслироваться аудиозапись. Идентификаторы сообществ должны быть заданы в
	/// формате "-gid", где gid - идентификатор
	/// сообщества. Например, 1,-34384434. По умолчанию аудиозапись транслируется
	/// текущему пользователю. (Количество элементов должно составлять не более 20).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает идентификаторы пользователя и сообществ для которых был установлен статус.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.setBroadcast
	/// </remarks>
	Task<IEnumerable<long>> SetBroadcastAsync(string audio = null,
											IEnumerable<long> targetIds = null,
											CancellationToken token = default);
}