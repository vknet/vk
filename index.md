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
+ [Users.GetFollowers](/vk/users/getFollowers/) - Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
+ [Users.GetSubscriptions](/vk/users/getSubscriptions/) - Возвращает список идентификаторов пользователей и сообществ, которые входят в список подписок пользователя.
+ (Устаревший) [Users.GetNearby](/vk/users/getNearby/) - Индексирует текущее местоположение пользователя и возвращает список пользователей, которые находятся вблизи.
+ (Устаревший) [Users.IsAppUser](/vk/users/isAppUser/) - Возвращает информацию о том, установил ли пользователь приложение.
+ [Users.Report](/vk/users/report/) - Позволяет пожаловаться на пользователя.
+ [Users.Search](/vk/users/search/) - Возвращает список пользователей в соответствии с заданным критерием поиска.

## Друзья
+ [Friends.Add](/vk/friends/add/) - Одобряет или создает заявку на добавление в друзья.
+ [Friends.AddList](/vk/friends/addList/) - Создает новый список друзей у текущего пользователя.
+ [Friends.AreFriends](/vk/friends/areFriends/) - Возвращает информацию о том, добавлен ли текущий пользователь в друзья у указанных пользователей.
+ [Friends.Delete](/vk/friends/delete/) - Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
+ [Friends.DeleteAllRequests](/vk/friends/deleteAllRequests/) - Отмечает все входящие заявки на добавление в друзья как просмотренные.
+ [Friends.DeleteList](/vk/friends/deleteList/) - Удаляет существующий список друзей текущего пользователя.
+ [Friends.Edit](/vk/friends/edit/) - Редактирует списки друзей для выбранного друга.
+ [Friends.EditList](/vk/friends/editList/) - Редактирует существующий список друзей текущего пользователя.
+ [Friends.Get](/vk/friends/get/) - Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
+ (Устаревший) [Friends.GetAvailableForCall](/vk/friends/getAvailableForCall/) - Позволяет получить список идентификаторов пользователей, доступных для вызова в приложении, используя метод JSAPI callUser. Подробнее о схеме вызова из приложений.
+ [Friends.GetAppUsers](/vk/friends/getAppUsers/) - Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.
+ [Friends.GetByPhones](/vk/friends/getByPhones/) - Возвращает список друзей пользователя, у которых завалидированные или указанные в профиле телефонные номера входят в заданный список.
+ [Friends.GetLists](/vk/friends/getLists/) - Возвращает список меток друзей текущего пользователя.
+ [Friends.GetMutual](/vk/friends/getMutual/) - Возвращает список идентификаторов общих друзей между парой пользователей.
+ [Friends.GetOnline](/vk/friends/getOnline/) - Возвращает список идентификаторов друзей пользователя, находящихся на сайте.
+ [Friends.GetRecent](/vk/friends/getRecent/) - Возвращает список идентификаторов недавно добавленных друзей текущего пользователя
+ [Friends.GetRequests](/vk/friends/getRequests/) - Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя.
+ [Friends.GetSuggestions](/vk/friends/getSuggestions/) - Возвращает список профилей пользователей, которые могут быть друзьями текущего пользователя.
+ [Friends.Search](/vk/friends/search/) - Позволяет искать по списку друзей пользователей.

## Группы
+ [Groups.addAddress](/vk/groups/addAddresses/) - Позволяет добавить адрес в сообщество. 
+ [Groups.AddCallbackServer](/vk/groups/addCallbackServer/) - !!Добавляет сервер для Callback API в сообщество.
+ [Groups.AddLink](/vk/groups/addLink/) - Позволяет добавлять ссылки в сообщество.
+ [Groups.ApproveRequest](/vk/groups/approveRequest/) - Позволяет одобрить заявку в группу от пользователя.
+ [Groups.Ban](/vk/groups/banUser/) - Добавляет пользователя в черный список сообщества.
+ [Groups.Create](/vk/groups/create/) - Создает новое сообщество.
+ [Groups.DeleteAddress](/vk/groups/deleteAddresses/) - Позволяет удалить адрес в сообществе.
+ [Groups.DeleteCallbackServer](/vk/groups/deleteCallbackServer/) - !!Удаляет сервер для Callback API из сообщества.
+ [Groups.DeleteLink](/vk/groups/deleteLink/) - Позволяет удалить ссылки из сообщества.
+ [Groups.DisableOnline](/vk/groups/disableOnline/) - !!Выключает статус «онлайн» в сообществе.
+ [Groups.Edit](/vk/groups/edit/) - Редактирует сообщество.
+ [Groups.EditAddress](/vk/groups/editAddresses/) - Позволяет отредактировать адрес в сообществе. 
+ [Groups.EditCallbackServer](/vk/groups/editCallbackServer/) - !!Редактирует данные сервера для Callback API в сообществе.
+ [Groups.EditLink](/vk/groups/editLink/) - Позволяет редактировать ссылки в сообществе.
+ [Groups.EditManager](/vk/groups/editManager/) - Позволяет назначить/разжаловать руководителя в сообществе или изменить уровень его полномочий.
+ [Groups.EnableOnline](/vk/groups/enableOnline/) - !!Включает статус «онлайн» в сообществе.
+ (Устаревший) [Groups.EditPlace](/vk/groups/editPlace/) - Позволяет редактировать информацию о месте группы.
+ [Groups.Get](/vk/groups/get/) - Возвращает список сообществ указанного пользователя.
+ [Groups.GetAddress](/vk/groups/GetAddresses/) - Позволяет отредактировать адрес в сообществе. 
+ [Groups.GetBanned](/vk/groups/getBanned/) - Возвращает список забаненных пользователей в сообществе.
+ [Groups.GetById](/vk/groups/getById/) - Возвращает информацию о заданном сообществе или о нескольких сообществах.
+ [Groups.GetCallbackConfirmationCode](/vk/groups/getCallbackConfirmationCode/) - Позволяет получить строку, необходимую для подтверждения адреса сервера в Callback API.
+ [Groups.GetCallbackServers](/vk/groups/getCallbackServers/) - !!Получает информацию о серверах для Callback API в сообществе.
+ [Groups.GetCallbackSettings](/vk/groups/getCallbackSettings/) - !!Позволяет получить настройки уведомлений Callback API для сообщества.
+ [Groups.GetCatalog](/vk/groups/getCatalog/) - Возвращает список сообществ выбранной категории каталога.
+ [Groups.GetCatalogInfo](/vk/groups/getCatalogInfo/) - Возвращает список категорий для каталога сообществ.
+ [Groups.GetInvitedUsers](/vk/groups/getInvitedUsers/) - Возвращает список пользователей, которые были приглашены в группу.
+ [Groups.GetInvites](/vk/groups/getInvites/) - Данный метод возвращает список приглашений в сообщества и встречи текущего пользователя.
+ [Groups.GetLongPollServer](/vk/groups/getLongPollServer/) - Возвращает данные для подключения к Bots Longpoll API.
+ [Groups.GetLongPollSettings](/vk/groups/getLongPollSettings/) - !!Получает настройки Bots Longpoll API для сообщества.
+ [Groups.GetMembers](/vk/groups/getMembers/) - Возвращает список участников сообщества.
+ [Groups.GetOnlineStatus](/vk/groups/getOnlineStatus/) - !!Получает информацию о статусе «онлайн» в сообществе.
+ [Groups.GetRequests](/vk/groups/getRequests/) - Возвращает список заявок на вступление в сообщество.
+ [Groups.GetSettings](/vk/groups/getSettings/) - Позволяет получать данные, необходимые для отображения страницы редактирования данных сообщества.
+ [Groups.GetTokenPermissions](/vk/groups/getTokenPermissions/) - !!Возвращает настройки прав для ключа доступа сообщества.
+ [Groups.Invite](/vk/groups/invite/) - Позволяет приглашать друзей в группу.
+ [Groups.IsMember](/vk/groups/isMember/) - Возвращает информацию о том, является ли пользователь участником сообщества.
+ [Groups.Join](/vk/groups/join/) - Данный метод позволяет вступить в группу, публичную страницу, а также подтвердить участие во встрече.
+ [Groups.Leave](/vk/groups/leave/) - Позволяет покинуть сообщество.
+ [Groups.RemoveUser](/vk/groups/removeUser/) - Позволяет исключить пользователя из группы или отклонить заявку на вступление.
+ [Groups.ReorderLink](/vk/groups/reorderLink/) - Позволяет менять местоположение ссылки в списке.
+ [Groups.Search](/vk/groups/search/) - Осуществляет поиск сообществ по заданной подстроке.
+ [Groups.SetCallbackSettings](/vk/groups/setCallbackSettings/) - !!Позволяет задать настройки уведомлений о событиях в Callback API.
+ [Groups.SetLongPollSettings](/vk/groups/setLongPollSettings/) - !!Задаёт настройки для Bots Long Poll API в сообществе.
+ [Groups.Unban](/vk/groups/unbanUser/) - Убирает пользователя из черного списка сообщества.

