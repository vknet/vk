namespace VkNet.Categories
{
    using System.Collections.ObjectModel;

    using Utils;
    using Enums;
    using Model;
    using Model.Attachments;

    public class PhotosCategory
    {
        private readonly VkApi _vk;

        internal PhotosCategory(VkApi vk)
        {
            _vk = vk;
        }
/// <summary>
/// Создает пустой альбом для фотографий. 
/// </summary>
/// <param name="title">название альбома. строка, обязательный параметр, минимальная длина 2</param>
/// <param name="groupId">идентификатор сообщества, в котором создаётся альбом. Для группы privacy  и comment_privacy могут принимать два значения: 0 — доступ для всех пользователей, 1 — доступ только для участников группы. целое число</param>
/// <param name="description">текст описания альбома. строка</param>
/// <param name="commentPrivacy">уровень доступа к комментированию альбома. Возможные значения: 0 — все пользователи, 1 — только друзья, 2 — друзья и друзья друзей, 3 — только я. </param>
/// <param name="privacy">уровень доступа к альбому. Возможные значения: 0 — все пользователи, 1 — только друзья, 2 — друзья и друзья друзей, 3 — только я. </param>
/// <returns>После успешного выполнения возвращает объект <see cref="PhotoAlbum"/></returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.createAlbum"/>.
/// </remarks>
public PhotoAlbum CreateAlbum(long title, long? groupId = null, long? description = null, long? commentPrivacy = null, long? privacy = null)
{

    var parameters = new VkParameters
        {
            {"title", title},
            {"group_id", groupId},
            {"description", description},
            {"comment_privacy", commentPrivacy},
            {"privacy", privacy}
        };

    VkResponse response = _vk.Call("photos.createAlbum", parameters);

    return response;
}

/// <summary>
/// Редактирует данные альбома для фотографий пользователя. 
/// </summary>
/// <param name="albumId">идентификатор альбома. целое число, положительное число, обязательный параметр</param>
/// <param name="title">новое название альбома. строка</param>
/// <param name="description">новый текст описания альбома. строка</param>
/// <param name="ownerId">идентификатор владельца альбома (пользователь или сообщество). Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  по умолчанию идентификатор текущего пользователя</param>
/// <param name="privacy">новый уровень доступа к альбому. Возможные значения: 0 — все пользователи, 1 — только друзья, 2 — друзья и друзья друзей, 3 — только я. </param>
/// <param name="commentPrivacy">новый уровень доступа к комментированию альбома. Возможные значения: 0 — все пользователи, 1 — только друзья, 2 — друзья и друзья друзей, 3 — только я. </param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.editAlbum"/>.
/// </remarks>
public bool EditAlbum(long albumId, long? title = null, long? description = null, long? ownerId = null, long? privacy = null, long? commentPrivacy = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => albumId);

    var parameters = new VkParameters
        {
            {"album_id", albumId},
            {"title", title},
            {"description", description},
            {"owner_id", ownerId},
            {"privacy", privacy},
            {"comment_privacy", commentPrivacy}
        };

    VkResponse response = _vk.Call("photos.editAlbum", parameters);

    return response;
}

/// <summary>
/// Возвращает список альбомов пользователя или сообщества. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежат альбомы. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="albumIds">перечисленные через запятую ID альбомов. список целых чисел, разделенных запятыми</param>
/// <param name="offset">смещение, необходимое для выборки определенного подмножества альбомов. положительное число</param>
/// <param name="count">количество альбомов, которое нужно вернуть. (по умолчанию – все альбомы) положительное число</param>
/// <param name="needSystem">1 – будут возвращены системные альбомы, имеющие отрицательные идентификаторы. </param>
/// <param name="needCovers">1 — будет возвращено дополнительное поле thumb_src. По умолчанию поле thumb_src не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="photoSizes">1 — будут возвращены размеры фотографий в специальном формате. флаг, может принимать значения 1 или 0</param>
/// <returns>Возвращает список объектов <see cref="PhotoAlbum"/></returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getAlbums"/>.
/// </remarks>
public ReadOnlyCollection<PhotoAlbum> GetAlbums(long? ownerId = null, long? albumIds = null, int? offset = null, int? count = null, long? needSystem = null, long? needCovers = null, long? photoSizes = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"album_ids", albumIds},
            {"offset", offset},
            {"count", count},
            {"need_system", needSystem},
            {"need_covers", needCovers},
            {"photo_sizes", photoSizes}
        };

    VkResponseArray response = _vk.Call("photos.getAlbums", parameters);

    return response.ToReadOnlyCollectionOf<PhotoAlbum>(x => x);
}

