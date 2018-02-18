---
layout: default
title: VKNET ВКонтакте API для .NET (C#)
comments: false
---
# Обсуждение в [Telegram](https://t.me/joinchat/CHFCHxHqca0waHIe3-Fuqg)

# Установка через Nuget
**Package Manager**
``` powershell
PM> Install-Package VkNet
```
**.NET CLI**
``` powershell
> dotnet add package VkNet
```

# Описание методов API
Ниже приводятся все реализованные методы для работы с данными ВКонтакте.

## Авторизация
[Authorize](/vk/authorize/) - авторизация на сервере вконтакте и получение AccessToken.

## Пользователи
+ [Users.Get](/vk/users/get/) - Возвращает расширенную информацию о пользователях.
+ [Users.Search](/vk/users/search/) - Возвращает список пользователей в соответствии с заданным критерием поиска.
+ [Users.IsAppUser](/vk/users/isAppUser/) - Возвращает информацию о том, установил ли пользователь приложение.
+ [Users.GetSubscriptions](/vk/users/getSubscriptions/) - Возвращает список идентификаторов пользователей и сообществ, которые входят в список подписок пользователя.
+ [Users.GetFollowers](/vk/users/getFollowers/) - Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
+ [Users.Report](/vk/users/report/) - Позволяет пожаловаться на пользователя.
+ [Users.GetNearby](/vk/users/getNearby/) - Индексирует текущее местоположение пользователя и возвращает список пользователей, которые находятся вблизи.


## Друзья
+ [Friends.Get](/vk/friends/get/) - Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
+ [Friends.GetOnline](/vk/friends/getOnline/) - Возвращает список идентификаторов друзей пользователя, находящихся на сайте.
+ [Friends.GetMutual](/vk/friends/getMutual/) - Возвращает список идентификаторов общих друзей между парой пользователей.
+ [Friends.GetRecent](/vk/friends/getRecent/) - Возвращает список идентификаторов недавно добавленных друзей текущего пользователя
+ [Friends.GetRequests](/vk/friends/getRequests/) - Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя.
+ [Friends.Add](/vk/friends/add/) - Одобряет или создает заявку на добавление в друзья.
+ [Friends.Edit](/vk/friends/edit/) - Редактирует списки друзей для выбранного друга.
+ [Friends.Delete](/vk/friends/delete/) - Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
+ [Friends.GetLists](/vk/friends/getLists/) - Возвращает список меток друзей текущего пользователя.
+ [Friends.AddList](/vk/friends/addList/) - Создает новый список друзей у текущего пользователя.
+ [Friends.EditList](/vk/friends/editList/) - Редактирует существующий список друзей текущего пользователя.
+ [Friends.DeleteList](/vk/friends/deleteList/) - Удаляет существующий список друзей текущего пользователя.
+ [Friends.GetAppUsers](/vk/friends/getAppUsers/) - Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.
+ [Friends.GetByPhones](/vk/friends/getByPhones/) - Возвращает список друзей пользователя, у которых завалидированные или указанные в профиле телефонные номера входят в заданный список.
+ [Friends.DeleteAllRequests](/vk/friends/deleteAllRequests/) - Отмечает все входящие заявки на добавление в друзья как просмотренные.
+ [Friends.GetSuggestions](/vk/friends/getSuggestions/) - Возвращает список профилей пользователей, которые могут быть друзьями текущего пользователя.
+ [Friends.AreFriends](/vk/friends/areFriends/) - Возвращает информацию о том, добавлен ли текущий пользователь в друзья у указанных пользователей.
+ [Friends.GetAvailableForCall](/vk/friends/getAvailableForCall/) - Позволяет получить список идентификаторов пользователей, доступных для вызова в приложении, используя метод JSAPI callUser.  Подробнее о схеме вызова из приложений.
+ [Friends.Search](/vk/friends/search/) - Позволяет искать по списку друзей пользователей.

## Группы
+ [Groups.IsMember](/vk/groups/isMember/) - Возвращает информацию о том, является ли пользователь участником сообщества.
+ [Groups.GetById](/vk/groups/getById/) - Возвращает информацию о заданном сообществе или о нескольких сообществах.
+ [Groups.Get](/vk/groups/get/) - Возвращает список сообществ указанного пользователя.
+ [Groups.GetMembers](/vk/groups/getMembers/) - Возвращает список участников сообщества.
+ [Groups.Join](/vk/groups/join/) - Данный метод позволяет вступить в группу, публичную страницу, а также подтвердить участие во встрече.
+ [Groups.Leave](/vk/groups/leave/) - Позволяет покинуть сообщество.
+ [Groups.Search](/vk/groups/search/) - Осуществляет поиск сообществ по заданной подстроке.
+ [Groups.GetCatalog](/vk/groups/getCatalog/) - Возвращает список сообществ выбранной категории каталога.
+ [Groups.GetCatalogInfo](/vk/groups/getCatalogInfo/) - Возвращает список категорий для каталога сообществ.
+ [Groups.GetInvites](/vk/groups/getInvites/) - Данный метод возвращает список приглашений в сообщества и встречи текущего пользователя.
+ [Groups.GetInvitedUsers](/vk/groups/getInvitedUsers/) - Возвращает список пользователей, которые были приглашены в группу.
+ [Groups.BanUser](/vk/groups/banUser/) - Добавляет пользователя в черный список сообщества.
+ [Groups.UnbanUser](/vk/groups/unbanUser/) - Убирает пользователя из черного списка сообщества.
+ [Groups.GetBanned](/vk/groups/getBanned/) - Возвращает список забаненных пользователей в сообществе.
+ [Groups.Create](/vk/groups/create/) - Создает новое сообщество.
+ [Groups.Edit](/vk/groups/edit/) - Редактирует сообщество.
+ [Groups.EditPlace](/vk/groups/editPlace/) - Позволяет редактировать информацию о месте группы.
+ [Groups.GetSettings](/vk/groups/getSettings/) - Позволяет получать данные, необходимые для отображения страницы редактирования данных сообщества.
+ [Groups.GetRequests](/vk/groups/getRequests/) - Возвращает список заявок на вступление в сообщество.
+ [Groups.EditManager](/vk/groups/editManager/) - Позволяет назначить/разжаловать руководителя в сообществе или изменить уровень его полномочий.
+ [Groups.Invite](/vk/groups/invite/) - Позволяет приглашать друзей в группу.
+ [Groups.AddLink](/vk/groups/addLink/) - Позволяет добавлять ссылки в сообщество.
+ [Groups.DeleteLink](/vk/groups/deleteLink/) - Позволяет удалить ссылки из сообщества.
+ [Groups.EditLink](/vk/groups/editLink/) - Позволяет редактировать ссылки в сообществе.
+ [Groups.ReorderLink](/vk/groups/reorderLink/) - Позволяет менять местоположение ссылки в списке.
+ [Groups.RemoveUser](/vk/groups/removeUser/) - Позволяет исключить пользователя из группы или отклонить заявку на вступление.
+ [Groups.ApproveRequest](/vk/groups/approveRequest/) - Позволяет одобрить заявку в группу от пользователя.


## Аудиозаписи
+ [Audio.Get](/vk/audio/get/) - Возвращает список аудиозаписей пользователя или сообщества.
+ [Audio.GetById](/vk/audio/getById/) - Возвращает информацию об аудиозаписях.
+ [Audio.GetLyrics](/vk/audio/getLyrics/) - Возвращает текст аудиозаписи.
+ [Audio.Search](/vk/audio/search/) - Возвращает список аудиозаписей в соответствии с заданным критерием поиска.
+ [Audio.GetUploadServer](/vk/audio/getUploadServer/) - Возвращает адрес сервера для загрузки аудиозаписей.
+ [Audio.Save](/vk/audio/save/) - Сохраняет аудиозаписи после успешной загрузки.
+ [Audio.Add](/vk/audio/add/) - Копирует аудиозапись на страницу пользователя или группы.
+ [Audio.Delete](/vk/audio/delete/) - Удаляет аудиозапись со страницы пользователя или сообщества.
+ [Audio.Edit](/vk/audio/edit/) - Редактирует данные аудиозаписи на странице пользователя или сообщества.
+ [Audio.Reorder](/vk/audio/reorder/) - Изменяет порядок аудиозаписи, перенося ее между аудиозаписями, идентификаторы которых переданы параметрами after и before.
+ [Audio.Restore](/vk/audio/restore/) - Восстанавливает аудиозапись после удаления.
+ [Audio.GetAlbums](/vk/audio/getAlbums/) - Возвращает список альбомов аудиозаписей пользователя или группы.
+ [Audio.AddAlbum](/vk/audio/addAlbum/) - Создает пустой альбом аудиозаписей.
+ [Audio.EditAlbum](/vk/audio/editAlbum/) - Редактирует название альбома аудиозаписей.
+ [Audio.DeleteAlbum](/vk/audio/deleteAlbum/) - Удаляет альбом аудиозаписей.
+ [Audio.MoveToAlbum](/vk/audio/moveToAlbum/) - Перемещает аудиозаписи в альбом.
+ [Audio.SetBroadcast](/vk/audio/setBroadcast/) - Транслирует аудиозапись в статус пользователю или сообществу.
+ [Audio.GetBroadcastList](/vk/audio/getBroadcastList/) - Возвращает список друзей и сообществ пользователя, которые транслируют музыку в статус.
+ [Audio.GetRecommendations](/vk/audio/getRecommendations/) - Возвращает список рекомендуемых аудиозаписей на основе списка воспроизведения заданного пользователя или на основе одной выбранной аудиозаписи.
+ [Audio.GetPopular](/vk/audio/getPopular/) - Возвращает список аудиозаписей из раздела "Популярное".
+ [Audio.GetCount](/vk/audio/getCount/) - Возвращает количество аудиозаписей пользователя или сообщества.

## Сообщения
+ [Messages.Get](/vk/messages/get/) - Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
+ [Messages.GetDialogs](/vk/messages/getDialogs/) - Возвращает список диалогов текущего пользователя.
+ [Messages.GetById](/vk/messages/getById/) - Возвращает сообщения по их id.
+ [Messages.Search](/vk/messages/search/) - Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
+ [Messages.GetHistory](/vk/messages/getHistory/) - Возвращает историю сообщений для указанного пользователя.
+ [Messages.Send](/vk/messages/send/) - Отправляет сообщение.
+ [Messages.Delete](/vk/messages/delete/) - Удаляет сообщение.
+ [Messages.DeleteDialog](/vk/messages/deleteDialog/) - Удаляет все личные сообщения в диалоге.
+ [Messages.Restore](/vk/messages/restore/) - Восстанавливает удаленное сообщение.
+ [Messages.MarkAsRead](/vk/messages/markAsRead/) - Помечает сообщения как прочитанные.
+ [Messages.MarkAsImportant](/vk/messages/markAsImportant/) - Помечает сообщения как важные либо снимает отметку.
+ [Messages.GetLongPollServer](/vk/messages/getLongPollServer/) - Возвращает данные, необходимые для подключения к Long Poll серверу.
+ [Messages.GetLongPollHistory](/vk/messages/getLongPollHistory/) - Возвращает обновления в личных сообщениях пользователя.
+ [Messages.GetChat](/vk/messages/getChat/) - Возвращает информацию о беседе.
+ [Messages.CreateChat](/vk/messages/createChat/) - Создаёт беседу с несколькими участниками.
+ [Messages.EditChat](/vk/messages/editChat/) - Изменяет название беседы.
+ [Messages.GetChatUsers](/vk/messages/getChatUsers/) - Позволяет получить список пользователей мультидиалога по его id.
+ [Messages.SetActivity](/vk/messages/setActivity/) - Изменяет статус набора текста пользователем в диалоге.
+ [Messages.SearchDialogs](/vk/messages/searchDialogs/) - Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.
+ [Messages.AddChatUser](/vk/messages/addChatUser/) - Добавляет в мультидиалог нового пользователя.
+ [Messages.RemoveChatUser](/vk/messages/removeChatUser/) - Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
+ [Messages.GetLastActivity](/vk/messages/getLastActivity/) - Возвращает текущий статус и дату последней активности указанного пользователя.
+ [Messages.SetChatPhoto](/vk/messages/setChatPhoto/) - Позволяет установить фотографию мультидиалога, загруженную с помощью метода photos.getChatUploadServer.
+ [Messages.DeleteChatPhoto](/vk/messages/deleteChatPhoto/) - Позволяет удалить фотографию мультидиалога.


## Стена
+ [Wall.Get](/vk/wall/get/) - Возвращает список записей со стены пользователя или сообщества.
+ [Wall.Search](/vk/wall/search/) - Метод, позволяющий осуществлять поиск по стенам пользователей.
+ [Wall.GetById](/vk/wall/getById/) - Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
+ [Wall.Post](/vk/wall/post/) - Публикует новую запись на своей или чужой стене.
+ [Wall.Repost](/vk/wall/repost/) - Копирует объект на стену пользователя или сообщества.
+ [Wall.GetReposts](/vk/wall/getReposts/) - Позволяет получать список репостов заданной записи.
+ [Wall.Edit](/vk/wall/edit/) - Редактирует запись на стене.
+ [Wall.Delete](/vk/wall/delete/) - Удаляет запись со стены.
+ [Wall.Restore](/vk/wall/restore/) - Восстанавливает удаленную запись на стене пользователя или сообщества.
+ [Wall.Pin](/vk/wall/pin/) - Закрепляет запись на стене (запись будет отображаться выше остальных).
+ [Wall.Unpin](/vk/wall/unpin/) - Отменяет закрепление записи на стене.
+ [Wall.GetComments](/vk/wall/getComments/) - Возвращает список комментариев к записи на стене.
+ [Wall.AddComment](/vk/wall/addComment/) - Добавляет комментарий к записи на стене пользователя или сообщества.
+ [Wall.EditComment](/vk/wall/editComment/) - Редактирует комментарий на стене пользователя или сообщества.
+ [Wall.DeleteComment](/vk/wall/deleteComment/) - Удаляет комментарий текущего пользователя к записи на своей или чужой стене.
+ [Wall.RestoreComment](/vk/wall/restoreComment/) - Восстанавливает комментарий текущего пользователя к записи на своей или чужой стене.
+ [Wall.ReportPost](/vk/wall/reportPost/) - Позволяет пожаловаться на запись.
+ [Wall.ReportComment](/vk/wall/reportComment/) - Позволяет пожаловаться на комментарий к записи.

## Статус
+ [Status.Get](/vk/status/get/) - Получает статус пользователя.
+ [Status.Set](/vk/status/set/) - Устанавливает статус текущего пользователя.

## Фотографии
+ [Photos.CreateAlbum](/vk/photos/createAlbum/) - Создает пустой альбом для фотографий.
+ [Photos.EditAlbum](/vk/photos/editAlbum/) - Редактирует данные альбома для фотографий пользователя.
+ [Photos.GetAlbums](/vk/photos/getAlbums/) - Возвращает список альбомов пользователя или сообщества.
+ [Photos.Get](/vk/photos/get/) - Возвращает список фотографий в альбоме.
+ [Photos.GetAlbumsCount](/vk/photos/getAlbumsCount/) - Возвращает количество доступных альбомов пользователя или сообщества.
+ [Photos.GetById](/vk/photos/getById/) - Возвращает информацию о фотографиях по их идентификаторам.
+ [Photos.GetUploadServer](/vk/photos/getUploadServer/) - Возвращает адрес сервера для загрузки фотографий.
+ [Photos.GetOwnerPhotoUploadServer](/vk/photos/getOwnerPhotoUploadServer/) - Возвращает адрес сервера для загрузки главной фотографии на страницу пользователя или сообщества.
+ [Photos.GetChatUploadServer](/vk/photos/getChatUploadServer/) - Позволяет получить адрес для загрузки фотографий мультидиалогов.
+ [Photos.GetMarketUploadServer](/vk/photos/getMarketUploadServer/) - Возвращает адрес сервера для загрузки фотографии товаров сообщества.
+ [Photos.GetMarketAlbumUploadServer](/vk/photos/getMarketAlbumUploadServer/) - Возвращает адрес сервера для загрузки фотографии подборки товаров в сообществе.
+ [Photos.SaveMarketPhoto](/vk/photos/saveMarketPhoto/) - Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getMarketUploadServer.
+ [Photos.SaveMarketAlbumPhoto](/vk/photos/saveMarketAlbumPhoto/) - Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getMarketAlbumUploadServer.
+ [Photos.SaveOwnerPhoto](/vk/photos/saveOwnerPhoto/) - Позволяет сохранить главную фотографию пользователя или сообщества.
+ [Photos.SaveWallPhoto](/vk/photos/saveWallPhoto/) - Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getWallUploadServer.
+ [Photos.GetWallUploadServer](/vk/photos/getWallUploadServer/) - Возвращает адрес сервера для загрузки фотографии на стену пользователя или сообщества.
+ [Photos.GetMessagesUploadServer](/vk/photos/getMessagesUploadServer/) - Возвращает адрес сервера для загрузки фотографии в личное сообщение пользователю.
+ [Photos.SaveMessagesPhoto](/vk/photos/saveMessagesPhoto/) - Сохраняет фотографию после успешной загрузки на URI, полученный методом photos.getMessagesUploadServer.
+ [Photos.Report](/vk/photos/report/) - Позволяет пожаловаться на фотографию.
+ [Photos.ReportComment](/vk/photos/reportComment/) - Позволяет пожаловаться на комментарий к фотографии.
+ [Photos.Search](/vk/photos/search/) - Осуществляет поиск изображений по местоположению или описанию.
+ [Photos.Save](/vk/photos/save/) - Сохраняет фотографии после успешной загрузки.
+ [Photos.Copy](/vk/photos/copy/) - Позволяет скопировать фотографию в альбом "Сохраненные фотографии"
+ [Photos.Edit](/vk/photos/edit/) - Изменяет описание у выбранной фотографии.
+ [Photos.Move](/vk/photos/move/) - Переносит фотографию из одного альбома в другой.
+ [Photos.MakeCover](/vk/photos/makeCover/) - Делает фотографию обложкой альбома.
+ [Photos.ReorderAlbums](/vk/photos/reorderAlbums/) - Меняет порядок альбома в списке альбомов пользователя.
+ [Photos.ReorderPhotos](/vk/photos/reorderPhotos/) - Меняет порядок фотографии в списке фотографий альбома пользователя.
+ [Photos.GetAll](/vk/photos/getAll/) - Возвращает все фотографии пользователя или сообщества в антихронологическом порядке.
+ [Photos.GetUserPhotos](/vk/photos/getUserPhotos/) - Возвращает список фотографий, на которых отмечен пользователь
+ [Photos.DeleteAlbum](/vk/photos/deleteAlbum/) - Удаляет указанный альбом для фотографий у текущего пользователя
+ [Photos.Delete](/vk/photos/delete/) - Удаление фотографии на сайте.
+ [Photos.Restore](/vk/photos/restore/) - Восстанавливает удаленную фотографию.
+ [Photos.ConfirmTag](/vk/photos/confirmTag/) - Подтверждает отметку на фотографии.
+ [Photos.GetComments](/vk/photos/getComments/) - Возвращает список комментариев к фотографии.
+ [Photos.GetAllComments](/vk/photos/getAllComments/) - Возвращает отсортированный в антихронологическом порядке список всех комментариев к конкретному альбому или ко всем альбомам пользователя.
+ [Photos.CreateComment](/vk/photos/createComment/) - Создает новый комментарий к фотографии.
+ [Photos.DeleteComment](/vk/photos/deleteComment/) - Удаляет комментарий к фотографии.
+ [Photos.RestoreComment](/vk/photos/restoreComment/) - Восстанавливает удаленный комментарий к фотографии.
+ [Photos.EditComment](/vk/photos/editComment/) - Изменяет текст комментария к фотографии.
+ [Photos.GetTags](/vk/photos/getTags/) - Возвращает список отметок на фотографии.
+ [Photos.PutTag](/vk/photos/putTag/) - Добавляет отметку на фотографию.
+ [Photos.RemoveTag](/vk/photos/removeTag/) - Удаляет отметку с фотографии.
+ [Photos.GetNewTags](/vk/photos/getNewTags/) - Возвращает список фотографий, на которых есть непросмотренные отметки.

## Видео
+ [Video.Get](/vk/video/get/) - Возвращает информацию о видеозаписях.
+ [Video.Edit](/vk/video/edit/) - Редактирует данные видеозаписи.
+ [Video.Add](/vk/video/add/) - Добавляет видеозапись в список пользователя.
+ [Video.Save](/vk/video/save/) - Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
+ [Video.Delete](/vk/video/delete/) - Удаляет видеозапись со страницы пользователя.
+ [Video.Restore](/vk/video/restore/) - Восстанавливает удаленную видеозапись.
+ [Video.Search](/vk/video/search/) - Возвращает список видеозаписей в соответствии с заданным критерием поиска.
+ [Video.GetUserVideos](/vk/video/getUserVideos/) - Возвращает список видеозаписей, на которых отмечен пользователь.
+ [Video.GetAlbums](/vk/video/getAlbums/) - Возвращает список альбомов видеозаписей пользователя или сообщества.
+ [Video.GetAlbumById](/vk/video/getAlbumById/) - Позволяет получить информацию об альбоме с видео.
+ [Video.AddAlbum](/vk/video/addAlbum/) - Создает пустой альбом видеозаписей.
+ [Video.EditAlbum](/vk/video/editAlbum/) - Редактирует название альбома видеозаписей.
+ [Video.DeleteAlbum](/vk/video/deleteAlbum/) - Удаляет альбом видеозаписей.
+ [Video.ReorderAlbums](/vk/video/reorderAlbums/) - Позволяет изменить порядок альбомов с видео.
+ [Video.ReorderVideos](/vk/video/reorderVideos/) - Позволяет переместить видеозапись в альбоме.
+ [Video.AddToAlbum](/vk/video/addToAlbum/) - Позволяет добавить видеозапись в альбом.
+ [Video.RemoveFromAlbum](/vk/video/removeFromAlbum/) - Позволяет убрать видеозапись из альбома.
+ [Video.GetAlbumsByVideo](/vk/video/getAlbumsByVideo/) - Возвращает список альбомов, в которых находится видеозапись.
+ [Video.GetComments](/vk/video/getComments/) - Возвращает список комментариев к видеозаписи.
+ [Video.CreateComment](/vk/video/createComment/) - Cоздает новый комментарий к видеозаписи
+ [Video.DeleteComment](/vk/video/deleteComment/) - Удаляет комментарий к видеозаписи.
+ [Video.RestoreComment](/vk/video/restoreComment/) - Восстанавливает удаленный комментарий к видеозаписи.
+ [Video.EditComment](/vk/video/editComment/) - Изменяет текст комментария к видеозаписи.
+ [Video.GetTags](/vk/video/getTags/) - Возвращает список отметок на видеозаписи.
+ [Video.PutTag](/vk/video/putTag/) - Добавляет отметку на видеозапись.
+ [Video.RemoveTag](/vk/video/removeTag/) - Удаляет отметку с видеозаписи.
+ [Video.GetNewTags](/vk/video/getNewTags/) - Возвращает список видеозаписей, на которых есть непросмотренные отметки.
+ [Video.Report](/vk/video/report/) - Позволяет пожаловаться на видеозапись.
+ [Video.ReportComment](/vk/video/reportComment/) - Позволяет пожаловаться на комментарий к видеозаписи.
+ [Video.GetCatalog](/vk/video/getCatalog/) - Позволяет получить представление каталога видео.
+ [Video.GetCatalogSection](/vk/video/getCatalogSection/) - Позволяет получить отдельный блок видеокаталога.
+ [Video.HideCatalogSection](/vk/video/hideCatalogSection/) - Скрывает для пользователя раздел видеокаталога.


## Закладки
+ [Fave.GetUsers](/vk/fave/getUsers/) - Возвращает список пользователей, добавленных текущим пользователем в закладки.
+ [Fave.GetPhotos](/vk/fave/getPhotos/) - Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".
+ [Fave.GetPosts](/vk/fave/getPosts/) - Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetVideos](/vk/fave/getVideos/) - Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetLinks](/vk/fave/getLinks/) - Возвращает ссылки, добавленные в закладки текущим пользователем.
+ [Fave.GetMarketItems](/vk/fave/getMarketItems/) - Возвращает товары, добавленные в закладки текущим пользователем.
+ [Fave.AddUser](/vk/fave/addUser/) - Добавляет пользователя в закладки.
+ [Fave.RemoveUser](/vk/fave/removeUser/) - Удаляет пользователя из закладок.
+ [Fave.AddGroup](/vk/fave/addGroup/) - Добавляет сообщество в закладки.
+ [Fave.RemoveGroup](/vk/fave/removeGroup/) - Удаляет сообщество из закладок.
+ [Fave.AddLink](/vk/fave/addLink/) - Добавляет ссылку в закладки.
+ [Fave.RemoveLink](/vk/fave/removeLink/) - Удаляет ссылку из закладок.