## Аудиозаписи [Решение по обходу блокировки API Audio](https://github.com/atckun/VkNet.AudioBypass)
### Установка через Nuget
***Package Manager***
``` powershell
PM> Install-Package VkNet.AudioBypassService
```
**.NET CLI**
``` powershell
> dotnet add package VkNet.AudioBypassService
```
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
+ [Messages.AddChatUser](/vk/messages/addChatUser/) - Добавляет в мультидиалог нового пользователя.
+ [Messages.AllowMessagesFromGroup](/vk/messages/allowMessagesFromGroup/) - !!Позволяет разрешить отправку сообщений от сообщества текущему пользователю.
+ [Messages.CreateChat](/vk/messages/createChat/) - Создаёт беседу с несколькими участниками.
+ [Messages.Delete](/vk/messages/delete/) - Удаляет сообщение.
+ [Messages.DeleteChatPhoto](/vk/messages/deleteChatPhoto/) - Позволяет удалить фотографию мультидиалога.
+ [Messages.DeleteConversation](/vk/messages/deleteConversation/) - Удаляет все личные сообщения в диалоге.
+ (Устаревший) [Messages.DeleteDialog](/vk/messages/deleteDialog/) - Удаляет все личные сообщения в диалоге.
+ [Messages.DenyMessagesFromGroup](/vk/messages/denyMessagesFromGroup/) - !!Позволяет запретить отправку сообщений от сообщества текущему пользователю.
+ [Messages.Edit](/vk/messages/edit/) - !!Редактирует сообщение.
+ [Messages.EditChat](/vk/messages/editChat/) - Изменяет название беседы.
+ (Устаревший) [Messages.Get](/vk/messages/get/) - Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
+ [Messages.GetByConversationMessageId](/vk/messages/getByConversationMessageId/) - !!Возвращает сообщения по их идентификаторам в рамках беседы.
+ [Messages.GetById](/vk/messages/getByConversationMessageId/) - !!Возвращает сообщения по их идентификаторам в рамках беседы.
+ [Messages.GetChat](/vk/messages/getChat/) - Возвращает информацию о беседе.
+ (Устаревший) [Messages.GetChatUsers](/vk/messages/getChatUsers/) - Позволяет получить список пользователей мультидиалога по его id.
+ [Messages.GetChatPreview](/vk/messages/getChatPreview/) - !!Получает данные для превью чата с приглашением по ссылке.
+ [Messages.GetConversationMembers](/vk/messages/getConversationMembers/) - Позволяет получить список участников беседы.
+ [Messages.GetConversations](/vk/messages/getConversations/) - Возвращает список бесед пользователя.
+ [Messages.GetConversationsById](/vk/messages/getConversationsById/) - Возвращает список бесед пользователя.
+ (Устаревший) [Messages.GetDialogs](/vk/messages/getDialogs/) - Возвращает список диалогов текущего пользователя.
+ [Messages.GetHistory](/vk/messages/getHistory/) - Возвращает историю сообщений для указанного пользователя.
+ [Messages.GetHistoryAttachments](/vk/messages/getHistoryAttachments/) - !!Возвращает материалы диалога или беседы.
+ [Messages.GetImportantMessages](/vk/messages/getImportantMessages/) - !!Возвращает список важных сообщений пользователя.
+ [Messages.GetInviteLink](/vk/messages/getInviteLink/) - !!Получает ссылку для приглашения пользователя в беседу.
+ [Messages.GetLastActivity](/vk/messages/getLastActivity/) - Возвращает текущий статус и дату последней активности указанного пользователя.
+ [Messages.GetLongPollHistory](/vk/messages/getLongPollHistory/) - Возвращает обновления в личных сообщениях пользователя.
+ [Messages.GetLongPollServer](/vk/messages/getLongPollServer/) - Возвращает данные, необходимые для подключения к Long Poll серверу.
+ [Messages.IsMessagesFromGroupAllowed](/vk/messages/isMessagesFromGroupAllowed/) - !!Возвращает информацию о том, разрешена ли отправка сообщений от сообщества пользователю.
+ [Messages.JoinChatByInviteLink](/vk/messages/joinChatByInviteLink/) - !!Позволяет присоединиться к чату по ссылке-приглашению.
+ [Messages.MarkAsAnsweredConversation](/vk/messages/markAsAnsweredConversation/) - !!Помечает беседу как отвеченную либо снимает отметку.
+ [Messages.MarkAsImportant](/vk/messages/markAsImportant/) - !!Помечает сообщения как важные либо снимает отметку.
+ [Messages.MarkAsImportantConversation](/vk/messages/markAsImportantConversation/) - !!Помечает беседу как важную либо снимает отметку.
+ [Messages.MarkAsRead](/vk/messages/markAsRead/) - Помечает сообщения как прочитанные.
+ [Messages.Pin](/vk/messages/pin/) - !!Закрепляет сообщение.
+ [Messages.RemoveChatUser](/vk/messages/removeChatUser/) - Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
+ [Messages.Restore](/vk/messages/restore/) - Восстанавливает удаленное сообщение.
+ [Messages.Search](/vk/messages/search/) - Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
+ (Устаревший) [Messages.SearchDialogs](/vk/messages/searchDialogs/) - Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.
+ [Messages.SearchConversations](/vk/messages/searchConversations/) - Позволяет искать диалоги.
+ [Messages.Send](/vk/messages/send/) - Отправляет сообщение.
+ [Messages.SetActivity](/vk/messages/setActivity/) - Изменяет статус набора текста пользователем в диалоге.
+ [Messages.SetChatPhoto](/vk/messages/setChatPhoto/) - Позволяет установить фотографию мультидиалога, загруженную с помощью метода pho/tos.getChatUploadServer.
+ [Messages.Unpin](/vk/messages/unpin/) - !!Открепляет сообщение.

## Стена
+ [Wall.CloseComments](/vk/wall/closeComments/) - !!Выключает комментирование записи.
+ (Устаревший метод) [Wall.AddComment](/vk/wall/addComment/) - Добавляет комментарий к записи на стене пользователя или сообщества.
+ [Wall.CreateComment](/vk/wall/createComment/) - !!Добавляет комментарий к записи на стене.
+ [Wall.Delete](/vk/wall/delete/) - Удаляет запись со стены.
+ [Wall.DeleteComment](/vk/wall/deleteComment/) - Удаляет комментарий текущего пользователя к записи на своей или чужой стене.
+ [Wall.Edit](/vk/wall/edit/) - Редактирует запись на стене.
+ [Wall.EditAdsStealth](/vk/wall/editAdsStealth/) - !!Позволяет отредактировать скрытую запись.
+ [Wall.EditComment](/vk/wall/editComment/) - Редактирует комментарий на стене пользователя или сообщества.
+ [Wall.Get](/vk/wall/get/) - Возвращает список записей со стены пользователя или сообщества.
+ [Wall.GetById](/vk/wall/getById/) - Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
+ [Wall.GetComments](/vk/wall/getComments/) - Возвращает список комментариев к записи на стене.
+ [Wall.GetReposts](/vk/wall/getReposts/) - Позволяет получать список репостов заданной записи.
+ [Wall.OpenComments](/vk/wall/openComments/) - !!Включает комментирование записи
+ [Wall.Pin](/vk/wall/pin/) - Закрепляет запись на стене (запись будет отображаться выше остальных).
+ [Wall.Post](/vk/wall/post/) - Публикует новую запись на своей или чужой стене.
+ [Wall.PostAdsStealth](/vk/wall/postAdsStealth/) - !!Позволяет создать скрытую запись, которая не попадает на стену сообщества и в дальнейшем может быть использована для создания рекламного объявления типа "Запись в сообществе".
+ [Wall.ReportComment](/vk/wall/reportComment/) - Позволяет пожаловаться на комментарий к записи.
+ [Wall.ReportPost](/vk/wall/reportPost/) - Позволяет пожаловаться на запись.
+ [Wall.Repost](/vk/wall/repost/) - Копирует объект на стену пользователя или сообщества.
+ [Wall.Restore](/vk/wall/restore/) - Восстанавливает удаленную запись на стене пользователя или сообщества.
+ [Wall.RestoreComment](/vk/wall/restoreComment/) - Восстанавливает комментарий текущего пользователя к записи на своей или чужой стене.
+ [Wall.Search](/vk/wall/search/) - Метод, позволяющий осуществлять поиск по стенам пользователей.
+ [Wall.Unpin](/vk/wall/unpin/) - Отменяет закрепление записи на стене.