/// <summary>
/// Возвращает список фотографий в альбоме. 
/// </summary>
/// <param name="ownerId">идентификатор владельца альбома. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="albumId">идентификатор альбома. Для служебных альбомов используются следующие идентификаторы: 
/// todo реализовать для следующих типов
/// wall — фотографии со стены; 
/// profile — аватары; 
/// saved — сохраненные фотографии. </param>
/// <param name="photoIds">идентификаторы фотографий, информацию о которых необходимо вернуть. список строк, разделенных через запятую</param>
/// <param name="rev">порядок сортировки фотографий (1 — антихронологический, 0 — хронологический). флаг, может принимать значения 1 или 0</param>
/// <param name="extended">1 — будут возвращены дополнительные поля likes, comments, tags, can_comment. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="feedType">Тип новости получаемый в поле type метода newsfeed.get, для получения только загруженных пользователем фотографий, либо только фотографий, на которых он был отмечен. Может принимать значения photo, photo_tag. строка</param>
/// <param name="feed">Unixtime, который может быть получен методом newsfeed.get в поле date, для получения всех фотографий загруженных пользователем в определённый день либо на которых пользователь был отмечен. Также нужно указать параметр uid пользователя, с которым произошло событие. </param>
/// <param name="photoSizes">Возвращать ли доступные размеры фотографии в специальном формате. флаг, может принимать значения 1 или 0</param>
/// <param name="offset">отступ, необходимый для получения определенного подмножества записей. положительное число</param>
/// <param name="count">количество записей, которое будет получено. положительное число, максимальное значение 1000</param>
/// <returns>После успешного выполнения возвращает список объектов <see cref="Photo"/>.</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.get"/>.
/// </remarks>
public ReadOnlyCollection<Photo> Get(long? ownerId = null, long? albumId = null, long? photoIds = null, long? rev = null, long? extended = null, long? feedType = null, long? feed = null, long? photoSizes = null, int? offset = null, int? count = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"album_id", albumId},
            {"photo_ids", photoIds},
            {"rev", rev},
            {"extended", extended},
            {"feed_type", feedType},
            {"feed", feed},
            {"photo_sizes", photoSizes},
            {"offset", offset},
            {"count", count}
        };

    VkResponseArray response = _vk.Call("photos.get", parameters);

    return response.ToReadOnlyCollectionOf<Photo>(x => x);
}

/// <summary>
/// Возвращает количество доступных альбомов пользователя или сообщества. 
/// </summary>
/// <param name="userId">идентификатор пользователя, количество альбомов которого необходимо получить. целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="groupId">идентификатор сообщества, количество альбомов которого необходимо получить. </param>
/// <returns>После успешного выполнения возвращает количество альбомов  с учетом настроек приватности. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getAlbumsCount"/>.
/// </remarks>
public int GetAlbumsCount(long? userId = null, long? groupId = null)
{
    var parameters = new VkParameters
        {
            {"user_id", userId},
            {"group_id", groupId}
        };

    VkResponse response = _vk.Call("photos.getAlbumsCount", parameters);

    return response;
}

/// <summary>
/// Возвращает список фотографий со страницы пользователя или сообщества. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, фотографии которого нужно получить. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoIds">идентификаторы фотографий, информацию о которых необходимо вернуть. список строк, разделенных через запятую</param>
/// <param name="rev">порядок сортировки фотографий (1 — антихронологический, 0 — хронологический). флаг, может принимать значения 1 или 0</param>
/// <param name="extended">1 — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="feedType">Тип новости, получаемый в поле type метода newsfeed.get. строка</param>
/// <param name="feed">Unixtime, который может быть получен методом newsfeed.get в поле date, для получения всех фотографий загруженных пользователем в определённый день либо на которых пользователь был отмечен. Также нужно указать параметр uid пользователя, с которым произошло событие. </param>
/// <param name="photoSizes">возвращать ли размеры фотографий в специальном формате. флаг, может принимать значения 1 или 0</param>
/// <param name="offset">положительное число</param>
/// <param name="count">положительное число, максимальное значение 1000</param>
/// <returns>После успешного выполнения возвращает массив объектов photo. В случае, если запись на стене о том, что была обновлена фотография профиля, не удалена, будет возвращено дополнительное поле post_id, содержащее идентификатор записи на стене. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getProfile"/>.
/// </remarks>
public ReadOnlyCollection<Photo> GetProfile(long? ownerId = null, long? photoIds = null, long? rev = null, long? extended = null, long? feedType = null, long? feed = null, long? photoSizes = null, int? offset = null, int? count = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_ids", photoIds},
            {"rev", rev},
            {"extended", extended},
            {"feed_type", feedType},
            {"feed", feed},
            {"photo_sizes", photoSizes},
            {"offset", offset},
            {"count", count}
        };

    VkResponseArray response = _vk.Call("photos.getProfile", parameters);

    return response.ToReadOnlyCollectionOf<Photo>(x => x);
}

/// <summary>
/// Возвращает информацию о фотографиях по их идентификаторам. 
/// </summary>
/// <param name="photos">перечисленные через запятую идентификаторы, которые представляют собой идущие через знак подчеркивания id пользователей, разместивших фотографии, и id самих фотографий. Чтобы получить информацию о фотографии в альбоме группы, вместо id пользователя следует указать -id группы.
Пример значения photos: 1_129207899,6492_135055734, 
-20629724_271945303 
Некоторые фотографии, идентификаторы которых могут быть получены через API, закрыты приватностью, и не будут получены. В этом случае следует использовать ключ доступа фотографии (access_key) в её идентификаторе. Пример значения photos: 1_129207899_220df2876123d3542f, 6492_135055734_e0a9bcc31144f67fbd 
Поле access_key будет возвращено вместе с остальными данными фотографии в методах, которые возвращают фотографии, закрытые приватностью но доступные в данном контексте. Например данное поле имеют фотографии, возвращаемые методом newsfeed.get. список строк, разделенных через запятую, обязательный параметр</param>
/// <param name="extended">1 — будут возвращены дополнительные поля likes, comments, tags, can_comment, can_repost. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="photoSizes">возвращать ли доступные размеры фотографии в специальном формате. флаг, может принимать значения 1 или 0</param>
/// <returns>После успешного выполнения возвращает список объектов photo. 
Если к фотографии прикреплено местоположение, также возвращаются поля lat и long, содержащие географические координаты отметки. 
Если был задан параметр extended=1, возвращаются дополнительные поля: 