## Служебные
+ [Utils.CheckLink](/vk/utils/checkLink/) - Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
+ [Utils.ResolveScreenName](/vk/utils/resolveScreenName/) - Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени screenName.
+ [Utils.GetServerTime](/vk/utils/getServerTime/) - Возвращает текущее время на сервере ВКонтакте.

## Данные ВК
+ [Database.GetCountries](/vk/database/getCountries/) - Возвращает список стран.
+ [Database.GetRegions](/vk/database/getRegions/) - Возвращает список регионов.
+ [Database.GetStreetsById](/vk/database/getStreetsById/) - Возвращает информацию об улицах по их идентификаторам (id).
+ [Database.GetCountriesById](/vk/database/getCountriesById/) - Возвращает информацию о странах по их идентификаторам
+ [Database.GetCities](/vk/database/getCities/) - Возвращает список городов.
+ [Database.GetCitiesById](/vk/database/getCitiesById/) - Возвращает информацию о городах по их идентификаторам.
+ [Database.GetUniversities](/vk/database/getUniversities/) - Возвращает список высших учебных заведений.
+ [Database.GetSchools](/vk/database/getSchools/) - Возвращает список школ.
+ [Database.GetSchoolClasses](/vk/database/getSchoolClasses/) - Возвращает список классов, характерных для школ определенной страны.
+ [Database.GetFaculties](/vk/database/getFaculties/) - Возвращает список факультетов.
+ [Database.GetChairs](/vk/database/getChairs/) - Возвращает список кафедр университета по указанному факультету.