## Статус
+ [Status.Get](/vk/status/get/) - Получает статус пользователя.
+ [Status.Set](/vk/status/set/) - Устанавливает статус текущему пользователю.

## Фотографии
+ [Photos.ConfirmTag](/vk/photos/confirmTag/) - Подтверждает отметку на фотографии.
+ [Photos.Copy](/vk/photos/copy/) - Позволяет скопировать фотографию в альбом "Сохраненные фотографии".
+ [Photos.CreateAlbum](/vk/photos/createAlbum/) - Создает пустой альбом для фотографий.
+ [Photos.CreateComment](/vk/photos/createComment/) - Создает новый комментарий к фотографии.
+ [Photos.Delete](/vk/photos/delete/) - Удаление фотографии на сайте.
+ [Photos.DeleteAlbum](/vk/photos/deleteAlbum/) - Удаляет указанный альбом для фотографий у текущего пользователя.
+ [Photos.DeleteComment](/vk/photos/deleteComment/) - Удаляет комментарий к фотографии.
+ [Photos.Edit](/vk/photos/edit/) - Изменяет описание у выбранной фотографии.
+ [Photos.EditAlbum](/vk/photos/editAlbum/) - Редактирует данные альбома для фотографий пользователя.
+ [Photos.EditComment](/vk/photos/editComment/) - Изменяет текст комментария к фотографии.
+ [Photos.Get](/vk/photos/get/) - Возвращает список фотографий в альбоме.
+ [Photos.GetAlbums](/vk/photos/getAlbums/) - Возвращает список альбомов пользователя или сообщества.
+ [Photos.GetAlbumsCount](/vk/photos/getAlbumsCount/) - Возвращает количество доступных альбомов пользователя или сообщества.
+ [Photos.GetAll](/vk/photos/getAll/) - Возвращает все фотографии пользователя или сообщества в антихронологическом порядке.
+ [Photos.GetAllComments](/vk/photos/getAllComments/) - Возвращает отсортированный в антихронологическом порядке список всех комментариев к конкретному альбому или ко всем альбомам пользователя.
+ [Photos.GetById](/vk/photos/getById/) - Возвращает информацию о фотографиях по их идентификаторам.
+ [Photos.GetChatUploadServer](/vk/photos/getChatUploadServer/) - Позволяет получить адрес для загрузки фотографий мультидиалогов.
+ [Photos.GetComments](/vk/photos/getComments/) - Возвращает список комментариев к фотографии.
+ [Photos.GetMarketAlbumUploadServer](/vk/photos/getMarketAlbumUploadServer/) - Возвращает адрес сервера для загрузки фотографии подборки товаров в сообществе.
+ [Photos.GetMarketUploadServer](/vk/photos/getMarketUploadServer/) - Возвращает адрес сервера для загрузки фотографии товаров сообщества.
+ [Photos.GetMessagesUploadServer](/vk/photos/getMessagesUploadServer/) - Возвращает адрес сервера для загрузки фотографии в личное сообщение пользователю.
+ [Photos.GetNewTags](/vk/photos/getNewTags/) - Возвращает список фотографий, на которых есть непросмотренные отметки.
+ [Photos.GetOwnerCoverPhotoUploadServer](/vk/photos/getOwnerCoverPhotoUploadServer/) - Получает адрес для загрузки обложки сообщества.
+ [Photos.GetOwnerPhotoUploadServer](/vk/photos/getOwnerPhotoUploadServer/) - Возвращает адрес сервера для загрузки главной фотографии на страницу пользователя или сообщества.
+ [Photos.GetTags](/vk/photos/getTags/) - Возвращает список отметок на фотографии.
+ [Photos.GetUploadServer](/vk/photos/getUploadServer/) - Возвращает адрес сервера для загрузки фотографий.
+ [Photos.GetUserPhotos](/vk/photos/getUserPhotos/) - Возвращает список фотографий, на которых отмечен пользователь.
+ [Photos.GetWallUploadServer](/vk/photos/getWallUploadServer/) - Возвращает адрес сервера для загрузки фотографии на стену пользователя или сообщества.
+ [Photos.Move](/vk/photos/move/) - Переносит фотографию из одного альбома в другой.
+ [Photos.MakeCover](/vk/photos/makeCover/) - Делает фотографию обложкой альбома.
+ [Photos.PutTag](/vk/photos/putTag/) - Добавляет отметку на фотографию.
+ [Photos.RemoveTag](/vk/photos/removeTag/) - Удаляет отметку с фотографии.
+ [Photos.ReorderAlbums](/vk/photos/reorderAlbums/) - Меняет порядок альбома в списке альбомов пользователя.
+ [Photos.ReorderPhotos](/vk/photos/reorderPhotos/) - Меняет порядок фотографии в списке фотографий альбома пользователя.
+ [Photos.Report](/vk/photos/report/) - Позволяет пожаловаться на фотографию.
+ [Photos.ReportComment](/vk/photos/reportComment/) - Позволяет пожаловаться на комментарий к фотографии.
+ [Photos.Restore](/vk/photos/restore/) - Восстанавливает удаленную фотографию.
+ [Photos.RestoreComment](/vk/photos/restoreComment/) - Восстанавливает удаленный комментарий к фотографии.
+ [Photos.Save](/vk/photos/save/) - Сохраняет фотографии после успешной загрузки.
+ [Photos.SaveMarketAlbumPhoto](/vk/photos/saveMarketAlbumPhoto/) - Сохраняет фотографии после успешной загрузки на URI, полученный методом ph/otos.getMarketAlbumUploadServer.
+ [Photos.SaveMarketPhoto](/vk/photos/saveMarketPhoto/) - Сохраняет фотографии после успешной загрузки на URI, полученный методом ph/otos.getMarketUploadServer.
+ [Photos.SaveMessagesPhoto](/vk/photos/saveMessagesPhoto/) - Сохраняет фотографию после успешной загрузки на URI, полученный методом ph/otos.getMessagesUploadServer.
+ [Photos.SaveOwnerCoverPhoto](/vk/photos/saveOwnerCoverPhoto/) - Сохраняет изображение для обложки сообщества после успешной загрузки.
+ [Photos.SaveOwnerPhoto](/vk/photos/saveOwnerPhoto/) - Позволяет сохранить главную фотографию пользователя или сообщества.
+ [Photos.SaveWallPhoto](/vk/photos/saveWallPhoto/) - Сохраняет фотографии после успешной загрузки на URI, полученный методом ph/   otos.getWallUploadServer.
+ [Photos.Search](/vk/photos/search/) - Осуществляет поиск изображений по местоположению или описанию.