likes — количество отметок Мне нравится и информация о том, поставил ли лайк текущий пользователь; 
comments — количество комментариев к фотографии; 
tags — количество отметок на фотографии; 
can_comment — может ли текущий пользователь комментировать фото (1 — может, 0 — не может); 
can_repost — может ли текущий пользователь сделать репост фотографии (1 — может, 0 — не может). 

Если был задан параметр photo_sizes, вместо полей width и height возвращаются размеры копий фотографии в специальном формате. 
</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getById"/>.
/// </remarks>
public ReadOnlyCollection<> GetById(long photos, long? extended = null, long? photoSizes = null)
{

    var parameters = new VkParameters
        {
            {"photos", photos},
            {"extended", extended},
            {"photo_sizes", photoSizes}
        };

    VkResponseArray response = _vk.Call("photos.getById", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Возвращает адрес сервера для загрузки фотографий. 
/// </summary>
/// <param name="albumId">идентификатор альбома. целое число</param>
/// <param name="groupId">идентификатор сообщества, которому принадлежит альбом (если необходимо загрузить фотографию в альбом сообщества). </param>
/// <returns>После успешного выполнения возвращает объект, содержащий следующие поля: 

upload_url — адрес для загрузки фотографий; 
album_id — идентификатор альбома, в который будет загружена фотография; 
user_id — идентификатор пользователя, от чьего имени будет загружено фото. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getUploadServer"/>.
/// </remarks>
public long GetUploadServer(long? albumId = null, long? groupId = null)
{

    var parameters = new VkParameters
        {
            {"album_id", albumId},
            {"group_id", groupId}
        };

    VkResponse response = _vk.Call("photos.getUploadServer", parameters);

    return response;
}

/// <summary>
/// Возвращает адрес сервера для загрузки фотографии на страницу пользователя. 
/// </summary>
/// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getProfileUploadServer"/>.
/// </remarks>
public Unknown GetProfileUploadServer()
{



    VkResponse response = _vk.Call("photos.getProfileUploadServer", VkParameters.Empty);

    return response;
}

/// <summary>
/// Позволяет получить адрес для загрузки фотографий мультидиалогов. 
/// </summary>
/// <param name="chatId">идентификатор беседы, для которой нужно загрузить фотографию. положительное число, обязательный параметр</param>
/// <param name="cropX">положительное число</param>
/// <param name="cropY">положительное число</param>
/// <param name="cropWidth">ширина фотографии после обрезки в px. положительное число, минимальное значение 200</param>
/// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getChatUploadServer"/>.
/// </remarks>
public Unknown GetChatUploadServer(long chatId, long? cropX = null, long? cropY = null, long? cropWidth = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => chatId);
    VkErrors.ThrowIfNumberIsNegative(() => cropX);
    VkErrors.ThrowIfNumberIsNegative(() => cropY);
    VkErrors.ThrowIfNumberIsNegative(() => cropWidth);

    var parameters = new VkParameters
        {
            {"chat_id", chatId},
            {"crop_x", cropX},
            {"crop_y", cropY},
            {"crop_width", cropWidth}
        };

    VkResponse response = _vk.Call("photos.getChatUploadServer", parameters);

    return response;
}

/// <summary>
/// Сохраняет фотографию пользователя после успешной загрузки. 
/// </summary>
/// <param name="server">параметр, возвращаемый в результате загрузки фотографии на сервер. строка</param>
/// <param name="hash">параметр, возвращаемый в результате загрузки фотографии на сервер. строка</param>
/// <param name="photo">параметр, возвращаемый в результате загрузки фотографии на сервер. строка</param>
/// <returns>После успешного выполнения возвращает объект, содержащий поля photo_hash и photo_src (при работе через VK.api метод вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash необходим для подтверждения пользователем изменения его фотографии через вызов метода saveProfilePhoto Javascript API. Поле photo_src содержит путь к загруженной фотографии. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.saveProfilePhoto"/>.
/// </remarks>
public Unknown SaveProfilePhoto(long? server = null, long? hash = null, long? photo = null)
{

    var parameters = new VkParameters
        {
            {"server", server},
            {"hash", hash},
            {"photo", photo}
        };

    VkResponse response = _vk.Call("photos.saveProfilePhoto", parameters);

    return response;
}

/// <summary>
/// Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getWallUploadServer. 
/// </summary>
/// <param name="userId">идентификатор пользователя, на стену которого нужно сохранить фотографию. положительное число</param>
/// <param name="groupId">идентификатор сообщества, на стену которого нужно сохранить фотографию. положительное число</param>
/// <param name="photo">параметр, возвращаемый в результате загрузки фотографии на сервер. строка, обязательный параметр</param>
/// <param name="server">параметр, возвращаемый в результате загрузки фотографии на сервер. целое число</param>
/// <param name="hash">параметр, возвращаемый в результате загрузки фотографии на сервер. строка</param>
/// <returns>После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.saveWallPhoto"/>.
/// </remarks>
public ReadOnlyCollection<> SaveWallPhoto(long? userId = null, long? groupId = null, long photo, long? server = null, long? hash = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => userId);
    VkErrors.ThrowIfNumberIsNegative(() => groupId);

    var parameters = new VkParameters
        {
            {"user_id", userId},
            {"group_id", groupId},
            {"photo", photo},
            {"server", server},
            {"hash", hash}
        };

    VkResponseArray response = _vk.Call("photos.saveWallPhoto", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Возвращает адрес сервера для загрузки фотографии на стену пользователя или сообщества. 
/// </summary>
/// <param name="groupId">идентификатор сообщества, на стену которого нужно загрузить фото (без знака «минус»). целое число</param>
/// <returns>После успешного выполнения возвращает объект с полями upload_url, aid, mid'. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getWallUploadServer"/>.
/// </remarks>
public Unknown GetWallUploadServer(long? groupId = null)
{

    var parameters = new VkParameters
        {
            {"group_id", groupId}
        };

    VkResponse response = _vk.Call("photos.getWallUploadServer", parameters);

    return response;
}

/// <summary>
/// Возвращает адрес сервера для загрузки фотографии в личное сообщение пользователю. 
/// </summary>
/// <returns>После успешного выполнения возвращает объект с полями upload_url, aid (id альбома)  и mid (id текущего пользователя). </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getMessagesUploadServer"/>.
/// </remarks>
public Unknown GetMessagesUploadServer()
{



    VkResponse response = _vk.Call("photos.getMessagesUploadServer", VkParameters.Empty);

    return response;
}

/// <summary>
/// Сохраняет фотографию после успешной загрузки на URI, полученный методом photos.getMessagesUploadServer. 
/// </summary>
/// <param name="photo">параметр, возвращаемый в результате загрузки фотографии на сервер. строка, обязательный параметр</param>
/// <returns>После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.saveMessagesPhoto"/>.
/// </remarks>
public ReadOnlyCollection<> SaveMessagesPhoto(long photo)
{

    var parameters = new VkParameters
        {
            {"photo", photo}
        };

    VkResponseArray response = _vk.Call("photos.saveMessagesPhoto", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Позволяет пожаловаться на фотографию. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. целое число, обязательный параметр</param>
/// <param name="photoId">идентификатор фотографии. положительное число, обязательный параметр</param>
/// <param name="reason">тип жалобы: 
0 – это спам 
1 – детская порнография 
2 – экстремизм 
3 – насилие 
4 – пропаганда наркотиков 
5 – материал для взрослых 
6 – оскорбление положительное число</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.report"/>.
/// </remarks>
public bool Report(long ownerId, long photoId, long? reason = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => photoId);
    VkErrors.ThrowIfNumberIsNegative(() => reason);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"reason", reason}
        };

    VkResponse response = _vk.Call("photos.report", parameters);

    return response;
}

/// <summary>
/// Позволяет пожаловаться на комментарий к фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор владельца фотографии к которой оставлен комментарий. целое число, обязательный параметр</param>
/// <param name="commentId">идентификатор комментария. положительное число, обязательный параметр</param>
/// <param name="reason">тип жалобы</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.reportComment"/>.
/// </remarks>
public bool ReportComment(long ownerId, long commentId, VideoReportType reason)
{
    VkErrors.ThrowIfNumberIsNegative(() => commentId);
    
    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"comment_id", commentId},
            {"reason", reason}
        };

    VkResponse response = _vk.Call("photos.reportComment", parameters);

    return response;
}