## Новости
+ [Newsfeed.Get](/vk/newsfeed/get/) - Возвращает данные, необходимые для показа списка новостей для текущего пользователя.
+ [Newsfeed.GetRecommended](/vk/newsfeed/getRecommended/) - Получает список новостей, рекомендованных пользователю.
+ [Newsfeed.GetComments](/vk/newsfeed/getComments/) - Возвращает данные, необходимые для показа раздела комментариев в новостях пользователя.
+ [Newsfeed.GetMentions](/vk/newsfeed/getMentions/) - Возвращает список записей пользователей на своих стенах, в которых упоминается указанный пользователь.
+ [Newsfeed.GetBanned](/vk/newsfeed/getBanned/) - Возвращает список пользователей и групп, которые текущий пользователь скрыл из ленты новостей.
+ [Newsfeed.AddBan](/vk/newsfeed/addBan/) - Запрещает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.
+ [Newsfeed.DeleteBan](/vk/newsfeed/deleteBan/) - Разрешает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.
+ [Newsfeed.IgnoreItem](/vk/newsfeed/ignoreItem/) - Позволяет скрыть объект из ленты новостей.
+ [Newsfeed.UnignoreItem](/vk/newsfeed/unignoreItem/) - Позволяет вернуть ранее скрытый объект в ленту новостей.
+ [Newsfeed.Search](/vk/newsfeed/search/) - Возвращает результаты поиска по статусам. Новости возвращаются в порядке от более новых к более старым.
+ [Newsfeed.GetLists](/vk/newsfeed/getLists/) - Возвращает пользовательские списки новостей.
+ [Newsfeed.SaveList](/vk/newsfeed/saveList/) - Метод позволяет создавать или редактировать пользовательские списки для просмотра новостей.
+ [Newsfeed.DeleteList](/vk/newsfeed/deleteList/) - Метод позволяет удалить пользовательский список новостей
+ [Newsfeed.Unsubscribe](/vk/newsfeed/unsubscribe/) - Отписывает текущего пользователя от комментариев к заданному объекту.
+ [Newsfeed.GetSuggestedSources](/vk/newsfeed/getSuggestedSources/) - Возвращает сообщества и пользователей, на которые текущему пользователю рекомендуется подписаться.