## Видео
+ [Video.Add](/vk/video/add/) - Добавляет видеозапись в список пользователя.
+ [Video.AddAlbum](/vk/video/addAlbum/) - Создает пустой альбом видеозаписей.
+ [Video.AddToAlbum](/vk/video/addToAlbum/) - Позволяет добавить видеозапись в альбом.
+ [Video.CreateComment](/vk/video/createComment/) - Cоздает новый комментарий к видеозаписи.
+ [Video.Delete](/vk/video/delete/) - Удаляет видеозапись со страницы пользователя.
+ [Video.DeleteAlbum](/vk/video/deleteAlbum/) - Удаляет альбом видеозаписей.
+ [Video.DeleteComment](/vk/video/deleteComment/) - Удаляет комментарий к видеозаписи.
+ [Video.Edit](/vk/video/edit/) - Редактирует данные видеозаписи.
+ [Video.EditAlbum](/vk/video/editAlbum/) - Редактирует название альбома видеозаписей.
+ [Video.EditComment](/vk/video/editComment/) - Изменяет текст комментария к видеозаписи.
+ [Video.Get](/vk/video/get/) - Возвращает информацию о видеозаписях.
+ [Video.GetAlbumById](/vk/video/getAlbumById/) - Позволяет получить информацию об альбоме с видео.
+ [Video.GetAlbums](/vk/video/getAlbums/) - Возвращает список альбомов видеозаписей пользователя или сообщества.
+ [Video.GetAlbumsByVideo](/vk/video/getAlbumsByVideo/) - Возвращает список альбомов, в которых находится видеозапись.
+ (Устаревший) [Video.GetCatalog](/vk/video/getCatalog/) - Позволяет получить представление каталога видео.
+ (Устаревший) [Video.GetCatalogSection](/vk/video/getCatalogSection/) - Позволяет получить отдельный блок видеокаталога.
+ [Video.GetComments](/vk/video/getComments/) - Возвращает список комментариев к видеозаписи.
+ (Устаревший) [Video.HideCatalogSection](/vk/video/hideCatalogSection/) - Скрывает для пользователя раздел видеокаталога.
+ [Video.RemoveFromAlbum](/vk/video/removeFromAlbum/) - Позволяет убрать видеозапись из альбома.
+ (Устаревший) [Video.RemoveTag](/vk/video/removeTag/) - Удаляет отметку с видеозаписи.
+ [Video.ReorderAlbums](/vk/video/reorderAlbums/) - Позволяет изменить порядок альбомов с видео.
+ [Video.ReorderVideos](/vk/video/reorderVideos/) - Позволяет переместить видеозапись в альбоме.
+ [Video.Report](/vk/video/report/) - Позволяет пожаловаться на видеозапись.
+ [Video.ReportComment](/vk/video/reportComment/) - Позволяет пожаловаться на комментарий к видеозаписи.
+ [Video.Restore](/vk/video/restore/) - Восстанавливает удаленную видеозапись.
+ [Video.RestoreComment](/vk/video/restoreComment/) - Восстанавливает удаленный комментарий к видеозаписи.
+ [Video.Save](/vk/video/save/) - Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
+ [Video.Search](/vk/video/search/) - Возвращает список видеозаписей в соответствии с заданным критерием поиска.


## Закладки

+ [Fave.AddArticle](/vk/fave/addArticle/) - Добавляет статью в закладки.
+ (Устаревший) [Fave.AddGroup](/vk/fave/addGroup/) - Добавляет сообщество в закладки.
+ [Fave.AddLink](/vk/fave/addLink/) - Добавляет ссылку в закладки.
+ [Fave.AddPage](/vk/fave/addPage/) - Добавляет сообщество или пользователя в закладки.
+ [Fave.AddPost](/vk/fave/addPost/) - Добавляет запись со стены пользователя или сообщества в закладки.
+ [Fave.AddProduct](/vk/fave/addProduct/) - Добавляет товар в закладки.
+ [Fave.AddTag](/vk/fave/addTag/) - Создает метку  в закладки.
+ (Устаревший) [Fave.AddUser](/vk/fave/addUser/) - Добавляет пользователя в закладки.
+ [Fave.AddVideo](/vk/fave/addVideo/) - Добавляет видеозапись в закладки.
+ [Fave.EditTag](/vk/fave/editTag/) - Редактирует метку.
+ [Fave.Get](/vk/fave/get/) - Возвращает объекты, добавленные в закладки пользователя..
+ (Устаревший) [Fave.GetLinks](/vk/fave/getLinks/) - Возвращает ссылки, добавленные в закладки текущим пользователем.
+ (Устаревший) [Fave.GetMarketItems](/vk/fave/getMarketItems/) - Возвращает товары, добавленные в закладки текущим пользователем.
+ [Fave.GetPages](/vk/fave/getPages/) - Возвращает страницы пользователей и сообществ, добавленных в закладки.
+ (Устаревший) [Fave.GetPhotos](/vk/fave/getPhotos/) - Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".
+ (Устаревший) [Fave.GetPosts](/vk/fave/getPosts/) - Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetTags](/vk/fave/getTags/) - Возвращает список меток в закладках.
+ (Устаревший) [Fave.GetUsers](/vk/fave/getUsers/) - Возвращает список пользователей, добавленных текущим пользователем в закладки.
+ (Устаревший) [Fave.GetVideos](/vk/fave/getVideos/) - Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.MarkSeen](/vk/fave/markSeen/) - Отмечает закладки как просмотренные.
+ [Fave.RemoveArticle](/vk/fave/removeArticle/) - Добавляет видеозапись в закладки.
+ (Устаревший) [Fave.RemoveGroup](/vk/fave/removeGroup/) - Удаляет сообщество из закладок.
+ [Fave.RemoveLink](/vk/fave/removeLink/) - Добавляет видеозапись в закладки.
+ [Fave.RemovePage](/vk/fave/removePage/) - Добавляет видеозапись в закладки.
+ [Fave.RemovePost](/vk/fave/removePost/) - Добавляет видеозапись в закладки.
+ [Fave.RemoveProduct](/vk/fave/removeProduct/) - Добавляет видеозапись в закладки.
+ [Fave.RemoveTag](/vk/fave/removeTag/) - Добавляет видеозапись в закладки.
+ (Устаревший) [Fave.RemoveUser](/vk/fave/removeUser/) - Удаляет пользователя из закладок.
+ [Fave.RemoveVideo](/vk/fave/removeVideo/) - Добавляет видеозапись в закладки.
+ [Fave.ReorderTags](/vk/fave/reorderTags/) - Добавляет видеозапись в закладки.
+ [Fave.SetPageTags](/vk/fave/setPageTags/) - Добавляет видеозапись в закладки.
+ [Fave.SetTags](/vk/fave/setTags/) - Добавляет видеозапись в закладки.
+ [Fave.TrackPageInteraction](/vk/fave/trackPageInteraction/) - Добавляет видеозапись в закладки.

## Служебные
+ [Utils.CheckLink](/vk/utils/checkLink/) - Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
+ [Utils.deleteFromLastShortened](/vk/utils/deleteFromLastShortened/) - !!Удаляет сокращенную ссылку из списка пользователя.
+ [Utils.getLastShortenedLinks](/vk/utils/getLastShortenedLinks/) - !!Получает список сокращенных ссылок для текущего пользователя.
+ [Utils.getLinkStats](/vk/utils/getLinkStats/) - !!Возвращает статистику переходов по сокращенной ссылке.
+ [Utils.GetServerTime](/vk/utils/getServerTime/) - Возвращает текущее время на сервере ВКонтакте.
+ [Utils.getShortLink](/vk/utils/getShortLink/) - !!Позволяет получить URL, сокращенный с помощью vk.cc.
+ [Utils.ResolveScreenName](/vk/utils/resolveScreenName/) - Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени screenName.

## Данные ВК
+ [Database.GetChairs](/vk/database/getChairs/) - Возвращает список кафедр университета по указанному факультету.
+ [Database.GetCities](/vk/database/getCities/) - Возвращает список городов.
+ [Database.GetCitiesById](/vk/database/getCitiesById/) - Возвращает информацию о городах по их идентификаторам.
+ [Database.GetCountries](/vk/database/getCountries/) - Возвращает список стран.
+ [Database.GetCountriesById](/vk/database/getCountriesById/) - Возвращает информацию о странах по их идентификаторам
+ [Database.GetFaculties](/vk/database/getFaculties/) - Возвращает список факультетов.
+ [Database.GetMetroStations](/vk/database/getMetroStations/) - Возвращает список станций метро.
+ [Database.getMetroStationsById](/vk/database/getMetroStationsById/) - Возвращает информацию об одной или нескольких станциях метро по их идентификаторам.
+ [Database.GetRegions](/vk/database/getRegions/) - Возвращает список регионов.
+ [Database.GetSchoolClasses](/vk/database/getSchoolClasses/) - Возвращает список классов, характерных для школ определенной страны.
+ [Database.GetSchools](/vk/database/getSchools/) - Возвращает список школ.
+ (Устаревший) [Database.GetStreetsById](/vk/database/getStreetsById/) - Возвращает информацию об улицах по их идентификаторам (id).
+ [Database.GetUniversities](/vk/database/getUniversities/) - Возвращает список высших учебных заведений.