/// <summary>
/// Осуществляет поиск изображений по местоположению или описанию. 
/// </summary>
/// <param name="q">строка поискового запроса, например, &quot;Nature&quot;. строка</param>
/// <param name="lat">географическая широта отметки, заданная в градусах (от -90 до 90). дробное число</param>
/// <param name="long">географическая долгота отметки, заданная в градусах (от -180 до 180). дробное число</param>
/// <param name="startTime">время в формате unixtime, не раньше которого должны были быть загружены найденные фотографии. положительное число</param>
/// <param name="endTime">время в формате unixtime, не позже которого должны были быть загружены найденные фотографии. положительное число</param>
/// <param name="sort">1 – сортировать по количеству отметок «Мне нравится», 0 – сортировать по дате добавления фотографии. положительное число</param>
/// <param name="offset">смещение относительно первой найденной фотографии для выборки определенного подмножества. положительное число</param>
/// <param name="count">количество возвращаемых фотографий. положительное число, по умолчанию 100, максимальное значение 1000</param>
/// <param name="radius">радиус поиска в метрах. (работает очень приближенно, поэтому реальное расстояние до цели может отличаться от заданного). Может принимать значения: 10, 100, 800, 6000, 50000 положительное число, по умолчанию 5000</param>
/// <returns>После успешного выполнения возвращает список объектов фотографий. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.search"/>.
/// </remarks>
public ReadOnlyCollection<> Search(long? q = null, long? lat = null, long? long = null, long? startTime = null, long? endTime = null, long? sort = null, int? offset = null, int? count = null, long? radius = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => startTime);
    VkErrors.ThrowIfNumberIsNegative(() => endTime);
    VkErrors.ThrowIfNumberIsNegative(() => sort);
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);
    VkErrors.ThrowIfNumberIsNegative(() => radius);

    var parameters = new VkParameters
        {
            {"q", q},
            {"lat", lat},
            {"long", long},
            {"start_time", startTime},
            {"end_time", endTime},
            {"sort", sort},
            {"offset", offset},
            {"count", count},
            {"radius", radius}
        };

    VkResponseArray response = _vk.Call("photos.search", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Сохраняет фотографии после успешной загрузки. 
/// </summary>
/// <param name="albumId">идентификатор альбома, в который необходимо сохранить фотографии. целое число</param>
/// <param name="groupId">идентификатор сообщества, в которое необходимо сохранить фотографии. </param>
/// <param name="server">параметр, возвращаемый в результате загрузки фотографий на сервер. строка</param>
/// <param name="photosList">параметр, возвращаемый в результате загрузки фотографий на сервер. строка</param>
/// <param name="hash">параметр, возвращаемый в результате загрузки фотографий на сервер. строка</param>
/// <param name="latitude">географическая широта, заданная в градусах (от -90 до 90); дробное число</param>
/// <param name="longitude">географическая долгота, заданная в градусах (от -180 до 180); дробное число</param>
/// <param name="caption">текст описания фотографии. строка</param>
/// <param name="description">текст описания альбома. строка</param>
/// <returns>После успешного выполнения возвращает список объектов фотографий. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.save"/>.
/// </remarks>
public ReadOnlyCollection<Photo> Save(long? albumId = null, long? groupId = null, long? server = null, long? photosList = null, long? hash = null, long? latitude = null, long? longitude = null, long? caption = null, long? description = null)
{

    var parameters = new VkParameters
        {
            {"album_id", albumId},
            {"group_id", groupId},
            {"server", server},
            {"photos_list", photosList},
            {"hash", hash},
            {"latitude", latitude},
            {"longitude", longitude},
            {"caption", caption},
            {"description", description}
        };

    VkResponseArray response = _vk.Call("photos.save", parameters);

    return response.ToReadOnlyCollectionOf<Photo>(x => x);
}

/// <summary>
/// Позволяет скопировать фотографию в альбом &quot;Сохраненные фотографии&quot; 
/// </summary>
/// <param name="ownerId">идентификатор владельца фотографии целое число, обязательный параметр</param>
/// <param name="photoId">индентификатор фотографии положительное число, обязательный параметр</param>
/// <param name="accessKey">специальный код доступа для приватных фотографий строка</param>
/// <returns>Возвращает идентификатор созданной фотографии. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.copy"/>.
/// </remarks>
public long Copy(long ownerId, long photoId, long? accessKey = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => photoId);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"access_key", accessKey}
        };

    VkResponse response = _vk.Call("photos.copy", parameters);

    return response;
}