## Мне нравится
+ [Likes.GetList](/vk/likes/getList/) - Получает список идентификаторов пользователей, которые добавили заданный объект в свой список Мне нравится.
+ [Likes.Add](/vk/likes/add/) - Добавляет указанный объект в список Мне нравится текущего пользователя.
+ [Likes.Delete](/vk/likes/delete/) - Удаляет указанный объект из списка Мне нравится текущего пользователя
+ [Likes.IsLiked](/vk/likes/isLiked/) - Проверяет, находится ли объект в списке Мне нравится заданного пользователя.

## Авторизация
+ [Auth.CheckPhone](/vk/auth/checkPhone/) - Проверяет правильность введённого номера.
+ [Auth.Signup](/vk/auth/signup/) - Регистрирует нового пользователя по номеру телефона.
+ [Auth.Confirm](/vk/auth/confirm/) - Завершает регистрацию нового пользователя, начатую методом auth.signup, по коду, полученному через SMS.
+ [Auth.Restore](/vk/auth/restore/) - Позволяет восстановить доступ к аккаунту, используя код, полученный через SMS.  Данный метод доступен только приложениям, имеющим доступ к Прямой авторизации.

## Статистика
+ [Stats.Get](/vk/stats/get/) - Возвращает статистику сообщества или приложения.
+ [Stats.TrackVisitor](/vk/stats/trackVisitor/) - Добавляет данные о текущем сеансе в статистику посещаемости приложения.
+ [Stats.GetPostReach](/vk/stats/getPostReach/) - Возвращает статистику для записи на стене.