## Новости
+ [Newsfeed.AddBan](/vk/newsfeed/addBan/) - Запрещает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.
+ [Newsfeed.DeleteBan](/vk/newsfeed/deleteBan/) - Разрешает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.
+ [Newsfeed.DeleteList](/vk/newsfeed/deleteList/) - Метод позволяет удалить пользовательский список новостей
+ [Newsfeed.Get](/vk/newsfeed/get/) - Возвращает данные, необходимые для показа списка новостей для текущего пользователя.
+ [Newsfeed.GetBanned](/vk/newsfeed/getBanned/) - Возвращает список пользователей и групп, которые текущий пользователь скрыл из ленты новостей.
+ [Newsfeed.GetComments](/vk/newsfeed/getComments/) - Возвращает данные, необходимые для показа раздела комментариев в новостях пользователя.
+ [Newsfeed.GetLists](/vk/newsfeed/getLists/) - Возвращает пользовательские списки новостей.
+ [Newsfeed.GetMentions](/vk/newsfeed/getMentions/) - Возвращает список записей пользователей на своих стенах, в которых упоминается указанный пользователь.
+ [Newsfeed.GetRecommended](/vk/newsfeed/getRecommended/) - Получает список новостей, рекомендованных пользователю.
+ [Newsfeed.GetSuggestedSources](/vk/newsfeed/getSuggestedSources/) - Возвращает сообщества и пользователей, на которые текущему пользователю рекомендуется подписаться.
+ [Newsfeed.IgnoreItem](/vk/newsfeed/ignoreItem/) - Позволяет скрыть объект из ленты новостей.
+ [Newsfeed.SaveList](/vk/newsfeed/saveList/) - Метод позволяет создавать или редактировать пользовательские списки для просмотра новостей.
+ [Newsfeed.Search](/vk/newsfeed/search/) - Возвращает результаты поиска по статусам. Новости возвращаются в порядке от более новых к более старым.
+ [Newsfeed.UnignoreItem](/vk/newsfeed/unignoreItem/) - Позволяет вернуть ранее скрытый объект в ленту новостей.
+ [Newsfeed.Unsubscribe](/vk/newsfeed/unsubscribe/) - Отписывает текущего пользователя от комментариев к заданному объекту.

## Мне нравится
+ [Likes.Add](/vk/likes/add/) - Добавляет указанный объект в список Мне нравится текущего пользователя.
+ [Likes.Delete](/vk/likes/delete/) - Удаляет указанный объект из списка Мне нравится текущего пользователя.
+ [Likes.GetList](/vk/likes/getList/) - Получает список идентификаторов пользователей, которые добавили заданный объект в свой список Мне нравится.
+ [Likes.IsLiked](/vk/likes/isLiked/) - Проверяет, находится ли объект в списке Мне нравится заданного пользователя.

## Авторизация
+ [Auth.CheckPhone](/vk/auth/checkPhone/) - Проверяет правильность введённого номера.
+ [Auth.Restore](/vk/auth/restore/) - Позволяет восстановить доступ к аккаунту, используя код, полученный через SMS.  Данный метод доступен только приложениям, имеющим доступ к Прямой авторизации.
+ (Устаревший) [Auth.Signup](/vk/auth/signup/) - Регистрирует нового пользователя по номеру телефона.
+ (Устаревший) [Auth.Confirm](/vk/auth/confirm/) - Завершает регистрацию нового пользователя, начатую методом auth.signup, по коду, полученному через SMS.

## Статистика
+ [Stats.Get](/vk/stats/get/) - Возвращает статистику сообщества или приложения.
+ [Stats.GetPostReach](/vk/stats/getPostReach/) - Возвращает статистику для записи на стене.
+ [Stats.TrackVisitor](/vk/stats/trackVisitor/) - Добавляет данные о текущем сеансе в статистику посещаемости приложения.

## Подарки
+ [Gifts.Get](/vk/gifts/get/) - Возвращает список полученных подарков пользователя.

## Страницы
+ [Pages.ClearCache](/vk/pages/clearCache/) - Позволяет очистить кеш отдельных внешних страниц, которые могут быть прикреплены к записям ВКонтакте. После очистки кеша при последующем прикреплении ссылки к записи, данные о странице будут обновлены.
+ [Pages.Get](/vk/pages/get/) - Возвращает информацию о вики-странице.
+ [Pages.GetHistory](/vk/pages/getHistory/) - Возвращает список всех старых версий вики-страницы.
+ [Pages.GetTitles](/vk/pages/getTitles/) - Возвращает список вики-страниц в группе.
+ [Pages.GetVersion](/vk/pages/getVersion/) - Возвращает текст одной из старых версий страницы.
+ [Pages.ParseWiki](/vk/pages/parseWiki/) - Возвращает html-представление вики-разметки.
+ [Pages.Save](/vk/pages/save/) - Сохраняет текст вики-страницы.
+ [Pages.SaveAccess](/vk/pages/saveAccess/) - Сохраняет новые настройки доступа на чтение и редактирование вики-страницы.

## Документы
+ [Docs.Add](/vk/docs/add/) - Копирует документ в документы текущего пользователя.
+ [Docs.Delete](/vk/docs/delete/) - Удаляет документ пользователя или группы.
+ [Docs.Edit](/vk/docs/edit/) - Редактирует документ пользователя или группы.
+ [Docs.Get](/vk/docs/get/) - Возвращает расширенную информацию о документах пользователя или сообщества.
+ [Docs.GetById](/vk/docs/getById/) - Возвращает информацию о документах по их идентификаторам.
+ [Docs.GetMessagesUploadServer](/vk/docs/getMessagesUploadServer/) - !!Получает адрес сервера для загрузки документа в личное сообщение.
+ [Docs.GetTypes](/vk/docs/getTypes/) - Возвращает доступные типы документы для пользователя
+ [Docs.GetUploadServer](/vk/docs/getUploadServer/) - Возвращает адрес сервера для загрузки документов.
+ [Docs.GetWallUploadServer](/vk/docs/getWallUploadServer/) - Возвращает адрес сервера для загрузки документов в папку Отправленные, для последующей отправки документа на стену или личным сообщением.
+ [Docs.Save](/vk/docs/save/) - Сохраняет документ после его успешной загрузки на сервер.
+ [Docs.Search](/vk/docs/search/) - Возвращает результаты поиска по документам.

## Приложения
+ [Apps.DeleteAppRequests](/vk/apps/deleteAppRequests/) - Удаляет все уведомления о запросах, отправленных из текущего приложения
+ [Apps.Get](/vk/apps/get/) - Возвращает данные о запрошенном приложении на платформе ВКонтакте
+ [Apps.GetCatalog](/vk/apps/getCatalog/) - Возвращает список приложений, доступных для пользователей сайта через каталог приложений.
+ [Apps.GetFriendsList](/vk/apps/getFriendsList/) - Создает список друзей, который будет использоваться при отправке пользователем приглашений в приложение и игровых запросов.
+ [Apps.GetLeaderboard](/vk/apps/getLeaderboard/) - Возвращает рейтинг пользователей в игре.
+ [Apps.GetScopes](/vk/apps/getScopes/) - !!Нет данных.
+ [Apps.GetScore](/vk/apps/getScore/) - Метод возвращает количество очков пользователя в этой игре.
+ [Apps.PromoHasActiveGift](/vk/apps/promoHasActiveGift/) - Проверяет есть ли у пользователя подарок в игре.
+ [Apps.PromoUseGift](/vk/apps/promoUseGift/) - Использовать подарок, полученный пользователем в промо-акции.
+ [Apps.SendRequest](/vk/apps/sendRequest/) - Позволяет отправить запрос другому пользователю в приложении, использующем авторизацию ВКонтакте.