/// <summary>
/// Изменяет описание у выбранной фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. положительное число, обязательный параметр</param>
/// <param name="caption">новый текст описания к фотографии. Если параметр не задан, то считается, что он равен пустой строке. строка</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.edit"/>.
/// </remarks>
public bool Edit(long? ownerId = null, long photoId, long? caption = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => photoId);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"caption", caption}
        };

    VkResponse response = _vk.Call("photos.edit", parameters);

    return response;
}

/// <summary>
/// Переносит фотографию из одного альбома в другой. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="targetAlbumId">идентификатор альбома, в который нужно переместить фотографию. обязательный параметр</param>
/// <param name="photoId">идентификатор фотографии, которую нужно перенести. обязательный параметр</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.move"/>.
/// </remarks>
public bool Move(long? ownerId = null, long targetAlbumId, long photoId)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"target_album_id", targetAlbumId},
            {"photo_id", photoId}
        };

    VkResponse response = _vk.Call("photos.move", parameters);

    return response;
}

/// <summary>
/// Делает фотографию обложкой альбома. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="albumId">идентификатор альбома. </param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.makeCover"/>.
/// </remarks>
public bool MakeCover(long? ownerId = null, long photoId, long? albumId = null)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"album_id", albumId}
        };

    VkResponse response = _vk.Call("photos.makeCover", parameters);

    return response;
}

/// <summary>
/// Меняет порядок альбома в списке альбомов пользователя. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит альбом. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="albumId">идентификатор альбома. обязательный параметр</param>
/// <param name="before">идентификатор альбома, перед которым следует поместить альбом. </param>
/// <param name="after">идентификатор альбома, после которого следует поместить альбом. </param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.reorderAlbums"/>.
/// </remarks>
public bool ReorderAlbums(long? ownerId = null, long albumId, long? before = null, long? after = null)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"album_id", albumId},
            {"before", before},
            {"after", after}
        };

    VkResponse response = _vk.Call("photos.reorderAlbums", parameters);

    return response;
}