## Подарки
+ [Gifts.Get](/vk/gifts/get/) - Возвращает список полученных подарков пользователя.

## Страницы
+ [Pages.Get](/vk/pages/get/) - Возвращает информацию о вики-странице.
+ [Pages.Save](/vk/pages/save/) - Сохраняет текст вики-страницы.
+ [Pages.SaveAccess](/vk/pages/saveAccess/) - Сохраняет новые настройки доступа на чтение и редактирование вики-страницы.
+ [Pages.GetHistory](/vk/pages/getHistory/) - Возвращает список всех старых версий вики-страницы.
+ [Pages.GetTitles](/vk/pages/getTitles/) - Возвращает список вики-страниц в группе.
+ [Pages.GetVersion](/vk/pages/getVersion/) - Возвращает текст одной из старых версий страницы.
+ [Pages.ParseWiki](/vk/pages/parseWiki/) - Возвращает html-представление вики-разметки.
+ [Pages.ClearCache](/vk/pages/clearCache/) - Позволяет очистить кеш отдельных внешних страниц, которые могут быть прикреплены к записям ВКонтакте. После очистки кеша при последующем прикреплении ссылки к записи, данные о странице будут обновлены.

## Документы
+ [Docs.Get](/vk/docs/get/) - Возвращает расширенную информацию о документах пользователя или сообщества.
+ [Docs.GetById](/vk/docs/getById/) - Возвращает информацию о документах по их идентификаторам.
+ [Docs.GetUploadServer](/vk/docs/getUploadServer/) - Возвращает адрес сервера для загрузки документов.
+ [Docs.GetWallUploadServer](/vk/docs/getWallUploadServer/) - Возвращает адрес сервера для загрузки документов в папку Отправленные, для последующей отправки документа на стену или личным сообщением.
+ [Docs.Save](/vk/docs/save/) - Сохраняет документ после его успешной загрузки на сервер.
+ [Docs.Delete](/vk/docs/delete/) - Удаляет документ пользователя или группы.
+ [Docs.Add](/vk/docs/add/) - Копирует документ в документы текущего пользователя.
+ [Docs.GetTypes](/vk/docs/getTypes/) - Возвращает доступные типы документы для пользователя
+ [Docs.Search](/vk/docs/search/) - Возвращает результаты поиска по документам.
+ [Docs.Edit](/vk/docs/edit/) - Редактирует документ пользователя или группы.