## Товары
+ [Market.Add](/vk/market/add/) - Добавляет новый товар.
+ [Market.AddAlbum](/vk/market/addAlbum/) - Добавляет новую подборку с товарами.
+ [Market.AddToAlbum](/vk/market/addToAlbum/) - Добавляет товар в одну или несколько выбранных подборок.
+ [Market.CreateComment](/vk/market/createComment/) - Создает новый комментарий к товару.
+ [Market.Delete](/vk/market/delete/) - Удаляет товар.
+ [Market.DeleteAlbum](/vk/market/deleteAlbum/) - Удаляет подборку с товарами.
+ [Market.DeleteComment](/vk/market/deleteComment/) - Удаляет комментарий к товару.
+ [Market.Edit](/vk/market/edit/) - Редактирует товар.
+ [Market.EditAlbum](/vk/market/editAlbum/) - Редактирует подборку с товарами.
+ [Market.EditComment](/vk/market/editComment/) - Изменяет текст комментария к товару.
+ [Market.Get](/vk/market/get/) - Возвращает список товаров в сообществе.
+ [Market.GetAlbums](/vk/market/getAlbums/) - Возвращает список подборок с товарами.
+ [Market.GetAlbumById](/vk/market/getAlbumById/) - Возвращает данные подборки с товарами.
+ [Market.GetById](/vk/market/getById/) - Возвращает информацию о товарах по идентификаторам.
+ [Market.GetCategories](/vk/market/getCategories/) - Возвращает список категорий для товаров.
+ [Market.GetComments](/vk/market/getComments/) - Возвращает список комментариев к товару.
+ [Market.RemoveFromAlbum](/vk/market/removeFromAlbum/) - Удаляет товар из одной или нескольких выбранных подборок.
+ [Market.ReorderAlbums](/vk/market/reorderAlbums/) - Изменяет положение подборки с товарами в списке.
+ [Market.ReorderItems](/vk/market/reorderItems/) - Изменяет положение товара в подборке.
+ [Market.Report](/vk/market/report/) - Позволяет отправить жалобу на товар.
+ [Market.ReportComment](/vk/market/reportComment/) - Позволяет оставить жалобу на комментарий к товару.
+ [Market.Restore](/vk/market/restore/) - Восстанавливает удаленный товар.
+ [Market.RestoreComment](/vk/market/restoreComment/) - Восстанавливает удаленный комментарий к товару.
+ [Market.Search](/vk/market/search/) - Ищет товары в каталоге сообщества.

## Аккаунт
+ [Account.Ban](/vk/account/ban/) - Добавляет пользователя или группу в черный список.
+ [Account.ChangePassword](/vk/account/changePassword/) - Позволяет сменить пароль пользователя после успешного восстановления доступа к аккаунту через СМС, используя метод auth.restore.
+ [Account.GetActiveOffers](/vk/account/getActiveOffers/) - Возвращает список активных рекламных предложений (офферов), выполнив которые пользователь сможет получить соответствующее количество голосов на свой счёт внутри приложения.
+ [Account.GetAppPermissions](/vk/account/getAppPermissions/) - Получает настройки текущего пользователя в данном приложении.
+ [Account.GetBanned](/vk/account/getBanned/) - Возвращает список пользователей, находящихся в черном списке.
+ [Account.GetCounters](/vk/account/getCounters/) - Возвращает ненулевые значения счетчиков пользователя.
+ [Account.GetInfo](/vk/account/getInfo/) - Возвращает информацию о текущем аккаунте.
+ [Account.GetProfileInfo](/vk/account/getProfileInfo/) - Возвращает информацию о текущем профиле.
+ [Account.GetPushSettings](/vk/account/getPushSettings/) - Позволяет получать настройки Push уведомлений.
+ [Account.RegisterDevice](/vk/account/registerDevice/) - Подписывает устройство на базе iOS, Android или Windows Phone на получение Push-уведомлений.
+ [Account.SaveProfileInfo](/vk/account/saveProfileInfo/) - Редактирует информацию текущего профиля.
+ [Account.SetInfo](/vk/account/setInfo/) - Позволяет редактировать информацию о текущем аккаунте.
+ [Account.SetNameInMenu](/vk/account/setNameInMenu/) - Устанавливает короткое название приложения (до 17 символов), которое выводится пользователю в левом меню.
+ [Account.SetOffline](/vk/account/setOffline/) - Помечает текущего пользователя как offline.
+ [Account.SetOnline](/vk/account/setOnline/) - Помечает текущего пользователя как online на 15 минут.
+ [Account.SetPushSettings](/vk/account/setPushSettings/) - Изменяет настройку Push-уведомлений.
+ [Account.SetSilenceMode](/vk/account/setSilenceMode/) - Отключает push-уведомления на заданный промежуток времени.
+ [Account.Unban](/vk/account/unban/) - Убирает пользователя из черного списка.
+ [Account.UnregisterDevice](/vk/account/unregisterDevice/) - Отписывает устройство от Push уведомлений.

## Рекламный Кабинет
+ [Ads.AddOfficeUsers](/vk/ads/addOfficeUsers/) - Добавляет администраторов и/или наблюдателей в рекламный кабинет.
+ [Ads.CheckLink](/vk/ads/checkLink/) - Проверяет ссылку на рекламируемый объект.
+ [Ads.CreateAds](/vk/ads/createAds/) - Создает рекламные объявления.
+ [Ads.CreateCampaigns](/vk/ads/createCampaigns/) - Создает рекламные кампании.
+ [Ads.CreateClients](/vk/ads/createClients/) - оздаёт клиентов рекламного агентства.
+ [Ads.CreateLookalikeRequest](/vk/ads/createLookalikeRequest/) - Создаёт запрос на поиск похожей аудитории.
+ [Ads.CreateTargetGroup](/vk/ads/createTargetGroup/) - Создает аудиторию для ретаргетинга рекламных объявлений на пользователей, которые посетили сайт рекламодателя (просмотрели информации о товаре, зарегистрировались и т.д.).
+ [Ads.CreateTargetPixel](/vk/ads/createTargetPixel/) - Создаёт пиксель ретаргетинга.
+ [Ads.DeleteAds](/vk/ads/deleteAds/) - Архивирует рекламные объявления.
+ [Ads.DeleteCampaigns](/vk/ads/deleteCampaigns/) - Архивирует рекламные кампании.
+ [Ads.DeleteClients](/vk/ads/deleteClients/) - Архивирует клиентов рекламного агентства.
+ [Ads.DeleteTargetGroup](/vk/ads/deleteTargetGroup/) - Удаляет аудиторию ретаргетинга.
+ [Ads.DeleteTargetPixel](/vk/ads/deleteTargetPixel/) - Удаляет пиксель ретаргетинга.
+ [Ads.GetAccounts](/vk/ads/getAccounts/) - Возвращает список рекламных кабинетов.
+ [Ads.GetAds](/vk/ads/getAds/) - Возвращает список рекламных объявлений.
+ [Ads.GetAdsLayout](/vk/ads/getAdsLayout/) - Возвращает описания внешнего вида рекламных объявлений.
+ [Ads.GetAdsTargeting](/vk/ads/getAdsTargeting/) - Возвращает параметры таргетинга рекламных объявлений
+ [Ads.GetBudget](/vk/ads/getBudget/) - Возвращает текущий бюджет рекламного кабинета.
+ [Ads.GetCampaigns](/vk/ads/getCampaigns/) - Возвращает список кампаний рекламного кабинета.
+ [Ads.GetCategories](/vk/ads/getCategories/) - Позволяет получить возможные тематики рекламных объявлений.
+ [Ads.GetClients](/vk/ads/getClients/) - Возвращает список клиентов рекламного агентства.
+ [Ads.GetDemographics](/vk/ads/getDemographics/) - Возвращает демографическую статистику по рекламным объявлениям или кампаниям.
+ [Ads.GetFloodStats](/vk/ads/getFloodStats/) - Возвращает информацию о текущем состоянии счетчика — количество оставшихся запусков методов и время до следующего обнуления счетчика в секундах.
+ [Ads.GetLookalikeRequests](/vk/ads/getLookalikeRequests/) - Возвращает список запросов на поиск похожей аудитории.
+ [Ads.GetOfficeUsers](/vk/ads/getOfficeUsers/) - Возвращает список администраторов и наблюдателей рекламного кабинета.
+ [Ads.GetPostsReach](/vk/ads/getPostsReach/) - Возвращает подробную статистику по охвату рекламных записей из объявлений и кампаний для продвижения записей сообщества.
+ [Ads.GetRejectionReason](/vk/ads/getRejectionReason/) - Возвращает причину, по которой указанному объявлению было отказано в прохождении премодерации.
+ [Ads.GetStatistics](/vk/ads/getStatistics/) - Возвращает статистику показателей эффективности по рекламным объявлениям, кампаниям, клиентам или всему кабинету.
+ [Ads.GetSuggestions](/vk/ads/getSuggestions/) - Возвращает набор подсказок для различных параметров таргетинга.
+ [Ads.GetTargetGroups](/vk/ads/getTargetGroups/) - Возвращает список аудиторий ретаргетинга.
+ [Ads.GetTargetPixels](/vk/ads/getTargetPixels/) - Возвращает список пикселей ретаргетинга.
+ [Ads.GetTargetingStats](/vk/ads/getTargetingStats/) - Возвращает размер целевой аудитории таргетинга, а также рекомендованные значения CPC и CPM.
+ [Ads.GetUploadURL](/vk/ads/getUploadURL/) - Возвращает URL-адрес для загрузки фотографии рекламного объявления.
+ [Ads.GetVideoUploadURL](/vk/ads/getVideoUploadURL/) - Возвращает URL-адрес для загрузки видеозаписи рекламного объявления.
+ [Ads.ImportTargetContacts](/vk/ads/importTargetContacts/) - Импортирует список контактов рекламодателя для учета зарегистрированных во ВКонтакте пользователей в аудитории ретаргетинга. 
+ [Ads.RemoveOfficeUsers](/vk/ads/removeOfficeUsers/) - Удаляет администраторов и/или наблюдателей из рекламного кабинета.
+ [Ads.RemoveTargetContacts](/vk/ads/removeTargetContacts/) - Принимает запрос на исключение контактов рекламодателя из аудитории ретаргетинга.
+ [Ads.SaveLookalikeRequestResult](/vk/ads/saveLookalikeRequestResult/) - Сохраняет результат поиска похожей аудитории.
+ [Ads.ShareTargetGroup](/vk/ads/shareTargetGroup/) - Предоставляет доступ к аудитории ретаргетинга другому рекламному кабинету. В результате выполнения метода возвращается идентификатор аудитории для указанного кабинета.
+ [Ads.UpdateAds](/vk/ads/updateAds/) - Редактирует рекламные объявления.
+ [Ads.UpdateCampaigns](/vk/ads/updateCampaigns/) - Редактирует рекламные кампании.
+ [Ads.UpdateClients](/vk/ads/updateClients/) - Редактирует клиентов рекламного агентства.
+ [Ads.UupdateTargetGroup](/vk/ads/updateTargetGroup/) - Редактирует аудиторию ретаргетинга.
+ [Ads.UpdateTargetPixel](/vk/ads/updateTargetPixel/) - Редактирует пиксель ретаргетинга.