/// <summary>
/// Меняет порядок фотографии в списке фотографий альбома пользователя. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="before">идентификатор фотографии, перед которой следует поместить фотографию. </param>
/// <param name="after">идентификатор фотографии, после которой следует поместить фотографию. </param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.reorderPhotos"/>.
/// </remarks>
public bool ReorderPhotos(long? ownerId = null, long photoId, long? before = null, long? after = null)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"before", before},
            {"after", after}
        };

    VkResponse response = _vk.Call("photos.reorderPhotos", parameters);

    return response;
}

/// <summary>
/// Возвращает все фотографии пользователя или сообщества в антихронологическом порядке. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, фотографии которого нужно получить. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="extended">1 — возвращать расширенную информацию о фотографиях. флаг, может принимать значения 1 или 0</param>
/// <param name="offset">смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — 0. положительное число</param>
/// <param name="count">число фотографий, информацию о которых необходимо получить. положительное число, по умолчанию 20, максимальное значение 200</param>
/// <param name="photoSizes">1 — будут возвращены размеры фотографий в специальном формате. флаг, может принимать значения 1 или 0</param>
/// <param name="noServiceAlbums">0 — вернуть все фотографии, включая находящиеся в сервисных альбомах, таких как &quot;Фотографии на моей стене&quot; (по умолчанию); 
1 — вернуть фотографии только из стандартных альбомов пользователя или сообщества. флаг, может принимать значения 1 или 0</param>
/// <returns>После успешного выполнения возвращает список объектов photo. 
Если был задан параметр extended — будет возвращено поле likes: 

user_likes: 1 — текущему пользователю нравится данная фотография, 0 - не указано. 
count — количество пользователей, которым нравится текущая фотография. 

Если был задан параметр photo_sizes=1, вместо полей width и height возвращаются размеры копий фотографии в специальном формате. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getAll"/>.
/// </remarks>
public ReadOnlyCollection<> GetAll(long? ownerId = null, long? extended = null, int? offset = null, int? count = null, long? photoSizes = null, long? noServiceAlbums = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"extended", extended},
            {"offset", offset},
            {"count", count},
            {"photo_sizes", photoSizes},
            {"no_service_albums", noServiceAlbums}
        };

    VkResponseArray response = _vk.Call("photos.getAll", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Возвращает список фотографий, на которых отмечен пользователь 
/// </summary>
/// <param name="userId">идентификатор пользователя, список фотографий для которого нужно получить. положительное число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="offset">смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — 0. положительное число</param>
/// <param name="count">количество фотографий, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 1000</param>
/// <param name="extended">1 — будут возвращены дополнительные поля likes, comments, tags, can_comment. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="sort">сортировка результатов (0 — по дате добавления отметки в порядке убывания, 1 — по дате добавления отметки в порядке возрастания). строка</param>
/// <returns>После успешного выполнения возвращает список объектов photo. 
Если был задан параметр extended=1, возвращаются дополнительные поля: 

likes — количество отметок Мне нравится и информация о том, поставил ли лайк текущий пользователь; 
comments — количество комментариев к фотографии; 
tags — количество отметок на фотографии; 
can_comment — может ли текущий пользователь комментировать фото (1 — может, 0 — не может). 

Если был задан параметр photo_sizes=1, вместо полей width и height возвращаются размеры копий фотографии в специальном формате. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getUserPhotos"/>.
/// </remarks>
public ReadOnlyCollection<> GetUserPhotos(long? userId = null, int? offset = null, int? count = null, long? extended = null, long? sort = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => userId);
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"user_id", userId},
            {"offset", offset},
            {"count", count},
            {"extended", extended},
            {"sort", sort}
        };

    VkResponseArray response = _vk.Call("photos.getUserPhotos", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Удаляет указанный альбом для фотографий у текущего пользователя 
/// </summary>
/// <param name="albumId">идентификатор альбома. целое число, положительное число, обязательный параметр</param>
/// <param name="groupId">идентификатор сообщества, в котором размещен альбом. положительное число</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.deleteAlbum"/>.
/// </remarks>
public bool DeleteAlbum(long albumId, long? groupId = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => albumId);
    VkErrors.ThrowIfNumberIsNegative(() => groupId);

    var parameters = new VkParameters
        {
            {"album_id", albumId},
            {"group_id", groupId}
        };

    VkResponse response = _vk.Call("photos.deleteAlbum", parameters);

    return response;
}

/// <summary>
/// Удаление фотографии на сайте. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. положительное число, обязательный параметр</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.delete"/>.
/// </remarks>
public bool Delete(long? ownerId = null, long photoId)
{
    VkErrors.ThrowIfNumberIsNegative(() => photoId);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId}
        };

    VkResponse response = _vk.Call("photos.delete", parameters);

    return response;
}