## Приложения
+ [Apps.GetCatalog](/vk/apps/getCatalog/) - Возвращает список приложений, доступных для пользователей сайта через каталог приложений.
+ [Apps.Get](/vk/apps/get/) - Возвращает данные о запрошенном приложении на платформе ВКонтакте
+ [Apps.SendRequest](/vk/apps/sendRequest/) - Позволяет отправить запрос другому пользователю в приложении, использующем авторизацию ВКонтакте.
+ [Apps.DeleteAppRequests](/vk/apps/deleteAppRequests/) - Удаляет все уведомления о запросах, отправленных из текущего приложения
+ [Apps.GetFriendsList](/vk/apps/getFriendsList/) - Создает список друзей, который будет использоваться при отправке пользователем приглашений в приложение и игровых запросов.
+ [Apps.GetLeaderboard](/vk/apps/getLeaderboard/) - Возвращает рейтинг пользователей в игре.
+ [Apps.GetScore](/vk/apps/getScore/) - Метод возвращает количество очков пользователя в этой игре.

## Товары
+ [Market.Get](/vk/market/get/) - Возвращает список товаров в сообществе.
+ [Market.GetById](/vk/market/getById/) - Возвращает информацию о товарах по идентификаторам.
+ [Market.Search](/vk/market/search/) - Ищет товары в каталоге сообщества.
+ [Market.GetAlbums](/vk/market/getAlbums/) - Возвращает список подборок с товарами.
+ [Market.GetAlbumById](/vk/market/getAlbumById/) - Возвращает данные подборки с товарами.
+ [Market.CreateComment](/vk/market/createComment/) - Создает новый комментарий к товару.
+ [Market.GetComments](/vk/market/getComments/) - Возвращает список комментариев к товару.
+ [Market.DeleteComment](/vk/market/deleteComment/) - Удаляет комментарий к товару.
+ [Market.RestoreComment](/vk/market/restoreComment/) - Восстанавливает удаленный комментарий к товару.
+ [Market.EditComment](/vk/market/editComment/) - Изменяет текст комментария к товару.
+ [Market.ReportComment](/vk/market/reportComment/) - Позволяет оставить жалобу на комментарий к товару.
+ [Market.GetCategories](/vk/market/getCategories/) - Возвращает список категорий для товаров.
+ [Market.Report](/vk/market/report/) - Позволяет отправить жалобу на товар.
+ [Market.Add](/vk/market/add/) - Добавляет новый товар.
+ [Market.Edit](/vk/market/edit/) - Редактирует товар.
+ [Market.Delete](/vk/market/delete/) - Удаляет товар.
+ [Market.Restore](/vk/market/restore/) - Восстанавливает удаленный товар.
+ [Market.ReorderItems](/vk/market/reorderItems/) - Изменяет положение товара в подборке.
+ [Market.ReorderAlbums](/vk/market/reorderAlbums/) - Изменяет положение подборки с товарами в списке.
+ [Market.AddAlbum](/vk/market/addAlbum/) - Добавляет новую подборку с товарами.
+ [Market.EditAlbum](/vk/market/editAlbum/) - Редактирует подборку с товарами.
+ [Market.DeleteAlbum](/vk/market/deleteAlbum/) - Удаляет подборку с товарами.
+ [Market.RemoveFromAlbum](/vk/market/removeFromAlbum/) - Удаляет товар из одной или нескольких выбранных подборок.
+ [Market.AddToAlbum](/vk/market/addToAlbum/) - Добавляет товар в одну или несколько выбранных подборок.