## Обсуждения
+ [Board.AddTopic](/vk/board/addTopic/) - Создает новую тему в списке обсуждений группы.
+ [Board.CloseTopic](/vk/board/closeTopic/) - Закрывает тему в списке обсуждений группы (в такой теме невозможно оставлять новые сообщения).
+ [Board.CreateComment](/vk/board/createComment/) - Добавляет новый комментарий в обсуждении.
+ [Board.DeleteComment](/vk/board/deleteComment/) - Удаляет сообщение темы в обсуждениях сообщества.
+ [Board.DeleteTopic](/vk/board/deleteTopic/) - Удаляет тему в обсуждениях группы.
+ [Board.EditComment](/vk/board/editComment/) - Редактирует одно из сообщений в обсуждении сообщества.
+ [Board.EditTopic](/vk/board/editTopic/) - Изменяет заголовок темы в списке обсуждений группы.
+ [Board.FixTopic](/vk/board/fixTopic/) - Закрепляет тему в списке обсуждений группы (такая тема при любой сортировке выводится выше остальных).
+ [Board.GetComments](/vk/board/getComments/) - Возвращает список сообщений в указанной теме.
+ [Board.GetTopics](/vk/board/getTopics/) - Возвращает список тем в обсуждениях указанной группы.
+ [Board.OpenTopic](/vk/board/openTopic/) - Открывает ранее закрытую тему (в ней станет возможно оставлять новые сообщения).
+ [Board.RestoreComment](/vk/board/restoreComment/) - Восстанавливает удаленное сообщение темы в обсуждениях группы.
+ [Board.UnfixTopic](/vk/board/unFixTopic/) - Отменяет прикрепление темы в списке обсуждений группы (тема будет выводиться согласно выбранной сортировке).

## Управление рекламными акциями (офферами)
+ [Leads.CheckUser](/vk/leads/checkUser/) - Проверяет, доступна ли рекламная акция пользователю.
+ [Leads.Complete](/vk/leads/complete/) - Завершает начатую пользователем рекламную акцию, используя сессию и секретный ключ.
+ [Leads.GetStats](/vk/leads/getStats/) - Возвращает статистику по рекламной акции.
+ [Leads.GetUsers](/vk/leads/getUsers/) - Возвращает список последних действий пользователей по рекламной акции.
+ [Leads.MetricHit](/vk/leads/metricHit/) - Засчитывает событие метрики.
+ [Leads.Start](/vk/leads/start/) - Создаёт новую сессию для прохождения рекламной акции для пользователя.

## Заметки
+ [Notes.Add](/vk/notes/add/) - Создает новую заметку у текущего пользователя.
+ [Notes.CreateComment](/vk/notes/createComment/) - Добавляет новый комментарий к заметке.
+ [Notes.Delete](/vk/notes/delete/) - Удаляет заметку текущего пользователя.
+ [Notes.DeleteComment](/vk/notes/deleteComment/) - Удаляет комментарий к заметке.
+ [Notes.Edit](/vk/notes/edit/) - Редактирует заметку текущего пользователя.
+ [Notes.EditComment](/vk/notes/editComment/) - Редактирует указанный комментарий у заметки.
+ [Notes.Get](/vk/notes/get/) - Возвращает список заметок, созданных пользователем.
+ [Notes.GetById](/vk/notes/getById/) - Возвращает заметку по её id.
+ [Notes.GetComments](/vk/notes/getComments/) - Возвращает список комментариев к заметке.
+ [Notes.RestoreComment](/vk/notes/restoreComment/) - Восстанавливает удалённый комментарий.

## Оповещения
+ [Notifications.Get](/vk/notifications/get/) - Возвращает список оповещений об ответах других пользователей на записи текущего пользователя.
+ [Notifications.MarkAsViewed](/vk/notifications/markAsViewed/) - Сбрасывает счетчик непросмотренных оповещений об ответах других пользователей на записи текущего пользователя.

## Опросы
+ [Polls.AddVote](/vk/polls/addVote/) - Отдает голос текущего пользователя за выбранный вариант ответа в указанном опросе.
+ [Polls.Create](/vk/polls/create/) - Позволяет создавать опросы, которые впоследствии можно прикреплять к записям на странице пользователя или сообщества.
+ [Polls.DeleteVote](/vk/polls/deleteVote/) - Снимает голос текущего пользователя с выбранного варианта ответа в указанном опросе.
+ [Polls.Edit](/vk/polls/edit/) - Позволяет редактировать созданные опросы.
+ [Polls.GetById](/vk/polls/getById/) - Возвращает детальную информацию об опросе по его идентификатору.
+ [Polls.GetVoters](/vk/polls/getVoters/) - Получает список идентификаторов пользователей, которые выбрали определенные варианты ответа в опросе.

## Поиск
+ [Search.GetHints](/vk/search/getHints/) - Метод позволяет получить результаты быстрого поиска по произвольной подстроке. 

## Административные методы от имени приложения
+ [Secure.AddAppEvent](/vk/secure/addAppEvent/) - Добавляет информацию о достижениях пользователя в приложении.
+ [Secure.CheckToken](/vk/secure/checkToken/) - Позволяет проверять валидность пользователя в IFrame, Flash и Standalone-приложениях с помощью передаваемого в приложения параметра access_token.
+ [Secure.GetAppBalance](/vk/secure/getAppBalance/) - Возвращает платежный баланс (счет) приложения в сотых долях голоса.
+ [Secure.GetSMSHistory](/vk/secure/getSMSHistory/) - Выводит список SMS-уведомлений, отосланных приложением с помощью метода secure.sendSMSNotification.
+ [Secure.GetTransactionsHistory](/vk/secure/getTransactionsHistory/) - Выводит историю транзакций по переводу голосов между пользователями и приложением.
+ [Secure.GetUserLevel](/vk/secure/getUserLevel/) - Возвращает ранее выставленный игровой уровень одного или нескольких пользователей в приложении.
+ [Secure.GiveEventSticker](/vk/secure/giveEventSticker/) - Выдает пользователю стикер и открывает игровое достижение.
+ [Secure.SendNotification](/vk/secure/sendNotification/) - Отправляет уведомление пользователю.
+ [Secure.SendSMSNotification](/vk/secure/sendSMSNotification/) - Отправляет SMS-уведомление на мобильный телефон пользователя.
+ [Secure.SetCounter](/vk/secure/setCounter/) - Устанавливает счетчик, который выводится пользователю жирным шрифтом в левом меню.