/// <summary>
/// Подтверждает отметку на фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="tagId">идентификатор отметки на фотографии. обязательный параметр</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.confirmTag"/>.
/// </remarks>
public bool ConfirmTag(long? ownerId = null, long photoId, long tagId)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"tag_id", tagId}
        };

    VkResponse response = _vk.Call("photos.confirmTag", parameters);

    return response;
}

/// <summary>
/// Возвращает список комментариев к фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="needLikes">1 — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="offset">смещение, необходимое для выборки определенного подмножества комментариев. По умолчанию — 0. положительное число</param>
/// <param name="count">количество комментариев, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 100</param>
/// <param name="sort">порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым) строка</param>
/// <param name="accessKey">строка</param>
/// <returns>После успешного выполнения возвращает список объектов комментариев. 
Если был задан параметр need_likes=1, возвращается дополнительное поле likes: 

count — число пользователей, которым понравился комментарий; 
user_likes — наличие отметки «Мне нравится» от текущего пользователя 
(1 — есть, 0 — нет); 
can_like — информация о том, может ли текущий пользователь поставить отметку «Мне нравится» 
(1 — может, 0 — не может). </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getComments"/>.
/// </remarks>
public ReadOnlyCollection<> GetComments(long? ownerId = null, long photoId, long? needLikes = null, int? offset = null, int? count = null, long? sort = null, long? accessKey = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"need_likes", needLikes},
            {"offset", offset},
            {"count", count},
            {"sort", sort},
            {"access_key", accessKey}
        };

    VkResponseArray response = _vk.Call("photos.getComments", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Возвращает отсортированный в антихронологическом порядке список всех комментариев к конкретному альбому или ко всем альбомам пользователя. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежат фотографии. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="albumId">идентификатор альбома. Если параметр не задан, то считается, что необходимо получить комментарии ко всем альбомам пользователя или сообщества. положительное число</param>
/// <param name="needLikes">1 — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
/// <param name="offset">смещение, необходимое для выборки определенного подмножества комментариев. Если параметр не задан, то считается, что он равен 0. положительное число</param>
/// <param name="count">количество комментариев, которое необходимо получить. Если параметр не задан, то считается что он равен 20. Максимальное значение параметра 100. положительное число</param>
/// <returns>После успешного выполнения возвращает список объектов комментариев. 
Если был задан параметр need_likes=1, возвращается дополнительное поле likes: 

count — число пользователей, которым понравился комментарий; 
user_likes — наличие отметки «Мне нравится» от текущего пользователя 
(1 — есть, 0 — нет); 
can_like — информация о том, может ли текущий пользователь поставить отметку «Мне нравится» 
(1 — может, 0 — не может). 
</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getAllComments"/>.
/// </remarks>
public ReadOnlyCollection<> GetAllComments(long? ownerId = null, long? albumId = null, long? needLikes = null, int? offset = null, int? count = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => albumId);
    VkErrors.ThrowIfNumberIsNegative(() => offset);
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"album_id", albumId},
            {"need_likes", needLikes},
            {"offset", offset},
            {"count", count}
        };

    VkResponseArray response = _vk.Call("photos.getAllComments", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Создает новый комментарий к фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="message">текст комментария (является обязательным, если не задан параметр attachments). строка</param>
/// <param name="attachments">список объектов, приложенных к комментарию и разделённых символом &quot;,&quot;. Поле attachments представляется в формате:
&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;
&lt;type&gt; — тип медиа-вложения:
photo — фотография 
video — видеозапись 
audio — аудиозапись 
doc — документ
&lt;owner_id&gt; — идентификатор владельца медиа-вложения 
&lt;media_id&gt; — идентификатор медиа-вложения. 

Например:
photo100172_166443618,photo66748_265827614
Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую</param>
/// <param name="fromGroup">Данный параметр учитывается, если oid &lt; 0 (комментарий к фотографии группы). 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет опубликован от имени пользователя (по умолчанию). флаг, может принимать значения 1 или 0</param>
/// <param name="replyToComment"></param>
/// <param name="accessKey">строка</param>
/// <returns>После успешного выполнения возвращает идентификатор созданного комментария. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.createComment"/>.
/// </remarks>
public long CreateComment(long? ownerId = null, long photoId, long? message = null, long? attachments = null, long? fromGroup = null, long? replyToComment = null, long? accessKey = null)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"message", message},
            {"attachments", attachments},
            {"from_group", fromGroup},
            {"reply_to_comment", replyToComment},
            {"access_key", accessKey}
        };

    VkResponse response = _vk.Call("photos.createComment", parameters);

    return response;
}

/// <summary>
/// Удаляет комментарий к фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="commentId">идентификатор комментария. обязательный параметр</param>
/// <returns>После успешного выполнения возвращает 1 (0, если комментарий не найден). 
</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.deleteComment"/>.
/// </remarks>
public bool DeleteComment(long? ownerId = null, long commentId)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"comment_id", commentId}
        };

    VkResponse response = _vk.Call("photos.deleteComment", parameters);

    return response;
}

/// <summary>
/// Восстанавливает удаленный комментарий к фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="commentId">идентификатор удаленного комментария. обязательный параметр</param>
/// <returns>После успешного выполнения возвращает 1 (0, если комментарий с таким идентификатором не является удаленным). </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.restoreComment"/>.
/// </remarks>
public long RestoreComment(long? ownerId = null, long commentId)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"comment_id", commentId}
        };

    VkResponse response = _vk.Call("photos.restoreComment", parameters);

    return response;
}