# Аккаунт
+ [Account.GetCounters](/vk/account/getCounters/) - Возвращает ненулевые значения счетчиков пользователя.
+ [Account.SetNameInMenu](/vk/account/setNameInMenu/) - Устанавливает короткое название приложения (до 17 символов), которое выводится пользователю в левом меню.
+ [Account.SetOnline](/vk/account/setOnline/) - Помечает текущего пользователя как online на 15 минут.
+ [Account.SetOffline](/vk/account/setOffline/) - Помечает текущего пользователя как offline.
+ [Account.LookupContacts](/vk/account/lookupContacts/) - Позволяет искать пользователей ВКонтакте, используя телефонные номера, email-адреса, и идентификаторы пользователей в других сервисах. Найденные пользователи могут быть также в дальнейшем получены методом friends.getSuggestions.
+ [Account.RegisterDevice](/vk/account/registerDevice/) - Подписывает устройство на базе iOS, Android или Windows Phone на получение Push-уведомлений.
+ [Account.UnregisterDevice](/vk/account/unregisterDevice/) - Отписывает устройство от Push уведомлений.
+ [Account.SetSilenceMode](/vk/account/setSilenceMode/) - Отключает push-уведомления на заданный промежуток времени.
+ [Account.GetPushSettings](/vk/account/getPushSettings/) - Позволяет получать настройки Push уведомлений.
+ [Account.SetPushSettings](/vk/account/setPushSettings/) - Изменяет настройку Push-уведомлений.
+ [Account.GetAppPermissions](/vk/account/getAppPermissions/) - Получает настройки текущего пользователя в данном приложении.
+ [Account.GetActiveOffers](/vk/account/getActiveOffers/) - Возвращает список активных рекламных предложений (офферов), выполнив которые пользователь сможет получить соответствующее количество голосов на свой счёт внутри приложения.
+ [Account.BanUser](/vk/account/banUser/) - Добавляет пользователя в черный список.
+ [Account.UnbanUser](/vk/account/unbanUser/) - Убирает пользователя из черного списка.
+ [Account.GetBanned](/vk/account/getBanned/) - Возвращает список пользователей, находящихся в черном списке.
+ [Account.GetInfo](/vk/account/getInfo/) - Возвращает информацию о текущем аккаунте.
+ [Account.SetInfo](/vk/account/setInfo/) - Позволяет редактировать информацию о текущем аккаунте.
+ [Account.ChangePassword](/vk/account/changePassword/) - Позволяет сменить пароль пользователя после успешного восстановления доступа к аккаунту через СМС, используя метод auth.restore.
+ [Account.GetProfileInfo](/vk/account/getProfileInfo/) - Возвращает информацию о текущем профиле.
+ [Account.SaveProfileInfo](/vk/account/saveProfileInfo/) - Редактирует информацию текущего профиля.