## Переменные в приложении
+ [Storage.Get](/vk/storage/get/) - Возвращает значение переменной, название которой передано в параметре key.
+ [Storage.GetKeys](/vk/storage/getKeys/) - Возвращает названия всех переменных.
+ [Storage.Set](/vk/storage/set/) - Сохраняет значение переменной, название которой передано в параметре key.

## Формы сбора заявок
+ [LeadForms.Create](/vk/leadForms/create/) - Создаёт форму сбора заявок.
+ [LeadForms.Delete](/vk/leadForms/delete/) - Удаляет форму сбора заявок.
+ [LeadForms.Get](/vk/leadForms/get/) - Возвращает информацию о форме сбора заявок.
+ [LeadForms.GetLeads](/vk/leadForms/getLeads/) - Возвращает заявки формы.
+ [LeadForms.GetUploadURL](/vk/leadForms/getUploadURL/) - Возвращает URL для загрузки обложки для формы.
+ [LeadForms.List](/vk/leadForms/list/) - Возвращает список форм сообщества.
+ [LeadForms.Update](/vk/leadForms/update/) - Обновляет форму сбора заявок.

## Истории
+ [Stories.BanOwner](/vk/stories/banOwner/) - Позволяет скрыть из ленты новостей истории от выбранных источников.
+ [Stories.Delete](/vk/stories/delete/) - Удаляет историю.
+ [Stories.Get](/vk/stories/get/) - Возвращает истории, доступные для текущего пользователя.
+ [Stories.GetBanned](/vk/stories/getBanned/) - Возвращает список источников историй, скрытых из ленты текущего пользователя.
+ [Stories.GetById](/vk/stories/getById/) - Возвращает информацию об истории по её идентификатору.
+ [Stories.GetPhotoUploadServer](/vk/stories/getPhotoUploadServer/) - Позволяет получить адрес для загрузки истории с фотографией.
+ [Stories.GetReplies](/vk/stories/getReplies/) - Позволяет получить ответы на историю.
+ [Stories.GetStats](/vk/stories/getStats/) - Возвращает статистику истории.
+ [Stories.GetVideoUploadServer](/vk/stories/getVideoUploadServer/) - Позволяет получить адрес для загрузки видеозаписи в историю.
+ [Stories.GetViewers](/vk/stories/getViewers/) - Возвращает список пользователей, просмотревших историю.
+ [Stories.HideAllReplies](/vk/stories/hideAllReplies/) - Скрывает все ответы автора за последние сутки на истории текущего пользователя.
+ [Stories.HideReply](/vk/stories/hideReply/) - Скрывает ответ на историю.
+ [Stories.UnbanOwner](/vk/stories/unbanOwner/) - Позволяет вернуть пользователя или сообщество в список отображаемых историй в ленте.

## Виджеты приложений
+ [AppWidgets.GetAppImageUploadServer](/vk/appWidgets/getAppImageUploadServer/) - Позволяет получить адрес для загрузки фотографии в коллекцию приложения для виджетов приложений сообществ.
+ [AppWidgets.GetAppImages](/vk/appWidgets/getAppImages/) - Позволяет получить коллекцию изображений, загруженных для приложения, в виджетах приложений сообществ.
+ [AppWidgets.GetGroupImageUploadServer](/vk/appWidgets/getGroupImageUploadServer/) - Позволяет получить адрес для загрузки фотографии в коллекцию сообщества для виджетов приложений сообществ.
+ [AppWidgets.GetGroupImages](/vk/appWidgets/getGroupImages/) - Позволяет получить коллекцию изображений, загруженных для приложения, в виджетах приложений сообществ.
+ [AppWidgets.GetImagesById](/vk/appWidgets/getImagesById/) - Позволяет получить изображение для виджетов приложений сообществ по его идентификатору.
+ [AppWidgets.SaveAppImage](/vk/appWidgets/saveAppImage/) - Позволяет сохранить изображение в коллекцию приложения для виджетов приложений сообществ после загрузки на сервер.
+ [AppWidgets.SaveGroupImage](/vk/appWidgets/saveGroupImage/) - Позволяет сохранить изображение в коллекцию сообщества для виджетов приложений сообществ. после загрузки на сервер.
+ [AppWidgets.Update](/vk/appWidgets/update/) - Позволяет обновить виджет приложения сообщества. Виджет обязательно должен быть уже установлен в сообществе.

## Streaming API
+ [Streaming.GetServerUrl](/vk/streaming/getServerUrl/) - Позволяет получить данные для подключения к Streaming API.
+ [Streaming.GetSettings](/vk/streaming/getSettings/) - Позволяет получить значение порога для Streaming API.
+ [Streaming.GetStats](/vk/streaming/getStats/) - Позволяет получить статистику для подготовленных и доставленных событий Streaming API.
+ [Streaming.SetSettings](/vk/streaming/setSettings/) - Позволяет задать значение порога для Streaming API.

## Состояние заказов
+ [Orders.CancelSubscription](/vk/orders/cancelSubscription/) - Отменяет подписку.
+ [Orders.ChangeState](/vk/orders/changeState/) - Изменяет состояние заказа.
+ [Orders.Get](/vk/orders/get/) - Возвращает список заказов.
+ [Orders.GetAmount](/vk/orders/getAmount/) - Возвращает стоимость голосов в валюте пользователя.
+ [Orders.GetById](/vk/orders/getById/) - Возвращает информацию об отдельном заказе.
+ [Orders.GetUserSubscriptionById](/vk/orders/getUserSubscriptionById/) - Получает информацию о подписке по её идентификатору.
+ [Orders.GetUserSubscriptions](/vk/orders/getUserSubscriptions/) - Получает список активных подписок пользователя.
+ [Orders.UpdateSubscription](/vk/orders/updateSubscription/) - Обновляет цену подписки для пользователя.

## Виджеты
+ [Widgets.GetComments](/vk/widgets/getComments/) - Получает список комментариев к странице, оставленных через Виджет комментариев.
+ [Widgets.GetPages](/vk/widgets/getPages/) - Получает список страниц приложения/сайта, на которых установлен Виджет комментариев или «Мне нравится».

# Не реализованные методы
## Группы
+ [Groups.setSettings](/vk/groups/setSettings/) - Устанавливает настройки сообщества.

## Стена
+ [Wall.GetComment](/vk/wall/getComment/) - !!Получает информацию о комментарии на стене.

## Оповещения
+ [Notifications.SendMessage](/vk/notifications/sendMessage/) - Отправляет уведомление пользователю приложения VK Apps.

## Опросы
+ [Polls.SavePhoto](/vk/polls/savePhoto/) - Сохраняет фотографию, загруженную в опрос.
+ [Polls.GetBackgrounds](/vk/polls/getBackgrounds/) - Возвращает варианты фонового изображения для опросов.
+ [Polls.GetPhotoUploadServer](/vk/polls/getPhotoUploadServer/) - Возвращает адрес сервера для загрузки фоновой фотографии в опрос.

## Места
+ [Places.](/vk/places/nodata/) - Нет данных. 

## Подкасты 
+ [Podcasts.](/vk/podcasts/nodata/) - Нет данных. 

## Карусель
+ [PrettyCards.Create](/vk/prettyCards/create/) - Создаёт карточку карусели.
+ [PrettyCards.Delete](/vk/prettyCards/delete/) - Удаляет карточку.
+ [PrettyCards.Edit](/vk/prettyCards/edit/) - Редактирует карточку карусели.
+ [PrettyCards.Get](/vk/prettyCards/get/) - Возвращает неиспользованные карточки владельца.
+ [PrettyCards.GetById](/vk/prettyCards/getById/) - Возвращает информацию о карточке.
+ [PrettyCards.GetUploadURL](/vk/prettyCards/getUploadURL/) - Возвращает URL для загрузки фотографии для карточки.

## Истории
+ [Stories.Search](/vk/stories/search/) - Возвращает результаты поиска по историям.

## Streaming API
+ [Streaming.GetStem](/vk/streaming/getStem/) - Позволяет получить основу слова.