/// <summary>
/// Изменяет текст комментария к фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="commentId">идентификатор комментария. обязательный параметр</param>
/// <param name="message">новый текст комментария (является обязательным, если не задан параметр attachments). строка</param>
/// <param name="attachments">новый список объектов, приложенных к комментарию и разделённых символом &quot;,&quot;. Поле attachments представляется в формате:
&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;
&lt;type&gt; — тип медиа-вложения:
photo — фотография 
video — видеозапись 
audio — аудиозапись 
doc — документ
&lt;owner_id&gt; — идентификатор владельца медиа-вложения 
&lt;media_id&gt; — идентификатор медиа-вложения. 

Например:
photo100172_166443618,photo66748_265827614
Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.editComment"/>.
/// </remarks>
public bool EditComment(long? ownerId = null, long commentId, long? message = null, long? attachments = null)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"comment_id", commentId},
            {"message", message},
            {"attachments", attachments}
        };

    VkResponse response = _vk.Call("photos.editComment", parameters);

    return response;
}

/// <summary>
/// Возвращает список отметок на фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="accessKey">строковой ключ доступа, который може быть получен при получении объекта фотографии. строка</param>
/// <returns>После успешного выполнения возвращает массив объектов tag, каждый из которых содержит следующие поля: 

uid — идентификатор пользователя, которому соответствует отметка; 
tag_id — идентификатор отметки; 
placer_id — идентификатор пользователя, сделавшего отметку; 
tagged_name — название отметки; 
date — дата добавления отметки в формате unixtime; 
x, y, x2, y2 — координаты прямоугольной области, на которой сделана отметка (верхний левый угол и нижний правый угол) в процентах; 
viewed — статус отметки (1 — подтвержденная, 0 — неподтвержденная). 
</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getTags"/>.
/// </remarks>
public ReadOnlyCollection<> GetTags(long? ownerId = null, long photoId, long? accessKey = null)
{

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"access_key", accessKey}
        };

    VkResponseArray response = _vk.Call("photos.getTags", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}

/// <summary>
/// Добавляет отметку на фотографию. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя, которому принадлежит фотография. положительное число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии.положительное число, обязательный параметр</param>
/// <param name="userId">идентификатор пользователя, которого нужно отметить на фотографии.целое число, обязательный параметр</param>
/// <param name="x">координата верхнего левого угла области с отметкой в % от ширины фотографии.дробное число</param>
/// <param name="y">координата верхнего левого угла области с отметкой в % от высоты фотографии.дробное число</param>
/// <param name="x2">координата правого нижнего угла области с отметкой в % от ширины фотографии.дробное число</param>
/// <param name="y2">координата правого нижнего угла области с отметкой в % от высоты фотографии.дробное число</param>
/// <returns>После успешного выполнения возвращает идентификатор созданной отметки (&#39;&#39;&#39;tag id&#39;&#39;&#39;).</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.putTag"/>.
/// </remarks>
public long PutTag(long? ownerId = null, long photoId, long userId, long? x = null, long? y = null, long? x2 = null, long? y2 = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => ownerId);
    VkErrors.ThrowIfNumberIsNegative(() => photoId);

    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"user_id", userId},
            {"x", x},
            {"y", y},
            {"x2", x2},
            {"y2", y2}
        };

    VkResponse response = _vk.Call("photos.putTag", parameters);

    return response;
}

/// <summary>
/// Удаляет отметку с фотографии. 
/// </summary>
/// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя</param>
/// <param name="photoId">идентификатор фотографии. обязательный параметр</param>
/// <param name="tagId">идентификатор отметки. обязательный параметр</param>
/// <returns>После успешного выполнения возвращает 1. </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.removeTag"/>.
/// </remarks>
public bool RemoveTag(long tagId, long photoId, long? ownerId = null)
{
    var parameters = new VkParameters
        {
            {"owner_id", ownerId},
            {"photo_id", photoId},
            {"tag_id", tagId}
        };

    VkResponse response = _vk.Call("photos.removeTag", parameters);

    return response;
}

/// <summary>
/// Возвращает список фотографий, на которых есть непросмотренные отметки. 
/// </summary>
/// <param name="offset">смещение, необходимое для получения определённого подмножества фотографий. целое число</param>
/// <param name="count">количество фотографий, которые необходимо вернуть. положительное число, максимальное значение 100, по умолчанию 20</param>
/// <returns>После успешного выполнения возвращает список объектов photo с дополнительными полями: </returns>
/// <remarks>
/// Страница документации ВКонтакте <see href="http://vk.com/dev/photos.getNewTags"/>.
/// </remarks>
public ReadOnlyCollection<Photo> GetNewTags(int? offset = null, int? count = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => count);

    var parameters = new VkParameters
        {
            {"offset", offset},
            {"count", count}
        };

    VkResponseArray response = _vk.Call("photos.getNewTags", parameters);

    return response.ToReadOnlyCollectionOf<Photo>(x => x);
}

}

}